namespace EasyCardFile
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCardFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewCard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRenameCard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteCard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExportToRtfDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportFromRtfDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSortCards = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCardFilePreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPasteWithoutFormatting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUndoAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSpellCheckCard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSpellCheckAllCards = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportLegacy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLocalization = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDumpLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbNewFile = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenFile = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewCard = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCardFilePreferences = new System.Windows.Forms.ToolStripButton();
            this.tsbRenameCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSortCards = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.tsbRedo = new System.Windows.Forms.ToolStripButton();
            this.tsbUndoAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSpellCheckCard = new System.Windows.Forms.ToolStripButton();
            this.tab5 = new Manina.Windows.Forms.Tab();
            this.odCardFileLegacy = new System.Windows.Forms.OpenFileDialog();
            this.sdCardFile = new System.Windows.Forms.SaveFileDialog();
            this.odCardFile = new System.Windows.Forms.OpenFileDialog();
            this.tmRemoteOpenFileQueue = new System.Windows.Forms.Timer(this.components);
            this.odRtf = new System.Windows.Forms.OpenFileDialog();
            this.sdRtf = new System.Windows.Forms.SaveFileDialog();
            this.tcCardFiles = new Manina.Windows.Forms.TabControl();
            this.mnuMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuCardFile,
            this.mnuEdit,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1000, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripMenuItem2,
            this.mnuTest,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuNew.Image")));
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuNew.Size = new System.Drawing.Size(177, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpen.Size = new System.Drawing.Size(177, 22);
            this.mnuOpen.Text = "Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(177, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("mnuSaveAs.Image")));
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.mnuSaveAs.Size = new System.Drawing.Size(177, 22);
            this.mnuSaveAs.Text = "Save As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(177, 22);
            this.mnuTest.Text = "Test";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuExit.Size = new System.Drawing.Size(177, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuCardFile
            // 
            this.mnuCardFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewCard,
            this.mnuRenameCard,
            this.mnuDeleteCard,
            this.toolStripMenuItem6,
            this.mnuExportToRtfDocument,
            this.mnuImportFromRtfDocument,
            this.toolStripMenuItem1,
            this.mnuSortCards,
            this.toolStripMenuItem4,
            this.mnuPrint,
            this.mnuPrintPreview,
            this.toolStripMenuItem3,
            this.mnuCardFilePreferences});
            this.mnuCardFile.Name = "mnuCardFile";
            this.mnuCardFile.Size = new System.Drawing.Size(65, 20);
            this.mnuCardFile.Text = "Card File";
            // 
            // mnuNewCard
            // 
            this.mnuNewCard.Image = ((System.Drawing.Image)(resources.GetObject("mnuNewCard.Image")));
            this.mnuNewCard.Name = "mnuNewCard";
            this.mnuNewCard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewCard.Size = new System.Drawing.Size(218, 22);
            this.mnuNewCard.Text = "New card";
            this.mnuNewCard.Click += new System.EventHandler(this.tsbNewCard_Click);
            // 
            // mnuRenameCard
            // 
            this.mnuRenameCard.Image = ((System.Drawing.Image)(resources.GetObject("mnuRenameCard.Image")));
            this.mnuRenameCard.Name = "mnuRenameCard";
            this.mnuRenameCard.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuRenameCard.Size = new System.Drawing.Size(218, 22);
            this.mnuRenameCard.Text = "Rename card";
            this.mnuRenameCard.Click += new System.EventHandler(this.tsbRenameCard_Click);
            // 
            // mnuDeleteCard
            // 
            this.mnuDeleteCard.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteCard.Image")));
            this.mnuDeleteCard.Name = "mnuDeleteCard";
            this.mnuDeleteCard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuDeleteCard.Size = new System.Drawing.Size(218, 22);
            this.mnuDeleteCard.Text = "Delete card";
            this.mnuDeleteCard.Click += new System.EventHandler(this.tsbDeleteCard_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuExportToRtfDocument
            // 
            this.mnuExportToRtfDocument.Image = global::EasyCardFile.Properties.Resources.export_document;
            this.mnuExportToRtfDocument.Name = "mnuExportToRtfDocument";
            this.mnuExportToRtfDocument.Size = new System.Drawing.Size(218, 22);
            this.mnuExportToRtfDocument.Text = "Export to Rtf document";
            this.mnuExportToRtfDocument.Click += new System.EventHandler(this.mnuExportToRtfDocument_Click);
            // 
            // mnuImportFromRtfDocument
            // 
            this.mnuImportFromRtfDocument.Image = global::EasyCardFile.Properties.Resources.import_document2;
            this.mnuImportFromRtfDocument.Name = "mnuImportFromRtfDocument";
            this.mnuImportFromRtfDocument.Size = new System.Drawing.Size(218, 22);
            this.mnuImportFromRtfDocument.Text = "Import from Rtf document";
            this.mnuImportFromRtfDocument.Click += new System.EventHandler(this.mnuImportFromRtfDocument_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuSortCards
            // 
            this.mnuSortCards.Image = global::EasyCardFile.Properties.Resources.tools_sort_table;
            this.mnuSortCards.Name = "mnuSortCards";
            this.mnuSortCards.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuSortCards.Size = new System.Drawing.Size(218, 22);
            this.mnuSortCards.Text = "Sort cards";
            this.mnuSortCards.Click += new System.EventHandler(this.tsbSortCards_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrint.Image")));
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuPrint.Size = new System.Drawing.Size(218, 22);
            this.mnuPrint.Text = "Print card";
            this.mnuPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // mnuPrintPreview
            // 
            this.mnuPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("mnuPrintPreview.Image")));
            this.mnuPrintPreview.Name = "mnuPrintPreview";
            this.mnuPrintPreview.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.mnuPrintPreview.Size = new System.Drawing.Size(218, 22);
            this.mnuPrintPreview.Text = "Print preview";
            this.mnuPrintPreview.Click += new System.EventHandler(this.tsbPrintPreview_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(215, 6);
            // 
            // mnuCardFilePreferences
            // 
            this.mnuCardFilePreferences.Image = ((System.Drawing.Image)(resources.GetObject("mnuCardFilePreferences.Image")));
            this.mnuCardFilePreferences.Name = "mnuCardFilePreferences";
            this.mnuCardFilePreferences.Size = new System.Drawing.Size(218, 22);
            this.mnuCardFilePreferences.Text = "Preferences";
            this.mnuCardFilePreferences.Click += new System.EventHandler(this.tsbCardFilePreferences_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCut,
            this.mnuCopy,
            this.mnuPaste,
            this.mnuPasteWithoutFormatting,
            this.toolStripMenuItem5,
            this.mnuUndo,
            this.mnuRedo,
            this.mnuUndoAll,
            this.toolStripMenuItem7,
            this.mnuSpellCheckCard,
            this.mnuSpellCheckAllCards});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.DropDownOpening += new System.EventHandler(this.mnuEdit_DropDownOpening);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = global::EasyCardFile.Properties.Resources.Cut;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuCut.Size = new System.Drawing.Size(302, 22);
            this.mnuCut.Text = "Cut";
            this.mnuCut.Click += new System.EventHandler(this.MenuCopyCutPaste_Click);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::EasyCardFile.Properties.Resources.Copy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopy.Size = new System.Drawing.Size(302, 22);
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Click += new System.EventHandler(this.MenuCopyCutPaste_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::EasyCardFile.Properties.Resources.Paste;
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuPaste.Size = new System.Drawing.Size(302, 22);
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Click += new System.EventHandler(this.MenuCopyCutPaste_Click);
            // 
            // mnuPasteWithoutFormatting
            // 
            this.mnuPasteWithoutFormatting.Image = global::EasyCardFile.Properties.Resources.edit_paste_3;
            this.mnuPasteWithoutFormatting.Name = "mnuPasteWithoutFormatting";
            this.mnuPasteWithoutFormatting.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.V)));
            this.mnuPasteWithoutFormatting.Size = new System.Drawing.Size(302, 22);
            this.mnuPasteWithoutFormatting.Text = "Paste without formatting";
            this.mnuPasteWithoutFormatting.Click += new System.EventHandler(this.MenuCopyCutPaste_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(299, 6);
            // 
            // mnuUndo
            // 
            this.mnuUndo.Image = global::EasyCardFile.Properties.Resources.edit_undo_5;
            this.mnuUndo.Name = "mnuUndo";
            this.mnuUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuUndo.Size = new System.Drawing.Size(302, 22);
            this.mnuUndo.Text = "Undo";
            this.mnuUndo.Click += new System.EventHandler(this.tsbUndo_Click);
            // 
            // mnuRedo
            // 
            this.mnuRedo.Image = global::EasyCardFile.Properties.Resources.edit_redo_5;
            this.mnuRedo.Name = "mnuRedo";
            this.mnuRedo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuRedo.Size = new System.Drawing.Size(302, 22);
            this.mnuRedo.Text = "Redo";
            this.mnuRedo.Click += new System.EventHandler(this.tsbRedo_Click);
            // 
            // mnuUndoAll
            // 
            this.mnuUndoAll.Image = global::EasyCardFile.Properties.Resources.arrow_undo;
            this.mnuUndoAll.Name = "mnuUndoAll";
            this.mnuUndoAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuUndoAll.Size = new System.Drawing.Size(302, 22);
            this.mnuUndoAll.Text = "Undo all";
            this.mnuUndoAll.Click += new System.EventHandler(this.tsbUndoAll_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(299, 6);
            // 
            // mnuSpellCheckCard
            // 
            this.mnuSpellCheckCard.Image = global::EasyCardFile.Properties.Resources.tools_check_spelling_2;
            this.mnuSpellCheckCard.Name = "mnuSpellCheckCard";
            this.mnuSpellCheckCard.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.mnuSpellCheckCard.Size = new System.Drawing.Size(302, 22);
            this.mnuSpellCheckCard.Text = "Spell check the selected card";
            // 
            // mnuSpellCheckAllCards
            // 
            this.mnuSpellCheckAllCards.Image = global::EasyCardFile.Properties.Resources.tools_check_spelling_4;
            this.mnuSpellCheckAllCards.Name = "mnuSpellCheckAllCards";
            this.mnuSpellCheckAllCards.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F7)));
            this.mnuSpellCheckAllCards.Size = new System.Drawing.Size(302, 22);
            this.mnuSpellCheckAllCards.Text = "Spell check all the cards";
            this.mnuSpellCheckAllCards.Click += new System.EventHandler(this.mnuSpellCheckAllCards_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuImportLegacy,
            this.mnuLocalization});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = ((System.Drawing.Image)(resources.GetObject("mnuSettings.Image")));
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F12)));
            this.mnuSettings.Size = new System.Drawing.Size(226, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuImportLegacy
            // 
            this.mnuImportLegacy.Image = ((System.Drawing.Image)(resources.GetObject("mnuImportLegacy.Image")));
            this.mnuImportLegacy.Name = "mnuImportLegacy";
            this.mnuImportLegacy.Size = new System.Drawing.Size(226, 22);
            this.mnuImportLegacy.Text = "Import from previous format";
            this.mnuImportLegacy.Click += new System.EventHandler(this.mnuImportLegacy_Click);
            // 
            // mnuLocalization
            // 
            this.mnuLocalization.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDumpLanguage});
            this.mnuLocalization.Image = ((System.Drawing.Image)(resources.GetObject("mnuLocalization.Image")));
            this.mnuLocalization.Name = "mnuLocalization";
            this.mnuLocalization.Size = new System.Drawing.Size(226, 22);
            this.mnuLocalization.Text = "Localization";
            this.mnuLocalization.Click += new System.EventHandler(this.mnuLocalization_Click);
            // 
            // mnuDumpLanguage
            // 
            this.mnuDumpLanguage.Image = ((System.Drawing.Image)(resources.GetObject("mnuDumpLanguage.Image")));
            this.mnuDumpLanguage.Name = "mnuDumpLanguage";
            this.mnuDumpLanguage.Size = new System.Drawing.Size(159, 22);
            this.mnuDumpLanguage.Text = "Dump language";
            this.mnuDumpLanguage.Click += new System.EventHandler(this.mnuDumpLanguage_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = ((System.Drawing.Image)(resources.GetObject("mnuAbout.Image")));
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(107, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // tab3
            // 
            this.tab3.Location = new System.Drawing.Point(1, 24);
            this.tab3.Name = "tab3";
            this.tab3.Size = new System.Drawing.Size(1145, 517);
            this.tab3.Text = "tab3";
            // 
            // tab1
            // 
            this.tab1.Location = new System.Drawing.Point(1, 24);
            this.tab1.Name = "tab1";
            this.tab1.Size = new System.Drawing.Size(1145, 517);
            this.tab1.Text = "tab1";
            // 
            // tab2
            // 
            this.tab2.Location = new System.Drawing.Point(1, 24);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(1145, 517);
            this.tab2.Text = "tab2";
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewFile,
            this.tsbOpenFile,
            this.tsbSave,
            this.tsbSaveAs,
            this.toolStripSeparator1,
            this.tsbNewCard,
            this.tsbDeleteCard,
            this.toolStripSeparator2,
            this.tsbCardFilePreferences,
            this.tsbRenameCard,
            this.toolStripSeparator3,
            this.tsbPrint,
            this.tsbPrintPreview,
            this.toolStripSeparator4,
            this.tsbSortCards,
            this.toolStripSeparator5,
            this.tsbUndo,
            this.tsbRedo,
            this.tsbUndoAll,
            this.toolStripSeparator6,
            this.tsbSpellCheckCard});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1000, 25);
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbNewFile
            // 
            this.tsbNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewFile.Image")));
            this.tsbNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewFile.Name = "tsbNewFile";
            this.tsbNewFile.Size = new System.Drawing.Size(23, 22);
            this.tsbNewFile.Text = "New file";
            this.tsbNewFile.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // tsbOpenFile
            // 
            this.tsbOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenFile.Image")));
            this.tsbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFile.Name = "tsbOpenFile";
            this.tsbOpenFile.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenFile.Text = "Open file";
            this.tsbOpenFile.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save the card file";
            this.tsbSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAs.Image")));
            this.tsbSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAs.Name = "tsbSaveAs";
            this.tsbSaveAs.Size = new System.Drawing.Size(23, 22);
            this.tsbSaveAs.Text = "Save the card file as";
            this.tsbSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbNewCard
            // 
            this.tsbNewCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewCard.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewCard.Image")));
            this.tsbNewCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewCard.Name = "tsbNewCard";
            this.tsbNewCard.Size = new System.Drawing.Size(23, 22);
            this.tsbNewCard.Text = "New card";
            this.tsbNewCard.Click += new System.EventHandler(this.tsbNewCard_Click);
            // 
            // tsbDeleteCard
            // 
            this.tsbDeleteCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteCard.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteCard.Image")));
            this.tsbDeleteCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteCard.Name = "tsbDeleteCard";
            this.tsbDeleteCard.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteCard.Text = "Delete card";
            this.tsbDeleteCard.Click += new System.EventHandler(this.tsbDeleteCard_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCardFilePreferences
            // 
            this.tsbCardFilePreferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCardFilePreferences.Image = ((System.Drawing.Image)(resources.GetObject("tsbCardFilePreferences.Image")));
            this.tsbCardFilePreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCardFilePreferences.Name = "tsbCardFilePreferences";
            this.tsbCardFilePreferences.Size = new System.Drawing.Size(23, 22);
            this.tsbCardFilePreferences.Text = "Card file preferences";
            this.tsbCardFilePreferences.Click += new System.EventHandler(this.tsbCardFilePreferences_Click);
            // 
            // tsbRenameCard
            // 
            this.tsbRenameCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRenameCard.Image = ((System.Drawing.Image)(resources.GetObject("tsbRenameCard.Image")));
            this.tsbRenameCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRenameCard.Name = "tsbRenameCard";
            this.tsbRenameCard.Size = new System.Drawing.Size(23, 22);
            this.tsbRenameCard.Text = "Rename card";
            this.tsbRenameCard.Click += new System.EventHandler(this.tsbRenameCard_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "Print card";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbPrintPreview
            // 
            this.tsbPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrintPreview.Image")));
            this.tsbPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintPreview.Name = "tsbPrintPreview";
            this.tsbPrintPreview.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintPreview.Text = "Print preview";
            this.tsbPrintPreview.Click += new System.EventHandler(this.tsbPrintPreview_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSortCards
            // 
            this.tsbSortCards.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSortCards.Image = global::EasyCardFile.Properties.Resources.tools_sort_table;
            this.tsbSortCards.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSortCards.Name = "tsbSortCards";
            this.tsbSortCards.Size = new System.Drawing.Size(23, 22);
            this.tsbSortCards.Text = "Sort cards";
            this.tsbSortCards.Click += new System.EventHandler(this.tsbSortCards_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Image = global::EasyCardFile.Properties.Resources.edit_undo_5;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbUndo.Text = "Undo";
            this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
            // 
            // tsbRedo
            // 
            this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRedo.Image = global::EasyCardFile.Properties.Resources.edit_redo_5;
            this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRedo.Name = "tsbRedo";
            this.tsbRedo.Size = new System.Drawing.Size(23, 22);
            this.tsbRedo.Text = "Redo";
            this.tsbRedo.Click += new System.EventHandler(this.tsbRedo_Click);
            // 
            // tsbUndoAll
            // 
            this.tsbUndoAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndoAll.Image = global::EasyCardFile.Properties.Resources.arrow_undo;
            this.tsbUndoAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndoAll.Name = "tsbUndoAll";
            this.tsbUndoAll.Size = new System.Drawing.Size(23, 22);
            this.tsbUndoAll.Text = "Undo all changes";
            this.tsbUndoAll.Click += new System.EventHandler(this.tsbUndoAll_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSpellCheckCard
            // 
            this.tsbSpellCheckCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpellCheckCard.Image = global::EasyCardFile.Properties.Resources.tools_check_spelling_2;
            this.tsbSpellCheckCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpellCheckCard.Name = "tsbSpellCheckCard";
            this.tsbSpellCheckCard.Size = new System.Drawing.Size(23, 22);
            this.tsbSpellCheckCard.Text = "Spell check the card";
            this.tsbSpellCheckCard.Click += new System.EventHandler(this.tsbSpellCheckCard_Click);
            // 
            // tab5
            // 
            this.tab5.Location = new System.Drawing.Point(1, 24);
            this.tab5.Name = "tab5";
            this.tab5.Size = new System.Drawing.Size(1145, 517);
            this.tab5.Text = "tab5";
            // 
            // odCardFileLegacy
            // 
            this.odCardFileLegacy.Filter = "Eeasy Cardfile Professional legacy files|*.ecfp";
            // 
            // sdCardFile
            // 
            this.sdCardFile.DefaultExt = "*.ecff";
            this.sdCardFile.Filter = "Easy CardFile files|*.ecff";
            this.sdCardFile.SupportMultiDottedExtensions = true;
            // 
            // odCardFile
            // 
            this.odCardFile.DefaultExt = "*.ecff";
            this.odCardFile.Filter = "Easy CardFile file|*.ecff";
            // 
            // tmRemoteOpenFileQueue
            // 
            this.tmRemoteOpenFileQueue.Tick += new System.EventHandler(this.tmRemoteOpenFileQueue_Tick);
            // 
            // odRtf
            // 
            this.odRtf.Filter = "Rtf files|*.rtf|Text files|*.txt|Any file|*.*";
            // 
            // sdRtf
            // 
            this.sdRtf.DefaultExt = "*.rtf";
            this.sdRtf.Filter = "Rtf files|*.rtf";
            // 
            // tcCardFiles
            // 
            this.tcCardFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcCardFiles.Location = new System.Drawing.Point(12, 52);
            this.tcCardFiles.Name = "tcCardFiles";
            this.tcCardFiles.SelectedIndex = -1;
            this.tcCardFiles.ShowCloseTabButtons = true;
            this.tcCardFiles.Size = new System.Drawing.Size(976, 533);
            this.tcCardFiles.TabIndex = 2;
            this.tcCardFiles.CloseTabButtonClick += new System.EventHandler<Manina.Windows.Forms.CancelTabEventArgs>(this.tcCardFiles_CloseTabButtonClick);
            this.tcCardFiles.PageChanged += new System.EventHandler<Manina.Windows.Forms.PageChangedEventArgs>(this.tcCardFiles_PageChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 597);
            this.Controls.Add(this.tcCardFiles);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.Text = "Easy CardFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private Manina.Windows.Forms.TabControl tcCardFiles;
        private Manina.Windows.Forms.Tab tab1;
        private Manina.Windows.Forms.Tab tab2;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStrip tsMain;
        private Manina.Windows.Forms.Tab tab3;
        private Manina.Windows.Forms.Tab tab5;
        private System.Windows.Forms.OpenFileDialog odCardFileLegacy;
        private System.Windows.Forms.SaveFileDialog sdCardFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.OpenFileDialog odCardFile;
        private System.Windows.Forms.ToolStripButton tsbNewCard;
        private System.Windows.Forms.ToolStripButton tsbDeleteCard;
        private System.Windows.Forms.ToolStripButton tsbNewFile;
        private System.Windows.Forms.ToolStripButton tsbOpenFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCardFilePreferences;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuImportLegacy;
        private System.Windows.Forms.Timer tmRemoteOpenFileQueue;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuCardFile;
        private System.Windows.Forms.ToolStripMenuItem mnuCardFilePreferences;
        private System.Windows.Forms.ToolStripMenuItem mnuNewCard;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteCard;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tsbRenameCard;
        private System.Windows.Forms.ToolStripMenuItem mnuRenameCard;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripMenuItem mnuPrintPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuLocalization;
        private System.Windows.Forms.ToolStripMenuItem mnuDumpLanguage;
        private System.Windows.Forms.ToolStripButton tsbSortCards;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuPasteWithoutFormatting;
        private System.Windows.Forms.ToolStripMenuItem mnuSortCards;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuExportToRtfDocument;
        private System.Windows.Forms.ToolStripMenuItem mnuImportFromRtfDocument;
        private System.Windows.Forms.OpenFileDialog odRtf;
        private System.Windows.Forms.SaveFileDialog sdRtf;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuUndo;
        private System.Windows.Forms.ToolStripMenuItem mnuRedo;
        private System.Windows.Forms.ToolStripButton tsbUndoAll;
        private System.Windows.Forms.ToolStripMenuItem mnuUndoAll;
        private System.Windows.Forms.ToolStripButton tsbSpellCheckCard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mnuSpellCheckCard;
        private System.Windows.Forms.ToolStripMenuItem mnuSpellCheckAllCards;
    }
}

