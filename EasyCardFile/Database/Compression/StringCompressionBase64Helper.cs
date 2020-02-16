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

using System.Text;

namespace EasyCardFile.Database.Compression
{
    /// <summary>
    /// A helper class for strings for dealing with base64 encoding and compression.
    /// </summary>
    public static class StringCompressionBase64Helper
    {
        /// <summary>
        /// Compresses a string using the given <see cref="Encoding"/> using
        /// BZip2 (<see cref="ICSharpCode.SharpZipLib.BZip2"/>) compression.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding to get the bytes from the string.</param>
        /// <returns>A base64 encoded data containing the compressed string value.</returns>
        public static string CompressToBase64(this string str, Encoding encoding)
        {
            return DatabaseCompressionHelper.CompressDataToBase64(str, encoding);
        }

        /// <summary>
        /// Decompresses a base64 encoded data using BZip2 (<see cref="ICSharpCode.SharpZipLib.BZip2"/>) and returns
        /// the decompressed data as a string encoded with the given <see cref="Encoding"/>.
        /// </summary>
        /// <param name="str">The base64-encoded string containing the data to to decompress.</param>
        /// <param name="encoding">The encoding to use to get a string from the decompressed bytes.</param>
        /// <returns>System.String.</returns>
        public static string DecompressFromBase64(this string str, Encoding encoding)
        {
            return DatabaseCompressionHelper.DecompressDataToString(str, encoding);
        }
    }
}
