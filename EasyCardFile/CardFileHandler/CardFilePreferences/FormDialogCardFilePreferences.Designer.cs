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
            this.tsbForegroundColor = new System.Windows.Forms.ToolStripButton();
            this.tsbBackgroundColor = new System.Windows.Forms.ToolStripButton();
            this.tsbTypeImage = new System.Windows.Forms.ToolStripButton();
            this.lbRowErrorText = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOk = new System.Windows.Forms.Button();
            this.pnChangePassword = new System.Windows.Forms.Panel();
            this.pbChangePassword = new System.Windows.Forms.PictureBox();
            this.lbChangePassword = new System.Windows.Forms.Label();
            this.tlpCardTypeProperties = new System.Windows.Forms.TableLayoutPanel();
            this.lbCartTypeForeground = new System.Windows.Forms.Label();
            this.lbCartTypeBackground = new System.Windows.Forms.Label();
            this.lbCardTypeImage = new System.Windows.Forms.Label();
            this.pnCartTypeForeground = new System.Windows.Forms.Panel();
            this.pnCartTypeBackground = new System.Windows.Forms.Panel();
            this.pbCardTypeImage = new System.Windows.Forms.PictureBox();
            this.lbCardTypeProperties = new System.Windows.Forms.Label();
            this.cdButtonColors = new System.Windows.Forms.ColorDialog();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabGeneralPreferences = new System.Windows.Forms.TabPage();
            this.btCardListFont = new System.Windows.Forms.Button();
            this.lbCardListFontValue = new System.Windows.Forms.Label();
            this.lbCardListFont = new System.Windows.Forms.Label();
            this.tlpCardTypeImageDimension = new System.Windows.Forms.TableLayoutPanel();
            this.lbCartTypeImageDimensions = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbLockAspectRatio = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.cbLockAspectRatio = new System.Windows.Forms.CheckBox();
            this.lbCardTypeImageDimension = new System.Windows.Forms.Label();
            this.tbbCardNamingInstruction = new EasyCardFile.UtilityClasses.ProjectControls.TextBoxButton();
            this.tabCardTypes = new System.Windows.Forms.TabPage();
            this.clbCardTypes = new EasyCardFile.UtilityClasses.ProjectControls.RefreshCheckListBox();
            this.tabCardSorting = new System.Windows.Forms.TabPage();
            this.tlpCardSorting = new System.Windows.Forms.TableLayoutPanel();
            this.cmbSortMethod4 = new System.Windows.Forms.ComboBox();
            this.cbIgnoreCase4 = new System.Windows.Forms.CheckBox();
            this.lbSortMethod4 = new System.Windows.Forms.Label();
            this.cmbSortMethod3 = new System.Windows.Forms.ComboBox();
            this.cbIgnoreCase3 = new System.Windows.Forms.CheckBox();
            this.lbSortMethod3 = new System.Windows.Forms.Label();
            this.cmbSortMethod2 = new System.Windows.Forms.ComboBox();
            this.cbIgnoreCase2 = new System.Windows.Forms.CheckBox();
            this.lbSortMethod2 = new System.Windows.Forms.Label();
            this.lbSortMethod1 = new System.Windows.Forms.Label();
            this.cmbSortMethod1 = new System.Windows.Forms.ComboBox();
            this.cbIgnoreCase1 = new System.Windows.Forms.CheckBox();
            this.odImage = new System.Windows.Forms.OpenFileDialog();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.tsbCardTypes.SuspendLayout();
            this.pnChangePassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbChangePassword)).BeginInit();
            this.tlpCardTypeProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCardTypeImage)).BeginInit();
            this.tcMain.SuspendLayout();
            this.tabGeneralPreferences.SuspendLayout();
            this.tlpCardTypeImageDimension.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            this.tabCardTypes.SuspendLayout();
            this.tabCardSorting.SuspendLayout();
            this.tlpCardSorting.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbCardFileName
            // 
            this.lbCardFileName.AutoSize = true;
            this.lbCardFileName.Location = new System.Drawing.Point(9, 12);
            this.lbCardFileName.Name = "lbCardFileName";
            this.lbCardFileName.Size = new System.Drawing.Size(108, 13);
            this.lbCardFileName.TabIndex = 0;
            this.lbCardFileName.Text = "Name of the card file:";
            // 
            // tbCardFileName
            // 
            this.tbCardFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCardFileName.Location = new System.Drawing.Point(167, 9);
            this.tbCardFileName.Name = "tbCardFileName";
            this.tbCardFileName.Size = new System.Drawing.Size(384, 20);
            this.tbCardFileName.TabIndex = 1;
            this.tbCardFileName.TextChanged += new System.EventHandler(this.tbCardFileName_TextChanged);
            // 
            // cbEncryption
            // 
            this.cbEncryption.AutoSize = true;
            this.cbEncryption.Location = new System.Drawing.Point(12, 37);
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
            this.cbCompression.Location = new System.Drawing.Point(12, 63);
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
            this.lbCardNamingInstruction.Location = new System.Drawing.Point(9, 90);
            this.lbCardNamingInstruction.Name = "lbCardNamingInstruction";
            this.lbCardNamingInstruction.Size = new System.Drawing.Size(125, 13);
            this.lbCardNamingInstruction.TabIndex = 6;
            this.lbCardNamingInstruction.Text = "Card naming instructions:";
            // 
            // cbCardsDropBetween
            // 
            this.cbCardsDropBetween.AutoSize = true;
            this.cbCardsDropBetween.Location = new System.Drawing.Point(167, 109);
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
            this.lbCardTypes.Location = new System.Drawing.Point(6, 3);
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
            this.tsbUndo,
            this.tsbForegroundColor,
            this.tsbBackgroundColor,
            this.tsbTypeImage});
            this.tsbCardTypes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsbCardTypes.Location = new System.Drawing.Point(357, 3);
            this.tsbCardTypes.Name = "tsbCardTypes";
            this.tsbCardTypes.Size = new System.Drawing.Size(196, 25);
            this.tsbCardTypes.TabIndex = 14;
            // 
            // tsbAddCardType
            // 
            this.tsbAddCardType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddCardType.Image = global::EasyCardFile.Properties.Resources.edit_add_2;
            this.tsbAddCardType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddCardType.Name = "tsbAddCardType";
            this.tsbAddCardType.Size = new System.Drawing.Size(23, 22);
            this.tsbAddCardType.Text = "Add a new card type";
            this.tsbAddCardType.Click += new System.EventHandler(this.tsbAddCardType_Click);
            // 
            // tsbRemoveCardType
            // 
            this.tsbRemoveCardType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveCardType.Image = global::EasyCardFile.Properties.Resources.edit_delete_6;
            this.tsbRemoveCardType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveCardType.Name = "tsbRemoveCardType";
            this.tsbRemoveCardType.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveCardType.Text = "Delete card type";
            this.tsbRemoveCardType.Click += new System.EventHandler(this.tsbRemoveCardType_Click);
            // 
            // tsbRename
            // 
            this.tsbRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRename.Image = ((System.Drawing.Image)(resources.GetObject("tsbRename.Image")));
            this.tsbRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRename.Name = "tsbRename";
            this.tsbRename.Size = new System.Drawing.Size(23, 22);
            this.tsbRename.Text = "Rename card type";
            this.tsbRename.Click += new System.EventHandler(this.tsbRename_Click);
            // 
            // tsbTypeSpecificCardNaming
            // 
            this.tsbTypeSpecificCardNaming.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTypeSpecificCardNaming.Image = global::EasyCardFile.Properties.Resources.textfield_rename;
            this.tsbTypeSpecificCardNaming.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTypeSpecificCardNaming.Name = "tsbTypeSpecificCardNaming";
            this.tsbTypeSpecificCardNaming.Size = new System.Drawing.Size(23, 22);
            this.tsbTypeSpecificCardNaming.Text = "Set card type specific naming instructions";
            this.tsbTypeSpecificCardNaming.Click += new System.EventHandler(this.tsbTypeSpecificCardNaming_Click);
            // 
            // tsbUndo
            // 
            this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUndo.Image = global::EasyCardFile.Properties.Resources.Undo;
            this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUndo.Name = "tsbUndo";
            this.tsbUndo.Size = new System.Drawing.Size(23, 22);
            this.tsbUndo.Text = "Undo card type changes";
            this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
            // 
            // tsbForegroundColor
            // 
            this.tsbForegroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbForegroundColor.Image = global::EasyCardFile.Properties.Resources.colorize_2;
            this.tsbForegroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbForegroundColor.Name = "tsbForegroundColor";
            this.tsbForegroundColor.Size = new System.Drawing.Size(23, 22);
            this.tsbForegroundColor.Text = "Type foreground color";
            this.tsbForegroundColor.Click += new System.EventHandler(this.tsbForegroundColor_Click);
            // 
            // tsbBackgroundColor
            // 
            this.tsbBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBackgroundColor.Image = global::EasyCardFile.Properties.Resources.color_fill;
            this.tsbBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBackgroundColor.Name = "tsbBackgroundColor";
            this.tsbBackgroundColor.Size = new System.Drawing.Size(23, 22);
            this.tsbBackgroundColor.Text = "Type background color";
            this.tsbBackgroundColor.Click += new System.EventHandler(this.tsbForegroundColor_Click);
            // 
            // tsbTypeImage
            // 
            this.tsbTypeImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbTypeImage.Image = global::EasyCardFile.Properties.Resources.image;
            this.tsbTypeImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbTypeImage.Name = "tsbTypeImage";
            this.tsbTypeImage.Size = new System.Drawing.Size(23, 22);
            this.tsbTypeImage.Text = "Type image";
            this.tsbTypeImage.Click += new System.EventHandler(this.tsbTypeImage_Click);
            // 
            // lbRowErrorText
            // 
            this.lbRowErrorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRowErrorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRowErrorText.ForeColor = System.Drawing.Color.Red;
            this.lbRowErrorText.Location = new System.Drawing.Point(12, 317);
            this.lbRowErrorText.Name = "lbRowErrorText";
            this.lbRowErrorText.Size = new System.Drawing.Size(405, 26);
            this.lbRowErrorText.TabIndex = 15;
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(504, 317);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 31;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // btOk
            // 
            this.btOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOk.Location = new System.Drawing.Point(423, 317);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(75, 23);
            this.btOk.TabIndex = 30;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // pnChangePassword
            // 
            this.pnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnChangePassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnChangePassword.Controls.Add(this.pbChangePassword);
            this.pnChangePassword.Controls.Add(this.lbChangePassword);
            this.pnChangePassword.Location = new System.Drawing.Point(333, 40);
            this.pnChangePassword.Margin = new System.Windows.Forms.Padding(0);
            this.pnChangePassword.Name = "pnChangePassword";
            this.pnChangePassword.Size = new System.Drawing.Size(218, 20);
            this.pnChangePassword.TabIndex = 32;
            this.pnChangePassword.Click += new System.EventHandler(this.pnChangePassword_Click);
            // 
            // pbChangePassword
            // 
            this.pbChangePassword.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbChangePassword.Image = global::EasyCardFile.Properties.Resources.system_password_2;
            this.pbChangePassword.Location = new System.Drawing.Point(196, 0);
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
            // tlpCardTypeProperties
            // 
            this.tlpCardTypeProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCardTypeProperties.ColumnCount = 3;
            this.tlpCardTypeProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpCardTypeProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCardTypeProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpCardTypeProperties.Controls.Add(this.lbCartTypeForeground, 0, 0);
            this.tlpCardTypeProperties.Controls.Add(this.lbCartTypeBackground, 1, 0);
            this.tlpCardTypeProperties.Controls.Add(this.lbCardTypeImage, 2, 0);
            this.tlpCardTypeProperties.Controls.Add(this.pnCartTypeForeground, 0, 1);
            this.tlpCardTypeProperties.Controls.Add(this.pnCartTypeBackground, 1, 1);
            this.tlpCardTypeProperties.Controls.Add(this.pbCardTypeImage, 2, 1);
            this.tlpCardTypeProperties.Location = new System.Drawing.Point(164, 188);
            this.tlpCardTypeProperties.Name = "tlpCardTypeProperties";
            this.tlpCardTypeProperties.RowCount = 2;
            this.tlpCardTypeProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpCardTypeProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCardTypeProperties.Size = new System.Drawing.Size(389, 82);
            this.tlpCardTypeProperties.TabIndex = 34;
            this.tlpCardTypeProperties.Resize += new System.EventHandler(this.tlpCardTypeProperties_Resize);
            // 
            // lbCartTypeForeground
            // 
            this.lbCartTypeForeground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCartTypeForeground.Location = new System.Drawing.Point(3, 0);
            this.lbCartTypeForeground.Name = "lbCartTypeForeground";
            this.lbCartTypeForeground.Size = new System.Drawing.Size(123, 40);
            this.lbCartTypeForeground.TabIndex = 0;
            this.lbCartTypeForeground.Text = "Card type foreground color:";
            // 
            // lbCartTypeBackground
            // 
            this.lbCartTypeBackground.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCartTypeBackground.Location = new System.Drawing.Point(132, 0);
            this.lbCartTypeBackground.Name = "lbCartTypeBackground";
            this.lbCartTypeBackground.Size = new System.Drawing.Size(123, 40);
            this.lbCartTypeBackground.TabIndex = 1;
            this.lbCartTypeBackground.Text = "Card type backround color:";
            // 
            // lbCardTypeImage
            // 
            this.lbCardTypeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbCardTypeImage.Location = new System.Drawing.Point(261, 0);
            this.lbCardTypeImage.Name = "lbCardTypeImage";
            this.lbCardTypeImage.Size = new System.Drawing.Size(125, 40);
            this.lbCardTypeImage.TabIndex = 2;
            this.lbCardTypeImage.Text = "Card type image";
            // 
            // pnCartTypeForeground
            // 
            this.pnCartTypeForeground.BackColor = System.Drawing.SystemColors.ControlText;
            this.pnCartTypeForeground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCartTypeForeground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnCartTypeForeground.Location = new System.Drawing.Point(0, 40);
            this.pnCartTypeForeground.Margin = new System.Windows.Forms.Padding(0);
            this.pnCartTypeForeground.Name = "pnCartTypeForeground";
            this.pnCartTypeForeground.Size = new System.Drawing.Size(42, 42);
            this.pnCartTypeForeground.TabIndex = 3;
            this.pnCartTypeForeground.Click += new System.EventHandler(this.tsbForegroundColor_Click);
            // 
            // pnCartTypeBackground
            // 
            this.pnCartTypeBackground.BackColor = System.Drawing.SystemColors.Window;
            this.pnCartTypeBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnCartTypeBackground.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnCartTypeBackground.Location = new System.Drawing.Point(129, 40);
            this.pnCartTypeBackground.Margin = new System.Windows.Forms.Padding(0);
            this.pnCartTypeBackground.Name = "pnCartTypeBackground";
            this.pnCartTypeBackground.Size = new System.Drawing.Size(42, 42);
            this.pnCartTypeBackground.TabIndex = 4;
            this.pnCartTypeBackground.Click += new System.EventHandler(this.tsbForegroundColor_Click);
            // 
            // pbCardTypeImage
            // 
            this.pbCardTypeImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCardTypeImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCardTypeImage.Location = new System.Drawing.Point(258, 40);
            this.pbCardTypeImage.Margin = new System.Windows.Forms.Padding(0);
            this.pbCardTypeImage.Name = "pbCardTypeImage";
            this.pbCardTypeImage.Size = new System.Drawing.Size(42, 42);
            this.pbCardTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCardTypeImage.TabIndex = 5;
            this.pbCardTypeImage.TabStop = false;
            this.pbCardTypeImage.Click += new System.EventHandler(this.pbCardTypeImage_Click);
            // 
            // lbCardTypeProperties
            // 
            this.lbCardTypeProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCardTypeProperties.Location = new System.Drawing.Point(6, 188);
            this.lbCardTypeProperties.Name = "lbCardTypeProperties";
            this.lbCardTypeProperties.Size = new System.Drawing.Size(152, 82);
            this.lbCardTypeProperties.TabIndex = 35;
            this.lbCardTypeProperties.Text = "Card type properties:";
            // 
            // cdButtonColors
            // 
            this.cdButtonColors.AnyColor = true;
            this.cdButtonColors.FullOpen = true;
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tabGeneralPreferences);
            this.tcMain.Controls.Add(this.tabCardTypes);
            this.tcMain.Controls.Add(this.tabCardSorting);
            this.tcMain.Location = new System.Drawing.Point(12, 12);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(567, 299);
            this.tcMain.TabIndex = 36;
            // 
            // tabGeneralPreferences
            // 
            this.tabGeneralPreferences.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabGeneralPreferences.Controls.Add(this.btCardListFont);
            this.tabGeneralPreferences.Controls.Add(this.lbCardListFontValue);
            this.tabGeneralPreferences.Controls.Add(this.lbCardListFont);
            this.tabGeneralPreferences.Controls.Add(this.tlpCardTypeImageDimension);
            this.tabGeneralPreferences.Controls.Add(this.lbCardFileName);
            this.tabGeneralPreferences.Controls.Add(this.tbCardFileName);
            this.tabGeneralPreferences.Controls.Add(this.cbEncryption);
            this.tabGeneralPreferences.Controls.Add(this.cbCompression);
            this.tabGeneralPreferences.Controls.Add(this.pnChangePassword);
            this.tabGeneralPreferences.Controls.Add(this.lbCardNamingInstruction);
            this.tabGeneralPreferences.Controls.Add(this.tbbCardNamingInstruction);
            this.tabGeneralPreferences.Controls.Add(this.cbCardsDropBetween);
            this.tabGeneralPreferences.Location = new System.Drawing.Point(4, 22);
            this.tabGeneralPreferences.Name = "tabGeneralPreferences";
            this.tabGeneralPreferences.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneralPreferences.Size = new System.Drawing.Size(559, 273);
            this.tabGeneralPreferences.TabIndex = 0;
            this.tabGeneralPreferences.Text = "General";
            this.tabGeneralPreferences.UseVisualStyleBackColor = true;
            // 
            // btCardListFont
            // 
            this.btCardListFont.Location = new System.Drawing.Point(458, 181);
            this.btCardListFont.Name = "btCardListFont";
            this.btCardListFont.Size = new System.Drawing.Size(92, 23);
            this.btCardListFont.TabIndex = 37;
            this.btCardListFont.Text = "Font...";
            this.btCardListFont.UseVisualStyleBackColor = true;
            this.btCardListFont.Click += new System.EventHandler(this.btCardListFont_Click);
            // 
            // lbCardListFontValue
            // 
            this.lbCardListFontValue.AutoSize = true;
            this.lbCardListFontValue.Location = new System.Drawing.Point(215, 186);
            this.lbCardListFontValue.Name = "lbCardListFontValue";
            this.lbCardListFontValue.Size = new System.Drawing.Size(137, 13);
            this.lbCardListFontValue.TabIndex = 36;
            this.lbCardListFontValue.Text = "Microsoft Sans Serif; 8,25pt";
            // 
            // lbCardListFont
            // 
            this.lbCardListFont.AutoSize = true;
            this.lbCardListFont.Location = new System.Drawing.Point(9, 186);
            this.lbCardListFont.Name = "lbCardListFont";
            this.lbCardListFont.Size = new System.Drawing.Size(142, 13);
            this.lbCardListFont.TabIndex = 35;
            this.lbCardListFont.Text = "Font to use with the card list:";
            // 
            // tlpCardTypeImageDimension
            // 
            this.tlpCardTypeImageDimension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpCardTypeImageDimension.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tlpCardTypeImageDimension.ColumnCount = 4;
            this.tlpCardTypeImageDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpCardTypeImageDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33333F));
            this.tlpCardTypeImageDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33333F));
            this.tlpCardTypeImageDimension.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.33333F));
            this.tlpCardTypeImageDimension.Controls.Add(this.lbCartTypeImageDimensions, 0, 0);
            this.tlpCardTypeImageDimension.Controls.Add(this.lbWidth, 1, 0);
            this.tlpCardTypeImageDimension.Controls.Add(this.lbHeight, 2, 0);
            this.tlpCardTypeImageDimension.Controls.Add(this.lbLockAspectRatio, 3, 0);
            this.tlpCardTypeImageDimension.Controls.Add(this.nudWidth, 1, 1);
            this.tlpCardTypeImageDimension.Controls.Add(this.nudHeight, 2, 1);
            this.tlpCardTypeImageDimension.Controls.Add(this.cbLockAspectRatio, 3, 1);
            this.tlpCardTypeImageDimension.Controls.Add(this.lbCardTypeImageDimension, 0, 1);
            this.tlpCardTypeImageDimension.Location = new System.Drawing.Point(12, 132);
            this.tlpCardTypeImageDimension.Name = "tlpCardTypeImageDimension";
            this.tlpCardTypeImageDimension.RowCount = 2;
            this.tlpCardTypeImageDimension.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardTypeImageDimension.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardTypeImageDimension.Size = new System.Drawing.Size(538, 43);
            this.tlpCardTypeImageDimension.TabIndex = 34;
            // 
            // lbCartTypeImageDimensions
            // 
            this.lbCartTypeImageDimensions.AutoSize = true;
            this.lbCartTypeImageDimensions.Location = new System.Drawing.Point(4, 1);
            this.lbCartTypeImageDimensions.Name = "lbCartTypeImageDimensions";
            this.lbCartTypeImageDimensions.Size = new System.Drawing.Size(104, 13);
            this.lbCartTypeImageDimensions.TabIndex = 35;
            this.lbCartTypeImageDimensions.Text = "Card type image size";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(164, 1);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(35, 13);
            this.lbWidth.TabIndex = 34;
            this.lbWidth.Text = "Width";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(289, 1);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(38, 13);
            this.lbHeight.TabIndex = 35;
            this.lbHeight.Text = "Height";
            // 
            // lbLockAspectRatio
            // 
            this.lbLockAspectRatio.AutoSize = true;
            this.lbLockAspectRatio.Location = new System.Drawing.Point(414, 1);
            this.lbLockAspectRatio.Name = "lbLockAspectRatio";
            this.lbLockAspectRatio.Size = new System.Drawing.Size(99, 13);
            this.lbLockAspectRatio.TabIndex = 36;
            this.lbLockAspectRatio.Text = "Square aspect ratio";
            // 
            // nudWidth
            // 
            this.nudWidth.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudWidth.Location = new System.Drawing.Point(206, 18);
            this.nudWidth.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudWidth.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(76, 20);
            this.nudWidth.TabIndex = 37;
            this.nudWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudWidth.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudWidth.ValueChanged += new System.EventHandler(this.nudWidth_ValueChanged);
            // 
            // nudHeight
            // 
            this.nudHeight.Dock = System.Windows.Forms.DockStyle.Right;
            this.nudHeight.Location = new System.Drawing.Point(331, 18);
            this.nudHeight.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.nudHeight.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(76, 20);
            this.nudHeight.TabIndex = 38;
            this.nudHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.nudHeight.ValueChanged += new System.EventHandler(this.nudHeight_ValueChanged);
            // 
            // cbLockAspectRatio
            // 
            this.cbLockAspectRatio.AutoSize = true;
            this.cbLockAspectRatio.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbLockAspectRatio.Location = new System.Drawing.Point(519, 18);
            this.cbLockAspectRatio.Name = "cbLockAspectRatio";
            this.cbLockAspectRatio.Size = new System.Drawing.Size(15, 21);
            this.cbLockAspectRatio.TabIndex = 39;
            this.cbLockAspectRatio.UseVisualStyleBackColor = true;
            this.cbLockAspectRatio.CheckedChanged += new System.EventHandler(this.cbLockAspectRatio_CheckedChanged);
            // 
            // lbCardTypeImageDimension
            // 
            this.lbCardTypeImageDimension.AutoSize = true;
            this.lbCardTypeImageDimension.Location = new System.Drawing.Point(4, 15);
            this.lbCardTypeImageDimension.Name = "lbCardTypeImageDimension";
            this.lbCardTypeImageDimension.Size = new System.Drawing.Size(138, 13);
            this.lbCardTypeImageDimension.TabIndex = 33;
            this.lbCardTypeImageDimension.Text = "Card type image dimensions";
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
            this.tbbCardNamingInstruction.Location = new System.Drawing.Point(167, 83);
            this.tbbCardNamingInstruction.Name = "tbbCardNamingInstruction";
            this.tbbCardNamingInstruction.SelectedText = "";
            this.tbbCardNamingInstruction.Size = new System.Drawing.Size(383, 20);
            this.tbbCardNamingInstruction.TabIndex = 8;
            this.tbbCardNamingInstruction.TextChanged += new System.EventHandler(this.tbbCardNamingInstruction_TextChanged);
            this.tbbCardNamingInstruction.Click += new System.EventHandler(this.tbbCardNamingInstruction_Click);
            // 
            // tabCardTypes
            // 
            this.tabCardTypes.Controls.Add(this.lbCardTypes);
            this.tabCardTypes.Controls.Add(this.lbCardTypeProperties);
            this.tabCardTypes.Controls.Add(this.tsbCardTypes);
            this.tabCardTypes.Controls.Add(this.tlpCardTypeProperties);
            this.tabCardTypes.Controls.Add(this.clbCardTypes);
            this.tabCardTypes.Location = new System.Drawing.Point(4, 22);
            this.tabCardTypes.Name = "tabCardTypes";
            this.tabCardTypes.Padding = new System.Windows.Forms.Padding(3);
            this.tabCardTypes.Size = new System.Drawing.Size(559, 273);
            this.tabCardTypes.TabIndex = 1;
            this.tabCardTypes.Text = "Card types";
            this.tabCardTypes.UseVisualStyleBackColor = true;
            // 
            // clbCardTypes
            // 
            this.clbCardTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clbCardTypes.FormattingEnabled = true;
            this.clbCardTypes.IntegralHeight = false;
            this.clbCardTypes.Location = new System.Drawing.Point(9, 31);
            this.clbCardTypes.Name = "clbCardTypes";
            this.clbCardTypes.Size = new System.Drawing.Size(544, 151);
            this.clbCardTypes.TabIndex = 33;
            this.clbCardTypes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbCardTypes_ItemCheck);
            this.clbCardTypes.SelectedValueChanged += new System.EventHandler(this.clbCardTypes_SelectedValueChanged);
            // 
            // tabCardSorting
            // 
            this.tabCardSorting.Controls.Add(this.tlpCardSorting);
            this.tabCardSorting.Location = new System.Drawing.Point(4, 22);
            this.tabCardSorting.Name = "tabCardSorting";
            this.tabCardSorting.Padding = new System.Windows.Forms.Padding(3);
            this.tabCardSorting.Size = new System.Drawing.Size(559, 273);
            this.tabCardSorting.TabIndex = 2;
            this.tabCardSorting.Text = "Card sorting";
            this.tabCardSorting.UseVisualStyleBackColor = true;
            // 
            // tlpCardSorting
            // 
            this.tlpCardSorting.ColumnCount = 2;
            this.tlpCardSorting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpCardSorting.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tlpCardSorting.Controls.Add(this.cmbSortMethod4, 0, 7);
            this.tlpCardSorting.Controls.Add(this.cbIgnoreCase4, 1, 6);
            this.tlpCardSorting.Controls.Add(this.lbSortMethod4, 0, 6);
            this.tlpCardSorting.Controls.Add(this.cmbSortMethod3, 0, 5);
            this.tlpCardSorting.Controls.Add(this.cbIgnoreCase3, 1, 4);
            this.tlpCardSorting.Controls.Add(this.lbSortMethod3, 0, 4);
            this.tlpCardSorting.Controls.Add(this.cmbSortMethod2, 0, 3);
            this.tlpCardSorting.Controls.Add(this.cbIgnoreCase2, 1, 2);
            this.tlpCardSorting.Controls.Add(this.lbSortMethod2, 0, 2);
            this.tlpCardSorting.Controls.Add(this.lbSortMethod1, 0, 0);
            this.tlpCardSorting.Controls.Add(this.cmbSortMethod1, 0, 1);
            this.tlpCardSorting.Controls.Add(this.cbIgnoreCase1, 1, 0);
            this.tlpCardSorting.Location = new System.Drawing.Point(6, 6);
            this.tlpCardSorting.Name = "tlpCardSorting";
            this.tlpCardSorting.RowCount = 8;
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpCardSorting.Size = new System.Drawing.Size(547, 215);
            this.tlpCardSorting.TabIndex = 4;
            // 
            // cmbSortMethod4
            // 
            this.cmbSortMethod4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortMethod4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tlpCardSorting.SetColumnSpan(this.cmbSortMethod4, 2);
            this.cmbSortMethod4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortMethod4.FormattingEnabled = true;
            this.cmbSortMethod4.Location = new System.Drawing.Point(3, 176);
            this.cmbSortMethod4.Name = "cmbSortMethod4";
            this.cmbSortMethod4.Size = new System.Drawing.Size(541, 21);
            this.cmbSortMethod4.TabIndex = 12;
            // 
            // cbIgnoreCase4
            // 
            this.cbIgnoreCase4.AutoSize = true;
            this.cbIgnoreCase4.Location = new System.Drawing.Point(194, 153);
            this.cbIgnoreCase4.Name = "cbIgnoreCase4";
            this.cbIgnoreCase4.Size = new System.Drawing.Size(147, 17);
            this.cbIgnoreCase4.TabIndex = 11;
            this.cbIgnoreCase4.Text = "ignore case (alphabetical)";
            this.cbIgnoreCase4.UseVisualStyleBackColor = true;
            // 
            // lbSortMethod4
            // 
            this.lbSortMethod4.AutoSize = true;
            this.lbSortMethod4.Location = new System.Drawing.Point(3, 150);
            this.lbSortMethod4.Name = "lbSortMethod4";
            this.lbSortMethod4.Size = new System.Drawing.Size(76, 13);
            this.lbSortMethod4.TabIndex = 10;
            this.lbSortMethod4.Text = "Sort method 4:";
            // 
            // cmbSortMethod3
            // 
            this.cmbSortMethod3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortMethod3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tlpCardSorting.SetColumnSpan(this.cmbSortMethod3, 2);
            this.cmbSortMethod3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortMethod3.FormattingEnabled = true;
            this.cmbSortMethod3.Location = new System.Drawing.Point(3, 126);
            this.cmbSortMethod3.Name = "cmbSortMethod3";
            this.cmbSortMethod3.Size = new System.Drawing.Size(541, 21);
            this.cmbSortMethod3.TabIndex = 9;
            // 
            // cbIgnoreCase3
            // 
            this.cbIgnoreCase3.AutoSize = true;
            this.cbIgnoreCase3.Location = new System.Drawing.Point(194, 103);
            this.cbIgnoreCase3.Name = "cbIgnoreCase3";
            this.cbIgnoreCase3.Size = new System.Drawing.Size(147, 17);
            this.cbIgnoreCase3.TabIndex = 8;
            this.cbIgnoreCase3.Text = "ignore case (alphabetical)";
            this.cbIgnoreCase3.UseVisualStyleBackColor = true;
            // 
            // lbSortMethod3
            // 
            this.lbSortMethod3.AutoSize = true;
            this.lbSortMethod3.Location = new System.Drawing.Point(3, 100);
            this.lbSortMethod3.Name = "lbSortMethod3";
            this.lbSortMethod3.Size = new System.Drawing.Size(76, 13);
            this.lbSortMethod3.TabIndex = 7;
            this.lbSortMethod3.Text = "Sort method 3:";
            // 
            // cmbSortMethod2
            // 
            this.cmbSortMethod2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortMethod2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tlpCardSorting.SetColumnSpan(this.cmbSortMethod2, 2);
            this.cmbSortMethod2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortMethod2.FormattingEnabled = true;
            this.cmbSortMethod2.Location = new System.Drawing.Point(3, 76);
            this.cmbSortMethod2.Name = "cmbSortMethod2";
            this.cmbSortMethod2.Size = new System.Drawing.Size(541, 21);
            this.cmbSortMethod2.TabIndex = 6;
            // 
            // cbIgnoreCase2
            // 
            this.cbIgnoreCase2.AutoSize = true;
            this.cbIgnoreCase2.Location = new System.Drawing.Point(194, 53);
            this.cbIgnoreCase2.Name = "cbIgnoreCase2";
            this.cbIgnoreCase2.Size = new System.Drawing.Size(147, 17);
            this.cbIgnoreCase2.TabIndex = 5;
            this.cbIgnoreCase2.Text = "ignore case (alphabetical)";
            this.cbIgnoreCase2.UseVisualStyleBackColor = true;
            // 
            // lbSortMethod2
            // 
            this.lbSortMethod2.AutoSize = true;
            this.lbSortMethod2.Location = new System.Drawing.Point(3, 50);
            this.lbSortMethod2.Name = "lbSortMethod2";
            this.lbSortMethod2.Size = new System.Drawing.Size(76, 13);
            this.lbSortMethod2.TabIndex = 4;
            this.lbSortMethod2.Text = "Sort method 2:";
            // 
            // lbSortMethod1
            // 
            this.lbSortMethod1.AutoSize = true;
            this.lbSortMethod1.Location = new System.Drawing.Point(3, 0);
            this.lbSortMethod1.Name = "lbSortMethod1";
            this.lbSortMethod1.Size = new System.Drawing.Size(76, 13);
            this.lbSortMethod1.TabIndex = 1;
            this.lbSortMethod1.Text = "Sort method 1:";
            // 
            // cmbSortMethod1
            // 
            this.cmbSortMethod1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSortMethod1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tlpCardSorting.SetColumnSpan(this.cmbSortMethod1, 2);
            this.cmbSortMethod1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSortMethod1.FormattingEnabled = true;
            this.cmbSortMethod1.Location = new System.Drawing.Point(3, 26);
            this.cmbSortMethod1.Name = "cmbSortMethod1";
            this.cmbSortMethod1.Size = new System.Drawing.Size(541, 21);
            this.cmbSortMethod1.TabIndex = 2;
            // 
            // cbIgnoreCase1
            // 
            this.cbIgnoreCase1.AutoSize = true;
            this.cbIgnoreCase1.Location = new System.Drawing.Point(194, 3);
            this.cbIgnoreCase1.Name = "cbIgnoreCase1";
            this.cbIgnoreCase1.Size = new System.Drawing.Size(147, 17);
            this.cbIgnoreCase1.TabIndex = 3;
            this.cbIgnoreCase1.Text = "ignore case (alphabetical)";
            this.cbIgnoreCase1.UseVisualStyleBackColor = true;
            // 
            // odImage
            // 
            this.odImage.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            // 
            // FormDialogCardFilePreferences
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(591, 352);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.lbRowErrorText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDialogCardFilePreferences";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Card file preferences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDialogCardFilePreferences_FormClosed);
            this.Shown += new System.EventHandler(this.FormDialogCardFilePreferences_Shown);
            this.tsbCardTypes.ResumeLayout(false);
            this.tsbCardTypes.PerformLayout();
            this.pnChangePassword.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbChangePassword)).EndInit();
            this.tlpCardTypeProperties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCardTypeImage)).EndInit();
            this.tcMain.ResumeLayout(false);
            this.tabGeneralPreferences.ResumeLayout(false);
            this.tabGeneralPreferences.PerformLayout();
            this.tlpCardTypeImageDimension.ResumeLayout(false);
            this.tlpCardTypeImageDimension.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            this.tabCardTypes.ResumeLayout(false);
            this.tabCardTypes.PerformLayout();
            this.tabCardSorting.ResumeLayout(false);
            this.tlpCardSorting.ResumeLayout(false);
            this.tlpCardSorting.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.ToolStripButton tsbRename;
        private System.Windows.Forms.ToolStripButton tsbUndo;
        private System.Windows.Forms.ToolStripButton tsbTypeSpecificCardNaming;
        private System.Windows.Forms.ToolStripButton tsbForegroundColor;
        private System.Windows.Forms.ToolStripButton tsbBackgroundColor;
        private System.Windows.Forms.ToolStripButton tsbTypeImage;
        private UtilityClasses.ProjectControls.RefreshCheckListBox clbCardTypes;
        private System.Windows.Forms.TableLayoutPanel tlpCardTypeProperties;
        private System.Windows.Forms.Label lbCartTypeForeground;
        private System.Windows.Forms.Label lbCartTypeBackground;
        private System.Windows.Forms.Label lbCardTypeImage;
        private System.Windows.Forms.Panel pnCartTypeForeground;
        private System.Windows.Forms.Label lbCardTypeProperties;
        private System.Windows.Forms.Panel pnCartTypeBackground;
        private System.Windows.Forms.ColorDialog cdButtonColors;
        private System.Windows.Forms.PictureBox pbCardTypeImage;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabGeneralPreferences;
        private System.Windows.Forms.Label lbCartTypeImageDimensions;
        private System.Windows.Forms.TableLayoutPanel tlpCardTypeImageDimension;
        private System.Windows.Forms.Label lbCardTypeImageDimension;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
        private System.Windows.Forms.Label lbLockAspectRatio;
        private System.Windows.Forms.NumericUpDown nudWidth;
        private System.Windows.Forms.NumericUpDown nudHeight;
        private System.Windows.Forms.CheckBox cbLockAspectRatio;
        private System.Windows.Forms.TabPage tabCardTypes;
        private System.Windows.Forms.OpenFileDialog odImage;
        private System.Windows.Forms.Label lbCardListFontValue;
        private System.Windows.Forms.Label lbCardListFont;
        private System.Windows.Forms.FontDialog fdFont;
        private System.Windows.Forms.Button btCardListFont;
        private System.Windows.Forms.TabPage tabCardSorting;
        private System.Windows.Forms.TableLayoutPanel tlpCardSorting;
        private System.Windows.Forms.ComboBox cmbSortMethod4;
        private System.Windows.Forms.CheckBox cbIgnoreCase4;
        private System.Windows.Forms.Label lbSortMethod4;
        private System.Windows.Forms.ComboBox cmbSortMethod3;
        private System.Windows.Forms.CheckBox cbIgnoreCase3;
        private System.Windows.Forms.Label lbSortMethod3;
        private System.Windows.Forms.ComboBox cmbSortMethod2;
        private System.Windows.Forms.CheckBox cbIgnoreCase2;
        private System.Windows.Forms.Label lbSortMethod2;
        private System.Windows.Forms.Label lbSortMethod1;
        private System.Windows.Forms.ComboBox cmbSortMethod1;
        private System.Windows.Forms.CheckBox cbIgnoreCase1;
    }
}