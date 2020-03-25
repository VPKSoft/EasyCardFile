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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using EasyCardFile.Database.Entity.Enumerations;

namespace EasyCardFile.Database.Entity.Entities
{
    /// <summary>
    /// A class representing a card file in the database.
    /// Implements the <see cref="EasyCardFile.Database.Entity.IEntity" />
    /// </summary>
    /// <seealso cref="EasyCardFile.Database.Entity.IEntity" />
    public class CardFile: IEntity
    {
        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the card file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the cards belonging to the card file.
        /// </summary>
        public virtual ICollection<Card> Cards { get; set; }

        /// <summary>
        /// Gets or sets the card types belonging to the card file.
        /// </summary>
        public virtual ICollection<CardType> CardTypes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the card file is encrypted.
        /// </summary>
        public bool Encrypted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the card file is compressed.
        /// </summary>
        public bool Compressed { get; set; }

        /// <summary>
        /// Gets or sets the card naming instruction.
        /// </summary>
        public string CardNamingInstruction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a card can be named alphabetically between other cards.
        /// </summary>
        public bool CardNamingDropBetween { get; set; }

        /// <summary>
        /// Gets or sets the password hash as a base64 encoded string.
        /// </summary>
        [NotMapped]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the default type of the card.
        /// </summary>
        public CardType DefaultCardType { get; set; }

        /// <summary>
        /// Gets or sets the type of how the cards should be sorted, the first ordering.
        /// </summary>
        public CardSortType CardSortType1 { get; set; } = CardSortType.None;

        /// <summary>
        /// Gets or sets the type of how the cards should be sorted, the second ordering.
        /// </summary>
        public CardSortType CardSortType2 { get; set; } = CardSortType.None;

        /// <summary>
        /// Gets or sets the type of how the cards should be sorted, the third ordering.
        /// </summary>
        public CardSortType CardSortType3 { get; set; } = CardSortType.None;

        /// <summary>
        /// Gets or sets the type of how the cards should be sorted, the fourth ordering.
        /// </summary>
        public CardSortType CardSortType4 { get; set; } = CardSortType.None;

        /// <summary>
        /// Gets the four defined card sort types <see cref="CardSortType"/> in a list format.
        /// </summary>
        [NotMapped]
        public List<CardSortType> CardSortTypes => new List<CardSortType>(new []{ CardSortType1, CardSortType2, CardSortType3, CardSortType4});

        /// <summary>
        /// Sorts the card file cards with the rules defined for the card file.
        /// </summary>
        public void SortCards()
        {
            Cards = SortCardList(Cards, CardSortType1)?.ToList();
            Cards = SortCardList(Cards, CardSortType2)?.ToList();
            Cards = SortCardList(Cards, CardSortType3)?.ToList();
            Cards = SortCardList(Cards, CardSortType4)?.ToList();
        }

        /// <summary>
        /// Sorts the card collection with given <see cref="CardSortType"/> enumeration value.
        /// </summary>
        /// <param name="cards">The collection of cards to sort.</param>
        /// <param name="cardSortType">The <see cref="CardSortType"/> enumeration value indicating the sorting style for the card.</param>
        /// <returns>IEnumerable&lt;Card&gt;.</returns>
        public static IEnumerable<Card> SortCardList(ICollection<Card> cards, CardSortType cardSortType)
        {
            bool ignoreCase = cardSortType.HasFlag(CardSortType.IgnoreCase);
            if (cardSortType.HasFlag(CardSortType.Alphabetical))
            {
                return cards?.OrderBy(f => f.CardName,
                    ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
            }

            if (cardSortType.HasFlag(CardSortType.AlphabeticalDescending))
            {
                return cards?.OrderByDescending(f => f.CardName,
                    ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
            }

            if (cardSortType.HasFlag(CardSortType.Created))
            {
                return cards?.OrderBy(f => f.CreateDateTime);
            }

            if (cardSortType.HasFlag(CardSortType.CreatedDescending))
            {
                return cards?.OrderByDescending(f => f.CreateDateTime);
            }

            if (cardSortType.HasFlag(CardSortType.Modified))
            {
                return cards?.OrderBy(f => f.ModifiedDateTime);
            }

            if (cardSortType.HasFlag(CardSortType.ModifiedDescending))
            {
                return cards?.OrderByDescending(f => f.ModifiedDateTime);
            }

            if (cardSortType.HasFlag(CardSortType.CardType))
            {
                return cards?.OrderByDescending(f => f.CardType?.CardTypeName,
                    ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
            }

            if (cardSortType.HasFlag(CardSortType.CardTypeDescending))
            {
                return cards?.OrderByDescending(f => f.CardType?.CardTypeName,
                    ignoreCase ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
            }

            return cards;
        }

        /// <summary>
        /// Gets or sets the encryption password validation randomized value. This is Base64 encoded binary data.
        /// </summary>
        public string EncryptionPasswordValidationRandomizedBase64 { get; set; }

        /// <summary>
        /// Gets or sets the encryption hash algorithm value containing the hash
        /// value of unencrypted <see cref="EncryptionPasswordValidationRandomizedBase64"/> property value. This is Base64 encoded binary data.
        /// </summary>
        public string EncryptionHashAlgorithmValueBase64 { get; set; }

        /// <summary>
        /// Gets or sets the width of the <see cref="CardType.TypeImage"/> image.
        /// </summary>
        public int ImageWidth { get; set; } = 16;

        /// <summary>
        /// Gets or sets the Height of the <see cref="CardType.TypeImage"/> image.
        /// </summary>
        public int ImageHeight { get; set; } = 16;

        /// <summary>
        /// Gets or sets the font to use in the card list.
        /// </summary>
        public string CardFont { get; set; }

        /// <summary>
        /// Gets or sets the additional data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public string AdditionalData1 { get; set; }

        /// <summary>
        /// Gets or sets the additional data 2. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public string AdditionalData2 { get; set; }

        /// <summary>
        /// Gets or sets the additional numeric data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public int IntData1 { get; set; }

        /// <summary>
        /// Gets or sets the additional numeric data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public int IntData2 { get; set; }
    }
}
