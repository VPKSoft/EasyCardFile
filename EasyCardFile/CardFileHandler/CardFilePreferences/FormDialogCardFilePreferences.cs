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
using System.Windows.Forms;
using EasyCardFile.CardFileHandler.CardFileNaming;
using EasyCardFile.Database.Entity.Entities;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;

namespace EasyCardFile.CardFileHandler.CardFilePreferences
{
    /// <summary>
    /// A dialog form for to set preferences to the current card file.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogCardFilePreferences : DBLangEngineWinforms
    {
        /// <summary>Initializes a new instance of the <see cref="T:EasyCardFile.CardFileHandler.CardFilePreferences.FormDialogCardFilePreferences"/> class.</summary>
        public FormDialogCardFilePreferences()
        {
            InitializeComponent();
        }

        private CardFile CardFile { get; set; }

        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// <param name="owner">Any object that implements <see cref="T:System.Windows.Forms.IWin32Window" /> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="cardFile">The card file which to configure.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.ArgumentException">The form specified in the <paramref name="owner" /> parameter is the same as the form being shown.</exception>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(IWin32Window owner, CardFile cardFile)
        {
            if (cardFile == null)
            {
                return DialogResult.Cancel;
            }

            var form = new FormDialogCardFilePreferences {CardFile = cardFile};
            return form.ShowDialog(owner);
        }

        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// <param name="cardFile">The card file which to configure.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(CardFile cardFile)
        {
            return ShowDialog(null, cardFile);
        }

        private void tbbCardNamingInstruction_Click(object sender, EventArgs e)
        {
            var naming = tbbCardNamingInstruction.Text;
            if (FormDialogCardFileNaming.ShowDialog(this, ref naming) == DialogResult.OK)
            {
                tbbCardNamingInstruction.Text = naming;
            }
        }

        private void FormDialogCardFilePreferences_Shown(object sender, EventArgs e)
        {
            tbCardFileName.Text = CardFile.Name;
            cbEncryption.Checked = CardFile.Encrypted;
            cbCompression.Checked = CardFile.Compressed;
            tbbCardNamingInstruction.Text = CardFile.CardNamingInstruction;
            cbCardsDropBetween.Checked = CardFile.CardNamingDropBetween;

            foreach (var cardType in CardFile.CardTypes)
            {
                dgvCardTypes.Rows.Add(CardFile.DefaultCardType.Id == cardType.Id, cardType.CardTypeName);
            }
        }

        private void dgvCardTypes_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            lbRowErrorText.Text = string.Empty;

            foreach (DataGridViewRow row in dgvCardTypes.Rows)
            {
                if (row.Index != e.RowIndex && 
                    !(string.IsNullOrWhiteSpace(e.FormattedValue.ToString()) || string.IsNullOrWhiteSpace(row.Cells[colName.Index].Value.ToString())) &&
                    row.Cells[colName.Index].Value.ToString() == e.FormattedValue.ToString().Trim())
                {
                    e.Cancel = true;
                    lbRowErrorText.Text =
                        DBLangEngine.GetMessage("msgCardTypeNameUniqueError",
                            "The card type name must be unique and can not be an empty string!|A message indicating that the name of the card type must be unique compared to other card types. Also the card type name can not be an empty string.");
                    break;
                }
            }
        }

        private void cbEncryption_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox) sender;

            if (checkBox.Checked && !CardFile.Encrypted)
            {
                var password1 = MessageBoxQueryPassword.Show(this,
                    DBLangEngine.GetMessage("msgQueryPassword1",
                        "Enter a password to protect the card file|A message querying the user to enter a password for the first time to protect the card file"),
                    DBLangEngine.GetMessage("msgEnterPassword",
                        "Give a password|A message querying a password from the user with the card file protection"));

                if (string.IsNullOrWhiteSpace(password1))
                {
                    return;
                }

                var password2 = MessageBoxQueryPassword.Show(this,
                    DBLangEngine.GetMessage("msgQueryPassword2",
                        "Re-enter the password for confirmation|A message querying the user to enter a password for the second time for confirmation purpose"),
                    DBLangEngine.GetMessage("msgEnterPasswordConfirm",
                        "Confirm the password|A message querying a password confirmation from the user with the card file protection"));

                if (string.IsNullOrWhiteSpace(password2))
                {
                    return;
                }

                if (password1 != password2)
                {
                    MessageBox.Show(DBLangEngine.GetMessage("msgPasswordMisMach",
                        "The entered passwords do not match. Please try again.|The user entered two different passwords so an error message is displayed."));
                    checkBox.Checked = false;
                }
            }
            else if (!checkBox.Checked && CardFile.Encrypted)
            {
                var password1 = MessageBoxQueryPassword.Show(this,
                    DBLangEngine.GetMessage("msgQueryPassword1",
                        "Enter a password to remove the encryption from the card file|A message querying the user to enter a password for the first time to protect the card file"),
                    DBLangEngine.GetMessage("msgEnterPassword",
                        "Give a password|A message querying a password from the user with the card file protection"));

                if (string.IsNullOrWhiteSpace(password1))
                {
                    MessageBox.Show(DBLangEngine.GetMessage("msgPasswordMisMach",
                        "The entered passwords do not match. Please try again.|The user entered two different passwords so an error message is displayed."));
                }
            }
        }
    }
}
