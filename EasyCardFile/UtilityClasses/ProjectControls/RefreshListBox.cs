using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EasyCardFile.UtilityClasses.Miscellaneous;
using Enumerable = System.Linq.Enumerable;

namespace EasyCardFile.UtilityClasses.ProjectControls
{
    /// <summary>
    /// A list box that can refresh it's items.
    /// Implements the <see cref="System.Windows.Forms.ListBox" />
    /// </summary>
    /// <seealso cref="System.Windows.Forms.ListBox" />
    public class RefreshListBox: ListBox
    {
        /// <summary>
        /// Refreshes all <see cref="T:System.Windows.Forms.ListBox" /> items and retrieves new strings for them.
        /// </summary>
        public new void RefreshItems()
        {
            base.RefreshItems();
        }

        // ReSharper disable four times InconsistentNaming
        // ReSharper disable four times IdentifierTypo
        private const int LB_ADDSTRING = 0x180;
        private const int LB_INSERTSTRING = 0x181;
        private const int LB_DELETESTRING = 0x182;
        private const int LB_RESETCONTENT = 0x184;

        /// <summary>
        /// Processes Windows messages.
        /// </summary>
        /// <param name="m">The Windows <see cref="T:System.Windows.Forms.Message" /> to process.</param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == LB_ADDSTRING ||
                m.Msg == LB_INSERTSTRING ||
                m.Msg == LB_DELETESTRING ||
                m.Msg == LB_RESETCONTENT)
            {
                ItemSizes.Clear();
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshListBox"/> class.
        /// </summary>
        public RefreshListBox()
        {
            ControlGraphics = Graphics.FromHwnd(Handle);
        }

        /// <summary>
        /// Gets the item sizes to compare if the item fits the list box.
        /// </summary>
        private HashSet<Pair<object, float>> ItemSizes { get; } = new HashSet<Pair<object, float>>();

        /// <summary>
        /// Gets the controls graphics.
        /// </summary>
        private Graphics ControlGraphics { get; }

        /// <summary>
        /// Gets the item at a given point.
        /// </summary>
        /// <param name="pt">The point to get the item at.</param>
        /// <returns>The item at the given point or <c>null</c> if no item was found.</returns>
        public object GetItemAtPoint(Point pt)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                var rectangle = GetItemRectangle(i);

                var itemWidthPair = Enumerable.FirstOrDefault(ItemSizes, f => f.PairFirst.Equals(Items[i]));

                if (itemWidthPair != null && itemWidthPair.PairSecond < ClientSize.Width)
                {
                    continue;
                }

                if (itemWidthPair == null)
                {
                    var width = ControlGraphics.MeasureString(Items[i].ToString(), Font).Width;
                    ItemSizes.Add(new Pair<object, float>(Items[i], width));
                    if (width < ClientSize.Width)
                    {
                        continue;
                    }
                }

                if (rectangle.Contains(pt))
                {
                    return Items[i];
                }
            }

            return null;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control" /> and its child controls and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                ControlGraphics?.Dispose();
            }
        }
    }
}
