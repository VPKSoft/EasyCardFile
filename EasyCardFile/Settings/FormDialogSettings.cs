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

using System;
using System.Reflection;
using System.Windows.Forms;
using VPKSoft.LangLib;
using VPKSoft.Utils.XmlSettingsMisc;

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
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        private Settings Settings { get; set; }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>DialogResult.</returns>
        public static DialogResult ShowDialog(IWin32Window owner, Settings settings)
        {
            var form = new FormDialogSettings {Settings = settings};
            return form.ShowDialog(owner);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Settings.AutoSave = cbAutoSaveExistingCardFilesAppClose.Checked;
            Settings.RestoreSessionOnStartup = cbRestorePreviousSession.Checked;
            Settings.Save(PathHandler.GetSettingsFile(Assembly.GetEntryAssembly(), ".xml",
                Environment.SpecialFolder.LocalApplicationData));

            DialogResult = DialogResult.OK;
        }

        private void FormDialogSettings_Shown(object sender, EventArgs e)
        {
            cbAutoSaveExistingCardFilesAppClose.Checked = Settings.AutoSave;
            cbRestorePreviousSession.Checked = Settings.RestoreSessionOnStartup;
        }
    }
}
