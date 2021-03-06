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

using System.ComponentModel.DataAnnotations.Schema;
using SQLite.CodeFirst;

namespace EasyCardFile.Database.Entity.Entities
{
    /// <summary>
    /// A class representing a single card type in the database.
    /// Implements the <see cref="IEntity" />
    /// </summary>
    public class CardType: IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardType"/> class.
        /// </summary>
        public CardType()
        {
            UniqueId = _uniqueIdCounter++;
        }

        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the card type.
        /// </summary>
        [Unique]
        public string CardTypeName { get; set; }

        /// <summary>
        /// Gets or sets the card file the card type belongs to.
        /// </summary>
        public virtual CardFile CardFile { get; set; }

        /// <summary>
        /// Gets or sets the card naming instruction.
        /// </summary>
        public string CardNamingInstruction { get; set; }

        /// <summary>
        /// Gets or sets the foreground color for the card type.
        /// </summary>
        public string ForeColor { get; set; }

        /// <summary>
        /// Gets or sets the background color for the card type.
        /// </summary>
        public string BackColor { get; set; }

        /// <summary>
        /// Gets or sets the card type image.
        /// </summary>
        public byte[] TypeImage { get; set; }

        /// <summary>
        /// Creates new localized card type name (a default).
        /// </summary>
        /// <value>The new card type name localized.</value>
        [NotMapped]
        public static string NewCardTypeNameLocalized { get; set; }

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
        public int UniqueId { get; }

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
