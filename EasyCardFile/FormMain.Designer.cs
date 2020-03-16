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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCardFilePreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportLegacy = new System.Windows.Forms.ToolStripMenuItem();
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
            this.tab5 = new Manina.Windows.Forms.Tab();
            this.odCardFileLegacy = new System.Windows.Forms.OpenFileDialog();
            this.sdCardFile = new System.Windows.Forms.SaveFileDialog();
            this.odCardFile = new System.Windows.Forms.OpenFileDialog();
            this.tmRemoteOpenFileQueue = new System.Windows.Forms.Timer(this.components);
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
            this.mnuTools,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(955, 24);
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
            this.mnuNew.Image = global::EasyCardFile.Properties.Resources.New_document;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(114, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = global::EasyCardFile.Properties.Resources.folder_database;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(114, 22);
            this.mnuOpen.Text = "Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = global::EasyCardFile.Properties.Resources.Save;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(114, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Image = global::EasyCardFile.Properties.Resources.SaveAs;
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(114, 22);
            this.mnuSaveAs.Text = "Save As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 6);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(114, 22);
            this.mnuTest.Text = "Test";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = global::EasyCardFile.Properties.Resources.Exit;
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(114, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuCardFile
            // 
            this.mnuCardFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewCard,
            this.mnuRenameCard,
            this.mnuDeleteCard,
            this.toolStripMenuItem1,
            this.mnuPrint,
            this.printPreviewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.mnuCardFilePreferences});
            this.mnuCardFile.Name = "mnuCardFile";
            this.mnuCardFile.Size = new System.Drawing.Size(65, 20);
            this.mnuCardFile.Text = "Card File";
            // 
            // mnuNewCard
            // 
            this.mnuNewCard.Image = global::EasyCardFile.Properties.Resources.new_card;
            this.mnuNewCard.Name = "mnuNewCard";
            this.mnuNewCard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuNewCard.Size = new System.Drawing.Size(184, 22);
            this.mnuNewCard.Text = "New card";
            this.mnuNewCard.Click += new System.EventHandler(this.tsbNewCard_Click);
            // 
            // mnuRenameCard
            // 
            this.mnuRenameCard.Image = global::EasyCardFile.Properties.Resources.Modify;
            this.mnuRenameCard.Name = "mnuRenameCard";
            this.mnuRenameCard.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.mnuRenameCard.Size = new System.Drawing.Size(184, 22);
            this.mnuRenameCard.Text = "Rename card";
            this.mnuRenameCard.Click += new System.EventHandler(this.tsbRenameCard_Click);
            // 
            // mnuDeleteCard
            // 
            this.mnuDeleteCard.Image = global::EasyCardFile.Properties.Resources.Delete;
            this.mnuDeleteCard.Name = "mnuDeleteCard";
            this.mnuDeleteCard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.mnuDeleteCard.Size = new System.Drawing.Size(184, 22);
            this.mnuDeleteCard.Text = "Delete card";
            this.mnuDeleteCard.Click += new System.EventHandler(this.tsbDeleteCard_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = global::EasyCardFile.Properties.Resources.printer_printing_2;
            this.mnuPrint.Name = "mnuPrint";
            this.mnuPrint.Size = new System.Drawing.Size(184, 22);
            this.mnuPrint.Text = "Print card";
            this.mnuPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = global::EasyCardFile.Properties.Resources.document_print_preview_4;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.printPreviewToolStripMenuItem.Text = "Print preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.tsbPrintPreview_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuCardFilePreferences
            // 
            this.mnuCardFilePreferences.Image = global::EasyCardFile.Properties.Resources.card_file_preferences;
            this.mnuCardFilePreferences.Name = "mnuCardFilePreferences";
            this.mnuCardFilePreferences.Size = new System.Drawing.Size(184, 22);
            this.mnuCardFilePreferences.Text = "Preferences";
            this.mnuCardFilePreferences.Click += new System.EventHandler(this.tsbCardFilePreferences_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings,
            this.mnuImportLegacy});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::EasyCardFile.Properties.Resources.system_settings_2;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(226, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuImportLegacy
            // 
            this.mnuImportLegacy.Image = global::EasyCardFile.Properties.Resources.import_document;
            this.mnuImportLegacy.Name = "mnuImportLegacy";
            this.mnuImportLegacy.Size = new System.Drawing.Size(226, 22);
            this.mnuImportLegacy.Text = "Import from previous format";
            this.mnuImportLegacy.Click += new System.EventHandler(this.mnuImportLegacy_Click);
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
            this.mnuAbout.Image = global::EasyCardFile.Properties.Resources.About;
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
            this.tsbPrintPreview});
            this.tsMain.Location = new System.Drawing.Point(0, 24);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(955, 25);
            this.tsMain.TabIndex = 4;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbNewFile
            // 
            this.tsbNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewFile.Image = global::EasyCardFile.Properties.Resources.New_document;
            this.tsbNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewFile.Name = "tsbNewFile";
            this.tsbNewFile.Size = new System.Drawing.Size(23, 22);
            this.tsbNewFile.Text = "New file";
            this.tsbNewFile.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // tsbOpenFile
            // 
            this.tsbOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpenFile.Image = global::EasyCardFile.Properties.Resources.folder_database;
            this.tsbOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenFile.Name = "tsbOpenFile";
            this.tsbOpenFile.Size = new System.Drawing.Size(23, 22);
            this.tsbOpenFile.Text = "Open file";
            this.tsbOpenFile.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = global::EasyCardFile.Properties.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save the card file";
            this.tsbSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // tsbSaveAs
            // 
            this.tsbSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveAs.Image = global::EasyCardFile.Properties.Resources.SaveAs;
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
            this.tsbNewCard.Image = global::EasyCardFile.Properties.Resources.new_card;
            this.tsbNewCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewCard.Name = "tsbNewCard";
            this.tsbNewCard.Size = new System.Drawing.Size(23, 22);
            this.tsbNewCard.Text = "New card";
            this.tsbNewCard.Click += new System.EventHandler(this.tsbNewCard_Click);
            // 
            // tsbDeleteCard
            // 
            this.tsbDeleteCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteCard.Image = global::EasyCardFile.Properties.Resources.Delete;
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
            this.tsbCardFilePreferences.Image = global::EasyCardFile.Properties.Resources.card_file_preferences;
            this.tsbCardFilePreferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCardFilePreferences.Name = "tsbCardFilePreferences";
            this.tsbCardFilePreferences.Size = new System.Drawing.Size(23, 22);
            this.tsbCardFilePreferences.Text = "Card file preferences";
            this.tsbCardFilePreferences.Click += new System.EventHandler(this.tsbCardFilePreferences_Click);
            // 
            // tsbRenameCard
            // 
            this.tsbRenameCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRenameCard.Image = global::EasyCardFile.Properties.Resources.Modify;
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
            this.tsbPrint.Image = global::EasyCardFile.Properties.Resources.printer_printing_2;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(23, 22);
            this.tsbPrint.Text = "Print card";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbPrintPreview
            // 
            this.tsbPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrintPreview.Image = global::EasyCardFile.Properties.Resources.document_print_preview_4;
            this.tsbPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrintPreview.Name = "tsbPrintPreview";
            this.tsbPrintPreview.Size = new System.Drawing.Size(23, 22);
            this.tsbPrintPreview.Text = "Print preview";
            this.tsbPrintPreview.Click += new System.EventHandler(this.tsbPrintPreview_Click);
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
            // tcCardFiles
            // 
            this.tcCardFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcCardFiles.Location = new System.Drawing.Point(12, 52);
            this.tcCardFiles.Name = "tcCardFiles";
            this.tcCardFiles.SelectedIndex = -1;
            this.tcCardFiles.ShowCloseTabButtons = true;
            this.tcCardFiles.Size = new System.Drawing.Size(931, 433);
            this.tcCardFiles.TabIndex = 2;
            this.tcCardFiles.CloseTabButtonClick += new System.EventHandler<Manina.Windows.Forms.CancelTabEventArgs>(this.tcCardFiles_CloseTabButtonClick);
            this.tcCardFiles.PageChanged += new System.EventHandler<Manina.Windows.Forms.PageChangedEventArgs>(this.tcCardFiles_PageChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 497);
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
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
    }
}

