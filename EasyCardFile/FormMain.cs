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
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using EasyCardFile.CardFileHandler;
using EasyCardFile.CardFileHandler.CardFileNaming;
using EasyCardFile.CardFileHandler.CardFilePreferences;
using EasyCardFile.CardFileHandler.LegacyCardFile;
using EasyCardFile.Database.Entity.Enumerations;
using EasyCardFile.Settings;
using EasyCardFile.Settings.TypeConverters;
using EasyCardFile.UtilityClasses.Constants;
using EasyCardFile.UtilityClasses.FileAssociation;
using EasyCardFile.UtilityClasses.Localization;
using EasyCardFile.UtilityClasses.Miscellaneous;
using VPKSoft.ErrorLogger;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;
using VPKSoft.PosLib;
using VPKSoft.Utils.XmlSettingsMisc;
using VPKSoft.VersionCheck.Forms;
using VPKSoft.WinFormsRtfPrint;
using VU = VPKSoft.Utils;

// Icon (C): https://icon-icons.com/icon/card-file-box/109271, Apache 2.0

namespace EasyCardFile
{
    /// <summary>
    /// The main form of the application.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormMain : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyCardFile.FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            // Add this form to be positioned..
            PositionForms.Add(this);

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

            // localize the "UI engine"..
            CardFileUiWrapper.LocalizeTexts();

            var appDataPath = VU.Paths.MakeAppSettingsFolder();
            CardFileSaveClose.TemporaryPath = Path.Combine(appDataPath + "Temporary");
            if (!Directory.Exists(CardFileSaveClose.TemporaryPath))
            {
                Directory.CreateDirectory(CardFileSaveClose.TemporaryPath);
            }
            CardFileUiWrapper.TemporaryPath = CardFileSaveClose.TemporaryPath;

            LocalizeStaticProperties.LocalizeStatic();
            CardSortTypeLocalize.LocalizeEnums();

            mnuTest.Visible = Debugger.IsAttached;

            Settings = new Settings.Settings();
            Settings.RequestTypeConverter += Settings_RequestTypeConverter;

            Settings.Load(PathHandler.GetSettingsFile(Assembly.GetEntryAssembly(), ".xml",
                Environment.SpecialFolder.LocalApplicationData));

            LocalizeStaticProperties.LocalizeFileDialogs(sdCardFile, odCardFile);

            tmRemoteOpenFileQueue.Enabled = true;

            AssociateFileExtension.AssociateApplicationToFileExtension(EasyCardFileConstants.FileExtension);

