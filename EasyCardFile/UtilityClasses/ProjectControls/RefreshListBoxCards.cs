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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.Database.Entity.ModelHelpers;
using VPKSoft.Utils;

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

            var newFont = cardFile.CardFont?.DeserializeObjectBinary<Font>();
            if (newFont != null)
            {
                base.Font = newFont;
            }
        }

        private void RefreshListBoxCards_Disposed(object sender, EventArgs e)
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
            Invalidate();
        }

        /// <summary>
        /// Gets the <see cref="CardType"/> image cache as this will speed things up rather than parsing an image from a byte array.
        /// </summary>
        private List<KeyValuePair<int, Image>> ImageCache { get; } = new List<KeyValuePair<int, Image>>();

        /// <summary>
        /// Gets or sets the space between the <see cref="Card.CardName"/> name and the <see cref="CardType.TypeImage"/> image.
        /// </summary>
        /// <value>The image text offset.</value>
        public int ImageTextOffset { get; set; } = 4;

        /// <summary>
        /// Gets a value indicating whether any card type in the <see cref="ListBox.Items"/> collection has defined images.
        /// </summary>
        private bool HasImages => ImageCache.Count(f => f.Value != null) > 0;

        // draw the "cool" card list box..
        private void RefreshListBoxCards_DrawItem(object sender, DrawItemEventArgs e)
        {
            // no deal here as an exception would occur..
            if (e.Index < 0 || e.Index > Items.Count)
            {
                return;
            }

            // this assumption is correct if the control is used correctly,
            // abandoning all the rules of making a great software code..
            var card = (Card) Items[e.Index];

            // if an item is selected, the coloring of the item must be different,
            // so do save the value to a bool..
            var colorInvert = e.State.HasFlag(DrawItemState.Selected);

            // assume that the drawing colors of a card type have been defined..
            var colorsDefined = true;

            // get the background color of the card type..
            var colorBack = ColorTranslator.FromHtml(card.CardType?.BackColor);

            // ..if no color was defined, just take one from the system colors and
            // set the flag of colors being defined to false..
            if (colorBack == Color.Empty)
            {
                colorBack = SystemColors.Window;
                colorsDefined = false;
            }

            // if the item is selected the defined color must be inverted..
            if (colorInvert)
            {
                colorBack = !colorsDefined ? SystemColors.Highlight : Color.FromArgb(colorBack.ToArgb() ^ 0xffffff);
            }

            // these things are all disposable..
            using (var backgroundBrush = new SolidBrush(colorBack))
            {
                e.Graphics.FillRectangle(backgroundBrush, e.Bounds);
            }

            // get the foreground color from the card type..
            var colorFore = ColorTranslator.FromHtml(card.CardType?.ForeColor);

            // ..if a color was not defined..
            if (colorFore == Color.Empty)
            {
                // ..use a system default color..
                colorFore = SystemColors.ControlText;
            }

            // if the item is selected the defined color must be inverted..
            if (colorInvert)
            {
                colorFore = !colorsDefined ? SystemColors.Window : Color.FromArgb(colorBack.ToArgb() ^ 0xffffff);
            }

            // these things are all disposable..
            using (var foregroundBrush = new SolidBrush(colorFore))
            {
                // ..draw the card name to the list item..
                e.Graphics.DrawString(card.CardName, Font, foregroundBrush,
                    e.Bounds.X + (HasImages ? ImageWidth + ImageTextOffset : 0), e.Bounds.Y);
            }

            // draw the optional focus rectangle..
            if (e.State.HasFlag(DrawItemState.Focus))
            {
                e.DrawFocusRectangle();
            }

            // the card type might have an image..
            Image image;

            // ..check if one exists..
            if (ImageCache.Count > 0 && card.CardType != null && ImageCache.Any(f => f.Key == card.CardType.Id)) 
            {
                // get the image matching the card type id..
                image = ImageCache.FirstOrDefault(f => f.Key == card.CardType.Id).Value;

                // ..if not null, then draw..
                if (image != null)
                {
                    e.Graphics.DrawImage(image, e.Bounds.X, e.Bounds.Y);
                }
            }
            else // the null case..
            {
                if (card.CardType == null) // this could also happen..
                {
                    return;
                }

                // ..get the image from the card type..
                image = card.CardType?.TypeImage?.FromBytes();

                if (image != null)
                {
                    var bitmap = new Bitmap(ImageWidth, ImageHeight);

                    using (var graphics = Graphics.FromImage(bitmap))
                    {
                        var maxSize = (double)Math.Max(image.Width, image.Height);
                        var minSize = (double)Math.Min(ImageWidth, ImageHeight);

                        var ratio =  minSize / maxSize;

                        int w = (int) (image.Width * ratio);
                        int h = (int) (image.Height * ratio);

                        // maintain the aspect ratio..
                        var destRect = new Rectangle((ImageWidth - w) / 2, (ImageHeight - h) / 2, w, h);

                        var sourceRect = new Rectangle(0, 0, image.Width, image.Height);

                        graphics.DrawImage(image, destRect, sourceRect, GraphicsUnit.Pixel);
                    }

                    ImageCache.Add(new KeyValuePair<int, Image>(card.CardType.Id, bitmap));
                    e.Graphics.DrawImage(bitmap, e.Bounds.X, e.Bounds.Y);
                    image.Dispose();
                }
            }
        }
    }
}
