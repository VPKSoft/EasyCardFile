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
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.ErrorHandling;
using Manina.Windows.Forms;

namespace EasyCardFile.CardFileHandler
{
    /// <summary>
    /// A class to help with saving and closing card files.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class CardFileSaveClose: ErrorHandlingBase
    {
        internal static bool Save(CardFileUiWrapper cardFile)
        {
            try
            {
                cardFile.CardFileDb.SaveChanges();
                cardFile.Changed = false;
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
                cardFile.Changed = false;
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
    }
}
