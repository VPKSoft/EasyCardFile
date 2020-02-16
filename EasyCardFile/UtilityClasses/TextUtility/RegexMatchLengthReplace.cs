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
using System.Text.RegularExpressions;

namespace EasyCardFile.UtilityClasses.TextUtility
{
    /// <summary>
    /// Some helper methods for regular expressions and strings.
    /// </summary>
    public static class RegexMatchLengthReplace
    {
        /// <summary>
        /// Replaces the regular exception matches of a given string with a given Func using the regular expression match length.
        /// </summary>
        /// <param name="value">The string instance.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="padCharacter">The padding character to pass for the <paramref name="replacementFunc"/>.</param>
        /// <param name="replacementFunc">The replacement function to generate the replacement value for the regular expression pattern.</param>
        /// <returns>Returns a new string in which a specified regular expression pattern matches are replaced with the result value of the given Func.</returns>
        /// <exception cref="ArgumentOutOfRangeException">replacementFunc - The replacement generator function must return a string with length of the given parameter.</exception>
        public static string ReplaceLength(this string value, string pattern, char padCharacter, Func<int, char, string> replacementFunc)
        {
            var match = Regex.Match(value, pattern);
            while (match.Success)
            {
                value = value.Remove(match.Index, match.Length);

                var replacement = replacementFunc(match.Length, padCharacter);

                if (replacement.Length < match.Length - (pattern.Length - match.Value.Length))
                {
                    throw new ArgumentOutOfRangeException(nameof(replacementFunc),
                        @"The replacement generator function must return a string with length of the given parameter.");
                }

                value = value.Insert(match.Index, replacement);

                match = Regex.Match(value, pattern);
            }

            return value;
        }

        /// <summary>
        /// Replaces the regular exception matches of a given string with a given Func.
        /// </summary>
        /// <param name="value">The string instance.</param>
        /// <param name="pattern">The regular expression pattern to match.</param>
        /// <param name="replacementFunc">The replacement function to generate the replacement value for the regular expression pattern.</param>
        /// <returns>Returns a new string in which a specified regular expression pattern matches are replaced with the result value of the given Func.</returns>
        public static string ReplaceMatch(this string value, string pattern, Func<string, string> replacementFunc)
        {
            var match = Regex.Match(value, pattern);
            while (match.Success)
            {
                value = value.Remove(match.Index, match.Length);
                var replacement = replacementFunc(match.Value);

                value = value.Insert(match.Index, replacement);

                match = Regex.Match(value, pattern);
            }

            return value;
        }
    }
}
