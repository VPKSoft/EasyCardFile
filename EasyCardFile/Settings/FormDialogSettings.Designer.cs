namespace EasyCardFile.Settings
{
    partial class FormDialogSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogSettings));
            this.tcMain = new Manina.Windows.Forms.TabControl();
            this.tabSettingsGeneral = new Manina.Windows.Forms.Tab();
            this.cbRestorePreviousSession = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAutoSaveExistingCardFilesAppClose = new System.Windows.Forms.CheckBox();
            this.tabSettingsCustomizeEditor = new Manina.Windows.Forms.Tab();
            this.lbEditorImageGlyphColor = new System.Windows.Forms.Label();
            this.cwEditorImageGlyphColor = new Cyotek.Windows.Forms.ColorWheel();
            this.rtbEditorToolStripColors = new VPKSoft.RichTextEdit.RichTextBoxWithToolStrip();
            this.lbEditorImageForeColor = new System.Windows.Forms.Label();
            this.cwEditorToolStripColors = new Cyotek.Windows.Forms.ColorWheel();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbSelectLanguageDescription = new System.Windows.Forms.Label();
            this.cmbSelectLanguageValue = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tcMain.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.tabSettingsCustomizeEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabSettingsGeneral);
            this.tcMain.Controls.Add(this.tabSettingsCustomizeEditor);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(683, 312);
            this.tcMain.TabIndex = 0;
            this.tcMain.Tabs.Add(this.tabSettingsGeneral);
            this.tcMain.Tabs.Add(this.tabSettingsCustomizeEditor);
            // 
            // tabSettingsGeneral
            // 
            this.tabSettingsGeneral.Controls.Add(this.textBox1);
            this.tabSettingsGeneral.Controls.Add(this.lbSelectLanguageDescription);
            this.tabSettingsGeneral.Controls.Add(this.cmbSelectLanguageValue);
            this.tabSettingsGeneral.Controls.Add(this.cbRestorePreviousSession);
            this.tabSettingsGeneral.Controls.Add(this.textBox2);
            this.tabSettingsGeneral.Controls.Add(this.label2);
            this.tabSettingsGeneral.Controls.Add(this.cbAutoSaveExistingCardFilesAppClose);
            this.tabSettingsGeneral.Location = new System.Drawing.Point(1, 21);
            this.tabSettingsGeneral.Name = "tabSettingsGeneral";
            this.tabSettingsGeneral.Size = new System.Drawing.Size(681, 290);
            this.tabSettingsGeneral.Text = "General";
            // 
            // cbRestorePreviousSession
            // 
            this.cbRestorePreviousSession.AutoSize = true;
            this.cbRestorePreviousSession.Location = new System.Drawing.Point(15, 42);
            this.cbRestorePreviousSession.Name = "cbRestorePreviousSession";
            this.cbRestorePreviousSession.Size = new System.Drawing.Size(248, 17);
            this.cbRestorePreviousSession.TabIndex = 5;
            this.cbRestorePreviousSession.Text = "Restore previous session on application startup";
            this.cbRestorePreviousSession.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(525, 14);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(411, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // cbAutoSaveExistingCardFilesAppClose
            // 
            this.cbAutoSaveExistingCardFilesAppClose.AutoSize = true;
            this.cbAutoSaveExistingCardFilesAppClose.Location = new System.Drawing.Point(15, 16);
            this.cbAutoSaveExistingCardFilesAppClose.Name = "cbAutoSaveExistingCardFilesAppClose";
            this.cbAutoSaveExistingCardFilesAppClose.Size = new System.Drawing.Size(307, 17);
            this.cbAutoSaveExistingCardFilesAppClose.TabIndex = 0;
            this.cbAutoSaveExistingCardFilesAppClose.Text = "Save existing card files automatically upon application close";
            this.cbAutoSaveExistingCardFilesAppClose.UseVisualStyleBackColor = true;
            // 
            // tabSettingsCustomizeEditor
            // 
            this.tabSettingsCustomizeEditor.Controls.Add(this.lbEditorImageGlyphColor);
            this.tabSettingsCustomizeEditor.Controls.Add(this.cwEditorImageGlyphColor);
            this.tabSettingsCustomizeEditor.Controls.Add(this.rtbEditorToolStripColors);
            this.tabSettingsCustomizeEditor.Controls.Add(this.lbEditorImageForeColor);
            this.tabSettingsCustomizeEditor.Controls.Add(this.cwEditorToolStripColors);
            this.tabSettingsCustomizeEditor.Location = new System.Drawing.Point(0, 0);
            this.tabSettingsCustomizeEditor.Name = "tabSettingsCustomizeEditor";
            this.tabSettingsCustomizeEditor.Size = new System.Drawing.Size(0, 0);
            this.tabSettingsCustomizeEditor.Text = "Customize editor";
            // 
            // lbEditorImageGlyphColor
            // 
            this.lbEditorImageGlyphColor.AutoSize = true;
            this.lbEditorImageGlyphColor.Location = new System.Drawing.Point(164, 115);
            this.lbEditorImageGlyphColor.Name = "lbEditorImageGlyphColor";
            this.lbEditorImageGlyphColor.Size = new System.Drawing.Size(123, 13);
            this.lbEditorImageGlyphColor.TabIndex = 11;
            this.lbEditorImageGlyphColor.Text = "Button image glyph color";
            // 
            // cwEditorImageGlyphColor
            // 
            this.cwEditorImageGlyphColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cwEditorImageGlyphColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cwEditorImageGlyphColor.Location = new System.Drawing.Point(167, -159);
            this.cwEditorImageGlyphColor.Name = "cwEditorImageGlyphColor";
            this.cwEditorImageGlyphColor.Size = new System.Drawing.Size(155, 156);
            this.cwEditorImageGlyphColor.TabIndex = 10;
            this.cwEditorImageGlyphColor.ColorChanged += new System.EventHandler(this.cwEditorImageGlyphColor_ColorChanged);
            // 
            // rtbEditorToolStripColors
            // 
            this.rtbEditorToolStripColors.AcceptsTab = true;
            this.rtbEditorToolStripColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEditorToolStripColors.AutomaticColorText = "Automatic";
            this.rtbEditorToolStripColors.ColorButtonForeground = System.Drawing.Color.Black;
            this.rtbEditorToolStripColors.ColorGlyph = System.Drawing.Color.Blue;
            this.rtbEditorToolStripColors.ImageFilter = "Images files|*.bmp;*.png;*.jpg;*.jpeg|Bitmaps|*.bmp|Portable Network Graphics|*.p" +
    "ng|Jpeg|*.jpg;*.jpeg";
            this.rtbEditorToolStripColors.Location = new System.Drawing.Point(3, 3);
            this.rtbEditorToolStripColors.MoreColorsText = "More colors...";
            this.rtbEditorToolStripColors.Name = "rtbEditorToolStripColors";
            this.rtbEditorToolStripColors.Size = new System.Drawing.Size(0, 109);
            this.rtbEditorToolStripColors.TabIndex = 9;
            this.rtbEditorToolStripColors.Text = resources.GetString("rtbEditorToolStripColors.Text");
            this.rtbEditorToolStripColors.WordWrap = false;
            // 
            // lbEditorImageForeColor
            // 
            this.lbEditorImageForeColor.AutoSize = true;
            this.lbEditorImageForeColor.Location = new System.Drawing.Point(3, 115);
            this.lbEditorImageForeColor.Name = "lbEditorImageForeColor";
            this.lbEditorImageForeColor.Size = new System.Drawing.Size(149, 13);
            this.lbEditorImageForeColor.TabIndex = 8;
            this.lbEditorImageForeColor.Text = "Button image foreground color";
            // 
            // cwEditorToolStripColors
            // 
            this.cwEditorToolStripColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cwEditorToolStripColors.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cwEditorToolStripColors.Location = new System.Drawing.Point(6, -159);
            this.cwEditorToolStripColors.Name = "cwEditorToolStripColors";
            this.cwEditorToolStripColors.Size = new System.Drawing.Size(155, 156);
            this.cwEditorToolStripColors.TabIndex = 7;
            this.cwEditorToolStripColors.ColorChanged += new System.EventHandler(this.cwEditorToolStripColors_ColorChanged);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(538, 336);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(619, 336);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // lbSelectLanguageDescription
            // 
            this.lbSelectLanguageDescription.AutoSize = true;
            this.lbSelectLanguageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbSelectLanguageDescription.Location = new System.Drawing.Point(12, 78);
            this.lbSelectLanguageDescription.Margin = new System.Windows.Forms.Padding(17, 15, 17, 15);
            this.lbSelectLanguageDescription.Name = "lbSelectLanguageDescription";
            this.lbSelectLanguageDescription.Size = new System.Drawing.Size(156, 13);
            this.lbSelectLanguageDescription.TabIndex = 28;
            this.lbSelectLanguageDescription.Text = "Language (a restart is required):";
            this.lbSelectLanguageDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbSelectLanguageValue
            // 
            this.cmbSelectLanguageValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectLanguageValue.DisplayMember = "DisplayName";
            this.cmbSelectLanguageValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectLanguageValue.FormattingEnabled = true;
            this.cmbSelectLanguageValue.Location = new System.Drawing.Point(243, 75);
            this.cmbSelectLanguageValue.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.cmbSelectLanguageValue.Name = "cmbSelectLanguageValue";
            this.cmbSelectLanguageValue.Size = new System.Drawing.Size(429, 21);
            this.cmbSelectLanguageValue.TabIndex = 29;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(525, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.Visible = false;
            // 
            // FormDialogSettings
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(707, 371);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings - Easy CardFile";
            this.Shown += new System.EventHandler(this.FormDialogSettings_Shown);
            this.tcMain.ResumeLayout(false);
            this.tabSettingsGeneral.ResumeLayout(false);
            this.tabSettingsGeneral.PerformLayout();
            this.tabSettingsCustomizeEditor.ResumeLayout(false);
            this.tabSettingsCustomizeEditor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Manina.Windows.Forms.TabControl tcMain;
        private Manina.Windows.Forms.Tab tabSettingsGeneral;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAutoSaveExistingCardFilesAppClose;
        private System.Windows.Forms.CheckBox cbRestorePreviousSession;
        private Manina.Windows.Forms.Tab tabSettingsCustomizeEditor;
        private VPKSoft.RichTextEdit.RichTextBoxWithToolStrip rtbEditorToolStripColors;
        private System.Windows.Forms.Label lbEditorImageForeColor;
        private Cyotek.Windows.Forms.ColorWheel cwEditorToolStripColors;
        private System.Windows.Forms.Label lbEditorImageGlyphColor;
        private Cyotek.Windows.Forms.ColorWheel cwEditorImageGlyphColor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbSelectLanguageDescription;
        private System.Windows.Forms.ComboBox cmbSelectLanguageValue;
    }
}