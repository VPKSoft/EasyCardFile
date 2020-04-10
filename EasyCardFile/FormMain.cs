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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using EasyCardFile.CardFileHandler;
using EasyCardFile.CardFileHandler.CardFilePreferences;
using EasyCardFile.CardFileHandler.LegacyCardFile;
using EasyCardFile.Database.Entity.Enumerations;
using EasyCardFile.Settings;
using EasyCardFile.UtilityClasses.Constants;
using EasyCardFile.UtilityClasses.FileAssociation;
using EasyCardFile.UtilityClasses.Localization;
using EasyCardFile.UtilityClasses.Miscellaneous;
using Microsoft.Win32;
using VPKSoft.ErrorLogger;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;
using VPKSoft.PosLib;
using VPKSoft.SpellCheckUtility;
using VPKSoft.SpellCheckUtility.WinForms;
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

            SystemEvents.SessionEnding += SystemEvents_SessionEnding;

            // localize the "UI engine"..
            CardFileUiWrapper.LocalizeTexts();

            AppDataPath = VU.Paths.MakeAppSettingsFolder();
            CardFileSaveClose.TemporaryPath = Path.Combine(AppDataPath + "Temporary");
            if (!Directory.Exists(CardFileSaveClose.TemporaryPath))
            {
                Directory.CreateDirectory(CardFileSaveClose.TemporaryPath);
            }
            CardFileUiWrapper.TemporaryPath = CardFileSaveClose.TemporaryPath;

            LocalizeStaticProperties.LocalizeStatic();
            CardSortTypeLocalize.LocalizeEnums();

            mnuTest.Visible = Debugger.IsAttached;

            LocalizeStaticProperties.LocalizeFileDialogs(sdCardFile, odCardFile);
            LocalizeStaticProperties.LocalizeRtfDialogs(odRtf, sdRtf);

            if (!string.IsNullOrWhiteSpace(Settings.Locale))
            {
                MessageBoxBase.Localize(new CultureInfo(Settings.Locale));
            }

            tmRemoteOpenFileQueue.Enabled = true;

            AssociateFileExtension.AssociateApplicationToFileExtension(EasyCardFileConstants.FileExtension);

            RtfPrint.Owner = this; // mother of all dialogs..

            LoadSpellChecking();
            FormDialogSpellCheck.OwnerWindow = this;
            FormDialogSpellCheck.Locale = Settings.Locale;

            // subscribe to the event which is called by the SpellChecker class on progressing with the spell checking;
            // there is no reason to subscribe this event if the checking isn't visualized or done in real-time..
            SpellChecker.SpellCheckLocationChanged += SpellChecker_SpellCheckLocationChanged;

            CreateRecentFilesMenu();
        }

        #region PublicAndInternalProperties
        /// <summary>
        /// Gets the application settings.
        /// </summary>
        public static Settings.Settings Settings { get; set; }

        /// <summary>
        /// Gets or sets the application data path.
        /// </summary>
        /// <value>The application data path.</value>
        internal static string AppDataPath { get; set; }
        #endregion

        #region InternalEvents
        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            SystemEvents.SessionEnding -= SystemEvents_SessionEnding;
            Close();
        }

        private void tcCardFiles_PageChanged(object sender, Manina.Windows.Forms.PageChangedEventArgs e)
        {
            SetTitle();
            SetGuiState();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileSaveClose.RunSaveCheckApplicationClose(tcCardFiles, this, sdCardFile, Settings.AutoSave))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath(Settings.PathFileDialogMainSave);
            }
            else // the user didn't accept the close..
            {
                e.Cancel = true;
                return;
            }

            SpellChecker.SaveUserDictionary(Path.Combine(AppDataPath, "user.dictionary"));

            CardFileSaveClose.HandleTabsAfterClose(tcCardFiles);

            Settings.SetSessionFiles(tcCardFiles);
            Settings.SetSplitters(tcCardFiles, Width);

            Settings.SessionActiveTabIndex = tcCardFiles.SelectedIndex;

            Settings.Save(PathHandler.GetSettingsFile(Assembly.GetEntryAssembly(), ".xml",
                Environment.SpecialFolder.LocalApplicationData));

            foreach (var wrapper in CardFileUiWrapper.GetTabList(tcCardFiles))
            {
                DetachEvents(wrapper);
            }

            CardFileSaveClose.ClearTemporaryFiles();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            RestoreSession();
            SetGuiState();
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
            SetGuiState();
        }

        private void CardContentsChanged(object sender, EventArgs e)
        {
            SetUndoRedoState();
        }

        private void UndoRedoChanged(object sender, EventArgs e)
        {
            // undo / redo..
            SetUndoRedoState();
        }
        #endregion

        #region PrivateProperties
        /// <summary>
        /// Gets or sets the text offset correction. This is used in the real time spell checking..
        /// </summary>
        /// <value>The text offset correction.</value>
        private int TextOffsetCorrection { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the previous session was restored upon the software startup.
        /// </summary>
        private bool SessionRestored { get; set; }
        #endregion

        #region PrivateMethods
        /// <summary>
        /// Creates a recent files menu.
        /// </summary>
        private void CreateRecentFilesMenu()
        {
            Settings.CreateRecentFilesMenu(mnuRecentFiles, tcCardFiles, MenuRecentFileClick, mnuSeparatorRecentFiles);
        }

        /// <summary>
        /// Loads the spell checking data.
        /// </summary>
        private void LoadSpellChecking()
        {
            // except the Hunspell affix and dictionary files to exists and load them..
            if (Settings.SpellCheckingEnabled)
            {
                SpellChecker.LoadDictionary(Settings.EditorHunspellDictionaryFile,
                    Settings.EditorHunspellAffixFile);

                var userDictionaryFile = Path.Combine(AppDataPath, "user.dictionary");

                if (File.Exists(userDictionaryFile))
                {
                    SpellChecker.LoadUserDictionary(userDictionaryFile);
                }
            }
        }

        /// <summary>
        /// Attaches the events to a given <see cref="CardFileUiWrapper"/>.
        /// </summary>
        /// <param name="wrapper">The wrapper which events to subscribe.</param>
        private void AttachEvents(CardFileUiWrapper wrapper)
        {
            wrapper.CardFileChanged += CardFileChanged;
            wrapper.UndoRedoChanged += UndoRedoChanged;
            wrapper.CardContentsChanged += CardContentsChanged;
        }

        /// <summary>
        /// Detaches the events from a given <see cref="CardFileUiWrapper"/>.
        /// </summary>
        /// <param name="wrapper">The wrapper which events to unsubscribe.</param>
        private void DetachEvents(CardFileUiWrapper wrapper)
        {
            // ReSharper disable three times DelegateSubtraction
            wrapper.CardFileChanged -= CardFileChanged;
            wrapper.UndoRedoChanged -= UndoRedoChanged;
            wrapper.CardContentsChanged -= CardContentsChanged;
        }

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

                    if (wrapper != null && wrapper.FileName == fileName)
                    {
                        tcCardFiles.SelectedTab = tab;
                        return false;
                    }
                }

                var newWrapper = new CardFileUiWrapper(fileName, tcCardFiles);
                AttachEvents(newWrapper);

                SetTitle();
                SetGuiState();
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

            wrapper.UpdateTitle();

            if (refresh)
            {
                Application.DoEvents();
                wrapper.RefreshCardList();
            }
        }

        /// <summary>
        /// Sets the state of the GUI.
        /// </summary>
        private void SetGuiState()
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            // delete a card..
            tsbDeleteCard.Enabled = wrapper?.SelectedCard != null;
            mnuDeleteCard.Enabled = wrapper?.SelectedCard != null;

            // add a card..
            tsbNewCard.Enabled = wrapper != null;
            mnuNewCard.Enabled = wrapper != null;

            // save the card file
            tsbSave.Enabled = wrapper != null && wrapper.Changed;
            mnuSave.Enabled = wrapper != null && wrapper.Changed;

            // printing..
            tsbPrint.Enabled = wrapper?.SelectedCard != null;
            mnuPrint.Enabled = wrapper?.SelectedCard != null;
            tsbPrintPreview.Enabled = wrapper?.SelectedCard != null;
            mnuPrintPreview.Enabled = wrapper?.SelectedCard != null;

            // card contents import/export..
            mnuImportFromRtfDocument.Enabled = wrapper?.SelectedCard != null;
            mnuExportToRtfDocument.Enabled = wrapper?.SelectedCard != null;

            // rename card..
            tsbRenameCard.Enabled = wrapper?.SelectedCard != null;
            mnuRenameCard.Enabled = wrapper?.SelectedCard != null;

            // card file preferences..
            tsbCardFilePreferences.Enabled = wrapper != null;
            mnuCardFilePreferences.Enabled = wrapper != null;

            // the sort cards function..
            tsbSortCards.Enabled = wrapper != null && wrapper.HasCards;
            mnuSortCards.Enabled = wrapper != null && wrapper.HasCards;

            // save the card file as..
            tsbSaveAs.Enabled = wrapper != null;
            mnuSaveAs.Enabled = wrapper != null;

            mnuSpellCheckCard.Enabled = wrapper?.SelectedCard != null && Settings.SpellCheckingEnabled;
            tsbSpellCheckCard.Enabled = wrapper?.SelectedCard != null && Settings.SpellCheckingEnabled;
            var cardCount = wrapper?.CardFileDb?.CardFile?.Cards?.Count;
            mnuSpellCheckAllCards.Enabled = cardCount != null && cardCount > 0 && Settings.SpellCheckingEnabled;

            // undo / redo..
            SetUndoRedoState();
        }

        /// <summary>
        /// Sets the state of the undo and redo buttons and menu items.
        /// </summary>
        private void SetUndoRedoState()
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            mnuUndo.Enabled = wrapper != null && wrapper.CanUndo;
            mnuRedo.Enabled = wrapper != null && wrapper.CanRedo;
            tsbUndo.Enabled = wrapper != null && wrapper.CanUndo;
            tsbRedo.Enabled = wrapper != null && wrapper.CanRedo;
            tsbUndoAll.Enabled = wrapper != null && wrapper.Changed;
            mnuUndoAll.Enabled = wrapper != null && wrapper.Changed;
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
                wrapper.RefreshUi(null, true, true);
                Application.DoEvents();
                wrapper.RefreshCardList();
                wrapper.SetCustomOrdering();
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            // ReSharper disable once ObjectCreationAsStatement
            var wrapper = new CardFileUiWrapper(tcCardFiles);
            AttachEvents(wrapper);
            SetGuiState();
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
                            Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath(Settings.PathFileDialogMainSave);
                            Settings.PathFileDialogMainOpenLegacy = odCardFileLegacy.FileName.GetPath(Settings.PathFileDialogMainSave);
                        }
                    }
                    return;
                }

                if (OpenCardFile(odCardFile.FileName, true))
                {
                    Settings.PathFileDialogMainOpen = odCardFile.FileName.GetPath(Settings.PathFileDialogMainOpen);
                }
            }
        }

        private void MenuRecentFileClick(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem) sender;

            if (OpenCardFile(item.Tag.ToString()))
            {
                CreateRecentFilesMenu();
            }
        }

        private void tcCardFiles_CloseTabButtonClick(object sender, Manina.Windows.Forms.CancelTabEventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetWrapperByTab(e.Tab);
            if (!CardFileSaveClose.RunSaveCheckWrapper(CardFileUiWrapper.GetWrapperByTab(e.Tab), this, sdCardFile,
                Settings.AutoSave)) 
            {
                e.Cancel = true;
                return;
            }

            using (wrapper)
            {
                Settings.AddRecentFile(wrapper);
                sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath(Settings.PathFileDialogMainSave);
                CardFileSaveClose.CloseCardFile(true, e.Tab);
                SetGuiState();
            }
            CreateRecentFilesMenu();
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
            bool previousSpellingEnabled = Settings.SpellCheckingEnabled;
            if (FormDialogSettings.ShowDialog(this, Settings, out var dictionaryDeleted) == DialogResult.OK)
            {
                if (dictionaryDeleted)
                {
                    SpellChecker.ClearUserDictionary();
                }
                if (previousSpellingEnabled != Settings.SpellCheckingEnabled)
                {
                    if (Settings.SpellCheckingEnabled)
                    {
                        LoadSpellChecking();
                    }
                }
            }
        }

        private void tsbNewCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            var changed = wrapper?.AddCard();
            if (changed == true)
            {
                SetTitle(true);
                SetGuiState();
            }
        }

        private void tsbDeleteCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            var changed = wrapper?.DeleteCard();
            if (changed == true)
            {
                SetTitle(true);
                SetGuiState();
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e)
        {
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileSaveClose.SaveCardFileAs(tcCardFiles, sdCardFile, false))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath(Settings.PathFileDialogMainSave);
            }

            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            wrapper.Changed = false;

            SetTitle(true);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            sdCardFile.InitialDirectory = Settings.PathFileDialogMainSave;
            if (CardFileSaveClose.SaveCardFile(tcCardFiles, sdCardFile, false))
            {
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath(Settings.PathFileDialogMainSave);
            }
            SetTitle(true);
        }

        private void tsbRenameCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            var changed = wrapper?.RenameCard();

            if (changed == true)
            {
                SetTitle();
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
                Settings.PathFileDialogMainSave = sdCardFile.FileName.GetPath(Settings.PathFileDialogMainSave);
                if (OpenCardFile(sdCardFile.FileName))
                {
                    Settings.PathFileDialogMainOpenLegacy = odCardFileLegacy.FileName.GetPath(Settings.PathFileDialogMainOpenLegacy);
                }
            }
        }

        private void tsbSortCards_Click(object sender, EventArgs e)
        {
            CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.RefreshUi(null, true);
        }

        private void mnuEdit_DropDownOpening(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (wrapper?.SelectedCard == null)
            {
                mnuCut.Enabled = false;
                mnuCopy.Enabled = false;
                mnuPaste.Enabled = false;
                mnuPasteWithoutFormatting.Enabled = false;
                return;
            }

            mnuCut.Enabled = wrapper.CanCopyCut;
            mnuCopy.Enabled = wrapper.CanCopyCut;
            mnuPaste.Enabled = wrapper.CanPaste;
            mnuPasteWithoutFormatting.Enabled = wrapper.CanPaste;
            mnuUndo.Enabled = wrapper.CanUndo;
            mnuRedo.Enabled = wrapper.CanRedo;
        }

        private void MenuCopyCutPaste_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (sender.Equals(mnuCut))
            {
                wrapper?.Cut();
            }

            if (sender.Equals(mnuCopy))
            {
                wrapper?.Copy();
            }

            if (sender.Equals(mnuPaste))
            {
                wrapper?.Paste();
            }

            if (sender.Equals(mnuPasteWithoutFormatting))
            {
                wrapper?.PasteWithoutFormatting();
            }
        }

        private void mnuExportToRtfDocument_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (wrapper?.SelectedCard != null)
            {
                sdRtf.InitialDirectory = Settings.PathFileDialogRtfSave;
                sdRtf.FileName = Path.ChangeExtension(wrapper.CardFileSaveRtfName, ".rtf");
                if (sdRtf.ShowDialog() == DialogResult.OK)
                {
                    if (wrapper.ExportRtf(sdRtf.FileName))
                    {
                        Settings.PathFileDialogRtfSave = sdRtf.FileName.GetPath(Settings.PathFileDialogRtfSave);
                    }
                }
            }
        }

        private void mnuImportFromRtfDocument_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            odRtf.InitialDirectory = Settings.PathFileDialogRtfOpen;

            if (wrapper.SelectedCard != null && odRtf.ShowDialog() == DialogResult.OK)
            {
                if (wrapper.ImportRtf(odRtf.FileName))
                {
                    Settings.PathFileDialogRtfOpen = odRtf.FileName.GetPath(Settings.PathFileDialogRtfOpen);
                }
            }
        }

        private void tsbUndo_Click(object sender, EventArgs e)
        {
            CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.Undo();
            SetUndoRedoState();
        }

        private void tsbRedo_Click(object sender, EventArgs e)
        {
            CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.Redo();
            SetUndoRedoState();
        }

        private void tsbUndoAll_Click(object sender, EventArgs e)
        {
            CardFileSaveClose.ReloadFromDisk(tcCardFiles);
            CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.ClearUndo();
            SetUndoRedoState();
            SetTitle(true);
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

        #region SpellCheck
        private void tsbSpellCheckCard_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (SpellCheckCurrent(wrapper, out _) && !SpellChecker.ChecksDoneOnPreviousRun)
            {
                MessageBox.Show(this,
                    DBLangEngine.GetMessage("msgSpellCheckingPassed",
                        "No errors were found during the spell checking process.|A message indicating that a card file spell checking yielded no errors."),
                    DBLangEngine.GetStatMessage("msgSpellCheckingPassedTitle",
                        "Passed|A title for a message box indicating that a card file spell checking yielded no errors."),
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void mnuSpellCheckAllCards_Click(object sender, EventArgs e)
        {
            var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles);
            if (wrapper == null)
            {
                return;
            }

            var checksDone = false;

            for (int i = 0; i < wrapper.ListBoxCards.Items.Count; i++)
            {
                wrapper.ListBoxCards.SelectedIndex = i;
                SpellCheckCurrent(wrapper, out var userCanceled);
                if (userCanceled)
                {
                    return;
                }

                checksDone |= SpellChecker.ChecksDoneOnPreviousRun;
            }

            if (!checksDone)
            {
                MessageBox.Show(this,
                    DBLangEngine.GetMessage("msgSpellCheckingPassed",
                        "No errors were found during the spell checking process.|A message indicating that a card file spell checking yielded no errors."),
                    DBLangEngine.GetStatMessage("msgSpellCheckingPassedTitle",
                        "Passed|A title for a message box indicating that a card file spell checking yielded no errors."),
                    MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private bool SpellCheckCurrent(CardFileUiWrapper wrapper, out bool userCanceled)
        {
            userCanceled = false;
            if (wrapper == null)
            {
                return false;
            }

            TextOffsetCorrection = 0; // re-set the offset..
            // create a new instance of the spell checker class..
            var spellChecker = new SpellChecker();

            // create a new spell checking dialog (implementing the ISpellCheck) interface..

            var spellingDialog = new FormDialogSpellCheck();

            // run the spell check..
            var result = spellChecker.RunSpellCheckInterface(spellingDialog, wrapper.RichTextBox.Text, true);

            userCanceled = result == null;

            return result != null && result.Count == 0;
        }

        // the real-time spell checking event..
        private void SpellChecker_SpellCheckLocationChanged(object sender, VPKSoft.SpellCheckUtility.UtilityClasses.SpellCheckLocationChangeEventArgs e)
        {
            var richTextBox = CardFileUiWrapper.GetActiveUiWrapper(tcCardFiles)?.RichTextBox.RichTextBox;
            if (richTextBox == null)
            {
                return;
            }

            // set the selection for the misspelled word..
            richTextBox.SelectionStart = e.SpellingError.StartLocation + TextOffsetCorrection;
            richTextBox.SelectionLength = e.SpellingError.Length;

            // if a correction for the spelling error was made..
            if (e.AfterSpellCheck) 
            {
                // ..fix the error in real time..
                richTextBox.SelectedText = e.SpellingError.CorrectedWord;

                // ..set the offset, so this doesn't get messy..
                TextOffsetCorrection += e.SpellingError.CorrectedWord.Length - e.SpellingError.Length;
            }

            // scroll the "view" into visibility..
            richTextBox.ScrollToCaret();
        }
        #endregion
    }
}
