﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EasyCardFile.UtilityClasses.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("EasyCardFile.UtilityClasses.Localization.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Automatic|A message for a ToolStrip color selection drop down text for automatic..
        /// </summary>
        internal static string msgAutomaticColorText {
            get {
                return ResourceManager.GetString("msgAutomaticColorText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The card file {0} has changed. Save the changes?|A query from the user whether to save the changed card file..
        /// </summary>
        internal static string msgCardFileSaveChangesQuery {
            get {
                return ResourceManager.GetString("msgCardFileSaveChangesQuery", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save changes to the card file?|A title for a dialog asking whether to save changed card file..
        /// </summary>
        internal static string msgCardFileSaveChangesQueryTitle {
            get {
                return ResourceManager.GetString("msgCardFileSaveChangesQueryTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The default card can not be deleted. Please set another card as default and then remove the selected one.|A message describing that the default card type can not be removed and another type should be set to default before removing the selected one..
        /// </summary>
        internal static string msgCardTypeDefaultCanNotDelete {
            get {
                return ResourceManager.GetString("msgCardTypeDefaultCanNotDelete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The default card can not be deleted|A title of a dialog explaining to the user that the default card type can not be removed..
        /// </summary>
        internal static string msgCardTypeDefaultCanNotDeleteTitle {
            get {
                return ResourceManager.GetString("msgCardTypeDefaultCanNotDeleteTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Card type:|A description text for a card type selection combo box..
        /// </summary>
        internal static string msgCardTypeDescription {
            get {
                return ResourceManager.GetString("msgCardTypeDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A default card type must be set!|A message indicating that a default card type must be set..
        /// </summary>
        internal static string msgCardTypeMustHaveDefault {
            get {
                return ResourceManager.GetString("msgCardTypeMustHaveDefault", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Card type name|A title for a dialog requesting a user to enter a name for a card type.
        /// </summary>
        internal static string msgCardTypeNameTitle {
            get {
                return ResourceManager.GetString("msgCardTypeNameTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The card type name must be unique and can not be an empty string!|A message indicating that the name of the card type must be unique compared to other card types. Also the card type name can not be an empty string..
        /// </summary>
        internal static string msgCardTypeNameUniqueError {
            get {
                return ResourceManager.GetString("msgCardTypeNameUniqueError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At least one card type is required|A message explaining to the user that at least one type for a card is requires within a card file.
        /// </summary>
        internal static string msgCardTypeOneRequired {
            get {
                return ResourceManager.GetString("msgCardTypeOneRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to One card type is required|A title of a dialog explaining to the user that at least one type for a card is requires within a card file.
        /// </summary>
        internal static string msgCardTypeOneRequiredTitle {
            get {
                return ResourceManager.GetString("msgCardTypeOneRequiredTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a new card type|A dialog title message instructing the user to select a new card type..
        /// </summary>
        internal static string msgCardTypeSelectTypeNewTitle {
            get {
                return ResourceManager.GetString("msgCardTypeSelectTypeNewTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a new card type for the cards with the deleted type of: {0}|A message instructing the user to select a new card type for the cards using a card type about to be deleted..
        /// </summary>
        internal static string msgCartTypeSelectTypeNewForDeleted {
            get {
                return ResourceManager.GetString("msgCartTypeSelectTypeNewForDeleted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm the password to protect the card file.|A user is asked for a confirmation for a password in a dialog (the second time).
        /// </summary>
        internal static string msgConfirmAPassword {
            get {
                return ResourceManager.GetString("msgConfirmAPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm the password|A user is asked for a confirmation for a password in a dialog (the second time).
        /// </summary>
        internal static string msgConfirmAPasswordTitle {
            get {
                return ResourceManager.GetString("msgConfirmAPasswordTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Copy|A message for a menu item indicating a copy function..
        /// </summary>
        internal static string msgCopy {
            get {
                return ResourceManager.GetString("msgCopy", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cut|A message for a menu item indicating a cut function..
        /// </summary>
        internal static string msgCut {
            get {
                return ResourceManager.GetString("msgCut", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm|A title for a dialog confirming something from the user..
        /// </summary>
        internal static string msgDialogConfirmTitle {
            get {
                return ResourceManager.GetString("msgDialogConfirmTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Image files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff|A filter for a file dialog to open image files..
        /// </summary>
        internal static string msgDialogImageFileFilter {
            get {
                return ResourceManager.GetString("msgDialogImageFileFilter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Open image file|A title for a dialog asking the user to open an image file..
        /// </summary>
        internal static string msgDialogImageFileOpenTitle {
            get {
                return ResourceManager.GetString("msgDialogImageFileOpenTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Export as Rtf file|A dialog title to export the card contents to a RTF file..
        /// </summary>
        internal static string msgDialogRtfFileExportTitle {
            get {
                return ResourceManager.GetString("msgDialogRtfFileExportTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rtf files|*.rtf|A filter for a file dialog to save RTF files..
        /// </summary>
        internal static string msgDialogRtfFileFilterExport {
            get {
                return ResourceManager.GetString("msgDialogRtfFileFilterExport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rtf files|*.rtf|Text files|*.txt|Any file|*.*|A filter for a file dialog to open RTF files..
        /// </summary>
        internal static string msgDialogRtfFileFilterImport {
            get {
                return ResourceManager.GetString("msgDialogRtfFileFilterImport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Import Rtf file|A dialog title to import a RTF file to the card contents..
        /// </summary>
        internal static string msgDialogRtfFileImportTitle {
            get {
                return ResourceManager.GetString("msgDialogRtfFileImportTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created: {0}|A message for a status strip to indicate a date and time the card was created..
        /// </summary>
        internal static string msgEditorCardCreated {
            get {
                return ResourceManager.GetString("msgEditorCardCreated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Modified: {0}|A message for a status strip to indicate a date and time the card was modified..
        /// </summary>
        internal static string msgEditorCardModified {
            get {
                return ResourceManager.GetString("msgEditorCardModified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The file is encrypted, please give a password.|A message indicating file encryption. A password is requested from the user..
        /// </summary>
        internal static string msgEncryptionGiveAPassword {
            get {
                return ResourceManager.GetString("msgEncryptionGiveAPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter a name for the card type|A message instructing the user to give a name for a new card type.
        /// </summary>
        internal static string msgEnterCardTypeName {
            get {
                return ResourceManager.GetString("msgEnterCardTypeName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Give a password|A message querying a password from the user with the card file protection.
        /// </summary>
        internal static string msgEnterPassword {
            get {
                return ResourceManager.GetString("msgEnterPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Confirm the password|A message querying a password confirmation from the user with the card file protection.
        /// </summary>
        internal static string msgEnterPasswordConfirm {
            get {
                return ResourceManager.GetString("msgEnterPasswordConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Alphabetical descending|A localized enumeration value for card sort style of: Alphabetical Descending..
        /// </summary>
        internal static string msgEnumAlphabeticalDescendingSort {
            get {
                return ResourceManager.GetString("msgEnumAlphabeticalDescendingSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Alphabetical|A localized enumeration value for card sort style of: Alphabetical..
        /// </summary>
        internal static string msgEnumAlphabeticalSort {
            get {
                return ResourceManager.GetString("msgEnumAlphabeticalSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created descending|A localized enumeration value for card sort style of: Created Descending..
        /// </summary>
        internal static string msgEnumCreatedDescendingSort {
            get {
                return ResourceManager.GetString("msgEnumCreatedDescendingSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Created|A localized enumeration value for card sort style of: Created..
        /// </summary>
        internal static string msgEnumCreatedSort {
            get {
                return ResourceManager.GetString("msgEnumCreatedSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ignore case|A localized enumeration value for card sort style of: Ignore Case..
        /// </summary>
        internal static string msgEnumIgnoreCaseSort {
            get {
                return ResourceManager.GetString("msgEnumIgnoreCaseSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Modified descending|A localized enumeration value for card sort style of: Modified Descending..
        /// </summary>
        internal static string msgEnumModifiedDescendingSort {
            get {
                return ResourceManager.GetString("msgEnumModifiedDescendingSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Modified|A localized enumeration value for card sort style of: Modified..
        /// </summary>
        internal static string msgEnumModifiedSort {
            get {
                return ResourceManager.GetString("msgEnumModifiedSort", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to None|A localized enumeration value for card sort style of: None..
        /// </summary>
        internal static string msgEnumSortNone {
            get {
                return ResourceManager.GetString("msgEnumSortNone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error|A message describing that some kind of error occurred..
        /// </summary>
        internal static string msgError {
            get {
                return ResourceManager.GetString("msgError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [•]|An indicator text to be used with the card file&apos;s file name to indicate that the file has been changed..
        /// </summary>
        internal static string msgFileChangedIndicatorText {
            get {
                return ResourceManager.GetString("msgFileChangedIndicatorText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Give a password to protect the card file.|A user is asked for a password in a dialog.
        /// </summary>
        internal static string msgGiveAPassword {
            get {
                return ResourceManager.GetString("msgGiveAPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Give a password to disable the card file encryption.|A user is asked for a password in a dialog to disable the card file encryption.
        /// </summary>
        internal static string msgGiveAPasswordDisableEncryption {
            get {
                return ResourceManager.GetString("msgGiveAPasswordDisableEncryption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Give a password to open the card file.|A user is asked for a password in a dialog to open an encrypted card file.
        /// </summary>
        internal static string msgGiveAPasswordOpen {
            get {
                return ResourceManager.GetString("msgGiveAPasswordOpen", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Give a password|A user is asked for a password in a dialog title to open an encrypted card file.
        /// </summary>
        internal static string msgGiveAPasswordOpenTitle {
            get {
                return ResourceManager.GetString("msgGiveAPasswordOpenTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Give a password|A user is asked for a password in a dialog.
        /// </summary>
        internal static string msgGiveAPasswordTitle {
            get {
                return ResourceManager.GetString("msgGiveAPasswordTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given password was invalid|The user gave an invalid password checked by the software&apos;s verification logic..
        /// </summary>
        internal static string msgInvalidPassword {
            get {
                return ResourceManager.GetString("msgInvalidPassword", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to More colors..|A message for a ToolStrip color selection drop down text for more colors..
        /// </summary>
        internal static string msgMoreColorsText {
            get {
                return ResourceManager.GetString("msgMoreColorsText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New {0}|A text for a new file name or a new card file internal name..
        /// </summary>
        internal static string msgNewCardFileName {
            get {
                return ResourceManager.GetString("msgNewCardFileName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CARD TYPE|A default name for a type of a card in a new card file..
        /// </summary>
        internal static string msgNewCardType {
            get {
                return ResourceManager.GetString("msgNewCardType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New card type|A localized default name for a new card type.
        /// </summary>
        internal static string msgNewCardTypeName {
            get {
                return ResourceManager.GetString("msgNewCardTypeName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given password is invalid. Please try again.|The user-given password is invalid so do complain via a dialog.
        /// </summary>
        internal static string msgPasswordInvalid {
            get {
                return ResourceManager.GetString("msgPasswordInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid password|The user-given password is invalid so do complain via a dialog title.
        /// </summary>
        internal static string msgPasswordInvalidTitle {
            get {
                return ResourceManager.GetString("msgPasswordInvalidTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The entered passwords mismatch. Please try again.|The user entered two different passwords so an error message is displayed..
        /// </summary>
        internal static string msgPasswordMisMach {
            get {
                return ResourceManager.GetString("msgPasswordMisMach", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The given passwords mismatch. Please try again.|The user-given password are different so do complain via a dialog.
        /// </summary>
        internal static string msgPasswordMismatch {
            get {
                return ResourceManager.GetString("msgPasswordMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password mismatch|The user-given password are different so do complain via a dialog title.
        /// </summary>
        internal static string msgPasswordMismatchTitle {
            get {
                return ResourceManager.GetString("msgPasswordMismatchTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Password is required|A short message indicating that some operation requires a valid password for the some operation to continue successfully..
        /// </summary>
        internal static string msgPasswordRequired {
            get {
                return ResourceManager.GetString("msgPasswordRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paste|A message for a menu item indicating a paste function..
        /// </summary>
        internal static string msgPaste {
            get {
                return ResourceManager.GetString("msgPaste", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Paste without formatting|A message for a menu item indicating a paste without formatting function..
        /// </summary>
        internal static string msgPasteWithoutFormatting {
            get {
                return ResourceManager.GetString("msgPasteWithoutFormatting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Print preview|A message for a print preview window title.
        /// </summary>
        internal static string msgPrintPreview {
            get {
                return ResourceManager.GetString("msgPrintPreview", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Delete the card: &apos;{0}&apos;?|A message asking from the user for confirmation of deletion of a card from the card file..
        /// </summary>
        internal static string msgQueryConfirmDeleteCard {
            get {
                return ResourceManager.GetString("msgQueryConfirmDeleteCard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enter a password to protect the card file|A message querying the user to enter a password for the first time to protect the card file.
        /// </summary>
        internal static string msgQueryPassword1 {
            get {
                return ResourceManager.GetString("msgQueryPassword1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Re-enter the password for confirmation|A message querying the user to enter a password for the second time for confirmation purpose.
        /// </summary>
        internal static string msgQueryPassword2 {
            get {
                return ResourceManager.GetString("msgQueryPassword2", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Search:|A text for a label near a search text box..
        /// </summary>
        internal static string msgSearchTextDescription {
            get {
                return ResourceManager.GetString("msgSearchTextDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select an image for the card type &apos;[{0}]&apos;|A title for a dialog to select a part of an image to be used with a card type..
        /// </summary>
        internal static string msgSelectCardImageTitle {
            get {
                return ResourceManager.GetString("msgSelectCardImageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Row: {0}, Column: {1}, Selection {2}|A message for a status strip to describe a row, column and a selection length of a text editor..
        /// </summary>
        internal static string msgTextEditorRowColumnSelection {
            get {
                return ResourceManager.GetString("msgTextEditorRowColumnSelection", resourceCulture);
            }
        }
    }
}
