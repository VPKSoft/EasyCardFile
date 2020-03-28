namespace EasyCardFile.UtilityClasses.Miscellaneous.Dialogs
{
    partial class FormDialogSelectImageArea
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDialogSelectImageArea));
            this.iasCartTypeImage = new VPKSoft.ImageAreaSelector.ImageAreaSelector();
            this.odImage = new System.Windows.Forms.OpenFileDialog();
            this.btOpenImage = new System.Windows.Forms.Button();
            this.pnSelectedImageArea = new System.Windows.Forms.Panel();
            this.cbZoomImage = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iasCartTypeImage
            // 
            this.iasCartTypeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iasCartTypeImage.AutoScroll = true;
            this.iasCartTypeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.iasCartTypeImage.Location = new System.Drawing.Point(12, 41);
            this.iasCartTypeImage.MaximumSelectionSize = new System.Drawing.Size(0, 0);
            this.iasCartTypeImage.MinimumSelectionSize = new System.Drawing.Size(16, 16);
            this.iasCartTypeImage.Name = "iasCartTypeImage";
            this.iasCartTypeImage.RequireRectangle = true;
            this.iasCartTypeImage.SelectImage = null;
            this.iasCartTypeImage.SelectionBoxColor = System.Drawing.Color.Blue;
            this.iasCartTypeImage.Size = new System.Drawing.Size(438, 397);
            this.iasCartTypeImage.TabIndex = 1;
            this.iasCartTypeImage.SelectedImageChanged += new VPKSoft.ImageAreaSelector.ImageAreaSelector.OnSelectedImageChanged(this.iasCartTypeImage_SelectedImageChanged);
            // 
            // odImage
            // 
            this.odImage.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            // 
            // btOpenImage
            // 
            this.btOpenImage.Image = global::EasyCardFile.Properties.Resources.image;
            this.btOpenImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btOpenImage.Location = new System.Drawing.Point(12, 12);
            this.btOpenImage.Name = "btOpenImage";
            this.btOpenImage.Size = new System.Drawing.Size(157, 23);
            this.btOpenImage.TabIndex = 2;
            this.btOpenImage.Text = "Open image";
            this.btOpenImage.UseVisualStyleBackColor = true;
            this.btOpenImage.Click += new System.EventHandler(this.btOpenImage_Click);
            // 
            // pnSelectedImageArea
            // 
            this.pnSelectedImageArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSelectedImageArea.Location = new System.Drawing.Point(456, 41);
            this.pnSelectedImageArea.Name = "pnSelectedImageArea";
            this.pnSelectedImageArea.Size = new System.Drawing.Size(332, 332);
            this.pnSelectedImageArea.TabIndex = 3;
            // 
            // cbZoomImage
            // 
            this.cbZoomImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZoomImage.AutoSize = true;
            this.cbZoomImage.Checked = true;
            this.cbZoomImage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbZoomImage.Location = new System.Drawing.Point(456, 379);
            this.cbZoomImage.Name = "cbZoomImage";
            this.cbZoomImage.Size = new System.Drawing.Size(169, 17);
            this.cbZoomImage.TabIndex = 4;
            this.cbZoomImage.Text = "Zoom the selected image area";
            this.cbZoomImage.UseVisualStyleBackColor = true;
            this.cbZoomImage.CheckedChanged += new System.EventHandler(this.cbZoomImage_CheckedChanged);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(632, 415);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Enabled = false;
            this.btOK.Location = new System.Drawing.Point(713, 415);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 6;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // FormDialogSelectImageArea
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.cbZoomImage);
            this.Controls.Add(this.pnSelectedImageArea);
            this.Controls.Add(this.btOpenImage);
            this.Controls.Add(this.iasCartTypeImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogSelectImageArea";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select an image for the card type";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDialogSelectImageArea_FormClosed);
            this.Shown += new System.EventHandler(this.FormDialogSelectImageArea_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VPKSoft.ImageAreaSelector.ImageAreaSelector iasCartTypeImage;
        private System.Windows.Forms.OpenFileDialog odImage;
        private System.Windows.Forms.Button btOpenImage;
        private System.Windows.Forms.Panel pnSelectedImageArea;
        private System.Windows.Forms.CheckBox cbZoomImage;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button btOK;
    }
}