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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.ErrorHandling;

namespace EasyCardFile.CardFileHandler.LegacyCardFile
{
    /// <summary>
    /// A class to support the old version of card naming.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class CardNamingOld: ErrorHandlingBase
    {
        /// <summary>
        /// Gets or sets the previous date and/or time formatting with the card naming.
        /// </summary>
        [SuppressMessage("ReSharper", "StringLiteralTypo")]
        private static string[] PreviousFormatting { get; } = {
            "dddd",
            "ddd",
            "dd",
            "d",
            "MMMM",
            "MMM",
            "MM",
            "M",
            "yyyy",
            "yy",
            "hh",
            "h",
            "HH",
            "H",
            "mm",
            "m",
            "ss",
            "s",
            "zzz",
            "z",
            "AP",
            "A",
            "ap",
            "a"
        };


        /// <summary>
        /// Formats the card naming using the previous naming rules from the 2008 -version.
        /// </summary>
        /// <param name="cardFile">The card file from which the naming rule should be gotten.</param>
        /// <returns>A formatted string containing the new card name if the naming rule exists; otherwise an empty string.</returns>
        public static string FormatPreviousNaming(CardFile cardFile)
        {
            // this is a mess, but everything is marked with a dollar sign ($), at 2008/2/x..
            const string indexerString = "$indexer[";

            string cardName = cardFile.CardNamingInstruction; // get the naming "instruction"..

            if (string.IsNullOrEmpty(cardFile.CardNamingInstruction))
            {
                return string.Empty;
            }

            try // there is a high change this night not succeed as it was blindly interpreted from a 12-year old C++ software..
            {

                var currentDateTime = DateTime.Now; // preserve the "now" ;-)

                // the previous date and time formatting..
                foreach (var previousFormat in PreviousFormatting)
                {
                    try
                    {
                        cardName = cardName.Replace("$" + previousFormat, currentDateTime.ToString(previousFormat));
                    }
                    catch (Exception ex)
                    {
                        // report the exception..
                        ExceptionLogAction?.Invoke(ex);
                    }
                }

                // initialize a "legacy" indexer..
                var cardIndexer = string.Empty;
                var cardIndexerStartPosition = 0;

                // check that there actually exists an indexer with the naming "instructions"..
                if (cardName.Contains(indexerString)) 
                {
                    cardIndexerStartPosition = cardName.IndexOf(indexerString, StringComparison.Ordinal);
                    var startIndex = cardIndexerStartPosition + indexerString.Length;
                    cardIndexer = cardName.Substring(startIndex);
                    var instructionLength = cardIndexer.IndexOf("]", StringComparison.Ordinal);
                    cardIndexer = cardIndexer.Substring(0, instructionLength);
                }

                // split the naming instruction..
                List<string> cardIndexerSplit = new List<string>(cardIndexer.Split(','));

                if (cardIndexerSplit.Count <= 2)
                {
                    cardIndexerSplit.Add(true.ToString());
                    cardIndexerSplit.Add(true.ToString());
                }

                if (cardIndexerSplit.Count <= 3)
                {
                    cardIndexerSplit.Add(true.ToString());
                }

                // do the naming "thingy" by looping stuff through.. :-)
                try 
                {
                    var cardIndexerLength = int.Parse(cardIndexerSplit[0]);
                    var cardIndexerStart = int.Parse(cardIndexerSplit[1]);
                    var dropBetween = bool.Parse(cardIndexerSplit[2]);
                    var skipOtherMarkings = bool.Parse(cardIndexerSplit[3]);

                    if (cardFile.Cards != null && cardIndexer != string.Empty)
                    {
                        var cardNameNew = cardName;

                        if (dropBetween)
                        {
                            foreach (var card in cardFile.Cards.OrderBy(f => f.CardName, StringComparer.Ordinal)
                                .Select(f => f.CardName))
                            {
                                cardNameNew = cardName.Replace(indexerString + cardIndexer + "]",
                                    // ReSharper disable twice FormatStringProblem
                                    string.Format("{0:D" + cardIndexerLength + "}", cardIndexerStart));

                                cardIndexerStart++;
                                if (!skipOtherMarkings)
                                {
                                    if (!card.Contains(cardNameNew))
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (card.Substring(cardIndexerStartPosition, cardIndexerLength) !=
                                        cardNameNew.Substring(cardIndexerStartPosition, cardIndexerLength))
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            var card = cardFile.Cards.OrderByDescending(f => f.CardName, StringComparer.Ordinal)
                                .Select(f => f.CardName).FirstOrDefault();

                            if (card != null)
                            {
                                cardNameNew = cardName.Replace(indexerString + cardIndexer + "]",
                                    string.Format("{0:D" + cardIndexerLength + "}", int.Parse(card) + 1));
                            }
                        }

                        return cardNameNew;
                    }
                }
                catch (Exception ex)
                {
                    // report the exception..
                    ExceptionLogAction?.Invoke(ex);
                }

                return cardName;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return cardName;
        }
    }
}
