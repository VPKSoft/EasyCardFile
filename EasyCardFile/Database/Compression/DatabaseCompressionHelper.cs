#region License
/*
MIT License

Copyright(c) 2019 Petteri Kautonen

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
using System.IO;
using System.Text;
using EasyCardFile.UtilityClasses.ErrorHandling;
using ICSharpCode.SharpZipLib.BZip2;

namespace EasyCardFile.Database.Compression
{
    /// <summary>
    /// A class with methods the help with data compression.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class DatabaseCompressionHelper: ErrorHandlingBase
    {
        /// <summary>
        /// Gets or sets the size of the buffer to use with the <see cref="Stream"/> read and write operations. The default value is 1 MB (1 million bytes).
        /// </summary>
        /// <value>The size of the buffer.</value>
        public static int BufferSize { get; set; } = 1000000;

        /// <summary>
        /// Compresses the given <see cref="Stream"/> using the BZip2 compression algorithm.
        /// </summary>
        /// <param name="dataToCompress">The data to compress.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <returns>The <paramref name="outputStream"/> with the compressed data if the operation was successful; otherwise null.</returns>
        public static Stream CompressData(Stream dataToCompress, Stream outputStream)
        {
            try
            {
                using (var bzip2 = new BZip2OutputStream(outputStream))
                {
                    var buffer = new byte [BufferSize]; // a megabyte should be enough..
                    int bufferLength;

                    while ((bufferLength = dataToCompress.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bzip2.Write(buffer, 0, bufferLength);
                    }
                }

                return outputStream;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return null;
        }

        /// <summary>
        /// Compresses the data to base64 encoded string.
        /// </summary>
        /// <param name="dataToCompress">The text data to compress.</param>
        /// <param name="encoding">The encoding to use to get the bytes from the <paramref name="dataToCompress"/> string.</param>
        /// <returns>A base64 encoded value containing the compressed data.</returns>
        public static string CompressDataToBase64(string dataToCompress, Encoding encoding)
        {
            var bytes = encoding.GetBytes(dataToCompress);
            bytes = CompressData(bytes);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// Decompresses a base64 encoded compressed data string to an uncompressed string.
        /// </summary>
        /// <param name="base64Compressed">The base64 encoded compressed data string.</param>
        /// <param name="encoding">The encoding to use to get the correct string data from the uncompressed bytes.</param>
        /// <returns>Uncompressed string value using the given encoding.</returns>
        public static string DecompressDataToString(string base64Compressed, Encoding encoding)
        {
            var bytes = Convert.FromBase64String(base64Compressed);
            bytes = DecompressData(bytes);
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// Compresses the given <see cref="byte"/> array using the BZip2 compression algorithm.
        /// </summary>
        /// <param name="dataToCompress">The data to compress.</param>
        /// <returns>The byte array containing the compressed data if the operation was successful; otherwise null.</returns>
        public static byte[] CompressData(byte [] dataToCompress)
        {
            try
            {
                using (var streamToCompress = new MemoryStream(dataToCompress))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        return ((MemoryStream) CompressData(streamToCompress, outputStream)).ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return null;
        }

        /// <summary>
        /// Decompresses the given <see cref="Stream"/> using the BZip2 compression algorithm.
        /// </summary>
        /// <param name="dataToDecompress">The data to decompress.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <returns>The <paramref name="outputStream"/> with the decompressed data if the operation was successful; otherwise null.</returns>
        public static Stream DecompressData(Stream dataToDecompress, Stream outputStream)
        {
            try
            {
                using (var bzip2 = new BZip2InputStream(dataToDecompress))
                {
                    var buffer = new byte [BufferSize]; // a megabyte should be enough..
                    int bufferLength;

                    while ((bufferLength = bzip2.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        outputStream.Write(buffer, 0, bufferLength);
                    }
                }

                return outputStream;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return null;
        }

        /// <summary>
        /// Decompresses the given <see cref="byte"/> array using the BZip2 compression algorithm.
        /// </summary>
        /// <param name="dataToDecompress">The data to decompress.</param>
        /// <returns>The byte array containing the decompressed data if the operation was successful; otherwise null.</returns>
        public static byte [] DecompressData(byte[] dataToDecompress)
        {
            try
            {
                using (var streamToDecompress = new MemoryStream(dataToDecompress))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        return ((MemoryStream) DecompressData(streamToDecompress, outputStream)).ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return null;
        }
    }
}
