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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using EasyCardFile.UtilityClasses.ErrorHandling;
using Microsoft.Win32;

namespace EasyCardFile.UtilityClasses.FileAssociation
{
    // ReSharper disable once CommentTypo
    // Thanks to Davisko1, https://youtu.be/XtYobuVvcFE for the help with this!

    /// <summary>
    /// A class to help with MS Windows (©, ™, ®) file associations.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class AssociateFileExtension: ErrorHandlingBase
    {
        /// <summary>
        /// A Windows API call to the SHChangeNotify.
        /// </summary>
        /// <param name="wEventId">Describes the event that has occurred. Typically, only one event is specified at a time. If more than one event is specified, the values contained in the dwItem1 and dwItem2 parameters must be the same, respectively, for all specified events.</param>
        /// <param name="uFlags">Flags that, when combined bitwise with SHCNF_TYPE, indicate the meaning of the dwItem1 and dwItem2 parameters.</param>
        /// <param name="dwItem1">Optional. First event-dependent value.</param>
        /// <param name="dwItem2">Optional. Second event-dependent value.</param>
        [DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [SuppressMessage("ReSharper", "CommentTypo")]
        private static extern void SHChangeNotify(long wEventId, uint uFlags, IntPtr dwItem1, IntPtr dwItem2);

        /// <summary>
        /// A file type association has changed. <see cref="SHChangeNotify"/>.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        // ReSharper disable twice IdentifierTypo
        private const long SHCNE_ASSOCCHANGED = 0x08000000;

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> path for Software\Classes\.
        /// </summary>
        private const string RegistrySoftwareClasses = @"Software\Classes\";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> path for HKCU\Software\Classes\Applications\.
        /// </summary>
        private const string RegistrySoftwareClassesApplications = @"Software\Classes\Applications\";

        // ReSharper disable twice CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> path for HKCU\Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\.
        /// </summary>
        private const string RegistrySoftwareMicrosoftWindowsCurrentVersionFileExts = @"Software\Microsoft\Windows\CurrentVersion\Explorer\FileExts\";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> path for shell\open\command.
        /// </summary>
        private const string RegistryShellOpenCommand = @"shell\open\command";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> path for shell\edit\command.
        /// </summary>
        private const string RegistryShellEditCommand = @"shell\edit\command";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> path for HKCU\Applications\.
        /// </summary>
        private const string RegistryApplications = @"Applications\";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> value name for DefaultIcon.
        /// </summary>
        private const string RegistryDefaultIcon = "DefaultIcon";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> value name for UserChoice.
        /// </summary>
        private const string RegistryUserChoice = "UserChoice";

        // ReSharper disable once CommentTypo
        /// <summary>
        /// A Windows <see cref="Registry"/> value name for Progid.
        /// </summary>
        private const string RegistryProgid = "Progid";

        /// <summary>
        /// Determines whether the given file extension associated within the Windows Registry.
        /// </summary>
        /// <param name="fileExtension">The file extension to check for.</param>
        /// <returns><c>True</c> if the file extension is associated, <c>false</c> otherwise.</returns>
        public static bool IsFileExtensionAssociated(string fileExtension)
        {
            try
            {
                if (!fileExtension.StartsWith("."))
                {
                    fileExtension = "." + fileExtension;
                }

                return Registry.CurrentUser.OpenSubKey(RegistrySoftwareClasses + fileExtension.ToLower(), false) != null;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Associates the file extension to a <see cref="System.Windows.Forms.Application"/>.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="force">A value indicating whether the existing keys should be forced to be re-created.</param>
        /// <returns><c>true</c> if the association was made successfully, <c>false</c> otherwise.</returns>
        public static bool AssociateApplicationToFileExtension(string fileExtension, bool force = false)
        {
            try
            {
                if (!fileExtension.StartsWith("."))
                {
                    fileExtension = "." + fileExtension;
                }

                if (IsFileExtensionAssociated(fileExtension))
                {
                    if (!force)
                    {
                        return true;
                    }
                }

                if (force)
                {
                    RemoveAssociatedFileExtension(fileExtension);
                }

                var fileRegistryKey =
                    Registry.CurrentUser.CreateSubKey(RegistrySoftwareClasses + fileExtension.ToLower());

                var applicationRegistryKey =
                    Registry.CurrentUser.CreateSubKey(RegistrySoftwareClassesApplications + Path.GetFileName(Application.ExecutablePath));

                var applicationAssociationKey =
                    Registry.CurrentUser.CreateSubKey(RegistrySoftwareMicrosoftWindowsCurrentVersionFileExts +
                                                      fileExtension);

                if (fileRegistryKey == null)
                {
                    return false;
                }

                fileRegistryKey.CreateSubKey(RegistryDefaultIcon)?.SetValue("", Application.ExecutablePath);

                applicationRegistryKey?.CreateSubKey(RegistryShellOpenCommand)
                    ?.SetValue("", "\"" + Application.ExecutablePath + "\" %1");

                applicationRegistryKey?.CreateSubKey(RegistryShellEditCommand)
                    ?.SetValue("", "\"" + Application.ExecutablePath + "\" %1");

                applicationRegistryKey?.CreateSubKey(RegistryDefaultIcon)?.SetValue("", Application.ExecutablePath);

                try
                {
                    applicationAssociationKey?.CreateSubKey(RegistryUserChoice)?.SetValue(RegistryProgid,
                        RegistryApplications + Path.GetFileName(Application.ExecutablePath));
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ExceptionLogAction?.Invoke(ex);
                }

                SHChangeNotify(SHCNE_ASSOCCHANGED, 0, IntPtr.Zero, IntPtr.Zero);

                return true;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Removes the associated file association for a given file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension.</param>
        /// <returns><c>true</c> if the association was removed successfully, <c>false</c> otherwise.</returns>
        public static bool RemoveAssociatedFileExtension(string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(fileExtension))
            {
                throw new ArgumentException(@"The given file extension must be a valid file extension",
                    nameof(fileExtension));
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(RegistrySoftwareClasses + fileExtension.ToLower());
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(RegistrySoftwareClassesApplications +
                                                      Path.GetFileName(Application.ExecutablePath));
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(RegistrySoftwareMicrosoftWindowsCurrentVersionFileExts +
                                                      fileExtension);
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
            }


            try
            {
                SHChangeNotify(SHCNE_ASSOCCHANGED, 0, IntPtr.Zero, IntPtr.Zero);
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
                throw;
            }

            return true;
        }
    }
}
