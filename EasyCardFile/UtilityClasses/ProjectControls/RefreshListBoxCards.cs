using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.Database.Entity.ModelHelpers;

namespace EasyCardFile.UtilityClasses.ProjectControls
{
    /// <summary>
    /// A list box for <see cref="Card"/> entities.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ProjectControls.RefreshListBox" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ProjectControls.RefreshListBox" />
    public class RefreshListBoxCards : RefreshListBox
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshListBoxCards"/> class.
        /// </summary>
        public RefreshListBoxCards(CardFile cardFile)
        {
            base.DrawMode = DrawMode.OwnerDrawFixed;
            base.ItemHeight = 16;
            DrawItem += RefreshListBoxCards_DrawItem;
            Disposed += RefreshListBoxCards_Disposed;
            ImageWidth = cardFile.ImageWidth < 16 ? 16 : cardFile.ImageWidth;
            ImageHeight = cardFile.ImageHeight < 16 ? 16 : cardFile.ImageHeight;
        }

        private void RefreshListBoxCards_Disposed(object sender, System.EventArgs e)
        {
            DrawItem -= RefreshListBoxCards_DrawItem;
            Disposed -= RefreshListBoxCards_Disposed;
            ClearCache();
        }

        /// <summary>
        /// Gets or sets the width of the image to draw the <see cref="CardType.TypeImage"/>.
        /// </summary>
        public int ImageWidth { get; set; }

        /// <summary>
        /// Gets or sets the height of the image to draw the <see cref="CardType.TypeImage"/>.
        /// </summary>
        public int ImageHeight
        {
            get => base.ItemHeight;
            set => base.ItemHeight = value;
        }

        /// <summary>
        /// Clears the cache of the card type images.
        /// </summary>
        public void ClearCache()
        {
            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < ImageCache.Count; i++)
            {
                ImageCache[i].Value?.Dispose();
            }

            ImageCache.Clear();
        }

        private List<KeyValuePair<int, Image>> ImageCache { get; set; } = new List<KeyValuePair<int, Image>>();

        /// <summary>
        /// Gets or sets the space between the <see cref="Card.CardName"/> name and the <see cref="CardType.TypeImage"/> image.
        /// </summary>
        /// <value>The image text offset.</value>
        public int ImageTextOffset { get; set; } = 4;

        private void RefreshListBoxCards_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index > Items.Count)
            {
                return;
            }

            var card = (Card) Items[e.Index];

            var colorInvert = e.State.HasFlag(DrawItemState.Selected);

            var colorsDefined = true;

            var colorBack = ColorTranslator.FromHtml(card.CardType.BackColor);
            if (colorBack == Color.Empty)
            {
                colorBack = SystemColors.Window;
                colorsDefined = false;
            }

            if (colorInvert)
            {
                colorBack = !colorsDefined ? SystemColors.Highlight : Color.FromArgb(colorBack.ToArgb() ^ 0xffffff);
            }

            using (var backgroundBrush = new SolidBrush(colorBack))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            var colorFore = ColorTranslator.FromHtml(card.CardType.ForeColor);
            if (colorFore == Color.Empty)
            {
                colorFore = SystemColors.ControlText;
            }

            if (colorInvert)
            {
                colorFore = !colorsDefined ? SystemColors.Window : Color.FromArgb(colorBack.ToArgb() ^ 0xffffff);
            }

            using (var foregroundBrush = new SolidBrush(colorFore))
            {
                e.Graphics.DrawString(card.CardName, Font, foregroundBrush, e.Bounds.X + ImageWidth + ImageTextOffset, e.Bounds.Y);
            }

            if (e.State.HasFlag(DrawItemState.Focus))
            {
                e.DrawFocusRectangle();
            }

            Image image;
            if (ImageCache.Any(f => f.Key == card.CardType.Id))
            {
                image = ImageCache.FirstOrDefault(f => f.Key == card.CardType.Id).Value;
                if (image != null)
                {
                    e.Graphics.DrawImage(image, e.Bounds.X, e.Bounds.Y);
                }
            }
            else
            {
                image = card.CardType?.TypeImage.FromBytes();
                ImageCache.Add(new KeyValuePair<int, Image>(card.CardType.Id, image));
                if (image != null)
                {
                    e.Graphics.DrawImage(image, e.Bounds.X, e.Bounds.Y);
                }
            }
        }
    }
}
