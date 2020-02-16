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
            this.btOK = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.cbAutoSaveExistingCardFilesAppClose = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbRestorePreviousSession = new System.Windows.Forms.CheckBox();
            this.tcMain.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabSettingsGeneral);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(683, 312);
            this.tcMain.TabIndex = 0;
            this.tcMain.Tabs.Add(this.tabSettingsGeneral);
            // 
            // tabSettingsGeneral
            // 
            this.tabSettingsGeneral.Controls.Add(this.cbRestorePreviousSession);
            this.tabSettingsGeneral.Controls.Add(this.textBox2);
            this.tabSettingsGeneral.Controls.Add(this.label2);
            this.tabSettingsGeneral.Controls.Add(this.cbAutoSaveExistingCardFilesAppClose);
            this.tabSettingsGeneral.Location = new System.Drawing.Point(1, 21);
            this.tabSettingsGeneral.Name = "tabSettingsGeneral";
            this.tabSettingsGeneral.Size = new System.Drawing.Size(681, 290);
            this.tabSettingsGeneral.Text = "General";
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(514, 40);
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
    }
}