namespace EasyCardFile.CardFileHandler.CardFileNaming
{
    partial class FormDialogCardFileNaming
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogCardFileNaming));
            this.lbCardNamingInstruction = new System.Windows.Forms.Label();
            this.tbCardNamingInstruction = new System.Windows.Forms.TextBox();
            this.tbNamingInstructionSample = new System.Windows.Forms.TextBox();
            this.lbNamingInstructionSample = new System.Windows.Forms.Label();
            this.lbIUsageList = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNamingNumbers = new System.Windows.Forms.Label();
            this.lbNamingCommonDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbNamingCommonTime = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbAddCustomFormat = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbAddReadManualDateTime = new System.Windows.Forms.Label();
            this.cmbDateTimeCustomFormats = new System.Windows.Forms.ComboBox();
            this.nudNamingNumbers = new System.Windows.Forms.NumericUpDown();
            this.lbTestNumber = new System.Windows.Forms.Label();
            this.cbLongDate = new System.Windows.Forms.CheckBox();
            this.cbLongTime = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNamingCommonDateTime = new System.Windows.Forms.Label();
            this.cbLongDateTime = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lbFormatInstruction = new System.Windows.Forms.Label();
            this.btnClearNaming = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNamingNumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCardNamingInstruction
            // 
            this.lbCardNamingInstruction.AutoSize = true;
            this.lbCardNamingInstruction.Location = new System.Drawing.Point(12, 9);
            this.lbCardNamingInstruction.Name = "lbCardNamingInstruction";
            this.lbCardNamingInstruction.Size = new System.Drawing.Size(117, 13);
            this.lbCardNamingInstruction.TabIndex = 0;
            this.lbCardNamingInstruction.Text = "Card naming instruction";
            // 
            // tbCardNamingInstruction
            // 
            this.tbCardNamingInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCardNamingInstruction.Location = new System.Drawing.Point(12, 25);
            this.tbCardNamingInstruction.Name = "tbCardNamingInstruction";
            this.tbCardNamingInstruction.Size = new System.Drawing.Size(523, 20);
            this.tbCardNamingInstruction.TabIndex = 1;
            this.tbCardNamingInstruction.TextChanged += new System.EventHandler(this.cardNamingInstruction_Changed);
            // 
            // tbNamingInstructionSample
            // 
            this.tbNamingInstructionSample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNamingInstructionSample.Location = new System.Drawing.Point(12, 64);
            this.tbNamingInstructionSample.Name = "tbNamingInstructionSample";
            this.tbNamingInstructionSample.ReadOnly = true;
            this.tbNamingInstructionSample.Size = new System.Drawing.Size(523, 20);
            this.tbNamingInstructionSample.TabIndex = 2;
            // 
            // lbNamingInstructionSample
            // 
            this.lbNamingInstructionSample.AutoSize = true;
            this.lbNamingInstructionSample.Location = new System.Drawing.Point(12, 48);
            this.lbNamingInstructionSample.Name = "lbNamingInstructionSample";
            this.lbNamingInstructionSample.Size = new System.Drawing.Size(42, 13);
            this.lbNamingInstructionSample.TabIndex = 3;
            this.lbNamingInstructionSample.Text = "Sample";
            // 
            // lbIUsageList
            // 
            this.lbIUsageList.AutoSize = true;
            this.lbIUsageList.Location = new System.Drawing.Point(9, 98);
            this.lbIUsageList.Name = "lbIUsageList";
            this.lbIUsageList.Size = new System.Drawing.Size(38, 13);
            this.lbIUsageList.TabIndex = 4;
            this.lbIUsageList.Text = "Usage";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "•";
            // 
            // lbNamingNumbers
            // 
            this.lbNamingNumbers.AutoSize = true;
            this.lbNamingNumbers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNamingNumbers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamingNumbers.Location = new System.Drawing.Point(31, 136);
            this.lbNamingNumbers.Name = "lbNamingNumbers";
            this.lbNamingNumbers.Size = new System.Drawing.Size(417, 13);
            this.lbNamingNumbers.TabIndex = 6;
            this.lbNamingNumbers.Text = "use consecutive number signs (#) to indicate an increasing number padded with zer" +
    "oes";
            this.lbNamingNumbers.Click += new System.EventHandler(this.commonDateTime_Click);
            this.lbNamingNumbers.DoubleClick += new System.EventHandler(this.commonDateTime_Click);
            // 
            // lbNamingCommonDate
            // 
            this.lbNamingCommonDate.AutoSize = true;
            this.lbNamingCommonDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNamingCommonDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamingCommonDate.Location = new System.Drawing.Point(31, 175);
            this.lbNamingCommonDate.Name = "lbNamingCommonDate";
            this.lbNamingCommonDate.Size = new System.Drawing.Size(277, 13);
            this.lbNamingCommonDate.TabIndex = 7;
            this.lbNamingCommonDate.Text = "click to add common date format using the system culture";
            this.lbNamingCommonDate.Click += new System.EventHandler(this.commonDateTime_Click);
            this.lbNamingCommonDate.DoubleClick += new System.EventHandler(this.commonDateTime_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "•";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "•";
            // 
            // lbNamingCommonTime
            // 
            this.lbNamingCommonTime.AutoSize = true;
            this.lbNamingCommonTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNamingCommonTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamingCommonTime.Location = new System.Drawing.Point(31, 195);
            this.lbNamingCommonTime.Name = "lbNamingCommonTime";
            this.lbNamingCommonTime.Size = new System.Drawing.Size(275, 13);
            this.lbNamingCommonTime.TabIndex = 9;
            this.lbNamingCommonTime.Text = "click to add common time format using the system culture";
            this.lbNamingCommonTime.Click += new System.EventHandler(this.commonDateTime_Click);
            this.lbNamingCommonTime.DoubleClick += new System.EventHandler(this.commonDateTime_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "•";
            // 
            // lbAddCustomFormat
            // 
            this.lbAddCustomFormat.AutoSize = true;
            this.lbAddCustomFormat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAddCustomFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddCustomFormat.Location = new System.Drawing.Point(31, 235);
            this.lbAddCustomFormat.Name = "lbAddCustomFormat";
            this.lbAddCustomFormat.Size = new System.Drawing.Size(279, 13);
            this.lbAddCustomFormat.TabIndex = 13;
            this.lbAddCustomFormat.Text = "click to add a selected custom format from the combo box";
            this.lbAddCustomFormat.Click += new System.EventHandler(this.lbAddCustomFormat_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "•";
            // 
            // lbAddReadManualDateTime
            // 
            this.lbAddReadManualDateTime.AutoSize = true;
            this.lbAddReadManualDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbAddReadManualDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddReadManualDateTime.ForeColor = System.Drawing.Color.Blue;
            this.lbAddReadManualDateTime.Location = new System.Drawing.Point(31, 275);
            this.lbAddReadManualDateTime.Name = "lbAddReadManualDateTime";
            this.lbAddReadManualDateTime.Size = new System.Drawing.Size(209, 39);
            this.lbAddReadManualDateTime.TabIndex = 15;
            this.lbAddReadManualDateTime.Text = "for more information for an advanced user, \r\nplease read the documentation \r\nfrom" +
    " the Microsoft web site";
            this.lbAddReadManualDateTime.Click += new System.EventHandler(this.lbAddReadManualDateTime_Click);
            // 
            // cmbDateTimeCustomFormats
            // 
            this.cmbDateTimeCustomFormats.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbDateTimeCustomFormats.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDateTimeCustomFormats.FormattingEnabled = true;
            this.cmbDateTimeCustomFormats.Items.AddRange(new object[] {
            "d",
            "dd",
            "ddd",
            "dddd",
            "f",
            "ff",
            "fff",
            "ffff",
            "fffff",
            "ffffff",
            "fffffff",
            "g",
            "gg",
            "h",
            "hh",
            "m",
            "mm",
            "s",
            "ss",
            "t",
            "tt",
            "y",
            "yy",
            "yyy",
            "yyyy",
            "yyyyy",
            "z",
            "zz",
            "zzz",
            "F",
            "FF",
            "FFF",
            "FFFF",
            "FFFFF",
            "FFFFFF",
            "FFFFFFF",
            "H",
            "HH",
            "K",
            "M",
            "MM",
            "MMM",
            "MMMM"});
            this.cmbDateTimeCustomFormats.Location = new System.Drawing.Point(34, 251);
            this.cmbDateTimeCustomFormats.Name = "cmbDateTimeCustomFormats";
            this.cmbDateTimeCustomFormats.Size = new System.Drawing.Size(144, 21);
            this.cmbDateTimeCustomFormats.TabIndex = 17;
            this.cmbDateTimeCustomFormats.Text = "yyyy";
            // 
            // nudNamingNumbers
            // 
            this.nudNamingNumbers.Location = new System.Drawing.Point(188, 152);
            this.nudNamingNumbers.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.nudNamingNumbers.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.nudNamingNumbers.Name = "nudNamingNumbers";
            this.nudNamingNumbers.Size = new System.Drawing.Size(83, 20);
            this.nudNamingNumbers.TabIndex = 18;
            this.nudNamingNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudNamingNumbers.Value = new decimal(new int[] {
            123,
            0,
            0,
            0});
            this.nudNamingNumbers.ValueChanged += new System.EventHandler(this.cardNamingInstruction_Changed);
            // 
            // lbTestNumber
            // 
            this.lbTestNumber.AutoSize = true;
            this.lbTestNumber.Location = new System.Drawing.Point(31, 154);
            this.lbTestNumber.Name = "lbTestNumber";
            this.lbTestNumber.Size = new System.Drawing.Size(69, 13);
            this.lbTestNumber.TabIndex = 19;
            this.lbTestNumber.Text = "Test number:";
            // 
            // cbLongDate
            // 
            this.cbLongDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLongDate.AutoSize = true;
            this.cbLongDate.Location = new System.Drawing.Point(449, 174);
            this.cbLongDate.Name = "cbLongDate";
            this.cbLongDate.Size = new System.Drawing.Size(46, 17);
            this.cbLongDate.TabIndex = 20;
            this.cbLongDate.Text = "long";
            this.cbLongDate.UseVisualStyleBackColor = true;
            // 
            // cbLongTime
            // 
            this.cbLongTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLongTime.AutoSize = true;
            this.cbLongTime.Location = new System.Drawing.Point(449, 194);
            this.cbLongTime.Name = "cbLongTime";
            this.cbLongTime.Size = new System.Drawing.Size(46, 17);
            this.cbLongTime.TabIndex = 21;
            this.cbLongTime.Text = "long";
            this.cbLongTime.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "•";
            // 
            // lbNamingCommonDateTime
            // 
            this.lbNamingCommonDateTime.AutoSize = true;
            this.lbNamingCommonDateTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNamingCommonDateTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNamingCommonDateTime.Location = new System.Drawing.Point(31, 215);
            this.lbNamingCommonDateTime.Name = "lbNamingCommonDateTime";
            this.lbNamingCommonDateTime.Size = new System.Drawing.Size(344, 13);
            this.lbNamingCommonDateTime.TabIndex = 22;
            this.lbNamingCommonDateTime.Text = "click to add both common date and time format using the system culture";
            this.lbNamingCommonDateTime.Click += new System.EventHandler(this.commonDateTime_Click);
            this.lbNamingCommonDateTime.DoubleClick += new System.EventHandler(this.commonDateTime_Click);
            // 
            // cbLongDateTime
            // 
            this.cbLongDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLongDateTime.AutoSize = true;
            this.cbLongDateTime.Location = new System.Drawing.Point(449, 214);
            this.cbLongDateTime.Name = "cbLongDateTime";
            this.cbLongDateTime.Size = new System.Drawing.Size(46, 17);
            this.cbLongDateTime.TabIndex = 24;
            this.cbLongDateTime.Text = "long";
            this.cbLongDateTime.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "•";
            // 
            // lbFormatInstruction
            // 
            this.lbFormatInstruction.AutoSize = true;
            this.lbFormatInstruction.ForeColor = System.Drawing.Color.Blue;
            this.lbFormatInstruction.Location = new System.Drawing.Point(31, 116);
            this.lbFormatInstruction.Name = "lbFormatInstruction";
            this.lbFormatInstruction.Size = new System.Drawing.Size(237, 13);
            this.lbFormatInstruction.TabIndex = 26;
            this.lbFormatInstruction.Text = "use square-brackets [ and ] to indicate formatting";
            // 
            // btnClearNaming
            // 
            this.btnClearNaming.Location = new System.Drawing.Point(12, 335);
            this.btnClearNaming.Name = "btnClearNaming";
            this.btnClearNaming.Size = new System.Drawing.Size(75, 23);
            this.btnClearNaming.TabIndex = 27;
            this.btnClearNaming.Text = "Clear";
            this.btnClearNaming.UseVisualStyleBackColor = true;
            this.btnClearNaming.Click += new System.EventHandler(this.btnClearNaming_Click);
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOk.Location = new System.Drawing.Point(379, 335);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 28;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(460, 335);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 29;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // FormDialogCardFileNaming
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(547, 370);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.btnClearNaming);
            this.Controls.Add(this.lbFormatInstruction);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbLongDateTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbNamingCommonDateTime);
            this.Controls.Add(this.cbLongTime);
            this.Controls.Add(this.cbLongDate);
            this.Controls.Add(this.lbTestNumber);
            this.Controls.Add(this.nudNamingNumbers);
            this.Controls.Add(this.cmbDateTimeCustomFormats);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbAddReadManualDateTime);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbAddCustomFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbNamingCommonTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbNamingCommonDate);
            this.Controls.Add(this.lbNamingNumbers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbIUsageList);
            this.Controls.Add(this.lbNamingInstructionSample);
            this.Controls.Add(this.tbNamingInstructionSample);
            this.Controls.Add(this.tbCardNamingInstruction);
            this.Controls.Add(this.lbCardNamingInstruction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogCardFileNaming";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Card naming";
            ((System.ComponentModel.ISupportInitialize)(this.nudNamingNumbers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCardNamingInstruction;
        private System.Windows.Forms.TextBox tbCardNamingInstruction;
        private System.Windows.Forms.TextBox tbNamingInstructionSample;
        private System.Windows.Forms.Label lbNamingInstructionSample;
        private System.Windows.Forms.Label lbIUsageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbNamingNumbers;
        private System.Windows.Forms.Label lbNamingCommonDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbNamingCommonTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbAddCustomFormat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbAddReadManualDateTime;
        private System.Windows.Forms.ComboBox cmbDateTimeCustomFormats;
        private System.Windows.Forms.NumericUpDown nudNamingNumbers;
        private System.Windows.Forms.Label lbTestNumber;
        private System.Windows.Forms.CheckBox cbLongDate;
        private System.Windows.Forms.CheckBox cbLongTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNamingCommonDateTime;
        private System.Windows.Forms.CheckBox cbLongDateTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbFormatInstruction;
        private System.Windows.Forms.Button btnClearNaming;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
    }
}