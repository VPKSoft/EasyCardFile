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
using System.Windows.Forms;
using EasyCardFile.UtilityClasses.ErrorHandling;

namespace EasyCardFile.CardFileHandler
{
    /// <summary>
    /// A helper class for <see cref="RichTextBox"/> and <see cref="Clipboard"/> classes.
    /// </summary>
    public static class RichTextBoxDataFormats
    {
        /// <summary>
        /// Determines whether you can paste information from the <see cref="Clipboard"/> to a <see cref="RichTextBox"/> class instance
        /// </summary>
        /// <param name="richTextBox">The rich text box.</param>
        /// <returns><c>true</c> if you can paste information from the <see cref="Clipboard"/> to a <see cref="RichTextBox"/> class instance; otherwise, <c>false</c>.</returns>
        public static bool CanPaste(this RichTextBox richTextBox)
        {
            try
            {
                return
                    Clipboard.ContainsData(DataFormats.Bitmap) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Bitmap))
                    ||
                    Clipboard.ContainsData(DataFormats.CommaSeparatedValue) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.CommaSeparatedValue))
                    ||
                    Clipboard.ContainsData(DataFormats.Dib) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Dib))
                    ||
                    Clipboard.ContainsData(DataFormats.Dif) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Dif))
                    ||
                    Clipboard.ContainsData(DataFormats.EnhancedMetafile) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.EnhancedMetafile))
                    ||
                    Clipboard.ContainsData(DataFormats.FileDrop) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.FileDrop))
                    ||
                    Clipboard.ContainsData(DataFormats.Html) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Html))
                    ||
                    Clipboard.ContainsData(DataFormats.Locale) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Locale))
                    ||
                    Clipboard.ContainsData(DataFormats.MetafilePict) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.MetafilePict))
                    ||
                    Clipboard.ContainsData(DataFormats.OemText) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.OemText))
                    ||
                    Clipboard.ContainsData(DataFormats.Palette) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Palette))
                    ||
                    Clipboard.ContainsData(DataFormats.PenData) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.PenData))
                    ||
                    Clipboard.ContainsData(DataFormats.Riff) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Riff))
                    ||
                    Clipboard.ContainsData(DataFormats.Rtf) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Rtf))
                    ||
                    Clipboard.ContainsData(DataFormats.Serializable) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Serializable))
                    ||
                    Clipboard.ContainsData(DataFormats.StringFormat) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.StringFormat))
                    ||
                    Clipboard.ContainsData(DataFormats.SymbolicLink) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.SymbolicLink))
                    ||
                    Clipboard.ContainsData(DataFormats.Text) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Text))
                    ||
                    Clipboard.ContainsData(DataFormats.Tiff) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Tiff))
                    ||
                    Clipboard.ContainsData(DataFormats.UnicodeText) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.UnicodeText))
                    ||
                    Clipboard.ContainsData(DataFormats.WaveAudio) &&
                    richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.WaveAudio));
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }
    }
}
