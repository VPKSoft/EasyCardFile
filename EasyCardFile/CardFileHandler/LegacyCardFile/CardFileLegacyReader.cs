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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.ErrorHandling;
using LegacySupportQTVersion;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;

namespace EasyCardFile.CardFileHandler.LegacyCardFile
{
    /// <summary>
    /// A class to convert legacy card files (v.2008, 12 years old) files to the new format.
    /// </summary>
    public class CardFileLegacyReader: ErrorHandlingBase
    {
        // ReSharper disable once CommentTypo
        /// <summary>
        /// Converts an old format file from the (Easy Cardfile Professional (© VPKSoft 2008)) to the new format.
        /// </summary>
        /// <param name="openFileDialog">The open file dialog to open the previous format.</param>
        /// <param name="saveFileDialog">The save file dialog to save the to the new format.</param>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog boxes opened by this method.</param>
        /// <returns><c>true</c> if the old format file was converted successfully, <c>false</c> otherwise.</returns>
        public static bool Convert(OpenFileDialog openFileDialog, SaveFileDialog saveFileDialog, IWin32Window owner)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    saveFileDialog.InitialDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                    saveFileDialog.FileName = Path.ChangeExtension(Path.GetFileName(openFileDialog.FileName), ".ecff");
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var password = "";
                        if (CardFileDataReader.IsEncrypted(openFileDialog.FileName))
                        {
                            if (string.IsNullOrEmpty(password =
                                MessageBoxQueryPassword.Show(owner, 
                                    DBLangEngine.GetStatMessage("msgEncryptionGiveAPassword", "The file is encrypted, please give a password.|A message indicating file encryption. A password is requested from the user."), 
                                    DBLangEngine.GetStatMessage("msgPasswordRequired", "Password is required|A short message indicating that some operation requires a valid password for the some operation to continue successfully."))))
                            {
                                return false;
                            }


                            if (!CardFileDataReader.ValidPassword(openFileDialog.FileName, password))
                            {
                                MessageBox.Show(owner,
                                    DBLangEngine.GetStatMessage("msgInvalidPassword",
                                        "The given password was invalid|The user gave an invalid password checked by the software's verification logic."),
                                    DBLangEngine.GetStatMessage("msgError",
                                        "Error|A message describing that some kind of error occurred."),
                                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                                return false;
                            }
                        }

                        if (File.Exists(saveFileDialog.FileName))
                        {
                            File.Delete(saveFileDialog.FileName);
                        }

                        var legacyReader = new CardFileDataReader(openFileDialog.FileName, password);

                        var cardFileEntry = legacyReader.GetCardFileData();

                        var cardFileNew = CardFileDbContext.InitializeDbContext(saveFileDialog.FileName);

                        var cardFile = new CardFile
                        {
                            Name = cardFileEntry.databaseName,
                            CardNamingInstruction = cardFileEntry.autoLabelInstructions,
                            Compressed = false,
                            Encrypted = false, 
                        };

                        cardFileNew.CardFiles.Add(cardFile);

                        cardFileNew.SaveChanges();

                        var cardTypes = legacyReader.GetCardTypes();
                        cardFile.CardTypes = new List<CardType>();
                        foreach (var cardType in cardTypes)
                        {
                            var cardTypeNew = new CardType {CardTypeName = cardType, CardFile = cardFile};
//                            cardFileNew.CardTypes.Add(cardTypeNew);
                            cardFile.CardTypes.Add(cardTypeNew);
                        }

                        cardFile.DefaultCardType =
                            cardFile.CardTypes?.FirstOrDefault(f =>
                                f.CardTypeName == cardFileEntry.defaultCardType);

                        cardFileNew.SaveChanges();

                        cardFile = cardFileNew.CardFiles.FirstOrDefault();

                        var ordering = 0;

                        if (cardFile != null)
                        {
                            cardFile.Cards = new List<Card>();

                            var cards = legacyReader.GetCards();
                            foreach (var card in cards)
                            {
                                var cardNew = new Card
                                {
                                    CardName = card.name,
                                    CardType = cardFile.CardTypes.FirstOrDefault(f => f.CardTypeName == card.type),
                                    Ordering = ordering++,
                                    CardContents = Encoding.UTF8.GetBytes(card.cardContents),
                                    WordWrap = card.wordWrap,
                                    CardFile = cardFile,
                                };

                                //cardFileNew.Cards.Add(cardNew);
                                cardFile.Cards.Add(cardNew);
                            }
                        }

                        cardFileNew.SaveChanges();

                        var templates = legacyReader.GetTemplates();
                        foreach (var template in templates)
                        {
                            cardFileNew.CardTemplates.Add(
                                new CardTemplate
                                {
                                    CardTemplateName = template.name,
                                    CardTemplateContents = Encoding.UTF8.GetBytes(template.templateContents),
                                });
                        }

                        CardFileDbContext.ReleaseDbContext(cardFileNew, true, true);

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }
    }
}
