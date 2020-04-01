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

using EasyCardFile.Database.NoEntity;

namespace EasyCardFile.Database.Entity.History
{
    /// <summary>
    /// A class to contain change history snapshot for the <see cref="UndoRedo"/> class.
    /// </summary>
    public class UndoRedoItem
    {
        /// <summary>
        /// Gets or sets the changed card item.
        /// </summary>
        public CardNoEntity CardItemChanged { get; set; }

        /// <summary>
        /// Gets or sets the card item before change.
        /// </summary>
        public CardNoEntity CardItemBeforeChange { get; set; }

        /// <summary>
        /// Gets or sets the type of the undo/redo operation which to negate for.
        /// </summary>
        public UndoRedoType UndoRedoType { get; set; }
    }
}
