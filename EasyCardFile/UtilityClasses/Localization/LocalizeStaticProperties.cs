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

using EasyCardFile.UtilityClasses.ErrorHandling;
using VPKSoft.LangLib;

namespace EasyCardFile.UtilityClasses.Localization
{
    /// <summary>
    /// A class to localize some static properties. I.e. title to a message box, etc.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class LocalizeStaticProperties: ErrorHandlingBase

    {
        /// <summary>
        /// Gets or sets the password query dialog title text.
        /// </summary>
        public static string PasswordQueryTitle { get; set; }

        /// <summary>
        /// Gets or sets the password query dialog title text asking the user to confirm the previously given password.
        /// </summary>
        public static string PasswordQueryTitleConfirm { get; set; }

        /// <summary>
        /// Gets or sets the password query dialog text.
        /// </summary>
        public static string PasswordQuery { get; set; }

        /// <summary>
        /// Gets or sets the password query dialog text asking the user to repeat the given password.
        /// </summary>
        public static string PasswordQueryConfirm { get; set; }

        /// <summary>
        /// Gets or sets a dialog title if the user-given passwords mismatch.
        /// </summary>
        public static string PasswordMismatchTitle { get; set; }

        /// <summary>
        /// Gets or sets a dialog text if the user-given passwords mismatch.
        /// </summary>
        /// <value>The password mismatch.</value>
        public static string PasswordMismatch { get; set; }

        /// <summary>
        /// Gets or sets a dialog title if the user-given password is invalid.
        /// </summary>
        public static string PasswordInvalidTitle { get; set; }

        /// <summary>
        /// Gets or sets a dialog text if the user-given password is invalid.
        /// </summary>
        /// <value>The password mismatch.</value>
        public static string PasswordInvalid { get; set; }

        /// <summary>
        /// Gets or sets the password query dialog title text when an encrypted card file is opened.
        /// </summary>
        public static string PasswordQueryOpenTitle { get; set; }

        /// <summary>
        /// Gets or sets the password query dialog text when an encrypted card file is opened.
        /// </summary>
        public static string PasswordQueryOpen { get; set; }

        /// <summary>
        /// Localizes the static texts used by the software.
        /// </summary>
        public static void LocalizeStatic()
        {
            PasswordQueryTitle = DBLangEngine.GetStatMessage("msgGiveAPasswordTitle",
                "Give a password|A user is asked for a password in a dialog");

            PasswordQuery = DBLangEngine.GetStatMessage("msgGiveAPassword",
                "Give a password to protect the card file.|A user is asked for a password in a dialog");

            PasswordQueryTitleConfirm = DBLangEngine.GetStatMessage("msgConfirmAPasswordTitle",
                "Confirm the password|A user is asked for a confirmation for a password in a dialog (the second time)");

            PasswordQueryConfirm = DBLangEngine.GetStatMessage("msgConfirmAPassword",
                "Confirm the password to protect the card file.|A user is asked for a confirmation for a password in a dialog (the second time)");

            PasswordMismatchTitle = DBLangEngine.GetStatMessage("msgPasswordMismatchTitle",
                "Password mismatch|The user-given password are different so do complain via a dialog title");

            PasswordMismatch = DBLangEngine.GetStatMessage("msgPasswordMismatch",
                "The given passwords mismatch. Please try again.|The user-given password are different so do complain via a dialog");

            PasswordInvalidTitle = DBLangEngine.GetStatMessage("msgPasswordInvalidTitle",
                "Invalid password|The user-given password is invalid so do complain via a dialog title");

            PasswordInvalid = DBLangEngine.GetStatMessage("msgPasswordInvalid",
                "The given password is invalid. Please try again.|The user-given password is invalid so do complain via a dialog");

            PasswordQueryOpenTitle = DBLangEngine.GetStatMessage("msgGiveAPasswordOpenTitle",
                "Give a password|A user is asked for a password in a dialog title to open an encrypted card file");

            PasswordQueryOpen = DBLangEngine.GetStatMessage("msgGiveAPasswordOpen",
                "Give a password to open the card file.|A user is asked for a password in a dialog to open an encrypted card file");
        }
    }
}
