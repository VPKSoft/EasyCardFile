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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.ErrorHandling;
using EasyCardFile.UtilityClasses.Localization;
using EasyCardFile.UtilityClasses.TextUtility;
using VPKSoft.ErrorLogger;

namespace EasyCardFile.CardFileHandler.CardFileNaming
{
    /// <summary>
    /// A class for helping to name a new card in a <see cref="CardFile"/>.
    /// </summary>
    public class CardNaming: ErrorHandlingBase
    {
        // Universal symbol for a number with padding, #n? Without padding, square braces #?n ?

        /// <summary>
        /// Names a card file card.
        /// </summary>
        /// <param name="cardNamingInstruction">The card naming instruction string.</param>
        /// <param name="counterValue">The counter value from one and onward.</param>
        /// <param name="dateTime">The date and time to be used for the card naming.</param>
        /// <param name="padCharacter">The pad character to pad the number.</param>
        /// <returns>A formatted string containing the new card name.</returns>
        public static string NameCard(string cardNamingInstruction, int counterValue, DateTime dateTime, char padCharacter = '0')
        {
            var cardNaming = cardNamingInstruction;

            // the numbering formula consists of '#' characters N times surrounded with square brackets '[' and ']'..
            cardNaming = cardNaming.ReplaceLength("\\[{1}#+\\]{1}", padCharacter,
                (padAmount, c) =>
                    counterValue.ToString().PadLeft(padAmount - 2, padCharacter));

            // the date and time formula consists of date and/or time formatting strings surrounded with square brackets '[' and ']'..
            try
            {
                cardNaming = cardNaming.ReplaceMatch("\\[{1}[^\\[|\\]]+\\]{1}", (s) =>
                    dateTime.ToString(s.TrimStart('[').TrimEnd(']')));
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogError(ex);
            }

            return cardNaming;
        }

        /// <summary>
        /// Names a card file card.
        /// </summary>
        /// <param name="cardFile">The card file containing the card naming instructions and the other cards.</param>
        /// <param name="dateTime">The date and time to be used for the card naming.</param>
        /// <param name="padCharacter">The pad character to pad the number.</param>
        /// <returns>A formatted string containing the new card name.</returns>
        public static string NameCard(CardFile cardFile, DateTime dateTime, char padCharacter = '0')
        {
            var cardNaming = cardFile.CardNamingInstruction;

            if (cardNaming == null) // not defined..
            {
                return string.Empty;
            }

            if (cardFile.Cards == null)
            {
                return NameCard(cardNaming, 1, dateTime, padCharacter);
            }


            if (cardNaming.Trim() == string.Empty)
            {
                return cardNaming;
            }

            var testFormula = NameCard(cardNaming, 1, dateTime, padCharacter);

            if (testFormula == cardNaming) // test that the card naming actually changes something to avoid an endless loop..
            {
                return testFormula;
            }

            if (cardFile.CardNamingDropBetween)
            {
                var cardNames = cardFile.Cards.Select(f => f.CardName).OrderBy(f => f, StringComparer.Ordinal).ToList();

                var counter = 1;

                for (int i = 0; i < cardNames.Count - 1; i++)
                {
                    var cardName = NameCard(cardNaming, counter++, dateTime, padCharacter);

                    if (string.Compare(cardNames[i], cardName, StringComparison.Ordinal) < 0 &&
                        string.Compare(cardNames[i + 1], cardName, StringComparison.Ordinal) > 0)
                    {
                        return cardName;
                    }
                }
            }
            else
            {
                var lastName = cardFile.Cards.Select(f => f.CardName).OrderBy(f => f, StringComparer.Ordinal)
                    .LastOrDefault();

                var counter = 1;
                var newName = NameCard(cardNaming, counter++, dateTime, padCharacter);

                while (string.CompareOrdinal(newName, lastName) <= 0)
                {
                    newName = NameCard(cardNaming, counter++, dateTime, padCharacter);
                }

                return newName;
            }

            return NameCard(cardNaming, 1, dateTime, padCharacter);
        }
    }
}