            RtfPrint.Owner = this; // mother of all dialogs..
        }

        /// <summary>
        /// Gets the application settings.
        /// </summary>
        public static Settings.Settings Settings { get; set; }

        #region InternalEvents
        private void tcCardFiles_PageChanged(object sender, Manina.Windows.Forms.PageChangedEventArgs e)
        {
            SetTitle();
        }

        private void Settings_RequestTypeConverter(object sender, RequestTypeConverterEventArgs e)
        {
            try
            {
                if (e.TypeToConvert == typeof(List<string>))
                {
                    e.TypeConverter = new TypeConverterPrimitiveGenericList<string>();
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileSaveClose.RunSaveCheckApplicationClose(tcCardFiles, this, sdCardFile, Settings.AutoSave))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath();
            }

            CardFileSaveClose.HandleTabsAfterClose(tcCardFiles);

            Settings.SetSessionFiles(tcCardFiles);
            Settings.SetSplitters(tcCardFiles, Width);

            Settings.SessionActiveTabIndex = tcCardFiles.SelectedIndex;

            Settings.Save(PathHandler.GetSettingsFile(Assembly.GetEntryAssembly(), ".xml",
                Environment.SpecialFolder.LocalApplicationData));

            foreach (var wrapper in CardFileUiWrapper.GetTabList(tcCardFiles))
            {
                // ResSharper: Delegate subtraction has unpredictable result? Lets hope not..
                // ReSharper disable once DelegateSubtraction
                wrapper.CardFileChanged -= CardFileChanged;
            }

            CardFileSaveClose.ClearTemporaryFiles();

            Settings.RequestTypeConverter -= Settings_RequestTypeConverter;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            RestoreSession();
        }

        private void tmRemoteOpenFileQueue_Tick(object sender, EventArgs e)
        {
            if (Program.OpenFileQueue.Count > 0)
            {
                OpenCardFile(Program.OpenFileQueue.Dequeue());
            }
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
            // test something here..
        }

        private void CardFileChanged(object sender, EventArgs e)
        {
            SetTitle();
        }
        #endregion

        #region PrivateProperties        
        /// <summary>
        /// Gets or sets a value indicating whether the previous session was restored upon the software startup.
        /// </summary>
        private bool SessionRestored { get; set; }
        #endregion

        #region PrivateMethods        
        /// <summary>
        /// Opens the card file.
        /// </summary>
        /// <param name="fileName">Name of the file of the card file.</param>
        /// <param name="displayLoadErrorDialog">if set to <c>true</c> a dialog is displayed in case of an error loading the card file.</param>
        /// <returns><c>true</c> if the card file was opened successfully, <c>false</c> otherwise.</returns>
        // ReSharper disable once UnusedMethodReturnValue.Local
        private bool OpenCardFile(string fileName, bool displayLoadErrorDialog = false)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }

            try
            {
                // don't allow a database to be re-opened..
                foreach (var tab in tcCardFiles.Tabs)
                {
                    var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);
                    if (wrapper.FileName == fileName)
                    {
                        tcCardFiles.SelectedTab = tab;
                        return false;

                    }
                }

                var newWrapper = new CardFileUiWrapper(fileName, tcCardFiles);
                newWrapper.CardFileChanged += CardFileChanged;

                SetTitle();
                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex);
                if (displayLoadErrorDialog)
                {
                    MessageBoxExtended.Show(this,
                        DBLangEngine.GetMessage("msgCardFileFailedOpen",
                            "Failed to open the card file: '{0}'.|A message for a message dialog that the card file failed to open",
                            odCardFile.FileName),
                        DBLangEngine.GetMessage("msgError",
                            "Error|A message describing that some kind of error occurred."),
                        MessageBoxButtonsExtended.OK, MessageBoxIcon.Error, true);
                }
            }

            return false;
        }

        /// <summary>
        /// Restores the previous session.
        /// </summary>
        private void RestoreSession()
        {
            if (Settings.RestoreSessionOnStartup && !SessionRestored)
            {
                foreach (var sessionFile in Settings.SessionFiles)
                {
                    OpenCardFile(sessionFile);
                }

                SessionRestored = true;
            }

            if (Settings.SessionActiveTabIndex >= 0 && Settings.SessionActiveTabIndex < tcCardFiles.Tabs.Count)
            {
                tcCardFiles.SelectedIndex = Settings.SessionActiveTabIndex;
            }

            Settings.GetSplitters(tcCardFiles, Width);
        }

        /// <summary>
        /// Sets the title of the main window of this software.
        /// <param name="refresh">A value indicating whether to repaint the card list box.</param>
        /// </summary>
        private void SetTitle(bool refresh = false)
        {
            if (tcCardFiles.SelectedTab == null)
            {
                Text = EasyCardFileConstants.SoftwareName;
            }

            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (wrapper == null)
            {
                return;
            }

            Text = EasyCardFileConstants.SoftwareName + @" [" + wrapper.CardFileName + @" | " + wrapper.FileName +
                   (wrapper.Changed ? @" *" : "") + @"]";

            if (refresh)
            {
                Application.DoEvents();
                wrapper.RefreshCardList();
            }
        }
        #endregion

        #region UserInteractionEvents
        private void tsbCardFilePreferences_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (FormDialogCardFilePreferences.ShowDialog(this, wrapper.CardFileDb) == DialogResult.OK)
            {
                wrapper.Changed = true;
                wrapper.UpdateTitle();
                wrapper.RefreshUi();
                Application.DoEvents();
                wrapper.RefreshCardList();
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            // ReSharper disable once ObjectCreationAsStatement
            var wrapper = new CardFileUiWrapper(tcCardFiles);
            wrapper.CardFileChanged += CardFileChanged;
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            odCardFile.InitialDirectory = Settings.PathFileDialogMainOpen;
            if (odCardFile.ShowDialog() == DialogResult.OK)
            {
                // ReSharper disable once StringLiteralTypo
                if (string.Equals(Path.GetExtension(odCardFile.FileName), ".ecfp", StringComparison.OrdinalIgnoreCase))
                {
                    odCardFileLegacy.InitialDirectory = Settings.PathFileDialogMainOpenLegacy;
                    if (CardFileLegacyReader.Convert(odCardFileLegacy, sdCardFile, this))
                    {
                        sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
                        if (OpenCardFile(sdCardFile.FileName))
                        {
                            Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath();
                            Settings.PathFileDialogMainOpenLegacy = odCardFileLegacy.FileName.GetPath();
                        }
                    }
                    return;
                }

                if (OpenCardFile(odCardFile.FileName, true))
                {
                    Settings.PathFileDialogMainOpen = odCardFile.FileName.GetPath();
                }
            }
        }

        private void tcCardFiles_CloseTabButtonClick(object sender, Manina.Windows.Forms.CancelTabEventArgs e)
        {
            using (CardFileUiWrapper.GetWrapperByTab(e.Tab))
            {
                CardFileSaveClose.CloseCardFile(true, e.Tab);
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new FormAbout(this, "MIT",
                "https://raw.githubusercontent.com/VPKSoft/EasyCardFile/master/LICENSE",
                "https://www.vpksoft.net/versions/version.php");
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            FormDialogSettings.ShowDialog(this, Settings);
        }

        private void tsbNewCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (wrapper != null)
            {
                if (FormDialogAddRenameCard.ShowDialog(this, wrapper.CardFileDb.CardFile, out var card) == DialogResult.OK)
                {
                    wrapper.Changed = true;
                    wrapper.RefreshUi(card);
                    SetTitle(true);
                    wrapper.FocusRichTextBox();
                }
            }
        }

        private void tsbDeleteCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            var changed = wrapper?.DeleteCard();
            if (changed != null && changed == true)
            {
                wrapper.Changed = true;
                SetTitle(true);
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileSaveClose.SaveCardFileAs(tcCardFiles, sdCardFile, false))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath();
            }
            SetTitle(true);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileSaveClose.SaveCardFile(tcCardFiles, sdCardFile, false))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath();
            }
            SetTitle(true);
        }

        private void tsbRenameCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            var cardFile = wrapper.CardFileDb.CardFile;

            if (wrapper.SelectedCard != null)
            {
                if (FormDialogAddRenameCard.ShowDialogRename(this, cardFile, wrapper.SelectedCard) == DialogResult.OK)
                {
                    wrapper.SelectedCard.ModifiedDateTime = DateTime.Now;
                    wrapper.Changed = true;
                    wrapper.RefreshCardList();
                    SetTitle();
                }
            }
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.Print();
        }

        private void tsbPrintPreview_Click(object sender, EventArgs e)
        {
            CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.PrintPreview();
        }

        private void mnuImportLegacy_Click(object sender, EventArgs e)
        {
            odCardFileLegacy.InitialDirectory = Settings.PathFileDialogMainOpenLegacy;
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileLegacyReader.Convert(odCardFileLegacy, sdCardFile, this))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath();
                if (OpenCardFile(sdCardFile.FileName))
                {
                    Settings.PathFileDialogMainOpenLegacy = odCardFileLegacy.FileName.GetPath();
                }
            }
        }
        #endregion

        #region LocalizeForFreeTM
        // a user wishes to help with localization of the software (?!)..
        private void mnuLocalization_Click(object sender, EventArgs e)
        {
            try
            {
                string args = "--localize=\"" +
                              Path.Combine(
                                  Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                                  "EasyCardFile",
                                  // ReSharper disable once StringLiteralTypo
                                  "localization.sqlite") + "\"";

                Process.Start(Application.ExecutablePath, args);
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex, "Localization");
            }
        }

        // a user wishes to dump (update) the current language database..
        private void mnuDumpLanguage_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.ExecutablePath, "--dblang");
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogger.LogError(ex, "Localization dump");
            }
        }
        #endregion
    }
}
