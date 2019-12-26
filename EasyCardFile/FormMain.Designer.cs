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
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuImportPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.tcCardFiles = new Manina.Windows.Forms.TabControl();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tab5 = new Manina.Windows.Forms.Tab();
            this.odCardFileLegacy = new System.Windows.Forms.OpenFileDialog();
            this.sdCardFile = new System.Windows.Forms.SaveFileDialog();
            this.odCardFile = new System.Windows.Forms.OpenFileDialog();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(876, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuNew,
            this.mnuImportPrevious});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(226, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(226, 22);
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuImportPrevious
            // 
            this.mnuImportPrevious.Name = "mnuImportPrevious";
            this.mnuImportPrevious.Size = new System.Drawing.Size(226, 22);
            this.mnuImportPrevious.Text = "Import from previous format";
            this.mnuImportPrevious.Click += new System.EventHandler(this.mnuImportPrevious_Click);
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
            this.tcCardFiles.Size = new System.Drawing.Size(852, 440);
            this.tcCardFiles.TabIndex = 2;
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(876, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 504);
            this.Controls.Add(this.tcCardFiles);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.Text = "Easy CardFile";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuImportPrevious;
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
    }
}

