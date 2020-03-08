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
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using EasyCardFile.Database.Encryption;
using EasyCardFile.UtilityClasses.ErrorHandling;
using EasyCardFile.UtilityClasses.Localization;
using VPKSoft.MessageBoxExtended;

namespace EasyCardFile.Database.Entity.Context.ContextEncryption
{
    /// <summary>
    /// A helper class to encrypt or decrypt a <see cref="CardFileDbContext"/> instance.
    /// </summary>
    public static class ContextEncryptDecryptHelper //: ErrorHandlingBase
    {
        /// <summary>
        /// Enables the <see cref="CardFileDbContext"/> encryption.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="dialogOwner">The parent window of the password query dialog.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool EnableEncryption(this CardFileDbContext cardFileDbContext, Encoding encoding,
            IWin32Window dialogOwner)
        {
            if (cardFileDbContext == null)
            {
                return false;
            }

            var cardFile = cardFileDbContext.CardFile;

            if (cardFile.Encrypted) // obvious..
            {
                return true;
            }

            var encryptionData = EnableEncryption(encoding, dialogOwner);
            if (encryptionData == default)
            {
                return false;
            }

            cardFile.PasswordHash = encryptionData.passwordHash;
            cardFile.EncryptionHashAlgorithmValueBase64 = encryptionData.valueBase64;
            cardFile.EncryptionPasswordValidationRandomizedBase64 = encryptionData.validationBase64;

            return true;
        }

        /// <summary>
        /// Generates the necessary data for a <see cref="CardFileDbContext"/> to be encrypted.
        /// </summary>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="dialogOwner">The parent window of the password query dialog.</param>
        /// <returns>A System.ValueTuple&lt;System.String, System.String, System.String&gt; if the operation was successful; otherwise default.</returns>
        public static (string passwordHash, string valueBase64, string validationBase64) EnableEncryption(
            Encoding encoding, IWin32Window dialogOwner)
        {
            try
            {
                MessageBoxBase.Localize(CultureInfo.CurrentUICulture);

                var password = string.Empty;

                password = MessageBoxQueryPassword.Show(dialogOwner,
                    LocalizeStaticProperties.PasswordQuery,
                    LocalizeStaticProperties.PasswordQueryTitle,
                    null, true, false,
                    true, password);

                var password2 = MessageBoxQueryPassword.Show(dialogOwner,
                    LocalizeStaticProperties.PasswordQueryConfirm,
                    LocalizeStaticProperties.PasswordQueryTitleConfirm,
                    null, true, false,
                    true, null);

                if (password != password2)
                {
                    MessageBoxExtended.Show(dialogOwner, LocalizeStaticProperties.PasswordMismatch,
                        LocalizeStaticProperties.PasswordMismatchTitle, MessageBoxButtonsExtended.OK,
                        MessageBoxIcon.Warning, true);
                    return default;
                }

                var passwordHash = DatabaseEncryptionHelper.PasswordHashBase64(password, encoding);
                var valueBase64 =
                    DatabaseEncryptionHelper.GenerateRandomBase64Data(150, 200);
                var validationBase64 =
                    DatabaseEncryptionHelper.EncryptData(password, valueBase64,
                        encoding);

                return (passwordHash, valueBase64, validationBase64);
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return default;
            }
        }

