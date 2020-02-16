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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuImportLegacy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewFile = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbNewCard = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteCard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCardFilePreferences = new System.Windows.Forms.ToolStripButton();
            this.tab5 = new Manina.Windows.Forms.Tab();
            this.odCardFileLegacy = new System.Windows.Forms.OpenFileDialog();
            this.sdCardFile = new System.Windows.Forms.SaveFileDialog();
            this.odCardFile = new System.Windows.Forms.OpenFileDialog();
            this.tcCardFiles = new Manina.Windows.Forms.TabControl();
            this.mnuMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuTools});
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
            this.toolStripMenuItem1,
            this.mnuImportLegacy,
            this.mnuTest});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Image = global::EasyCardFile.Properties.Resources.New_document;
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(226, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = global::EasyCardFile.Properties.Resources.folder_database;
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(226, 22);
            this.mnuOpen.Text = "Open...";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = global::EasyCardFile.Properties.Resources.Save;
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(226, 22);
            this.mnuSave.Text = "Save";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(223, 6);
            // 
            // mnuImportLegacy
            // 
            this.mnuImportLegacy.Image = global::EasyCardFile.Properties.Resources.import_document;
            this.mnuImportLegacy.Name = "mnuImportLegacy";
            this.mnuImportLegacy.Size = new System.Drawing.Size(226, 22);
            this.mnuImportLegacy.Text = "Import from previous format";
            this.mnuImportLegacy.Click += new System.EventHandler(this.mnuImportPrevious_Click);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(226, 22);
            this.mnuTest.Text = "Test";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSettings});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(46, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::EasyCardFile.Properties.Resources.system_settings_2;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(116, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewFile,
            this.tsbOpenFile,
            this.toolStripSeparator1,
            this.tsbNewCard,
            this.tsbDeleteCard,
            this.toolStripSeparator2,
            this.tsbCardFilePreferences});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(955, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
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
            // 
            // tsbDeleteCard
            // 
            this.tsbDeleteCard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteCard.Image = global::EasyCardFile.Properties.Resources.Delete;
            this.tsbDeleteCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteCard.Name = "tsbDeleteCard";
            this.tsbDeleteCard.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteCard.Text = "Delete card";
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
            this.sdCardFile.DefaultExt = "*.ecfpf";
            this.sdCardFile.Filter = "Easy CardFile files|*.ecff";
            this.sdCardFile.SupportMultiDottedExtensions = true;
            // 
            // odCardFile
            // 
            this.odCardFile.DefaultExt = "*.ecfpf";
            this.odCardFile.Filter = "Easy CardFile file|*.ecff";
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
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 497);
            this.Controls.Add(this.tcCardFiles);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.Text = "Easy CardFile";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuImportLegacy;
        private Manina.Windows.Forms.TabControl tcCardFiles;
        private Manina.Windows.Forms.Tab tab1;
        private Manina.Windows.Forms.Tab tab2;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuTest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCardFilePreferences;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
    }
}

