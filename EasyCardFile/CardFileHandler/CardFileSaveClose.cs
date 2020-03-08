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
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.UtilityClasses.Constants;
using EasyCardFile.UtilityClasses.ErrorHandling;
using EasyCardFile.UtilityClasses.Localization;
using Manina.Windows.Forms;
using VPKSoft.MessageBoxExtended;

namespace EasyCardFile.CardFileHandler
{
    /// <summary>
    /// A class to help with saving and closing card files.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class CardFileSaveClose: ErrorHandlingBase
    {
        /// <summary>
        /// Clears the temporary files used by the software.
        /// </summary>
        /// <returns><c>true</c> if the files were cleared successfully, <c>false</c> otherwise.</returns>
        internal static bool ClearTemporaryFiles()
        {
            try
            {
                foreach (var file in Directory.GetFiles(TemporaryPath))
                {
                    File.Delete(file);
                }

                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        internal static bool SaveCardFile(Manina.Windows.Forms.TabControl tabControl, 
            SaveFileDialog sdSaveCardFileAs, bool releaseResources)
        {
            var cardFile = CardFileUiWrapper.GetActiveUiWrapper(tabControl);

            if (cardFile.IsTemporary || !File.Exists(cardFile.FileName))
            {
                return SaveCardFileAs(tabControl, sdSaveCardFileAs, releaseResources);
            }

            try
            {
                if (!releaseResources)
                {
                    cardFile.CardFileDb.SaveChanges();
                }
                else
                {
                    CardFileDbContext.ReleaseDbContext(cardFile.CardFileDb, true, true);
                }
                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }

        }

        private static string RemoveInvalidPathChars(string path)
        {
            var split = path.Split(Path.GetInvalidFileNameChars());
            if (split.Length == 1)
            {
                return split[0];
            }
            return string.Concat("_", split);
        }

        internal static string GetSaveFileName(CardFileUiWrapper wrapper)
        {
            try
            {
                if (wrapper.IsTemporary)
                {
                    return RemoveInvalidPathChars(wrapper.CardFileDb.CardFile.Name) + EasyCardFileConstants.FileExtension;
                }

                return Path.GetFileName(wrapper.FileName);
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// Saves the active card file as.
        /// </summary>
        /// <param name="tabControl">The tab control witch the active card files reside.</param>
        /// <param name="sdCardFile">A save file dialog to save the file as.</param>
        /// <param name="releaseResources">A value indicating whether to release the resources (database connection and UI resources) in case the card file is being closed.</param>
        /// <returns><c>true</c> if the active card file was saved as successfully, <c>false</c> otherwise.</returns>
        internal static bool SaveCardFileAs(Manina.Windows.Forms.TabControl tabControl, SaveFileDialog sdCardFile, bool releaseResources)
        {
            try
            {
                var wrapper = CardFileUiWrapper.GetActiveUiWrapper(tabControl);
                if (wrapper != null)
                {
                    var context = wrapper.CardFileDb;
                    if (!wrapper.IsTemporary)
                    {
                        var tempSave = TemporaryFile;
                        var previousFileName = wrapper.FileName;
                        File.Copy(wrapper.FileName, tempSave);

                        sdCardFile.FileName = GetSaveFileName(wrapper);

                        if (context != null && sdCardFile.ShowDialog() == DialogResult.OK)
                        {
                            var newFileName = sdCardFile.FileName;
                            CardFileDbContext.SaveFileAs(ref context, newFileName);
                            CardFileUiWrapper.SetActiveDbContext(tabControl, context, newFileName);
                            if (releaseResources)
                            {
                                CardFileDbContext.ReleaseDbContext(context, true, true);
                            }

                            if (previousFileName != newFileName)
                            {
                                File.Delete(previousFileName);

                                File.Move(tempSave, previousFileName);
                            }
                            else
                            {
                                File.Delete(tempSave);
                            }
                        }
                        else
                        {
                            File.Delete(tempSave);
                        }
                    }
                    else
                    {
                        sdCardFile.FileName = GetSaveFileName(wrapper);

                        if (sdCardFile.ShowDialog() == DialogResult.OK)
                        {
                            wrapper.SaveFile = true;
                            wrapper.NewFileName = sdCardFile.FileName;

                            CardFileDbContext.ReleaseDbContext(wrapper.CardFileDb, wrapper.SaveFile, true,
                                wrapper.NewFileName, !wrapper.IsTemporary);
                            wrapper.IsTemporary = false;
                            if (!releaseResources)
                            {
                                wrapper.FileName = wrapper.NewFileName;
                                wrapper.CardFileDb = CardFileDbContext.InitializeDbContext(wrapper.NewFileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles the closing and saving the card file tabs in case the user has accepted the application to be closed.
        /// </summary>
        /// <param name="tabControl">The tab control where the <see cref="CardFileUiWrapper"/> instances are located.</param>
        /// <returns><c>true</c> if the card file tabs for handled successfully, <c>false</c> otherwise.</returns>
        internal static bool HandleTabsAfterClose(Manina.Windows.Forms.TabControl tabControl)
        {
            try
            {
                foreach (var tab in tabControl.Tabs)
                {
                    var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);
                    if (wrapper.CardFileDb.ChangeTracker.HasChanges())
                    {
                        if (CardFileDbContext.ReleaseDbContext(wrapper.CardFileDb, wrapper.SaveFile, true,
                            wrapper.NewFileName, !wrapper.IsTemporary))
                        {
                            if (wrapper.IsTemporary)
                            {
                                File.Delete(wrapper.FileName);
                            }

                            if (!string.IsNullOrEmpty(wrapper.NewFileName))
                            {
                                wrapper.FileName = wrapper.NewFileName;
                            }
                        }
                    }
                    else
                    {
                        CardFileDbContext.ReleaseDbContext(wrapper.CardFileDb, false, true);
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Runs the save check before the application close.
        /// </summary>
        /// <param name="tabControl">The tab control where the <see cref="CardFileUiWrapper"/> instances are located.</param>
        /// <param name="owner">An implementation of <see cref="T:System.Windows.Forms.IWin32Window" /> that will own the modal dialog box in case one is required by the method.</param>
        /// <param name="sdCardFile">A save file dialog in case new changed card files should be saved.</param>
        /// <param name="autoSave">if set to <c>true</c> the existing card files are automatically saved.</param>
        /// <returns><c>true</c> if the user accepted the application to be closed, <c>false</c> otherwise.</returns>
        internal static bool RunSaveCheckApplicationClose(Manina.Windows.Forms.TabControl tabControl,
            IWin32Window owner, SaveFileDialog sdCardFile, bool autoSave)
        {
            foreach (var tab in tabControl.Tabs)
            {
                var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);

                if (wrapper.CardFileDb.ChangeTracker.HasChanges())
                {
                    wrapper.SaveFile = false;
                    wrapper.NewFileName = default;

                    if (wrapper.IsTemporary)
                    {
                        var result = MessageBoxExtended.Show(owner,
                            string.Format(LocalizeStaticProperties.CardFileChangedSaveQuery,
                                wrapper.CardFileDb?.CardFile?.Name),
                            LocalizeStaticProperties.CardFileChangedSaveQueryTitle,
                            MessageBoxButtonsExtended.YesNoCancel,
                            MessageBoxIcon.Question, true);

                        if (result == DialogResultExtended.Cancel)
                        {
                            return false;
                        }

                        sdCardFile.FileName = wrapper.CardFileDb?.CardFile?.Name + EasyCardFileConstants.FileExtension;

                        if (result == DialogResultExtended.Yes && sdCardFile.ShowDialog() == DialogResult.OK)
                        {
                            wrapper.SaveFile = true;
                            wrapper.NewFileName = sdCardFile.FileName;
                        }
                    }
                    else if (autoSave)
                    {
                        wrapper.SaveFile = true;
                    }
                    else
                    {
                        var result = MessageBoxExtended.Show(owner,
                            string.Format(LocalizeStaticProperties.CardFileChangedSaveQuery,
                                wrapper.CardFileDb?.CardFile?.Name),
                            LocalizeStaticProperties.CardFileChangedSaveQueryTitle,
                            MessageBoxButtonsExtended.YesNoCancel,
                            MessageBoxIcon.Question, true);

                        if (result == DialogResultExtended.Cancel)
                        {
                            return false;
                        }

                        wrapper.SaveFile = result == DialogResultExtended.Yes;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Saves the card file as a new file.
        /// </summary>
        /// <param name="newFile">The new file name to save the card file to.</param>
        /// <param name="tab">The <see cref="Manina.Windows.Forms.Tab"/> instance which associated UI wrapper belongs to.</param>
        /// <returns><c>true</c> if the card file was saved successfully, <c>false</c> otherwise.</returns>
        internal static bool SaveCardFileAs(string newFile, Tab tab)
        {
            var uiWrapper = CardFileUiWrapper.GetWrapperByTab(tab);
            if (uiWrapper != null)
            {
                SaveCardFileAs(newFile, uiWrapper);
            }

            return false;
        }

        /// <summary>
        /// Saves the card file as a new file.
        /// </summary>
        /// <param name="newFile">The new file name to save the card file to.</param>
        /// <param name="cardFile">The card file.</param>
        /// <returns><c>true</c> if the card file was saved successfully, <c>false</c> otherwise.</returns>
        internal static bool SaveCardFileAs(string newFile, CardFileUiWrapper cardFile)
        {
            try
            {
                // the previous file must be deleted as the SQLite connection would open the file contents otherwise..
                if (File.Exists(newFile)) 
                {
                    File.Delete(newFile);
                }

                if (cardFile.IsTemporary) // a temporary file can be moved..
                {
                    CardFileDbContext.ReleaseDbContext(cardFile.CardFileDb, true, true);
                    File.Move(cardFile.FileName, newFile);
                    cardFile.CardFileDb = CardFileDbContext.InitializeDbContext(newFile);
                }
                else // an existing non-temporary file is kept..
                {
                    cardFile.CardFileDb = CardFileDbContext.Copy(cardFile.CardFileDb, newFile);
                }

                cardFile.FileName = newFile;
                cardFile.IsTemporary = false;

                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Closes the card file and optionally saves the changes.
        /// </summary>
        /// <param name="saveChanges">A value indicating whether to save the changes to the card file.</param>
        /// <param name="tab">The <see cref="Manina.Windows.Forms.Tab"/> instance which associated UI wrapper belongs to.</param>
        /// <returns><c>true</c> if the card file was closed successfully; <c>false</c> otherwise.</returns>
        internal static bool CloseCardFile(bool saveChanges, Tab tab)
        {
            var uiWrapper = CardFileUiWrapper.GetWrapperByTab(tab);
            if (uiWrapper != null)
            {
                return CloseCardFile(saveChanges, uiWrapper);
            }

            return false;
        }

        /// <summary>
        /// Closes the card file and optionally saves the changes.
        /// </summary>
        /// <param name="saveChanges">A value indicating whether to save the changes to the card file.</param>
        /// <param name="cardFile"></param>
        /// <returns><c>True</c> if the card file was closed successfully; <c>false</c> otherwise.</returns>
        internal static bool CloseCardFile(bool saveChanges, CardFileUiWrapper cardFile)
        {
            try
            {
                using (cardFile)
                {
                    cardFile.SaveChangesOnClose = saveChanges;
                }

                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            return false;
        }

        #region InternalProperties
        /// <summary>
        /// Gets or sets the temporary path used by the software.
        /// </summary>
        internal static string TemporaryPath { get; set; }

        /// <summary>
        /// Gets the temporary random file name residing in the <see cref="TemporaryPath"/> folder.
        /// </summary>
        internal static string TemporaryFile => Path.Combine(TemporaryPath, Path.GetRandomFileName());
        #endregion
    }
}
