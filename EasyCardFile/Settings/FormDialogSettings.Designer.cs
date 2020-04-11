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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbSelectLanguageDescription = new System.Windows.Forms.Label();
            this.cmbSelectLanguageValue = new System.Windows.Forms.ComboBox();
            this.cbRestorePreviousSession = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbAutoSaveExistingCardFilesAppClose = new System.Windows.Forms.CheckBox();
            this.tabSettingsCustomizeEditor = new Manina.Windows.Forms.Tab();
            this.btButtonColorRestoreDefaults = new System.Windows.Forms.Button();
            this.btEditorImageGlyphColor = new System.Windows.Forms.Button();
            this.btEditorImageForeColor = new System.Windows.Forms.Button();
            this.lbEditorImageGlyphColor = new System.Windows.Forms.Label();
            this.rtbEditorToolStripColors = new VPKSoft.RichTextEdit.RichTextBoxWithToolStrip();
            this.lbEditorImageForeColor = new System.Windows.Forms.Label();
            this.tabSpelling = new Manina.Windows.Forms.Tab();
            this.btClearUserDictionary = new System.Windows.Forms.Button();
            this.cmbInstalledDictionaries = new System.Windows.Forms.ComboBox();
            this.lbInstalledDictionaries = new System.Windows.Forms.Label();
            this.btDictionaryPath = new System.Windows.Forms.Button();
            this.tbDictionaryPath = new System.Windows.Forms.TextBox();
            this.lbDictionaryPath = new System.Windows.Forms.Label();
            this.btHunspellAffixFile = new System.Windows.Forms.Button();
            this.tbHunspellAffixFile = new System.Windows.Forms.TextBox();
            this.lbHunspellAffixFile = new System.Windows.Forms.Label();
            this.btHunspellDictionary = new System.Windows.Forms.Button();
            this.tbHunspellDictionary = new System.Windows.Forms.TextBox();
            this.lbHunspellDictionary = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.odAffixFile = new System.Windows.Forms.OpenFileDialog();
            this.odDictionaryFile = new System.Windows.Forms.OpenFileDialog();
            this.fbFolder = new Ookii.Dialogs.WinForms.VistaFolderBrowserDialog();
            this.tcMain.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.tabSettingsCustomizeEditor.SuspendLayout();
            this.tabSpelling.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabSettingsGeneral);
            this.tcMain.Controls.Add(this.tabSettingsCustomizeEditor);
            this.tcMain.Controls.Add(this.tabSpelling);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(683, 312);
            this.tcMain.TabIndex = 0;
            this.tcMain.Tabs.Add(this.tabSettingsGeneral);
            this.tcMain.Tabs.Add(this.tabSettingsCustomizeEditor);
            this.tcMain.Tabs.Add(this.tabSpelling);
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(525, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 30;
            this.textBox1.Visible = false;
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
            this.cmbSelectLanguageValue.Size = new System.Drawing.Size(425, 21);
            this.cmbSelectLanguageValue.TabIndex = 29;
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
            this.tabSettingsCustomizeEditor.Controls.Add(this.btButtonColorRestoreDefaults);
            this.tabSettingsCustomizeEditor.Controls.Add(this.btEditorImageGlyphColor);
            this.tabSettingsCustomizeEditor.Controls.Add(this.btEditorImageForeColor);
            this.tabSettingsCustomizeEditor.Controls.Add(this.lbEditorImageGlyphColor);
            this.tabSettingsCustomizeEditor.Controls.Add(this.rtbEditorToolStripColors);
            this.tabSettingsCustomizeEditor.Controls.Add(this.lbEditorImageForeColor);
            this.tabSettingsCustomizeEditor.Location = new System.Drawing.Point(1, 21);
            this.tabSettingsCustomizeEditor.Name = "tabSettingsCustomizeEditor";
            this.tabSettingsCustomizeEditor.Size = new System.Drawing.Size(681, 290);
            this.tabSettingsCustomizeEditor.Text = "Customize editor";
            // 
            // btButtonColorRestoreDefaults
            // 
            this.btButtonColorRestoreDefaults.Location = new System.Drawing.Point(6, 160);
            this.btButtonColorRestoreDefaults.Name = "btButtonColorRestoreDefaults";
            this.btButtonColorRestoreDefaults.Size = new System.Drawing.Size(298, 23);
            this.btButtonColorRestoreDefaults.TabIndex = 14;
            this.btButtonColorRestoreDefaults.Text = "Restore defaults";
            this.btButtonColorRestoreDefaults.UseVisualStyleBackColor = true;
            this.btButtonColorRestoreDefaults.Click += new System.EventHandler(this.btButtonColorRestoreDefaults_Click);
            // 
            // btEditorImageGlyphColor
            // 
            this.btEditorImageGlyphColor.Location = new System.Drawing.Point(158, 131);
            this.btEditorImageGlyphColor.Name = "btEditorImageGlyphColor";
            this.btEditorImageGlyphColor.Size = new System.Drawing.Size(146, 23);
            this.btEditorImageGlyphColor.TabIndex = 13;
            this.btEditorImageGlyphColor.Tag = "1";
            this.btEditorImageGlyphColor.UseVisualStyleBackColor = true;
            this.btEditorImageGlyphColor.Click += new System.EventHandler(this.btEditorImageForeColor_Click);
            // 
            // btEditorImageForeColor
            // 
            this.btEditorImageForeColor.Location = new System.Drawing.Point(6, 131);
            this.btEditorImageForeColor.Name = "btEditorImageForeColor";
            this.btEditorImageForeColor.Size = new System.Drawing.Size(146, 23);
            this.btEditorImageForeColor.TabIndex = 12;
            this.btEditorImageForeColor.Tag = "0";
            this.btEditorImageForeColor.UseVisualStyleBackColor = true;
            this.btEditorImageForeColor.Click += new System.EventHandler(this.btEditorImageForeColor_Click);
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
            this.rtbEditorToolStripColors.Size = new System.Drawing.Size(675, 109);
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
            // tabSpelling
            // 
            this.tabSpelling.Controls.Add(this.btClearUserDictionary);
            this.tabSpelling.Controls.Add(this.cmbInstalledDictionaries);
            this.tabSpelling.Controls.Add(this.lbInstalledDictionaries);
            this.tabSpelling.Controls.Add(this.btDictionaryPath);
            this.tabSpelling.Controls.Add(this.tbDictionaryPath);
            this.tabSpelling.Controls.Add(this.lbDictionaryPath);
            this.tabSpelling.Controls.Add(this.btHunspellAffixFile);
            this.tabSpelling.Controls.Add(this.tbHunspellAffixFile);
            this.tabSpelling.Controls.Add(this.lbHunspellAffixFile);
            this.tabSpelling.Controls.Add(this.btHunspellDictionary);
            this.tabSpelling.Controls.Add(this.tbHunspellDictionary);
            this.tabSpelling.Controls.Add(this.lbHunspellDictionary);
            this.tabSpelling.Location = new System.Drawing.Point(1, 21);
            this.tabSpelling.Name = "tabSpelling";
            this.tabSpelling.Size = new System.Drawing.Size(681, 290);
            this.tabSpelling.Text = "Spell checking";
            // 
            // btClearUserDictionary
            // 
            this.btClearUserDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btClearUserDictionary.Location = new System.Drawing.Point(14, 209);
            this.btClearUserDictionary.Name = "btClearUserDictionary";
            this.btClearUserDictionary.Size = new System.Drawing.Size(658, 23);
            this.btClearUserDictionary.TabIndex = 56;
            this.btClearUserDictionary.Text = "Delete user personal dictionary";
            this.btClearUserDictionary.UseVisualStyleBackColor = true;
            this.btClearUserDictionary.Click += new System.EventHandler(this.btClearUserDictionary_Click);
            // 
            // cmbInstalledDictionaries
            // 
            this.cmbInstalledDictionaries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInstalledDictionaries.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInstalledDictionaries.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbInstalledDictionaries.DisplayMember = "DisplayName";
            this.cmbInstalledDictionaries.FormattingEnabled = true;
            this.cmbInstalledDictionaries.Location = new System.Drawing.Point(14, 173);
            this.cmbInstalledDictionaries.Margin = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.cmbInstalledDictionaries.Name = "cmbInstalledDictionaries";
            this.cmbInstalledDictionaries.Size = new System.Drawing.Size(658, 21);
            this.cmbInstalledDictionaries.TabIndex = 55;
            this.cmbInstalledDictionaries.SelectedIndexChanged += new System.EventHandler(this.cmbInstalledDictionaries_SelectedIndexChanged);
            // 
            // lbInstalledDictionaries
            // 
            this.lbInstalledDictionaries.AutoSize = true;
            this.lbInstalledDictionaries.Location = new System.Drawing.Point(11, 148);
            this.lbInstalledDictionaries.Name = "lbInstalledDictionaries";
            this.lbInstalledDictionaries.Size = new System.Drawing.Size(149, 13);
            this.lbInstalledDictionaries.TabIndex = 54;
            this.lbInstalledDictionaries.Text = "Installed Hunspell dictionaries:";
            // 
            // btDictionaryPath
            // 
            this.btDictionaryPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDictionaryPath.Location = new System.Drawing.Point(641, 125);
            this.btDictionaryPath.Name = "btDictionaryPath";
            this.btDictionaryPath.Size = new System.Drawing.Size(31, 21);
            this.btDictionaryPath.TabIndex = 53;
            this.btDictionaryPath.Tag = "tbDictionaryPath";
            this.btDictionaryPath.Text = "...";
            this.btDictionaryPath.UseVisualStyleBackColor = true;
            this.btDictionaryPath.Click += new System.EventHandler(this.btDictionaryPath_Click);
            // 
            // tbDictionaryPath
            // 
            this.tbDictionaryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDictionaryPath.Location = new System.Drawing.Point(14, 125);
            this.tbDictionaryPath.Name = "tbDictionaryPath";
            this.tbDictionaryPath.Size = new System.Drawing.Size(621, 20);
            this.tbDictionaryPath.TabIndex = 52;
            // 
            // lbDictionaryPath
            // 
            this.lbDictionaryPath.AutoSize = true;
            this.lbDictionaryPath.Location = new System.Drawing.Point(11, 102);
            this.lbDictionaryPath.Name = "lbDictionaryPath";
            this.lbDictionaryPath.Size = new System.Drawing.Size(139, 13);
            this.lbDictionaryPath.TabIndex = 51;
            this.lbDictionaryPath.Text = "Hunspell dictionary file path:";
            // 
            // btHunspellAffixFile
            // 
            this.btHunspellAffixFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHunspellAffixFile.Location = new System.Drawing.Point(641, 79);
            this.btHunspellAffixFile.Name = "btHunspellAffixFile";
            this.btHunspellAffixFile.Size = new System.Drawing.Size(31, 20);
            this.btHunspellAffixFile.TabIndex = 50;
            this.btHunspellAffixFile.Text = "...";
            this.btHunspellAffixFile.UseVisualStyleBackColor = true;
            this.btHunspellAffixFile.Click += new System.EventHandler(this.btHunspellAffixFile_Click);
            // 
            // tbHunspellAffixFile
            // 
            this.tbHunspellAffixFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHunspellAffixFile.Location = new System.Drawing.Point(14, 79);
            this.tbHunspellAffixFile.Name = "tbHunspellAffixFile";
            this.tbHunspellAffixFile.Size = new System.Drawing.Size(621, 20);
            this.tbHunspellAffixFile.TabIndex = 49;
            // 
            // lbHunspellAffixFile
            // 
            this.lbHunspellAffixFile.AutoSize = true;
            this.lbHunspellAffixFile.Location = new System.Drawing.Point(11, 56);
            this.lbHunspellAffixFile.Name = "lbHunspellAffixFile";
            this.lbHunspellAffixFile.Size = new System.Drawing.Size(128, 13);
            this.lbHunspellAffixFile.TabIndex = 48;
            this.lbHunspellAffixFile.Text = "Hunspell affix file (UTF-8):";
            // 
            // btHunspellDictionary
            // 
            this.btHunspellDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btHunspellDictionary.Location = new System.Drawing.Point(641, 32);
            this.btHunspellDictionary.Name = "btHunspellDictionary";
            this.btHunspellDictionary.Size = new System.Drawing.Size(31, 21);
            this.btHunspellDictionary.TabIndex = 47;
            this.btHunspellDictionary.Text = "...";
            this.btHunspellDictionary.UseVisualStyleBackColor = true;
            this.btHunspellDictionary.Click += new System.EventHandler(this.btHunspellDictionary_Click);
            // 
            // tbHunspellDictionary
            // 
            this.tbHunspellDictionary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbHunspellDictionary.Location = new System.Drawing.Point(14, 33);
            this.tbHunspellDictionary.Name = "tbHunspellDictionary";
            this.tbHunspellDictionary.Size = new System.Drawing.Size(621, 20);
            this.tbHunspellDictionary.TabIndex = 46;
            // 
            // lbHunspellDictionary
            // 
            this.lbHunspellDictionary.AutoSize = true;
            this.lbHunspellDictionary.Location = new System.Drawing.Point(11, 10);
            this.lbHunspellDictionary.Name = "lbHunspellDictionary";
            this.lbHunspellDictionary.Size = new System.Drawing.Size(154, 13);
            this.lbHunspellDictionary.TabIndex = 45;
            this.lbHunspellDictionary.Text = "Hunspell dictionary file (UTF-8):";
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
            // odAffixFile
            // 
            this.odAffixFile.Filter = "Hunspell affix dictionary description file|*.aff";
            // 
            // odDictionaryFile
            // 
            this.odDictionaryFile.Filter = "Hunspell dictionary file|*.dic";
            // 
            // fbFolder
            // 
            this.fbFolder.UseDescriptionForTitle = true;
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
            this.tabSpelling.ResumeLayout(false);
            this.tabSpelling.PerformLayout();
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
        private System.Windows.Forms.Label lbEditorImageGlyphColor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbSelectLanguageDescription;
        private System.Windows.Forms.ComboBox cmbSelectLanguageValue;
        private Manina.Windows.Forms.Tab tabSpelling;
        private System.Windows.Forms.ComboBox cmbInstalledDictionaries;
        private System.Windows.Forms.Label lbInstalledDictionaries;
        private System.Windows.Forms.Button btDictionaryPath;
        private System.Windows.Forms.TextBox tbDictionaryPath;
        private System.Windows.Forms.Label lbDictionaryPath;
        private System.Windows.Forms.Button btHunspellAffixFile;
        private System.Windows.Forms.TextBox tbHunspellAffixFile;
        private System.Windows.Forms.Label lbHunspellAffixFile;
        private System.Windows.Forms.Button btHunspellDictionary;
        private System.Windows.Forms.TextBox tbHunspellDictionary;
        private System.Windows.Forms.Label lbHunspellDictionary;
        private System.Windows.Forms.OpenFileDialog odAffixFile;
        private System.Windows.Forms.OpenFileDialog odDictionaryFile;
        private Ookii.Dialogs.WinForms.VistaFolderBrowserDialog fbFolder;
        private System.Windows.Forms.Button btClearUserDictionary;
        private System.Windows.Forms.Button btEditorImageGlyphColor;
        private System.Windows.Forms.Button btEditorImageForeColor;
        private System.Windows.Forms.Button btButtonColorRestoreDefaults;
    }
}