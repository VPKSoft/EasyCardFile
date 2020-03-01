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

namespace EasyCardFile.UtilityClasses.Miscellaneous
{
    /// <summary>
    /// Defines a pair that can be set or retrieved.
    /// </summary>
    /// <typeparam name="TPairFirst">The type of the first part of the pair.</typeparam>
    /// <typeparam name="TPairSecond">The type of the second part of the pair.</typeparam>
    public class Pair<TPairFirst, TPairSecond>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pair{TPairFirst, TPairSecond}"/> class.
        /// </summary>
        public Pair()
        {
            PairFirst = default;
            PairSecond = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pair{TPairFirst, TPairSecond}"/> class.
        /// </summary>
        /// <param name="pairFirst">The first object defined in each first/second pair.</param>
        /// <param name="pairSecond">The second object defined in each first/second pair.</param>
        public Pair(TPairFirst pairFirst, TPairSecond pairSecond)
        {
            PairFirst = pairFirst;
            PairSecond = pairSecond;
        }

        /// <summary>
        /// Gets or sets the first pair defined in this instance.
        /// </summary>
        public TPairFirst PairFirst { get; set; }

        /// <summary>
        /// Gets or sets the second pair defined in this instance.
        /// </summary>
        public TPairSecond PairSecond { get; set; }
    }
}
