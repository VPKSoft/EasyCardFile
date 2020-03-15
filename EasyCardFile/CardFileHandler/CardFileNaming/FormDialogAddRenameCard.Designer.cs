namespace EasyCardFile.CardFileHandler.CardFileNaming
{
    partial class FormDialogAddRenameCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogAddRenameCard));
            this.tbCardName = new System.Windows.Forms.TextBox();
            this.lbCardName = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.cmbCardType = new System.Windows.Forms.ComboBox();
            this.lbCardType = new System.Windows.Forms.Label();
            this.pbGenerateName = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerateName)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCardName
            // 
            this.tbCardName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCardName.Location = new System.Drawing.Point(124, 12);
            this.tbCardName.Name = "tbCardName";
            this.tbCardName.Size = new System.Drawing.Size(375, 20);
            this.tbCardName.TabIndex = 0;
            this.tbCardName.TextChanged += new System.EventHandler(this.tbCardName_TextChanged);
            // 
            // lbCardName
            // 
            this.lbCardName.AutoSize = true;
            this.lbCardName.Location = new System.Drawing.Point(12, 15);
            this.lbCardName.Name = "lbCardName";
            this.lbCardName.Size = new System.Drawing.Size(61, 13);
            this.lbCardName.TabIndex = 1;
            this.lbCardName.Text = "Card name:";
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(447, 65);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 31;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(366, 65);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 30;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // cmbCardType
            // 
            this.cmbCardType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCardType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbCardType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCardType.FormattingEnabled = true;
            this.cmbCardType.Location = new System.Drawing.Point(124, 38);
            this.cmbCardType.Name = "cmbCardType";
            this.cmbCardType.Size = new System.Drawing.Size(398, 21);
            this.cmbCardType.TabIndex = 32;
            this.cmbCardType.SelectedIndexChanged += new System.EventHandler(this.cmbCardType_SelectedIndexChanged);
            // 
            // lbCardType
            // 
            this.lbCardType.AutoSize = true;
            this.lbCardType.Location = new System.Drawing.Point(12, 41);
            this.lbCardType.Name = "lbCardType";
            this.lbCardType.Size = new System.Drawing.Size(55, 13);
            this.lbCardType.TabIndex = 33;
            this.lbCardType.Text = "Card type:";
            // 
            // pbGenerateName
            // 
            this.pbGenerateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbGenerateName.Image = global::EasyCardFile.Properties.Resources.view_refresh_5;
            this.pbGenerateName.Location = new System.Drawing.Point(502, 12);
            this.pbGenerateName.Margin = new System.Windows.Forms.Padding(0);
            this.pbGenerateName.Name = "pbGenerateName";
            this.pbGenerateName.Size = new System.Drawing.Size(20, 20);
            this.pbGenerateName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbGenerateName.TabIndex = 34;
            this.pbGenerateName.TabStop = false;
            this.pbGenerateName.Click += new System.EventHandler(this.pbGenerateName_Click);
            // 
            // FormDialogAddRenameCard
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(534, 100);
            this.Controls.Add(this.pbGenerateName);
            this.Controls.Add(this.lbCardType);
            this.Controls.Add(this.cmbCardType);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lbCardName);
            this.Controls.Add(this.tbCardName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogAddRenameCard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter a name for the card";
            this.Shown += new System.EventHandler(this.FormDialogAddRenameCard_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbGenerateName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbCardName;
        private System.Windows.Forms.Label lbCardName;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.ComboBox cmbCardType;
        private System.Windows.Forms.Label lbCardType;
        private System.Windows.Forms.PictureBox pbGenerateName;
    }
}