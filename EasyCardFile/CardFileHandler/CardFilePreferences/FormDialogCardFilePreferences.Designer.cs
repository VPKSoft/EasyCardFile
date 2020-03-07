namespace EasyCardFile.CardFileHandler.CardFilePreferences
{
    partial class FormDialogCardFilePreferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogCardFilePreferences));
            this.lbCardFileName = new System.Windows.Forms.Label();
            this.tbCardFileName = new System.Windows.Forms.TextBox();
            this.cbEncryption = new System.Windows.Forms.CheckBox();
            this.cbCompression = new System.Windows.Forms.CheckBox();
            this.lbCardNamingInstruction = new System.Windows.Forms.Label();
            this.cbCardsDropBetween = new System.Windows.Forms.CheckBox();
            this.lbCardTypes = new System.Windows.Forms.Label();
            this.tsbCardTypes = new System.Windows.Forms.ToolStrip();
            this.tsbAddCardType = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveCardType = new System.Windows.Forms.ToolStripButton();
            this.tsbRename = new System.Windows.Forms.ToolStripButton();
            this.tsbTypeSpecificCardNaming = new System.Windows.Forms.ToolStripButton();
            this.tsbUndo = new System.Windows.Forms.ToolStripButton();
            this.lbRowErrorText = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.pnChangePassword = new System.Windows.Forms.Panel();
            this.pbChangePassword = new System.Windows.Forms.PictureBox();
            this.lbChangePassword = new System.Windows.Forms.Label();
            this.clbCardTypes = new EasyCardFile.UtilityClasses.ProjectControls.RefreshCheckListBox();
            this.tbbCardNamingInstruction = new EasyCardFile.UtilityClasses.ProjectControls.TextBoxButton();
            this.tsbCardTypes.SuspendLayout();
            this.pnChangePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChangePassword)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCardFileName
            // 
            this.lbCardFileName.AutoSize = true;
            this.lbCardFileName.Location = new System.Drawing.Point(12, 15);
            this.lbCardFileName.Name = "lbCardFileName";
            this.lbCardFileName.Size = new System.Drawing.Size(108, 13);
            this.lbCardFileName.TabIndex = 0;
            this.lbCardFileName.Text = "Name of the card file:";
            // 
            // tbCardFileName
            // 
            this.tbCardFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCardFileName.Location = new System.Drawing.Point(170, 12);
            this.tbCardFileName.Name = "tbCardFileName";
            this.tbCardFileName.Size = new System.Drawing.Size(377, 20);
            this.tbCardFileName.TabIndex = 1;
            this.tbCardFileName.TextChanged += new System.EventHandler(this.tbCardFileName_TextChanged);
            // 
            // cbEncryption
            // 
            this.cbEncryption.AutoSize = true;
            this.cbEncryption.Location = new System.Drawing.Point(15, 40);
            this.cbEncryption.Name = "cbEncryption";
            this.cbEncryption.Size = new System.Drawing.Size(120, 17);
            this.cbEncryption.TabIndex = 2;
            this.cbEncryption.Text = "Encrypt the card file";
            this.cbEncryption.UseVisualStyleBackColor = true;
            this.cbEncryption.CheckedChanged += new System.EventHandler(this.common_ValueChanged);
            // 
            // cbCompression
            // 
            this.cbCompression.AutoSize = true;
            this.cbCompression.Location = new System.Drawing.Point(15, 66);
            this.cbCompression.Name = "cbCompression";
            this.cbCompression.Size = new System.Drawing.Size(130, 17);
            this.cbCompression.TabIndex = 4;
            this.cbCompression.Text = "Compress the card file";
            this.cbCompression.UseVisualStyleBackColor = true;
            this.cbCompression.CheckedChanged += new System.EventHandler(this.common_ValueChanged);
            // 
            // lbCardNamingInstruction
            // 
            this.lbCardNamingInstruction.AutoSize = true;
            this.lbCardNamingInstruction.Location = new System.Drawing.Point(12, 93);
            this.lbCardNamingInstruction.Name = "lbCardNamingInstruction";
            this.lbCardNamingInstruction.Size = new System.Drawing.Size(125, 13);
            this.lbCardNamingInstruction.TabIndex = 6;
            this.lbCardNamingInstruction.Text = "Card naming instructions:";
            // 
            // cbCardsDropBetween
            // 
            this.cbCardsDropBetween.AutoSize = true;
            this.cbCardsDropBetween.Location = new System.Drawing.Point(170, 112);
            this.cbCardsDropBetween.Name = "cbCardsDropBetween";
            this.cbCardsDropBetween.Size = new System.Drawing.Size(206, 17);
            this.cbCardsDropBetween.TabIndex = 9;
            this.cbCardsDropBetween.Text = "Allow name generation between cards";
            this.cbCardsDropBetween.UseVisualStyleBackColor = true;
            this.cbCardsDropBetween.CheckedChanged += new System.EventHandler(this.common_ValueChanged);
            // 
            // lbCardTypes
            // 
            this.lbCardTypes.AutoSize = true;
            this.lbCardTypes.Location = new System.Drawing.Point(12, 138);
            this.lbCardTypes.Name = "lbCardTypes";
            this.lbCardTypes.Size = new System.Drawing.Size(60, 13);
            this.lbCardTypes.TabIndex = 11;
            this.lbCardTypes.Text = "Card types:";
            // 
            // tsbCardTypes
            // 
            this.tsbCardTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsbCardTypes.CanOverflow = false;
            this.tsbCardTypes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsbCardTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddCardType,
            this.tsbRemoveCardType,
            this.tsbRename,
            this.tsbTypeSpecificCardNaming,
            this.tsbUndo});
            this.tsbCardTypes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsbCardTypes.Location = new System.Drawing.Point(526, 154);
            this.tsbCardTypes.Name = "tsbCardTypes";
            this.tsbCardTypes.ShowItemToolTips = false;
            this.tsbCardTypes.Size = new System.Drawing.Size(24, 126);
            this.tsbCardTypes.TabIndex = 14;
            // 
            // tsbAddCardType
            // 
            this.tsbAddCardType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddCardType.Image = global::EasyCardFile.Properties.Resources.edit_add_2;
            this.tsbAddCardType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddCardType.Name = "tsbAddCardType";
            this.tsbAddCardType.Size = new System.Drawing.Size(22, 20);
            this.tsbAddCardType.Text = "toolStripButton1";
            this.tsbAddCardType.Click += new System.EventHandler(this.tsbAddCardType_Click);
            // 
            // tsbRemoveCardType
            // 
            this.tsbRemoveCardType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveCardType.Image = global::EasyCardFile.Properties.Resources.edit_delete_6;
            this.tsbRemoveCardType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveCardType.Name = "tsbRemoveCardType";
            this.tsbRemoveCardType.Size = new System.Drawing.Size(22, 20);
            this.tsbRemoveCardType.Text = "Delete card type";
            this.tsbRemoveCardType.Click += new System.EventHandler(this.tsbRemoveCardType_Click);
            // 
            // tsbRename
            // 
            this.tsbRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRename.Image = global::EasyCardFile.Properties.Resources.Modify;
            this.tsbRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRename.Name = "tsbRename";
            this.tsbRename.Size = new System.Drawing.Size(22, 20);
            this.tsbRename.Text = "Rename card type";
            this.tsbRename.Click += new System.EventHandler(this.tsbRename_Click);
            // 
            // tsbTypeSpecificCardNaming
            // 
            this.tsbTypeSpecificCardNaming.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTypeSpecificCardNaming.Image = global::EasyCardFile.Properties.Resources.textfield_rename;
            this.tsbTypeSpecificCardNaming.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTypeSpecificCardNaming.Name = "tsbTypeSpecificCardNaming";
            this.tsbTypeSpecificCardNaming.Size = new System.Drawing.Size(22, 20);
            this.tsbTypeSpecificCardNaming.Text = "Set card type specific naming instructions";
            this.tsbTypeSpecificCardNaming.Click += new System.EventHandler(this.tsbTypeSpecificCardNaming_Click);
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Image = global::EasyCardFile.Properties.Resources.Undo;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(22, 20);
            this.tsbUndo.Text = "Undo card type changes";
            this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
            // 
            // lbRowErrorText
            // 
            this.lbRowErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRowErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRowErrorText.ForeColor = System.Drawing.Color.Red;
            this.lbRowErrorText.Location = new System.Drawing.Point(12, 330);
            this.lbRowErrorText.Name = "lbRowErrorText";
            this.lbRowErrorText.Size = new System.Drawing.Size(373, 26);
            this.lbRowErrorText.TabIndex = 15;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(472, 330);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 31;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(391, 330);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 30;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // pnChangePassword
            // 
            this.pnChangePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnChangePassword.Controls.Add(this.pbChangePassword);
            this.pnChangePassword.Controls.Add(this.lbChangePassword);
            this.pnChangePassword.Location = new System.Drawing.Point(343, 43);
            this.pnChangePassword.Margin = new System.Windows.Forms.Padding(0);
            this.pnChangePassword.Name = "pnChangePassword";
            this.pnChangePassword.Size = new System.Drawing.Size(204, 20);
            this.pnChangePassword.TabIndex = 32;
            this.pnChangePassword.Click += new System.EventHandler(this.pnChangePassword_Click);
            // 
            // pbChangePassword
            // 
            this.pbChangePassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbChangePassword.Image = global::EasyCardFile.Properties.Resources.system_password_2;
            this.pbChangePassword.Location = new System.Drawing.Point(182, 0);
            this.pbChangePassword.Margin = new System.Windows.Forms.Padding(0);
            this.pbChangePassword.Name = "pbChangePassword";
            this.pbChangePassword.Size = new System.Drawing.Size(20, 18);
            this.pbChangePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbChangePassword.TabIndex = 1;
            this.pbChangePassword.TabStop = false;
            this.pbChangePassword.Click += new System.EventHandler(this.pnChangePassword_Click);
            // 
            // lbChangePassword
            // 
            this.lbChangePassword.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbChangePassword.Location = new System.Drawing.Point(0, 0);
            this.lbChangePassword.Name = "lbChangePassword";
            this.lbChangePassword.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.lbChangePassword.Size = new System.Drawing.Size(179, 18);
            this.lbChangePassword.TabIndex = 0;
            this.lbChangePassword.Text = "Change password";
            this.lbChangePassword.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbChangePassword.Click += new System.EventHandler(this.pnChangePassword_Click);
            // 
            // clbCardTypes
            // 
            this.clbCardTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCardTypes.FormattingEnabled = true;
            this.clbCardTypes.Location = new System.Drawing.Point(15, 154);
            this.clbCardTypes.Name = "clbCardTypes";
            this.clbCardTypes.Size = new System.Drawing.Size(498, 169);
            this.clbCardTypes.TabIndex = 33;
            this.clbCardTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCardTypes_ItemCheck);
            this.clbCardTypes.SelectedValueChanged += new System.EventHandler(this.clbCardTypes_SelectedValueChanged);
            // 
            // tbbCardNamingInstruction
            // 
            this.tbbCardNamingInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbbCardNamingInstruction.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbCardNamingInstruction.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.tbbCardNamingInstruction.ButtonImage = global::EasyCardFile.Properties.Resources.textfield_rename;
            this.tbbCardNamingInstruction.ButtonImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbbCardNamingInstruction.ButtonText = "Configure";
            this.tbbCardNamingInstruction.ButtonWidth = 101;
            this.tbbCardNamingInstruction.Location = new System.Drawing.Point(170, 86);
            this.tbbCardNamingInstruction.Name = "tbbCardNamingInstruction";
            this.tbbCardNamingInstruction.SelectedText = "";
            this.tbbCardNamingInstruction.Size = new System.Drawing.Size(377, 20);
            this.tbbCardNamingInstruction.TabIndex = 8;
            this.tbbCardNamingInstruction.TextChanged += new System.EventHandler(this.tbbCardNamingInstruction_TextChanged);
            this.tbbCardNamingInstruction.Click += new System.EventHandler(this.tbbCardNamingInstruction_Click);
            // 
            // FormDialogCardFilePreferences
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(559, 365);
            this.Controls.Add(this.clbCardTypes);
            this.Controls.Add(this.pnChangePassword);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lbRowErrorText);
            this.Controls.Add(this.tsbCardTypes);
            this.Controls.Add(this.lbCardTypes);
            this.Controls.Add(this.cbCardsDropBetween);
            this.Controls.Add(this.tbbCardNamingInstruction);
            this.Controls.Add(this.lbCardNamingInstruction);
            this.Controls.Add(this.cbCompression);
            this.Controls.Add(this.cbEncryption);
            this.Controls.Add(this.tbCardFileName);
            this.Controls.Add(this.lbCardFileName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogCardFilePreferences";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Card file preferences";
            this.Shown += new System.EventHandler(this.FormDialogCardFilePreferences_Shown);
            this.tsbCardTypes.ResumeLayout(false);
            this.tsbCardTypes.PerformLayout();
            this.pnChangePassword.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbChangePassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCardFileName;
        private System.Windows.Forms.TextBox tbCardFileName;
        private System.Windows.Forms.CheckBox cbEncryption;
        private System.Windows.Forms.CheckBox cbCompression;
        private System.Windows.Forms.Label lbCardNamingInstruction;
        private UtilityClasses.ProjectControls.TextBoxButton tbbCardNamingInstruction;
        private System.Windows.Forms.CheckBox cbCardsDropBetween;
        private System.Windows.Forms.Label lbCardTypes;
        private System.Windows.Forms.ToolStrip tsbCardTypes;
        private System.Windows.Forms.ToolStripButton tsbAddCardType;
        private System.Windows.Forms.ToolStripButton tsbRemoveCardType;
        private System.Windows.Forms.Label lbRowErrorText;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Panel pnChangePassword;
        private System.Windows.Forms.Label lbChangePassword;
        private System.Windows.Forms.PictureBox pbChangePassword;
        private EasyCardFile.UtilityClasses.ProjectControls.RefreshCheckListBox clbCardTypes;
        private System.Windows.Forms.ToolStripButton tsbRename;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbTypeSpecificCardNaming;
    }
}