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
            this.imageAreaSelector1 = new VPKSoft.ImageAreaSelector.ImageAreaSelector();
            this.odImage = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // imageAreaSelector1
            // 
            this.imageAreaSelector1.AutoScroll = true;
            this.imageAreaSelector1.Location = new System.Drawing.Point(25, 72);
            this.imageAreaSelector1.MaximumSelectionSize = new System.Drawing.Size(0, 0);
            this.imageAreaSelector1.MinimumSelectionSize = new System.Drawing.Size(0, 0);
            this.imageAreaSelector1.Name = "imageAreaSelector1";
            this.imageAreaSelector1.RequireRectangle = true;
            this.imageAreaSelector1.SelectImage = null;
            this.imageAreaSelector1.SelectionBoxColor = System.Drawing.Color.Blue;
            this.imageAreaSelector1.Size = new System.Drawing.Size(379, 317);
            this.imageAreaSelector1.TabIndex = 1;
            // 
            // odImage
            // 
            this.odImage.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            // 
            // FormDialogSelectImageArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.imageAreaSelector1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogSelectImageArea";
            this.Text = "Select an image for the card type";
            this.ResumeLayout(false);

        }

        #endregion

        private VPKSoft.ImageAreaSelector.ImageAreaSelector imageAreaSelector1;
        private System.Windows.Forms.OpenFileDialog odImage;
    }
}