        /// <summary>
        /// Determines if the encryption password of a <see cref="CardFileDbContext"/> can be changed.
        /// </summary>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="passwordHash">The password hash as a base64 encoded string.</param>
        /// <param name="valueBase64">The value base64 encoded unencrypted value.</param>
        /// <param name="validationBase64">The base64 encoded encrypted value validation value.</param>
        /// <param name="dialogOwner">The dialog owner.</param>
        /// <returns><c>true</c> if card file password can be changed, <c>false</c> otherwise.</returns>
        public static bool ChangeEncryptionPassword(Encoding encoding, ref string passwordHash, 
            ref string valueBase64, ref string validationBase64, IWin32Window dialogOwner)
        {
            if (DisableEncryption(encoding, valueBase64, validationBase64, dialogOwner))
            {
                var result = EnableEncryption(encoding, dialogOwner);
                if (result != default)
                {
                    passwordHash = result.passwordHash;
                    validationBase64 = result.validationBase64;
                    valueBase64 = result.valueBase64;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Changes the encryption password of the card file if the password validation succeeds.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="dialogOwner">The parent window of the password query dialog.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool ChangeEncryptionPassword(this CardFileDbContext cardFileDbContext, Encoding encoding,
            IWin32Window dialogOwner)
        {
            if (cardFileDbContext?.CardFile == null)
            {
                return false;
            }

            try
            {
                if (!cardFileDbContext.CardFile.Encrypted)
                {
                    return false;
                }

                var cardFileEncryptionPasswordValidation =
                    cardFileDbContext.CardFile.EncryptionPasswordValidationRandomizedBase64;

                var cardFileEncryptionHashAlgorithm = 
                    cardFileDbContext.CardFile.EncryptionHashAlgorithmValueBase64;

                if (!cardFileDbContext.DisableEncryption(encoding, dialogOwner))
                {
                    return false;
                }

                if (!cardFileDbContext.EnableEncryption(encoding, dialogOwner))
                {

                    cardFileDbContext.CardFile.EncryptionPasswordValidationRandomizedBase64 =
                        cardFileEncryptionPasswordValidation;

                    cardFileDbContext.CardFile.EncryptionHashAlgorithmValueBase64 = 
                        cardFileEncryptionHashAlgorithm;

                    return false;
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the <see cref="CardFileDbContext"/> encryption can be disabled by verifying the user given password.
        /// </summary>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="valueBase64">The value base64 encoded unencrypted value.</param>
        /// <param name="validationBase64">The base64 encoded encrypted value validation value.</param>
        /// <param name="dialogOwner">The parent window of the password query dialog.</param>
        /// <returns>True if the user given password was correct and the operation was successful; otherwise false.</returns>
        public static bool DisableEncryption(Encoding encoding, string valueBase64,
            string validationBase64, IWin32Window dialogOwner)
        {
            try
            {
                MessageBoxBase.Localize(CultureInfo.CurrentUICulture);

                bool invalidKey = false;

                for (int i = 0; i < 5; i++) // allow five tries..
                {
                    var key = MessageBoxQueryPassword.Show(dialogOwner,
                        LocalizeStaticProperties.PasswordQueryDisableEncryption,
                        LocalizeStaticProperties.PasswordQueryOpenTitle,
                        null, true, invalidKey,
                        false, null);

                    if (string.IsNullOrEmpty(key))
                    {
                        return false;
                    }

                    var testPassword = validationBase64.DecryptBase64(key, encoding);

                    if (testPassword != valueBase64)
                    {
                        invalidKey = true;
                    }
                    else
                    {
                        invalidKey = false;
                        break;
                    }
                }

                if (invalidKey)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Disables the encryption of a card file if the password validation succeeds.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="dialogOwner">The parent window of the password query dialog.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool DisableEncryption(this CardFileDbContext cardFileDbContext, Encoding encoding,
            IWin32Window dialogOwner)
        {
            if (cardFileDbContext?.CardFile == null)
            {
                return false;
            }

            var cardFile = cardFileDbContext.CardFile;

            if (!cardFile.Encrypted) // obvious..
            {
                return true;
            }

            if (DisableEncryption(encoding, cardFile.EncryptionHashAlgorithmValueBase64,
                cardFile.EncryptionPasswordValidationRandomizedBase64, dialogOwner))
            {
                cardFile.EncryptionPasswordValidationRandomizedBase64 = null;
                cardFile.EncryptionHashAlgorithmValueBase64 = null;
                cardFile.PasswordHash = null;
                cardFile.Encrypted = false;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Saves the <see cref="CardFileDbContext"/> with encryption. Use this extension only when the card file is closing.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool SaveWithEncryption(this CardFileDbContext cardFileDbContext)
        {
            if (cardFileDbContext == null)
            {
                return false;
            }

            var cardFile = cardFileDbContext.CardFile;

            if (!cardFile.Encrypted)
            {
                return false;
            }

            try
            {
                var encoding = Encoding.UTF8;

                DatabaseEncryptionHelper.KeyBytes =
                    Convert.FromBase64String(cardFile.PasswordHash); // set this to override the key use..

                cardFile.EncryptionHashAlgorithmValueBase64 =
                    DatabaseEncryptionHelper.GenerateRandomBase64Data(150, 200);
                cardFile.Encrypted = true;
                cardFile.EncryptionPasswordValidationRandomizedBase64 =
                    DatabaseEncryptionHelper.EncryptData(string.Empty, cardFile.EncryptionHashAlgorithmValueBase64,
                        encoding);

                cardFile.Name = cardFile.Name.EncryptBase64(string.Empty, encoding);
                cardFile.CardNamingInstruction = cardFile.CardNamingInstruction?.EncryptBase64(string.Empty, encoding);

                foreach (var card in cardFile.Cards)
                {
                    card.CardName = card.CardName.EncryptBase64(string.Empty, encoding);
                    card.CardContents = DatabaseEncryptionHelper.EncryptData(string.Empty, card.CardContents, encoding);
                }

                foreach (var cardType in cardFile.CardTypes)
                {
                    cardType.CardTypeName = cardType.CardTypeName.EncryptBase64(string.Empty, encoding);
                }

                cardFileDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                DatabaseEncryptionHelper.KeyBytes = null; // set this to null as the key override is no longer used..
                // log the exception..
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }

            DatabaseEncryptionHelper.KeyBytes = null; // set this to null as the key override is no longer used..
            return true;
        }

        /// <summary>
        /// Loads an encrypted card file.
        /// </summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <param name="encoding">The encoding to be used with the user given password.</param>
        /// <param name="dialogOwner">The parent window of the password query dialog.</param>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public static bool LoadWithEncryption(this CardFileDbContext cardFileDbContext, Encoding encoding, IWin32Window dialogOwner)
        {
            if (cardFileDbContext == null)
            {
                return false;
            }

            var cardFile = cardFileDbContext.CardFile;

            if (!cardFile.Encrypted)
            {
                return false;
            }

            string key = null;
            bool invalidKey = false;

            for (int i = 0; i < 5; i++) // allow five tries..
            {
                key = MessageBoxQueryPassword.Show(dialogOwner,
                    LocalizeStaticProperties.PasswordQueryOpen,
                    LocalizeStaticProperties.PasswordQueryOpenTitle,
                    null, true, invalidKey,
                    false, null);

                if (string.IsNullOrEmpty(key))
                {
                    return false;
                }

                var testPassword = cardFile.EncryptionPasswordValidationRandomizedBase64.DecryptBase64(key, encoding);

                if (testPassword != cardFile.EncryptionHashAlgorithmValueBase64)
                {
                    invalidKey = true;
                }
                else
                {
                    invalidKey = false;
                    break;
                }
            }

            if (invalidKey)
            {
                return false;
            }

            cardFile.Name = cardFile.Name.DecryptFromBase64(key, encoding);
            cardFile.CardNamingInstruction = cardFile.CardNamingInstruction?.DecryptFromBase64(key, encoding);
            cardFile.PasswordHash = DatabaseEncryptionHelper.PasswordHashBase64(key, encoding);

            foreach (var card in cardFile.Cards)
            {
                card.CardName = card.CardName.DecryptFromBase64(key, encoding);
                card.CardContents = DatabaseEncryptionHelper.DecryptData(key, card.CardContents, encoding);
            }

            foreach (var cardType in cardFile.CardTypes)
            {
                cardType.CardTypeName = cardType.CardTypeName.DecryptFromBase64(key, encoding);
            }

            return true;
        }
    }
}
