#region License
/*
MIT License

Copyright(c) 2019 Petteri Kautonen

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
using System.Text;
using EasyCardFile.Database.Compression;
using EasyCardFile.UtilityClasses.ErrorHandling;

namespace EasyCardFile.Database.Entity.Context.ContextCompression
{
    /// <summary>
    /// A helper class to compress or decompress a <see cref="CardFileDbContext"/> instance.
    /// </summary>
    public static class ContextCompressionHelper
    {
        /// <summary>
        /// Saves the <see cref="CardFileDbContext"/> with compression. Use this extension only when the card file is closing.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <param name="encoding">The encoding to be used to get the bytes of the string properties to compress.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool SaveWithCompression(this CardFileDbContext cardFileDbContext, Encoding encoding)
        {
            var cardFile = cardFileDbContext.CardFile;

            try
            {
                if (!cardFile.Compressed)
                {
                    return false;
                }

                cardFile.Name = cardFile.Name.CompressToBase64(encoding);
                cardFile.CardNamingInstruction = cardFile.CardNamingInstruction.CompressToBase64(encoding);

                foreach (var card in cardFile.Cards)
                {
                    card.CardName = card.CardName.CompressToBase64(encoding);
                    card.CardContents = DatabaseCompressionHelper.CompressData(card.CardContents);
                }

                foreach (var cardType in cardFile.CardTypes)
                {
                    cardType.CardTypeName = cardType.CardTypeName.CompressToBase64(encoding);
                }

                cardFileDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loads the <see cref="CardFileDbContext"/> with compression. Use this extension only when the card file is opened.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <param name="encoding">The encoding of the string data of the card file.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool LoadWithCompression(this CardFileDbContext cardFileDbContext, Encoding encoding)
        {
            var cardFile = cardFileDbContext.CardFile;

            try
            {
                if (!cardFile.Compressed)
                {
                    return false;
                }

                cardFile.Name = cardFile.Name.DecompressFromBase64(encoding);
                cardFile.CardNamingInstruction = cardFile.CardNamingInstruction.DecompressFromBase64(encoding);

                foreach (var card in cardFile.Cards)
                {
                    card.CardName = card.CardName.DecompressFromBase64(encoding);
                    card.CardContents = DatabaseCompressionHelper.DecompressData(card.CardContents);
                }

                foreach (var cardType in cardFile.CardTypes)
                {
                    cardType.CardTypeName = cardType.CardTypeName.DecompressFromBase64(encoding);
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }

            return true;
        }
    }
}
