namespace EasyCardFileProfessional
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
            this.mnuImportPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.tcCardFiles = new Manina.Windows.Forms.TabControl();
            this.tab3 = new Manina.Windows.Forms.Tab();
            this.tab1 = new Manina.Windows.Forms.Tab();
            this.rtbCardContents = new VPKSoft.RichTextEdit.RichTextBoxWithToolStrip();
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667 = new VPKSoft.RichTextEdit.RichTextBoxExtended();
            this.tab2 = new Manina.Windows.Forms.Tab();
            this.scCardFile = new System.Windows.Forms.SplitContainer();
            this.tlpCardList = new System.Windows.Forms.TableLayoutPanel();
            this.lbSearchCards = new System.Windows.Forms.Label();
            this.tbSearchCards = new System.Windows.Forms.TextBox();
            this.lbCards = new System.Windows.Forms.ListBox();
            this.ssEditorStrip = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tab5 = new Manina.Windows.Forms.Tab();
            this.odCardFileLegacy = new System.Windows.Forms.OpenFileDialog();
            this.sdCardFile = new System.Windows.Forms.SaveFileDialog();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.odCardFile = new System.Windows.Forms.OpenFileDialog();
            this.mnuMain.SuspendLayout();
            this.rtbCardContents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCardFile)).BeginInit();
            this.scCardFile.Panel1.SuspendLayout();
            this.scCardFile.Panel2.SuspendLayout();
            this.scCardFile.SuspendLayout();
            this.tlpCardList.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1171, 24);
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
            this.tcCardFiles.Size = new System.Drawing.Size(1147, 542);
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
            // rtbCardContents
            // 
            this.rtbCardContents.AcceptsTab = true;
            this.rtbCardContents.AutomaticColorText = "Automatic";
            this.rtbCardContents.ColorButtonForeground = System.Drawing.Color.Black;
            this.rtbCardContents.ColorGlyph = System.Drawing.Color.Blue;
            this.rtbCardContents.Controls.Add(this.object_60e73559_5a8d_441d_bed0_2a0a51358667);
            this.rtbCardContents.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtbCardContents.ImageFilter = "Images files|*.bmp;*.png;*.jpg;*.jpeg|Bitmaps|*.bmp|Portable Network Graphics|*.p" +
    "ng|Jpeg|*.jpg;*.jpeg";
            this.rtbCardContents.Location = new System.Drawing.Point(0, 0);
            this.rtbCardContents.MoreColorsText = "More colors...";
            this.rtbCardContents.Name = "rtbCardContents";
            this.rtbCardContents.Size = new System.Drawing.Size(624, 487);
            this.rtbCardContents.TabIndex = 2;
            this.rtbCardContents.WordWrap = true;
            // 
            // object_60e73559_5a8d_441d_bed0_2a0a51358667
            // 
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.AcceptsTab = true;
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.Dock = System.Windows.Forms.DockStyle.Fill;
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.HideSelection = false;
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.Location = new System.Drawing.Point(0, 0);
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.Name = "object_60e73559_5a8d_441d_bed0_2a0a51358667";
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.Size = new System.Drawing.Size(624, 487);
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.TabIndex = 0;
            this.object_60e73559_5a8d_441d_bed0_2a0a51358667.Text = "";
            // 
            // tab2
            // 
            this.tab2.Location = new System.Drawing.Point(1, 24);
            this.tab2.Name = "tab2";
            this.tab2.Size = new System.Drawing.Size(1145, 517);
            this.tab2.Text = "tab2";
            // 
            // scCardFile
            // 
            this.scCardFile.Location = new System.Drawing.Point(118, 52);
            this.scCardFile.Name = "scCardFile";
            // 
            // scCardFile.Panel1
            // 
            this.scCardFile.Panel1.Controls.Add(this.tlpCardList);
            // 
            // scCardFile.Panel2
            // 
            this.scCardFile.Panel2.Controls.Add(this.ssEditorStrip);
            this.scCardFile.Panel2.Controls.Add(this.rtbCardContents);
            this.scCardFile.Size = new System.Drawing.Size(941, 512);
            this.scCardFile.SplitterDistance = 313;
            this.scCardFile.TabIndex = 3;
            // 
            // tlpCardList
            // 
            this.tlpCardList.ColumnCount = 2;
            this.tlpCardList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpCardList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCardList.Controls.Add(this.lbSearchCards, 0, 0);
            this.tlpCardList.Controls.Add(this.tbSearchCards, 1, 0);
            this.tlpCardList.Controls.Add(this.lbCards, 0, 1);
            this.tlpCardList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCardList.Location = new System.Drawing.Point(0, 0);
            this.tlpCardList.Name = "tlpCardList";
            this.tlpCardList.RowCount = 2;
            this.tlpCardList.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCardList.Size = new System.Drawing.Size(313, 512);
            this.tlpCardList.TabIndex = 0;
            // 
            // lbSearchCards
            // 
            this.lbSearchCards.AutoSize = true;
            this.lbSearchCards.Location = new System.Drawing.Point(3, 3);
            this.lbSearchCards.Margin = new System.Windows.Forms.Padding(3);
            this.lbSearchCards.Name = "lbSearchCards";
            this.lbSearchCards.Padding = new System.Windows.Forms.Padding(2);
            this.lbSearchCards.Size = new System.Drawing.Size(48, 17);
            this.lbSearchCards.TabIndex = 0;
            this.lbSearchCards.Text = "Search:";
            // 
            // tbSearchCards
            // 
            this.tbSearchCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSearchCards.Location = new System.Drawing.Point(57, 3);
            this.tbSearchCards.Name = "tbSearchCards";
            this.tbSearchCards.Size = new System.Drawing.Size(253, 20);
            this.tbSearchCards.TabIndex = 1;
            // 
            // lbCards
            // 
            this.tlpCardList.SetColumnSpan(this.lbCards, 2);
            this.lbCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCards.FormattingEnabled = true;
            this.lbCards.Location = new System.Drawing.Point(3, 29);
            this.lbCards.Name = "lbCards";
            this.lbCards.Size = new System.Drawing.Size(307, 480);
            this.lbCards.TabIndex = 2;
            // 
            // ssEditorStrip
            // 
            this.ssEditorStrip.Location = new System.Drawing.Point(0, 490);
            this.ssEditorStrip.Name = "ssEditorStrip";
            this.ssEditorStrip.Size = new System.Drawing.Size(624, 22);
            this.ssEditorStrip.TabIndex = 3;
            this.ssEditorStrip.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1171, 25);
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
            this.odCardFileLegacy.Filter = "Eeasy CardFile Professional legacy files|*.ecfp";
            // 
            // sdCardFile
            // 
            this.sdCardFile.DefaultExt = "*.ecfpf";
            this.sdCardFile.Filter = "Easy CardFile Professional files|*.ecfpf";
            this.sdCardFile.SupportMultiDottedExtensions = true;
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(226, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // odCardFile
            // 
            this.odCardFile.DefaultExt = "*.ecfpf";
            this.odCardFile.Filter = "Easy CardFile Professional file|*.ecfpf";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 606);
            this.Controls.Add(this.tcCardFiles);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.scCardFile);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "FormMain";
            this.Text = "Easy CardFile Professional";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.rtbCardContents.ResumeLayout(false);
            this.rtbCardContents.PerformLayout();
            this.scCardFile.Panel1.ResumeLayout(false);
            this.scCardFile.Panel2.ResumeLayout(false);
            this.scCardFile.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scCardFile)).EndInit();
            this.scCardFile.ResumeLayout(false);
            this.tlpCardList.ResumeLayout(false);
            this.tlpCardList.PerformLayout();
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
        private VPKSoft.RichTextEdit.RichTextBoxWithToolStrip rtbCardContents;
        private VPKSoft.RichTextEdit.RichTextBoxExtended object_60e73559_5a8d_441d_bed0_2a0a51358667;
        private System.Windows.Forms.SplitContainer scCardFile;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.TableLayoutPanel tlpCardList;
        private System.Windows.Forms.Label lbSearchCards;
        private System.Windows.Forms.TextBox tbSearchCards;
        private System.Windows.Forms.ListBox lbCards;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip ssEditorStrip;
        private Manina.Windows.Forms.Tab tab3;
        private Manina.Windows.Forms.Tab tab5;
        private System.Windows.Forms.OpenFileDialog odCardFileLegacy;
        private System.Windows.Forms.SaveFileDialog sdCardFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.OpenFileDialog odCardFile;
    }
}

