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
using System.Security.Cryptography;
using System.Text;
using EasyCardFileProfessional.UtilityClasses.ErrorHandling;

namespace EasyCardFileProfessional.Database.Encryption
{
    /// <summary>
    /// A class with methods the help with encryption.
    /// Implements the <see cref="EasyCardFileProfessional.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFileProfessional.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class DatabaseEncryptionHelper: ErrorHandlingBase
    {
        /// <summary>
        /// Gets or sets the size of the buffer to use with the <see cref="Stream"/> read and write operations. The default value is 1 MB (1 million bytes).
        /// </summary>
        /// <value>The size of the buffer.</value>
        public static int BufferSize { get; set; } = 1000000;

        /// <summary>
        /// Encrypts the given data <see cref="Stream"/>.
        /// The method uses <see cref="Aes"/> encryption with <see cref="SHA512"/> hash algorithm to the password.
        /// The IV (Initialization Vector) is randomized by the <see cref="Aes"/> instance and it's length and contents are stored to the beginning of the stream.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToEncrypt">The data to encrypt.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>The <paramref name="outputStream"/> with the encrypted data if the operation was successful; otherwise null.</returns>
        public static Stream EncryptData(string key, Stream dataToEncrypt, Stream outputStream, Encoding encoding)
        {
            try
            {
                var aes = Aes.Create();

                if (aes == null)
                {
                    return null;
                }

                var sha512 = SHA512.Create();
                aes.Key = sha512.ComputeHash(encoding.GetBytes(key));
                aes.GenerateIV();
                using (var writer = new BinaryWriter(outputStream))
                {
                    using (var reader = new BinaryReader(dataToEncrypt))
                    {
                        var buffer = new byte [1000000]; // a megabyte should be enough..
                        int bufferLength;

                        writer.Write(aes.IV.Length);
                        writer.Write(aes.IV);
                        while ((bufferLength = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            writer.Write(buffer, 0, bufferLength);
                        }
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
        /// Decrypts the given data <see cref="Stream"/>.
        /// The method uses <see cref="Aes"/> encryption with <see cref="SHA512"/> hash algorithm to the password.
        /// The IV (Initialization Vector) is expected to be in the stream starting position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToDecrypt">The data to decrypt.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>The <paramref name="outputStream"/> with the encrypted data if the operation was successful; otherwise null.</returns>
        public static Stream DecryptData(string key, Stream dataToDecrypt, Stream outputStream, Encoding encoding)
        {
            try
            {
                var aes = Aes.Create();

                if (aes == null)
                {
                    return null;
                }

                var sha512 = SHA512.Create();
                aes.Key = sha512.ComputeHash(encoding.GetBytes(key));
                using (var writer = new BinaryWriter(outputStream))
                {
                    using (var reader = new BinaryReader(dataToDecrypt))
                    {
                        var buffer = new byte [1000000]; // a megabyte should be enough..
                        int bufferLength;

                        // get the initialization vector..
                        var ivLength = reader.ReadInt32();
                        aes.IV = reader.ReadBytes(ivLength);

                        while ((bufferLength = reader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            writer.Write(buffer, 0, bufferLength);
                        }
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
