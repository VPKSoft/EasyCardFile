namespace EasyCardFile.UtilityClasses.ProjectControls
{
    partial class TextBoxButton
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbButtonHolder = new System.Windows.Forms.Panel();
            this.pnButton = new System.Windows.Forms.Panel();
            this.lbButton = new System.Windows.Forms.Label();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tbButton = new System.Windows.Forms.TextBox();
            this.pbButtonHolder.SuspendLayout();
            this.pnButton.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbButtonHolder
            // 
            this.pbButtonHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbButtonHolder.Controls.Add(this.pnButton);
            this.pbButtonHolder.Location = new System.Drawing.Point(99, 0);
            this.pbButtonHolder.Margin = new System.Windows.Forms.Padding(0);
            this.pbButtonHolder.Name = "pbButtonHolder";
            this.pbButtonHolder.Padding = new System.Windows.Forms.Padding(1);
            this.pbButtonHolder.Size = new System.Drawing.Size(101, 20);
            this.pbButtonHolder.TabIndex = 1;
            // 
            // pnButton
            // 
            this.pnButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnButton.Controls.Add(this.lbButton);
            this.pnButton.Location = new System.Drawing.Point(1, 0);
            this.pnButton.Margin = new System.Windows.Forms.Padding(0);
            this.pnButton.Name = "pnButton";
            this.pnButton.Size = new System.Drawing.Size(101, 20);
            this.pnButton.TabIndex = 3;
            // 
            // lbButton
            // 
            this.lbButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbButton.Location = new System.Drawing.Point(0, 0);
            this.lbButton.Margin = new System.Windows.Forms.Padding(0);
            this.lbButton.Name = "lbButton";
            this.lbButton.Size = new System.Drawing.Size(100, 20);
            this.lbButton.TabIndex = 0;
            this.lbButton.Text = "__NOT_SET__";
            this.lbButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbButton.Click += new System.EventHandler(this.lbButton_Click);
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 2;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tlpButtons.Controls.Add(this.tbButton, 0, 0);
            this.tlpButtons.Controls.Add(this.pbButtonHolder, 1, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(200, 20);
            this.tlpButtons.TabIndex = 2;
            // 
            // tbButton
            // 
            this.tbButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbButton.Location = new System.Drawing.Point(0, 0);
            this.tbButton.Margin = new System.Windows.Forms.Padding(0);
            this.tbButton.Name = "tbButton";
            this.tbButton.Size = new System.Drawing.Size(99, 20);
            this.tbButton.TabIndex = 0;
            this.tbButton.TextChanged += new System.EventHandler(this.tbButton_TextChanged);
            // 
            // TextBoxButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpButtons);
            this.Name = "TextBoxButton";
            this.Size = new System.Drawing.Size(200, 20);
            this.pbButtonHolder.ResumeLayout(false);
            this.pnButton.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.tlpButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pbButtonHolder;
        private System.Windows.Forms.Panel pnButton;
        private System.Windows.Forms.Label lbButton;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.TextBox tbButton;
    }
}
