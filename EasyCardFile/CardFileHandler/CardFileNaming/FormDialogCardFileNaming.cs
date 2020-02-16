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
using VPKSoft.LangLib;

namespace EasyCardFile.CardFileHandler.CardFileNaming
{
    /// <summary>
    /// A dialog form to set up card file card naming instruction for a specific card file.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogCardFileNaming : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogCardFileNaming"/> class.
        /// </summary>
        public FormDialogCardFileNaming()
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
        }

        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// <param name="owner">Any object that implements <see cref="T:System.Windows.Forms.IWin32Window" /> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="cardNaming">The string containing the card naming instructions for the card file.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.ArgumentException">The form specified in the <paramref name="owner" /> parameter is the same as the form being shown.</exception>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(IWin32Window owner, ref string cardNaming)
        {
            var form = new FormDialogCardFileNaming {tbCardNamingInstruction = {Text = cardNaming}};

            var result = form.ShowDialog(owner);

            if (result == DialogResult.OK)
            {
                cardNaming = form.tbCardNamingInstruction.Text;
            }

            return result;
        }

        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// <param name="cardNaming">The string containing the card naming instructions for the card file.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(ref string cardNaming)
        {
            return ShowDialog(null, ref cardNaming);
        }

        private void lbAddCustomFormat_Click(object sender, EventArgs e)
        {
            var comboBox = cmbDateTimeCustomFormats;
            if (comboBox.Text.Trim() != string.Empty)
            {
                tbCardNamingInstruction.SelectedText = "[" + comboBox.Text + "]";
            }
        }

        private void cardNamingInstruction_Changed(object sender, EventArgs e)
        {
            var cardNaming = CardNaming.NameCard(tbCardNamingInstruction.Text, (int)nudNamingNumbers.Value, DateTime.Now);

            btOk.Enabled = tbCardNamingInstruction.Text.Trim() != string.Empty;

            tbNamingInstructionSample.Text = cardNaming;
        }

        private void commonDateTime_Click(object sender, EventArgs e)
        {
            if (sender.Equals(lbNamingCommonDate))
            {
                tbCardNamingInstruction.SelectedText += cbLongDate.Checked ? "[D]" : "[d]";
            }
            else if (sender.Equals(lbNamingCommonTime))
            {
                tbCardNamingInstruction.SelectedText += cbLongTime.Checked ? "[T]" : "[t]";
            }
            else if (sender.Equals(lbNamingCommonDateTime))
            {
                tbCardNamingInstruction.SelectedText += cbLongDateTime.Checked ? "[F]" : "[f]";
            }
            else if (sender.Equals(lbNamingNumbers))
            {
                tbCardNamingInstruction.SelectedText += "[###]";
            }
        }

        private void lbAddReadManualDateTime_Click(object sender, EventArgs e)
        {
            // help the user although in english
            System.Diagnostics.Process.Start(
                "https://docs.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings");
        }

        private void btnClearNaming_Click(object sender, EventArgs e)
        {
            tbCardNamingInstruction.Text = string.Empty;
        }
    }
}
