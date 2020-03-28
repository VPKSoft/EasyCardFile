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

using System.Windows.Forms;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.Constants;
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
        public static string PasswordMismatch { get; set; }

        /// <summary>
        /// Gets or sets a dialog title if the user-given password is invalid.
        /// </summary>
        public static string PasswordInvalidTitle { get; set; }

        /// <summary>
        /// Gets or sets a dialog text if the user-given password is invalid.
        /// </summary>
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
        /// Gets or sets the password query dialog text to disable encryption of an open card file.
        /// </summary>
        public static string PasswordQueryDisableEncryption { get; set; }

        /// <summary>
        /// Gets or sets a message displayed to the user that the card type name must be unique within a card file.
        /// </summary>
        public static string CardTypeNameUniqueError { get; set; }

        /// <summary>
        /// Gets or sets the title of a dialog querying the user of a card type name.
        /// </summary>
        public static string CardTypeNameQueryTitle { get; set; }

        /// <summary>
        /// Gets or sets the displayed in a dialog querying the user of a card type name.
        /// </summary>
        public static string CardTypeNameQuery { get; set; }

        /// <summary>
        /// Gets or sets a message instructing the user that a default card type is required.
        /// </summary>
        public static string CardTypeDefaultRequired { get; set; }

        /// <summary>
        /// A title in a dialog displayed to the user that at leas one card is requires in a card file.
        /// </summary>
        public static string CardTypeOneRequiredTitle { get; set; }

        /// <summary>
        /// A message displayed to the user that at leas one card is requires in a card file.
        /// </summary>
        public static string CardTypeOneRequired { get; set; }

        /// <summary>
        /// Gets or sets the title of a dialog displaying a message that the default card type can not be removed.
        /// </summary>
        public static string CardTypeCanNotDeleteDefaultTitle { get; set; }

        /// <summary>
        /// Gets or sets a message that the default card type can not be removed.
        /// </summary>
        public static string CardTypeCanNotDeleteDefault { get; set; }

        /// <summary>
        /// Gets or sets the title of a dialog displaying a message for the user to select a new card type for card(s).
        /// </summary>
        public static string CardTypeSelectTypeNewTitle { get; set; }

        /// <summary>
        /// Gets or sets a message querying a new type for card(s) having their previous type to be deleted.
        /// </summary>
        public static string CartTypeSelectTypeNewForDeleted { get; set; }

        /// <summary>
        /// Gets or sets the localized Easy CardFile file dialog extension text.
        /// </summary>
        public static string EasyCardFileDialogExtension { get; set; }

        /// <summary>
        /// Gets or sets a localized query whether to save changes to a changed card file.
        /// </summary>
        public static string CardFileChangedSaveQuery { get; set; }

        /// <summary>
        /// Gets or sets a localized title for a dialog asking whether to save changed card file.
        /// </summary>
        public static string CardFileChangedSaveQueryTitle { get; set; }

        /// <summary>
        /// Gets or sets the localized dialog title for a Save As dialog.
        /// </summary>
        public static string DialogSaveAsTitle { get; set; }

        /// <summary>
        /// Gets or sets the localized dialog title for an Open dialog.
        /// </summary>
        public static string DialogOpenTitle { get; set; }

        /// <summary>
        /// Gets or sets the title for a dialog confirming something from the user.
        /// </summary>
        public static string DialogConfirmTitle { get; set; }

        /// <summary>
        /// Gets or sets the title for a file dialog to open image files.
        /// </summary>
        public static string DialogImageFileOpenTitle { get; set; }

        /// <summary>
        /// Gets or sets the filter for a file dialog to open image files.
        /// </summary>
        public static string DialogImageFileFilter { get; set; }

        /// <summary>
        /// Gets or sets the filter for a file dialog to save RTF files.
        /// </summary>
        public static string DialogRtfFileFilterExport { get; set; }

        /// <summary>
        /// Gets or sets the filter for a file dialog to open RTF files.
        /// </summary>
        public static string DialogRtfFileFilterImport { get; set; }


        /// <summary>
        /// Gets or sets the dialog title to import a RTF file to the card contents.
        /// </summary>
        public static string DialogRtfFileImportTitle { get; set; }

        /// <summary>
        /// Gets or sets the dialog title to export the card contents to a RTF file.
        /// </summary>
        public static string DialogRtfFileExportTitle { get; set; }

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

            PasswordQueryDisableEncryption = DBLangEngine.GetStatMessage("msgGiveAPasswordDisableEncryption",
                "Give a password to disable the card file encryption.|A user is asked for a password in a dialog to disable the card file encryption");

            CardTypeNameUniqueError = DBLangEngine.GetStatMessage("msgCardTypeNameUniqueError",
                "The card type name must be unique and can not be an empty string!|A message indicating that the name of the card type must be unique compared to other card types. Also the card type name can not be an empty string.");

            CardTypeNameQueryTitle = DBLangEngine.GetStatMessage("msgCardTypeNameTitle",
                "Card type name|A title for a dialog requesting a user to enter a name for a card type");

            CardTypeNameQuery = DBLangEngine.GetStatMessage("msgEnterCardTypeName",
                "Enter a name for the card type|A message instructing the user to give a name for a new card type");

            CardTypeDefaultRequired = DBLangEngine.GetStatMessage("msgCardTypeMustHaveDefault",
                "A default card type must be set!|A message indicating that a default card type must be set.");

            CardTypeOneRequired = DBLangEngine.GetStatMessage("msgCardTypeOneRequired",
                "At least one card type is required|A message explaining to the user that at least one type for a card is requires within a card file");

            CardTypeOneRequiredTitle = DBLangEngine.GetStatMessage("msgCardTypeOneRequiredTitle",
                "One card type is required|A title of a dialog explaining to the user that at least one type for a card is requires within a card file");

            CardTypeCanNotDeleteDefaultTitle = DBLangEngine.GetStatMessage("msgCardTypeDefaultCanNotDeleteTitle",
                "The default card can not be deleted|A title of a dialog explaining to the user that the default card type can not be removed.");

            CardTypeCanNotDeleteDefault = DBLangEngine.GetStatMessage("msgCardTypeDefaultCanNotDelete",
                "The default card can not be deleted. Please set another card as default and then remove the selected one.|A message describing that the default card type can not be removed and another type should be set to default before removing the selected one.");

            CardTypeSelectTypeNewTitle = DBLangEngine.GetStatMessage("msgCardTypeSelectTypeNewTitle",
                "Select a new card type|A dialog title message instructing the user to select a new card type.");

            CartTypeSelectTypeNewForDeleted = DBLangEngine.GetStatMessage("msgCartTypeSelectTypeNewForDeleted",
                "Select a new card type for the cards with the deleted type of: {0}|A message instructing the user to select a new card type for the cards using a card type about to be deleted.");

            CardType.NewCardTypeNameLocalized =
                DBLangEngine.GetStatMessage("msgNewCardTypeName",
                    "New card type|A localized default name for a new card type");

            EasyCardFileDialogExtension = DBLangEngine.GetStatMessage("msgEasyCardFileDialogExtension",
                "Easy CardFile file|A text for a file dialog to describe the Easy CardFile file extension.");

            CardFileChangedSaveQuery = DBLangEngine.GetStatMessage("msgCardFileSaveChangesQuery",
                "The card file {0} has changed. Save the changes?|A query from the user whether to save the changed card file.");

            CardFileChangedSaveQueryTitle = DBLangEngine.GetStatMessage("msgCardFileSaveChangesQueryTitle",
                "Save changes to the card file?|A title for a dialog asking whether to save changed card file.");

            DialogSaveAsTitle = DBLangEngine.GetStatMessage("msgDialogSaveAsTitle",
                "Save As|A title for a Save As dialog.");

            DialogOpenTitle = DBLangEngine.GetStatMessage("msgDialogOpenTitle",
                "Open|A title for a Open dialog.");

            DialogConfirmTitle = DBLangEngine.GetStatMessage("msgDialogConfirmTitle",
                "Confirm|A title for a dialog confirming something from the user.");

            DialogImageFileOpenTitle = DBLangEngine.GetStatMessage("msgDialogImageFileOpenTitle",
                "Open image file|A title for a dialog asking the user to open an image file.");

            DialogImageFileFilter = DBLangEngine.GetStatMessage("msgDialogImageFileFilter",
                "Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff|A filter for a file dialog to open image files.");

            DialogRtfFileFilterExport = DBLangEngine.GetStatMessage("msgDialogRtfFileFilterExport",
                "Rtf files|*.rtf|A filter for a file dialog to save RTF files.");

            DialogRtfFileFilterImport = DBLangEngine.GetStatMessage("msgDialogRtfFileFilterImport",
                "Rtf files|*.rtf|Text files|*.txt|Any file|*.*|A filter for a file dialog to open RTF files.");

            DialogRtfFileImportTitle = DBLangEngine.GetStatMessage("msgDialogRtfFileImportTitle",
                "Import Rtf file|A dialog title to import a RTF file to the card contents.");

            DialogRtfFileExportTitle = DBLangEngine.GetStatMessage("msgDialogRtfFileExportTitle",
                "Export as Rtf file|A dialog title to export the card contents to a RTF file.");
        }

        /// <summary>
        /// Localizes the file dialogs.
        /// </summary>
        /// <param name="sdCardFile">The Save As card file dialog to localize.</param>
        /// <param name="odCardFile">The Open card file dialog to localize.</param>
        internal static void LocalizeFileDialogs(SaveFileDialog sdCardFile, OpenFileDialog odCardFile)
        {
            odCardFile.DefaultExt = EasyCardFileConstants.FileExtensionFileDialog;
            sdCardFile.DefaultExt = EasyCardFileConstants.FileExtensionFileDialog;

            sdCardFile.Filter = EasyCardFileDialogExtension + @"|" +
                                EasyCardFileConstants.FileExtensionFileDialog;

            odCardFile.Filter = EasyCardFileDialogExtension + @"|" +
                                EasyCardFileConstants.FileExtensionFileDialog;

            sdCardFile.Title = DialogSaveAsTitle;

            odCardFile.Title = DialogOpenTitle;
        }

        /// <summary>
        /// Localizes the import/export Rtf file dialogs.
        /// </summary>
        /// <param name="odRtf">The open dialog for a Rtf file.</param>
        /// <param name="sdRtf">The save dialog for a Rtf file.</param>
        internal static void LocalizeRtfDialogs(OpenFileDialog odRtf, SaveFileDialog sdRtf)
        {
            odRtf.Filter = DialogRtfFileFilterImport;
            sdRtf.Filter = DialogRtfFileFilterExport;

            odRtf.Title = DialogRtfFileImportTitle;
            sdRtf.Title = DialogRtfFileExportTitle;
        }

        /// <summary>
        /// Localizes a dialog to open an image file.
        /// </summary>
        /// <param name="dialog">The dialog to localize.</param>
        internal static void LocalizeDialogOpenImageFile(OpenFileDialog dialog)
        {
            dialog.Title = DialogImageFileOpenTitle;
            dialog.Filter = DialogImageFileFilter;
        }
    }
}
