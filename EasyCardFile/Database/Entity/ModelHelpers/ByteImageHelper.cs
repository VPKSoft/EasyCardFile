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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using EasyCardFile.UtilityClasses.ErrorHandling;

namespace EasyCardFile.Database.Entity.ModelHelpers
{
    /// <summary>
    /// A helper class for <see cref="Image"/> to <see cref="T:byte[]"/> conversions.
    /// </summary>
    public static class ImageToByteHelper
    {
        /// <summary>
        /// Converts a <see cref="Image"/> instance to a byte array.
        /// </summary>
        /// <param name="image">The image to convert.</param>
        /// <returns>A byte array containing the image data if the operation was successful; <c>null</c> otherwise.</returns>
        public static byte[] ToBytes(this Image image)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    try // the raw format may fail..
                    {
                        image.Save(memoryStream, image.RawFormat);
                    }
                    catch
                    {
                        // ..upon failure try the Png compression..
                        image.Save(memoryStream, ImageFormat.Png);
                    }

                    return memoryStream.ToArray();
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return null;
            }
        }
    }

    /// <summary>
    /// A helper class for <see cref="T:byte[]"/> to <see cref="Image"/> conversions.
    /// </summary>
    public static class ByteToImageHelper
    {
        /// <summary>
        /// Creates an <see cref="Image"/> instance from byte array containing the image data.
        /// </summary>
        /// <param name="bytes">The bytes to convert to an image.</param>
        /// <returns>An image instance if the byte array was successfully converted to image; <c>null</c> otherwise.</returns>
        public static Image FromBytes(this byte[] bytes)
        {
            try
            {
                using (var memoryStream = new MemoryStream(bytes))
                {
                    return Image.FromStream(memoryStream);
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return null;
            }
        }
    }
}
