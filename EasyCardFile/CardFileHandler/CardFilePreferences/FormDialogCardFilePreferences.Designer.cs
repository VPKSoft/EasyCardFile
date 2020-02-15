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
            this.dgvCardTypes = new System.Windows.Forms.DataGridView();
            this.colDefault = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsbCardTypes = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.lbRowErrorText = new System.Windows.Forms.Label();
            this.tbbCardNamingInstruction = new EasyCardFile.UtilityClasses.ProjectControls.TextBoxButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardTypes)).BeginInit();
            this.tsbCardTypes.SuspendLayout();
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
            this.tbCardFileName.Location = new System.Drawing.Point(170, 12);
            this.tbCardFileName.Name = "tbCardFileName";
            this.tbCardFileName.Size = new System.Drawing.Size(369, 20);
            this.tbCardFileName.TabIndex = 1;
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
            this.cbEncryption.CheckedChanged += new System.EventHandler(this.cbEncryption_CheckedChanged);
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
            // dgvCardTypes
            // 
            this.dgvCardTypes.AllowUserToAddRows = false;
            this.dgvCardTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCardTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDefault,
            this.colName});
            this.dgvCardTypes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCardTypes.Location = new System.Drawing.Point(15, 154);
            this.dgvCardTypes.Name = "dgvCardTypes";
            this.dgvCardTypes.RowHeadersVisible = false;
            this.dgvCardTypes.Size = new System.Drawing.Size(484, 150);
            this.dgvCardTypes.TabIndex = 13;
            this.dgvCardTypes.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCardTypes_CellValidating);
            // 
            // colDefault
            // 
            this.colDefault.HeaderText = "Default";
            this.colDefault.Name = "colDefault";
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.Width = 390;
            // 
            // tsbCardTypes
            // 
            this.tsbCardTypes.CanOverflow = false;
            this.tsbCardTypes.Dock = System.Windows.Forms.DockStyle.None;
            this.tsbCardTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.tsbCardTypes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsbCardTypes.Location = new System.Drawing.Point(507, 154);
            this.tsbCardTypes.Name = "tsbCardTypes";
            this.tsbCardTypes.ShowItemToolTips = false;
            this.tsbCardTypes.Size = new System.Drawing.Size(24, 57);
            this.tsbCardTypes.TabIndex = 14;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::EasyCardFile.Properties.Resources.edit_add_2;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::EasyCardFile.Properties.Resources.edit_delete_6;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(22, 20);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // lbRowErrorText
            // 
            this.lbRowErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRowErrorText.ForeColor = System.Drawing.Color.Red;
            this.lbRowErrorText.Location = new System.Drawing.Point(12, 307);
            this.lbRowErrorText.Name = "lbRowErrorText";
            this.lbRowErrorText.Size = new System.Drawing.Size(487, 39);
            this.lbRowErrorText.TabIndex = 15;
            // 
            // tbbCardNamingInstruction
            // 
            this.tbbCardNamingInstruction.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbCardNamingInstruction.ButtonForeColor = System.Drawing.SystemColors.ControlText;
            this.tbbCardNamingInstruction.ButtonImage = global::EasyCardFile.Properties.Resources.textfield_rename;
            this.tbbCardNamingInstruction.ButtonImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tbbCardNamingInstruction.ButtonText = "Configure";
            this.tbbCardNamingInstruction.ButtonWidth = 101;
            this.tbbCardNamingInstruction.Location = new System.Drawing.Point(170, 86);
            this.tbbCardNamingInstruction.Name = "tbbCardNamingInstruction";
            this.tbbCardNamingInstruction.SelectedText = "";
            this.tbbCardNamingInstruction.Size = new System.Drawing.Size(369, 20);
            this.tbbCardNamingInstruction.TabIndex = 8;
            this.tbbCardNamingInstruction.Click += new System.EventHandler(this.tbbCardNamingInstruction_Click);
            // 
            // FormDialogCardFilePreferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbRowErrorText);
            this.Controls.Add(this.tsbCardTypes);
            this.Controls.Add(this.dgvCardTypes);
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
            this.Text = "FormDialogCardFilePreferences";
            this.Shown += new System.EventHandler(this.FormDialogCardFilePreferences_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCardTypes)).EndInit();
            this.tsbCardTypes.ResumeLayout(false);
            this.tsbCardTypes.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvCardTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.ToolStrip tsbCardTypes;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.Label lbRowErrorText;
    }
}