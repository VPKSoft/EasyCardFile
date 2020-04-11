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
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Windows.Forms;
using SQLite.CodeFirst;

namespace EasyCardFile.Database.Entity.Entities
{
    /// <summary>
    /// A class representing a single card file card in the database.
    /// Implements the <see cref="EasyCardFile.Database.Entity.IEntity" />
    /// </summary>
    /// <seealso cref="EasyCardFile.Database.Entity.IEntity" />
    public class Card: IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        public Card()
        {
            UniqueId = _uniqueIdCounter++;
        }

        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the card.
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// Gets or sets the card contents. This is in RTF format and can be compressed and/or encrypted.
        /// </summary>
        public byte [] CardContents { get; set; }

        private string cardContentsPlain;

        /// <summary>
        /// Gets the card contents as plain text for searching purposes.
        /// </summary>
        /// <returns>A string containing the cards contents as plain text.</returns>
        public string GetCardContentsPlain()
        {
            return GetCardContentsPlain(false);
        }

        /// <summary>
        /// Gets the card the contents as a string.
        /// </summary>
        /// <returns>A string containing the entire card contents.</returns>
        public string CardContentsString()
        {
            return Encoding.UTF8.GetString(CardContents);
        }

        /// <summary>
        /// Gets the card contents as plain text for searching purposes.
        /// </summary>
        /// <returns>A string containing the cards contents as plain text.</returns>
        public string GetCardContentsPlain(bool reset)
        {
            if (cardContentsPlain == null || reset)
            {
                if (RichTextBoxConvert == null)
                {
                    RichTextBoxConvert = new RichTextBox();
                }

                RichTextBoxConvert.Rtf = Encoding.UTF8.GetString(CardContents);
                cardContentsPlain = RichTextBoxConvert.Text;
                RichTextBoxConvert.Clear();
                RichTextBoxConvert.ClearUndo();
            }

            return cardContentsPlain;
        }

        /// <summary>
        /// Gets or sets the type of the card.
        /// </summary>
        public CardType CardType { get; set; }

        /// <summary>
        /// Gets or sets the ordering of the card in a list.
        /// </summary>
        public int Ordering { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use word wrap while displaying the card contents.
        /// </summary>
        public bool WordWrap { get; set; }

        /// <summary>
        /// Gets or sets the card file the card belongs to.
        /// </summary>
        public virtual CardFile CardFile { get; set; }

        /// <summary>
        /// Gets or sets the date and time the card was created.
        /// </summary>
        /// <value>The create date time.</value>
        [SqlDefaultValue(DefaultValue = "DATETIME('now', 'localtime')")]
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date and time the card was modified.
        /// </summary>
        [SqlDefaultValue(DefaultValue = "DATETIME('now', 'localtime')")]
        public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the additional data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public string AdditionalData1 { get; set; }

        /// <summary>
        /// Gets or sets the additional numeric data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public int IntData1 { get; set; }

        private static int _uniqueIdCounter;

        /// <summary>
        /// Gets the an unique run-time identifier for the class instance.
        /// </summary>
        [NotMapped]
        public int UniqueId { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return CardName;
        }

        private static RichTextBox RichTextBoxConvert { get; set; }
    }
}
