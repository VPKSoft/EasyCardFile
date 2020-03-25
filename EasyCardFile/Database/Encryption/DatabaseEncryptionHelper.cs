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
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using EasyCardFile.UtilityClasses.ErrorHandling;

namespace EasyCardFile.Database.Encryption
{
    /// <summary>
    /// A class with methods the help with encryption.
    /// Implements the <see cref="ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="ErrorHandlingBase" />
    public class DatabaseEncryptionHelper: ErrorHandlingBase
    {
        /// <summary>
        /// Gets or sets the encryption algorithm.
        /// </summary>
        public static SymmetricAlgorithm EncryptionAlgorithm { get; set; } = Aes.Create();

        /// <summary>
        /// Gets or sets the key bytes for encryption / decryption.
        /// If this property is set the key parameter of the methods is ignored and the property value is used instead.
        /// </summary>
        public static byte [] KeyBytes { get; set; }

        /// <summary>
        /// Gets or sets the static <see cref="Random"/> class instance.
        /// </summary>
        private static Random Random { get; } = new Random();

        /// <summary>
        /// Gets or sets the size of the buffer to use with the <see cref="Stream"/> read and write operations. The default value is 1 MB (1 million bytes).
        /// </summary>
        /// <value>The size of the buffer.</value>
        public static int BufferSize { get; set; } = 1000000;

        /// <summary>
        /// Encrypts the given data <see cref="Stream"/>.
        /// The method uses <see cref="EncryptionAlgorithm"/> encryption with <see cref="SHA512"/> hash algorithm to the password.
        /// The IV (Initialization Vector) is randomized by the <see cref="EncryptionAlgorithm"/> instance and it's length and contents are stored to the beginning of the stream.
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
                var algorithm = EncryptionAlgorithm;

                if (algorithm == null)
                {
                    return null;
                }

                algorithm.Key = KeyBytes ?? PasswordHash(algorithm, key, encoding);
                algorithm.GenerateIV();

                using (var writer = new BinaryWriter(outputStream, Encoding.UTF8, true))
                {
                    writer.Write(algorithm.IV.Length);
                    writer.Write(algorithm.IV);
                }

