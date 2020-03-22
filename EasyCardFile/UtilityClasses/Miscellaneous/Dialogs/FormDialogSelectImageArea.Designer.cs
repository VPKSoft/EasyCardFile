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
            this.iasCartTypeImage.MinimumSelectionSize = new System.Drawing.Size(0, 0);
            this.iasCartTypeImage.Name = "iasCartTypeImage";
            this.iasCartTypeImage.RequireRectangle = true;
            this.iasCartTypeImage.SelectImage = null;
            this.iasCartTypeImage.SelectionBoxColor = System.Drawing.Color.Blue;
            this.iasCartTypeImage.Size = new System.Drawing.Size(438, 397);
            this.iasCartTypeImage.TabIndex = 1;
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
            // 
            // pnSelectedImageArea
            // 
            this.pnSelectedImageArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSelectedImageArea.Location = new System.Drawing.Point(588, 41);
            this.pnSelectedImageArea.Name = "pnSelectedImageArea";
            this.pnSelectedImageArea.Size = new System.Drawing.Size(200, 200);
            this.pnSelectedImageArea.TabIndex = 3;
            // 
            // FormDialogSelectImageArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnSelectedImageArea);
            this.Controls.Add(this.btOpenImage);
            this.Controls.Add(this.iasCartTypeImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogSelectImageArea";
            this.Text = "Select an image for the card type";
            this.Shown += new System.EventHandler(this.FormDialogSelectImageArea_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private VPKSoft.ImageAreaSelector.ImageAreaSelector iasCartTypeImage;
        private System.Windows.Forms.OpenFileDialog odImage;
        private System.Windows.Forms.Button btOpenImage;
        private System.Windows.Forms.Panel pnSelectedImageArea;
    }
}