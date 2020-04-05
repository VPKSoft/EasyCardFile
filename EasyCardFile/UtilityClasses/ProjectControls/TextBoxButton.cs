#region License
/*
MIT License

Copyright(c) 2020 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EasyCardFile.UtilityClasses.ProjectControls
{
    /// <summary>
    /// A text box with a button.
    /// Implements the <see cref="System.Windows.Forms.UserControl" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [DefaultEvent("TextChanged")]
    public partial class TextBoxButton : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxButton"/> class.
        /// </summary>
        public TextBoxButton()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Gets or sets the name of the control.
        /// </summary>
        public new string Name
        {
            get => base.Name;
            set
            {
                base.Name = value;
                if (ButtonText == "__NOT_SET__" || ButtonText == "TextBoxButton")
                {
                    ButtonText = base.Name;
                }
            }
        }

        /// <summary>
        /// Gets the text box of the control.
        /// </summary>
        [Browsable(false)]
        public TextBox TextBox => tbButton;

        /// <summary>
        /// Gets the button label.
        /// </summary>
        [Browsable(false)]
        public Label ButtonLabel => lbButton;

        /// <summary>
        /// Gets or sets the image that is displayed on a <see cref="T:System.Windows.Forms.Label" />.
        /// </summary>
        [Category("Appearance")]
        public Image ButtonImage { get => lbButton.Image; set => lbButton.Image = value; }

        /// <summary>
        /// Gets or sets the alignment of an image that is displayed in the control.
        /// </summary>
        [Category("Appearance")]
        public ContentAlignment ButtonImageAlign { get => lbButton.ImageAlign; set => lbButton.ImageAlign = value; }


        /// <summary>
        /// Gets or sets the button font.
        /// </summary>
        [Category("Appearance")]
        public Font ButtonFont
        {
            get => lbButton.Font;
            set => lbButton.Font = value;
        }

        /// <summary>
        /// Gets or sets the color of the button foreground.
        /// </summary>
        [Category("Appearance")]
        public Color ButtonForeColor 
        {
            get => lbButton.ForeColor;
            set => lbButton.ForeColor = value;
        }

        /// <summary>
        /// Gets or sets the width of the button.
        /// </summary>
        [Category("Appearance")]
        public int ButtonWidth
        {
            get => (int) tlpButtons.ColumnStyles[1].Width; 
            set => tlpButtons.ColumnStyles[1].Width = value; 
        }

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        [Category("Appearance")]
        public string ButtonText { get => lbButton.Text; set => lbButton.Text = value; }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        [Category("Appearance")]
        public override string Text { get => tbButton.Text; set => tbButton.Text = value; }

        /// <summary>
        /// Gets or sets a value indicating the currently selected text in the control.
        /// </summary>
        [Browsable(false)]
        public string SelectedText
        {
            get => tbButton.SelectedText;
            set => tbButton.SelectedText = value;
        }


        private void tbButton_TextChanged(object sender, EventArgs e)
        {
            OnTextChanged(e);
        }

        private void lbButton_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
