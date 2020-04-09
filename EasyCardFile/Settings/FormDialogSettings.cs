#region License
/*
MIT License

Copyright(c) 2020 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using Cyotek.Windows.Forms;
using EasyCardFile.UtilityClasses.Miscellaneous;
using EasyCardFile.UtilityClasses.SpellCheck;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using VPKSoft.LangLib;
using VPKSoft.SpellCheckUtility;
using VPKSoft.Utils;
using VPKSoft.Utils.XmlSettingsMisc;
using Utils = VPKSoft.LangLib.Utils;

namespace EasyCardFile.Settings
{
    /// <summary>
    /// A settings dialog for the application.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogSettings : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogSettings"/> class.
        /// </summary>
        public FormDialogSettings()
        {
            InitializeComponent();

            // additional name spaces to the localization..
            // ReSharper disable once StringLiteralTypo
            DBLangEngine.NameSpaces.Add("Manina.Windows.Forms");
            
            // ReSharper disable once StringLiteralTypo
            DBLangEngine.DBName = "localization.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages",
                    Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            // initialize the language/localization database..
            DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages");

            // list the translated cultures..
            List<CultureInfo> cultures = DBLangEngine.GetLocalizedCultures();

            // a the translated cultures to the selection combo box..
            // ReSharper disable once CoVariantArrayConversion
            cmbSelectLanguageValue.Items.AddRange(cultures.ToArray());

            LocalizeDialogs();
        }


        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        private Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether event handlers should be temporarily suspended.
        /// </summary>
        private bool SuspendEvents { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the user spell checking dictionary was deleted and should be cleared.
        /// </summary>
        private bool UserDictionaryDeleted { get; set; }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="settings">The settings.</param>
        /// <param name="userDictionaryDeleted"></param>
        /// <returns>DialogResult.</returns>
        public static DialogResult ShowDialog(IWin32Window owner, Settings settings, out bool userDictionaryDeleted)
        {
            var form = new FormDialogSettings {Settings = settings, UserDictionaryDeleted = false,};
            var result = form.ShowDialog(owner);
            userDictionaryDeleted = form.UserDictionaryDeleted;
            return result;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            Settings.Save(PathHandler.GetSettingsFile(Assembly.GetEntryAssembly(), ".xml",
                Environment.SpecialFolder.LocalApplicationData));

            DialogResult = DialogResult.OK;
        }

        private void FormDialogSettings_Shown(object sender, EventArgs e)
        {
            cmbInstalledDictionaries.Items.AddRange(HunspellDictionaryCrawler
                .CrawlDirectory(Settings.EditorHunspellDictionaryPath).OrderBy(f => f.ToString().ToLowerInvariant())
                .ToArray<object>());

            DisplaySettings();
        }

        private void DisplaySettings()
        {
            cbAutoSaveExistingCardFilesAppClose.Checked = Settings.AutoSave;
            cbRestorePreviousSession.Checked = Settings.RestoreSessionOnStartup;            

            // get the current culture from the settings..
            cmbSelectLanguageValue.SelectedItem = string.IsNullOrWhiteSpace(Settings.Locale)
                ? new CultureInfo("en-US")
                : new CultureInfo(Settings.Locale);

            if (Settings.SpellCheckingEnabled)
            {
                SuspendEvents = true;
                cmbInstalledDictionaries.SelectedItem = cmbInstalledDictionaries.Items.Cast<HunspellData>()
                    .FirstOrDefault(f => f.DictionaryFile == Settings.EditorHunspellDictionaryFile);
                SuspendEvents = false;
            }

            tbHunspellAffixFile.Text = Settings.EditorHunspellAffixFile;
            tbHunspellDictionary.Text = Settings.EditorHunspellDictionaryFile;
            tbDictionaryPath.Text = Settings.EditorHunspellDictionaryPath;
        }

        private void ApplySettings()
        {
            Settings.AutoSave = cbAutoSaveExistingCardFilesAppClose.Checked;
            Settings.RestoreSessionOnStartup = cbRestorePreviousSession.Checked;
            Settings.Locale = ((CultureInfo) cmbSelectLanguageValue.SelectedItem)?.Name;
            Settings.EditorHunspellAffixFile = tbHunspellAffixFile.Text;
            Settings.EditorHunspellDictionaryFile = tbHunspellDictionary.Text;
            Settings.EditorHunspellDictionaryPath = tbDictionaryPath.Text;
        }

        private void cwEditorToolStripColors_ColorChanged(object sender, EventArgs e)
        {
            var colorWheel = (ColorWheel) sender;
            rtbEditorToolStripColors.ColorButtonForeground = colorWheel.Color;
        }

        private void cwEditorImageGlyphColor_ColorChanged(object sender, EventArgs e)
        {
            var colorWheel = (ColorWheel) sender;
            rtbEditorToolStripColors.ColorGlyph = colorWheel.Color;
        }

        private void btDictionaryPath_Click(object sender, EventArgs e)
        {
            var dialog = fbFolder;

            var textBox = tbDictionaryPath;

            if (textBox != null)
            {
                if (Directory.Exists(tbDictionaryPath.Text))
                {
                    dialog.SelectedPath = textBox.Text;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = dialog.SelectedPath;
                }
            }
        }

        private void btHunspellDictionary_Click(object sender, EventArgs e)
        {
            odDictionaryFile.InitialDirectory = string.IsNullOrWhiteSpace(Settings.FileLocationOpenDictionary)
                ? Settings.EditorHunspellDictionaryPath
                : Settings.FileLocationOpenDictionary;

            if (odDictionaryFile.ShowDialog() == DialogResult.OK)
            {
                Settings.FileLocationOpenDictionary = odDictionaryFile.FileName.GetPath(Settings.FileLocationOpenDictionary);
                tbHunspellDictionary.Text = odDictionaryFile.FileName;
            }
        }

        private void btHunspellAffixFile_Click(object sender, EventArgs e)
        {
            odAffixFile.InitialDirectory = string.IsNullOrWhiteSpace(Settings.FileLocationOpenAffix)
                ? Settings.EditorHunspellDictionaryPath
                : Settings.FileLocationOpenAffix;

            if (odAffixFile.ShowDialog() == DialogResult.OK)
            {
                Settings.FileLocationOpenAffix = odAffixFile.FileName.GetPath(Settings.FileLocationOpenAffix);
                tbHunspellAffixFile.Text = odAffixFile.FileName;
            }
        }

        private void cmbInstalledDictionaries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SuspendEvents)
            {
                return;
            }
            var comboBox = (ComboBox) sender;
            
            if (comboBox.SelectedIndex != -1)
            {
                HunspellData data = (HunspellData) comboBox.Items[comboBox.SelectedIndex];
                tbHunspellDictionary.Text = data.DictionaryFile;
                tbHunspellAffixFile.Text = data.AffixFile;
            }
        }

        /// <summary>
        /// Localizes the file dialogs used in this dialog.
        /// </summary>
        private void LocalizeDialogs()
        {
            odAffixFile.Title = DBLangEngine.GetMessage("msgDialogSelectAffixFile",
                "Select an affix file|A title for an open file dialog to indicate user that the user is selecting a Hunspell affix file for the spell checking");

            odAffixFile.Filter = DBLangEngine.GetMessage("msgFileAffix",
                "Hunspell affix file |*.aff|A text in a file dialog filter to indicate a Hunspell affix file");

            fbFolder.Description = DBLangEngine.GetMessage("msgDirectoryDialogDictionary",
                "Select the dictionary folder|A message describing that the user should select a folder where the Hunspell dictionaries reside");

            odDictionaryFile.Title = DBLangEngine.GetMessage("msgDialogSelectDicFile",
                "Select a dictionary file|A title for an open file dialog to indicate user that the user is selecting a dictionary file for the spell checking");

            odDictionaryFile.Filter = DBLangEngine.GetMessage("msgFileDic",
                "Hunspell dictionary file|*.dic|A text in a file dialog filter to indicate a Hunspell dictionary file");
        }

        private void btClearUserDictionary_Click(object sender, EventArgs e)
        {
            var userDictionaryFile = Path.Combine(Paths.GetAppSettingsFolder(), "user.dictionary");

            if (File.Exists(userDictionaryFile))
            {
                File.Delete(userDictionaryFile);
                UserDictionaryDeleted = true;
            }
        }
    }
}
