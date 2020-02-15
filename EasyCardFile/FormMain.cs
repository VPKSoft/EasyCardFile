#region License
/*
MIT License

Copyright(c) 2019 Petteri Kautonen

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
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EasyCardFile.CardFileHandler;
using EasyCardFile.CardFileHandler.CardFileNaming;
using EasyCardFile.CardFileHandler.CardFilePreferences;
using EasyCardFile.CardFileHandler.LegacyCardFile;
using EasyCardFile.Database.Encryption;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Context.ContextCompression;
using EasyCardFile.Database.Entity.Context.ContextEncryption;
using EasyCardFile.UtilityClasses.Localization;
using VPKSoft.ErrorLogger;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;
using VU = VPKSoft.Utils;

// Icon (C): https://icon-icons.com/icon/card-file-box/109271, Apache 2.0

namespace EasyCardFile
{
    /// <summary>
    /// The main form of the application.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormMain : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyCardFile.FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            // ReSharper disable once StringLiteralTypo
            DBLangEngine.DBName = "localization.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages",
                    Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }

            // initialize the language/localization database..
            DBLangEngine.InitializeLanguage("EasyCardFile.UtilityClasses.Localization.Messages");

            // localize the "UI engine"..
            CardFileUiWrapper.LocalizeTexts();

            var appDataPath = VU.Paths.MakeAppSettingsFolder();
            var temporaryPath = Path.Combine(appDataPath + "Temporary");
            if (!Directory.Exists(temporaryPath))
            {
                Directory.CreateDirectory(temporaryPath);
            }
            CardFileUiWrapper.TemporaryPath = temporaryPath;

            LocalizeStaticProperties.LocalizeStatic();

            mnuTest.Visible = Debugger.IsAttached;
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            // ReSharper disable once ObjectCreationAsStatement
            var cardFile = new CardFileUiWrapper(tcCardFiles);
        }

        private void mnuImportPrevious_Click(object sender, EventArgs e)
        {
            CardFileLegacyReader.Convert(odCardFileLegacy, sdCardFile, this);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (odCardFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // ReSharper disable once ObjectCreationAsStatement
                    new CardFileUiWrapper(odCardFile.FileName, tcCardFiles);
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ExceptionLogger.LogError(ex);
                    MessageBoxExtended.Show(this,
                        DBLangEngine.GetMessage("msgCardFileFailedOpen",
                            "Failed to open the card file: '{0}'.|A message for a message dialog that the card file failed to open",
                            odCardFile.FileName),
                        DBLangEngine.GetMessage("msgError",
                            "Error|A message describing that some kind of error occurred."),
                        MessageBoxButtonsExtended.OK, MessageBoxIcon.Error, true);
                }
            }
        }

        private void tcCardFiles_CloseTabButtonClick(object sender, Manina.Windows.Forms.CancelTabEventArgs e)
        {
            CardFileSaveClose.CloseCardFile(true, e.Tab);
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
            
            var cardFile = CardFileUiWrapper.GetActiveDbContext(tcCardFiles);
            cardFile.EnableEncryption(Encoding.UTF8, this);
            cardFile.CardFile.Compressed = true;
            cardFile.SaveWithEncryption();
            cardFile.SaveWithCompression(Encoding.UTF8);
            cardFile.VacuumDatabase();

            //cardFile.EnableEncryption(Encoding.UTF8, this);

            //CardFileDbContext.CompressCardFile(cardFile, Encoding.UTF8);

            /*
            var randomBase64 = DatabaseEncryptionHelper.GenerateRandomBase64Data(150, 200);
            var encryptedBase64 = DatabaseEncryptionHelper.EncryptData("helevetti", randomBase64, Encoding.UTF8);
            var decryptedBase64 = encryptedBase64.DecryptBase64("helevetti", Encoding.UTF8);

            return;


/*            var value = "testitekstiä jonniin verran";

            var encrypted = value.EncryptBase64("helevetti", Encoding.UTF8);
            var decrypted = encrypted.DecryptBase64("helevetti", Encoding.UTF8);

            MessageBox.Show(decrypted);
            return;*/
            //var cardFile = CardFileUiWrapper.GetActiveDbContext(tcCardFiles);

            //CardFileDbContext.SaveEncryptedCardFile(cardFile, "helevetti", Encoding.UTF8);

//            CardFileDbContext.DecryptCardFile(cardFile, "helevetti", Encoding.UTF8);
        }
    }
}
