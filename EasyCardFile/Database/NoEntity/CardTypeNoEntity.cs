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

using EasyCardFile.Database.Entity.Entities;

namespace EasyCardFile.Database.NoEntity
{
    /// <summary>
    /// A class representing a single card type not in the database.
    /// </summary>
    public class CardTypeNoEntity
    {
        /// <summary>
        /// Generates an instance of the <see cref="CardTypeNoEntity"/> class from an instance of the <see cref="CardType"/> entity class.
        /// </summary>
        /// <param name="cardType">Type of the card.</param>
        /// <param name="isDefaultType">A value indicating whether the instance represents the default card type of a <see cref="CardFile"/>.</param>
        /// <returns>CardTypeNoEntity.</returns>
        public static CardTypeNoEntity FromEntity(CardType cardType, bool isDefaultType)
        {
            return cardType == null
                ? new CardTypeNoEntity {CardTypeName = CardType.NewCardTypeNameLocalized, DefaultCardType = true, Id = -1}
                : new CardTypeNoEntity
                {
                    Id = cardType.Id, CardTypeName = cardType.CardTypeName, AdditionalData1 = cardType.AdditionalData1,
                    DefaultCardType = isDefaultType
                };
        }

        /// <summary>
        /// Sets the matching values to <see cref="CardFile"/> class instance.
        /// </summary>
        /// <param name="cardTypeNoEntity">The non-entity card type which values to set for the entity version.</param>
        /// <param name="cardType">The entity cart type which values to set from the non-entity version.</param>
        public static void SetToEntity(CardTypeNoEntity cardTypeNoEntity, ref CardType cardType)
        {
            cardType.CardTypeName = cardTypeNoEntity.CardTypeName;
            cardType.CardNamingInstruction = cardTypeNoEntity.CardNamingInstruction;
            cardType.AdditionalData1 = cardTypeNoEntity.AdditionalData1;
        }

        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the card type.
        /// </summary>
        public string CardTypeName { get; set; }

        /// <summary>
        /// Gets or sets the card naming instruction.
        /// </summary>
        public string CardNamingInstruction { get; set; }

        /// <summary>
        /// Gets or sets the additional data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public string AdditionalData1 { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance represents the default card type.
        /// </summary>
        public bool DefaultCardType { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return CardTypeName;
        }
    }
}
