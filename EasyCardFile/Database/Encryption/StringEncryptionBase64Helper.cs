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
using System.Text;

namespace EasyCardFile.Database.Encryption
{
    /// <summary>
    /// A helper class for strings for dealing with base64 encoding and encryption.
    /// </summary>
    public static class StringEncryptionBase64Helper
    {
        /// <summary>
        /// Converts the string to a base64 encoded data.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding to be used to get the bytes for the conversion.</param>
        /// <returns>A string converted to base64 encoded data.</returns>
        public static string ToBase64String(string str, Encoding encoding)
        {
            return Convert.ToBase64String(encoding.GetBytes(str));
        }

        /// <summary>
        /// Converts the string from base64 encoded data to string data.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="encoding">The encoding to be used to get the bytes for the conversion.</param>
        /// <returns>A string converted from base64 encoded data.</returns>
        public static string FromBase64String(string str, Encoding encoding)
        {
            return encoding.GetString(Convert.FromBase64String(str));
        }


        /// <summary>
        /// Encrypts the string and converts the encrypted binary data to base64 encoded string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key to be used for the encryption.</param>
        /// <param name="encoding">The encoding to be used to get the bytes from the string.</param>
        /// <returns>A base64 encoded encrypted data string.</returns>
        public static string EncryptBase64(this string str, string key, Encoding encoding)
        {
            return DatabaseEncryptionHelper.EncryptData(key, Convert.ToBase64String(encoding.GetBytes(str)), encoding);
        }

        /// <summary>
        /// Decrypts the string and converts the decrypted binary data to base64 encoded string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key to be used for the decryption.</param>
        /// <param name="encoding">The encoding to be used to get the bytes from the string.</param>
        /// <returns>A base64 encoded decrypted data string.</returns>
        public static string DecryptBase64(this string str, string key, Encoding encoding)
        {
            var result = DatabaseEncryptionHelper.DecryptData(key, str, encoding);
            return result;
        }

        /// <summary>
        /// Decrypts the string and converts the decrypted binary data to a normal string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="key">The key to be used for the decryption.</param>
        /// <param name="encoding">The encoding to be used to get the bytes from the string.</param>
        /// <returns>A string containing the data in decrypted format.</returns>
        public static string DecryptFromBase64(this string str, string key, Encoding encoding)
        {
            return encoding.GetString(Convert.FromBase64String(DecryptBase64(str, key, encoding)));
        }
    }
}