                using (var reader = new BinaryReader(dataToEncrypt))
                {
                    // ReSharper disable once IdentifierTypo (MS example..)
                    var encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

                    using (var cryptoStream = new CryptoStream(outputStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new BinaryWriter(cryptoStream))
                        {
                            var buffer = new byte [BufferSize]; // a megabyte should be enough..
                            int bufferLength;

                            while ((bufferLength = reader.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                writer.Write(buffer, 0, bufferLength);
                            }
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
        /// Gets the hashed password converted to a base64 encoded string.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>A base64 encoded string representing the password hash data.</returns>
        public static string PasswordHashBase64(string key, Encoding encoding)
        {
            return Convert.ToBase64String(PasswordHash(EncryptionAlgorithm, key, encoding));
        }

        /// <summary>
        /// Generated a hash value for a given <paramref name="key"/> for <see cref="SymmetricAlgorithm"/> instances
        /// maximum legal key size using the SHA algorithm except for a key size of 128 for which MD5 is used.
        /// </summary>
        /// <param name="algorithm">The algorithm to generate the hashed password for.</param>
        /// <param name="key">The key.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>A byte array with the length of the <paramref name="algorithm"/> maximum legal key size.</returns>
        private static byte[] PasswordHash(SymmetricAlgorithm algorithm, string key, Encoding encoding)
        {
            var size = algorithm.LegalKeySizes.AsQueryable().Max(f => f.MaxSize);
            if (size == 512)
            {
                using (var sha512 = SHA512.Create())
                {
                    return sha512.ComputeHash(encoding.GetBytes(key));
                }
            }

            if (size == 384)
            {
                using (var sha384 = SHA384.Create())
                {
                    return sha384.ComputeHash(encoding.GetBytes(key));
                }
            }
            
            if (size == 256)
            {
                using (var sha256 = SHA256.Create())
                {
                    return sha256.ComputeHash(encoding.GetBytes(key));
                }
            }

            if (size == 128) // for legacy support...
            {
                using (var md5 = MD5.Create())
                {
                    return md5.ComputeHash(encoding.GetBytes(key));
                }
            }

            using (var sha1 = SHA1.Create())
            {
                return sha1.ComputeHash(encoding.GetBytes(key));
            }
        }

        /// <summary>
        /// Encrypts the given data <see cref="byte"/> array.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToEncrypt">The data to encrypt.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>The byte array containing the encrypted data if the operation was successful; otherwise null.</returns>
        public static byte[] EncryptData(string key, byte[] dataToEncrypt, Encoding encoding)
        {
            if (dataToEncrypt == null)
            {
                return null;
            }

            try
            {
                using (var streamToEncrypt = new MemoryStream(dataToEncrypt))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        return ((MemoryStream) EncryptData(key, streamToEncrypt, outputStream, encoding)).ToArray();
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
        /// Encrypts the given data given in a base64 encoded string format.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="base64data">The base64 encoded data to encrypt.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>The <paramref name="base64data"/> data encrypted into a base64 encoded string representation if the operation was successful; otherwise null.</returns>
        public static string EncryptData(string key, string base64data, Encoding encoding)
        {
            try
            {
                var bytes = Convert.FromBase64String(base64data);
                bytes = EncryptData(key, bytes, encoding);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return null;
        }

        /// <summary>
        /// Generates random bytes with the amount randomized between the <paramref name="minimumLength"/> and <paramref name="maximumLength"/>
        /// and returns the randomized data as a base64 encoded string.
        /// </summary>
        /// <param name="minimumLength">The minimum length of the data to generate.</param>
        /// <param name="maximumLength">The maximum length of the data to generate.</param>
        /// <returns>A base64 encoded random bytes in a base64 encoded string.</returns>
        public static string GenerateRandomBase64Data(int minimumLength, int maximumLength)
        {
            using (var cryptoRandom = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[Random.Next(minimumLength, maximumLength)];
                cryptoRandom.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Encrypts the given data <see cref="byte"/> array. UTF-8 Encoding is used with the key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToEncrypt">The data to encrypt.</param>
        /// <returns>The byte array containing the encrypted data if the operation was successful; otherwise null.</returns>
        public static byte[] EncryptData(string key, byte[] dataToEncrypt)
        {
            using (var streamToEncrypt = new MemoryStream(dataToEncrypt))
            {
                using (var outputStream = new MemoryStream())
                {
                    return ((MemoryStream) EncryptData(key, streamToEncrypt, outputStream, Encoding.UTF8))
                        .ToArray();
                }
            }
        }

        /// <summary>
        /// Decrypts the given data <see cref="Stream"/>.
        /// The method uses <see cref="EncryptionAlgorithm"/> encryption with <see cref="SHA512"/> hash algorithm to the password.
        /// The IV (Initialization Vector) is expected to be in the stream starting position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToDecrypt">The data to decrypt.</param>
        /// <param name="outputStream">The output stream.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>The <paramref name="outputStream"/> with the encrypted data if the operation was successful; otherwise null.</returns>
        public static Stream DecryptData(string key, Stream dataToDecrypt, Stream outputStream, Encoding encoding)
        {
            try
            {
                var algorithm = EncryptionAlgorithm;

                if (algorithm == null)
                {
                    return null;
                }

                algorithm.Key = KeyBytes ?? PasswordHash(algorithm, key, encoding);
                using (var writer = new BinaryWriter(outputStream))
                {
                    using (var reader = new BinaryReader(dataToDecrypt, encoding, true))
                    {
                        // get the initialization vector..
                        var ivLength = reader.ReadInt32();
                        algorithm.IV = reader.ReadBytes(ivLength);
                    }

                    // ReSharper disable once IdentifierTypo (MS example..)
                    var decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

                    using (var cryptoStream = new CryptoStream(dataToDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var reader = new BinaryReader(cryptoStream))
                        {
                            var buffer = new byte [BufferSize]; // a megabyte should be enough..
                            int bufferLength;
                            while ((bufferLength = reader.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                writer.Write(buffer, 0, bufferLength);
                            }
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
        /// Decrypts the given data given in a base64 encoded string format.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="base64data">The base64 encoded data to decrypt.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>The <paramref name="base64data"/> data decrypted into a base64 encoded string representation if the operation was successful; otherwise null.</returns>
        public static string DecryptData(string key, string base64data, Encoding encoding)
        {
            try
            {
                var bytes = Convert.FromBase64String(base64data);
                bytes = DecryptData(key, bytes, encoding);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return null;
        }

        /// <summary>
        /// Decrypts the given data <see cref="byte"/> array.
        /// The method uses <see cref="EncryptionAlgorithm"/> encryption with <see cref="SHA512"/> hash algorithm to the password.
        /// The IV (Initialization Vector) is expected to be in data area's starting position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToDecrypt">The data to decrypt.</param>
        /// <param name="encoding">The encoding to use with the <paramref name="key"/>.</param>
        /// <returns>The byte array containing the decrypted data if the operation was successful; otherwise null.</returns>
        public static byte[] DecryptData(string key, byte[] dataToDecrypt, Encoding encoding)
        {
            if (dataToDecrypt == null)
            {
                return null;
            }

            try
            {
                using (var streamToDecrypt = new MemoryStream(dataToDecrypt))
                {
                    using (var outputStream = new MemoryStream())
                    {
                        return ((MemoryStream) DecryptData(key, streamToDecrypt, outputStream, encoding)).ToArray();
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
        /// Decrypts the given data <see cref="byte"/> array. UTF-8 Encoding is used with the key.
        /// The method uses <see cref="EncryptionAlgorithm"/> encryption with <see cref="SHA512"/> hash algorithm to the password.
        /// The IV (Initialization Vector) is expected to be in data area's starting position.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="dataToDecrypt">The data to decrypt.</param>
        /// <returns>The byte array containing the decrypted data if the operation was successful; otherwise null.</returns>
        public static byte[] DecryptData(string key, byte[] dataToDecrypt)
        {
            using (var streamToDecrypt = new MemoryStream(dataToDecrypt))
            {
                using (var outputStream = new MemoryStream())
                {
                    return ((MemoryStream) DecryptData(key, streamToDecrypt, outputStream, Encoding.UTF8)).ToArray();
                }
            }
        }
    }
}
