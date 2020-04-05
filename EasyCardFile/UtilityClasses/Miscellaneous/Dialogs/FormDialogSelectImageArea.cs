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

using System.Drawing;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.ModelHelpers;
using EasyCardFile.Database.NoEntity;
using EasyCardFile.UtilityClasses.Localization;
using VPKSoft.LangLib;

namespace EasyCardFile.UtilityClasses.Miscellaneous.Dialogs
{

    /// <summary>
    /// A dialog to select an image for a card type.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogSelectImageArea : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyCardFile.UtilityClasses.Miscellaneous.Dialogs.FormDialogSelectImageArea"/> class.
        /// </summary>
        public FormDialogSelectImageArea()
        {
            InitializeComponent();

            // ReSharper disable once StringLiteralTypo
            DBLangEngine.DBName = "localization.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages",
                    Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            // initialize the language/localization database..
            DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages");

            // localize the open image file dialog..
            LocalizeStaticProperties.LocalizeDialogOpenImageFile(odImage);
        }

        private CardTypeNoEntity CardType { get; set; }

        /// <summary>
        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// </summary>
        /// <param name="owner">Any object that implements <see cref="T:System.Windows.Forms.IWin32Window" /> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="cardType">Type of the card to select an image for.</param>
        /// <param name="squareAspectRatio">A value indicating whether the selected image should be a square.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.ArgumentException">The form specified in the <paramref name="owner" /> parameter is the same as the form being shown.</exception>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(IWin32Window owner, CardTypeNoEntity cardType, bool squareAspectRatio)
        {
            var form = new FormDialogSelectImageArea
            {
                CardType = cardType, iasCartTypeImage = {RequireRectangle = squareAspectRatio}
            };

            return form.ShowDialog();
        }

        private void FormDialogSelectImageArea_Shown(object sender, System.EventArgs e)
        {
            Text = DBLangEngine.GetMessage("msgSelectCardImageTitle",
                "Select an image for the card type '[{0}]'|A title for a dialog to select a part of an image to be used with a card type.", CardType.CardTypeName);
        }

        private void btOpenImage_Click(object sender, System.EventArgs e)
        {
            odImage.InitialDirectory = FormMain.Settings.PathImageDialogSelectImageArea;
            if (odImage.ShowDialog(this) == DialogResult.OK)
            {
                FormMain.Settings.PathImageDialogSelectImageArea = odImage.FileName.GetPath(FormMain.Settings.PathImageDialogSelectImageArea);
                iasCartTypeImage.SelectImage?.Dispose();
                iasCartTypeImage.SelectImage = Image.FromFile(odImage.FileName);
            }
        }

        private void FormDialogSelectImageArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            iasCartTypeImage.SelectImage?.Dispose();
        }

        private bool firstCheck = true;

        private void iasCartTypeImage_SelectedImageChanged(object sender, VPKSoft.ImageAreaSelector.ImageSelectionChangedEventArgs e)
        {
            var bitmap = new Bitmap(e.SelectedImageArea);
            if (bitmap.Width < pnSelectedImageArea.ClientSize.Height &&
                bitmap.Height < pnSelectedImageArea.ClientSize.Height && (!cbZoomImage.Checked || firstCheck))
            {
                pnSelectedImageArea.BackgroundImageLayout = ImageLayout.Center;
                cbZoomImage.Checked = false;
                firstCheck = false;
            }
            else
            {
                pnSelectedImageArea.BackgroundImageLayout = ImageLayout.Zoom;
                cbZoomImage.Checked = true;
                firstCheck = false;
            }
            pnSelectedImageArea.BackgroundImage?.Dispose();
            pnSelectedImageArea.BackgroundImage = bitmap;
            btOK.Enabled = true;
        }

        private void btOK_Click(object sender, System.EventArgs e)
        {
            CardType.TypeImage = pnSelectedImageArea.BackgroundImage.ToBytes();
            pnSelectedImageArea.BackgroundImage.Dispose();
            DialogResult = DialogResult.OK;
        }

        private void cbZoomImage_CheckedChanged(object sender, System.EventArgs e)
        {
            if (firstCheck)
            {
                return;
            }
            var checkBox = (CheckBox) sender;
            pnSelectedImageArea.BackgroundImageLayout = checkBox.Checked ? ImageLayout.Zoom : ImageLayout.Center;
        }
    }
}
