﻿#region License
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Entities;
using VPKSoft.LangLib;

namespace EasyCardFile.CardFileHandler.CardFileNaming
{
    /// <summary>
    /// A form to name or rename a card file card.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogAddRenameCard : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDialogAddRenameCard"/> class.
        /// </summary>
        public FormDialogAddRenameCard()
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

        /// <summary>
        /// Gets or sets the card file the ShowMethod was called with.
        /// </summary>
        /// <value>The card file.</value>
        private CardFile CardFile { get; set; }

        /// <summary>
        /// Gets or sets the added card if the dialog was accepted without validation errors.
        /// </summary>
        private Card AddedCard { get; set; }

        /// <summary>
        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// </summary>
        /// <param name="owner">Any object that implements <see cref="T:System.Windows.Forms.IWin32Window" /> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="cardFile">The card file fow which a card is to be renamed or a new card to be added.</param>
        /// <param name="addedCard"></param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.ArgumentException">The form specified in the <paramref name="owner" /> parameter is the same as the form being shown.</exception>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(IWin32Window owner, CardFile cardFile, out Card addedCard)
        {
            var form = new FormDialogAddRenameCard
            {
                tbCardName = {Text = CardNaming.NameCard(cardFile, DateTime.Now)}, CardFile = cardFile
            };

            var result = form.ShowDialog();

            addedCard = form.AddedCard;

            return result;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (CardFile.Cards == null)
            {
                CardFile.Cards = new List<Card>();
            }

            AddedCard = new Card {CardName = tbCardName.Text, CardType = CardFile.DefaultCardType,};

            CardFile.Cards.Add(AddedCard);

            DialogResult = DialogResult.OK;
        }
    }
}
