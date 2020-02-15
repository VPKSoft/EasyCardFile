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
        ///   Looks up a localized string similar to Card type:|A description text for a card type selection combo box..
        /// </summary>
        internal static string msgCardTypeDescription {
            get {
                return ResourceManager.GetString("msgCardTypeDescription", resourceCulture);
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
        ///   Looks up a localized string similar to The file is encrypted, please give a password.|A message indicating file encryption. A password is requested from the user..
        /// </summary>
        internal static string msgEncryptionGiveAPassword {
            get {
                return ResourceManager.GetString("msgEncryptionGiveAPassword", resourceCulture);
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
    }
}