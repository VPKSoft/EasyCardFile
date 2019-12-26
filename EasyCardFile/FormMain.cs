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
using System.IO;
using System.Windows.Forms;
using EasyCardFile.CardFileHandler;
using VPKSoft.LangLib;
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
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            // ReSharper disable once ObjectCreationAsStatement
            new CardFileUiWrapper(tcCardFiles);
        }

        private void mnuImportPrevious_Click(object sender, EventArgs e)
        {
            CardFileLegacyReader.Convert(odCardFileLegacy, sdCardFile, this);
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (odCardFile.ShowDialog() == DialogResult.OK)
            {
                // ReSharper disable once ObjectCreationAsStatement
                new CardFileUiWrapper(odCardFile.FileName, tcCardFiles);
            }
        }
    }
}
