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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using EasyCardFile.CardFileHandler;
using EasyCardFile.CardFileHandler.CardFilePreferences;
using EasyCardFile.UtilityClasses.ErrorHandling;
using EasyCardFile.UtilityClasses.Miscellaneous.Dialogs;
using VPKSoft.Utils;
using VPKSoft.Utils.XmlSettingsMisc;

namespace EasyCardFile.Settings
{
    /// <summary>
    /// A class for the application settings.
    /// Implements the <see cref="VPKSoft.Utils.XmlSettings" />
    /// </summary>
    /// <seealso cref="VPKSoft.Utils.XmlSettings" />
    public class Settings: XmlSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the existing card files are auto saved upon software close.
        /// </summary>
        [IsSetting(DefaultValue = true)]
        public bool AutoSave { get; set; }

        /// <summary>
        /// Gets or sets the session files.
        /// </summary>
        [IsSetting]
        public List<string> SessionFiles { get; set; }

        /// <summary>
        /// Gets or sets the splitter settings.
        /// </summary>
        /// <value>The splitter settings.</value>
        [IsSetting]
        public List<string> SplitterSettings { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the locale setting for the software.
        /// </summary>
        [IsSetting]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to restore the session on application startup.
        /// </summary>
        [IsSetting(DefaultValue = true)]
        public bool RestoreSessionOnStartup { get; set; }

        /// <summary>
        /// Gets or sets the index of the session active tab.
        /// </summary>
        [IsSetting]
        public int SessionActiveTabIndex { get; set; }

        /// <summary>
        /// Gets or sets the path of the image dialog in the <see cref="FormDialogCardFilePreferences"/> dialog.
        /// </summary>
        [IsSetting]
        public string PathImageDialogPreference { get; set; }

        /// <summary>
        /// Gets or sets the path of the image dialog in the <see cref="FormDialogSelectImageArea"/> dialog.
        /// </summary>
        [IsSetting]
        public string PathImageDialogSelectImageArea { get; set; }

        /// <summary>
        /// Gets or sets the path of the file dialog to open legacy card files in the <see cref="FormMain"/> from.
        /// </summary>
        [IsSetting]
        public string PathFileDialogMainOpenLegacy { get; set; }

        /// <summary>
        /// Gets or sets the path of the file dialog to save a card file in the <see cref="FormMain"/> from.
        /// </summary>
        [IsSetting]
        public string PathFileDialogMainSave { get; set; }

        /// <summary>
        /// Gets or sets the path of the file dialog to open a card file in the <see cref="FormMain"/> from.
        /// </summary>
        [IsSetting]
        public string PathFileDialogMainOpen { get; set; }

        /// <summary>
        /// Gets or sets the path of the file dialog to import Rtf files to card contents in the <see cref="FormMain"/> from.
        /// </summary>
        [IsSetting]
        public string PathFileDialogRtfOpen { get; set; }

        /// <summary>
        /// Gets or sets the path of the file dialog to export Rtf files from card contents in the <see cref="FormMain"/> from.
        /// </summary>
        [IsSetting]
        public string PathFileDialogRtfSave { get; set; }

        #region RecentFiles
        /// <summary>
        /// Gets or sets the recent files.
        /// </summary>
        [IsSetting]
        public List<string> RecentFiles { get; set; }

        /// <summary>
        /// Tidies the recent file list.
        /// </summary>
        private void TidyRecentFileList()
        {
            if (RecentFiles == null)
            {
                RecentFiles = new List<string>();
            }

            for (int i = RecentFiles.Count - 1; i >= 0; i--)
            {
                if (!File.Exists(RecentFiles[i]))
                {
                    RecentFiles.RemoveAt(i);
                }
            }

            while (RecentFiles.Count > 20)
            {
                RecentFiles.RemoveAt(0);
            }
        }

        /// <summary>
        /// Adds a given <see cref="CardFileUiWrapper"/> instance file name to the recent files.
        /// </summary>
        /// <param name="wrapper">The wrapper which file name to add to the recent files.</param>
        public void AddRecentFile(CardFileUiWrapper wrapper)
        {
            if (wrapper == null)
            {
                return;
            }
            AddRecentFile(wrapper.FileName);
        }

        /// <summary>
        /// Adds a given file name to the recent files.
        /// </summary>
        /// <param name="fileName">Name of the file to add to the recent files collection.</param>
        public void AddRecentFile(string fileName)
        {
            if (RecentFiles == null)
            {
                RecentFiles = new List<string>();
            }

            if (!RecentFiles.Contains(fileName))
            {
                RecentFiles.Add(fileName);
            }
            else
            {
                RecentFiles.Remove(fileName);
                RecentFiles.Add(fileName);
            }

            TidyRecentFileList();
        }

        /// <summary>
        /// Creates the recent files menu.
        /// </summary>
        /// <param name="item">The menu item which <see cref="ToolStripDropDownItem.DropDownItems"/> should contain the recent file list.</param>
        /// <param name="tabControl">The tab control which the currently opened <see cref="CardFileUiWrapper"/> instances reside.</param>
        /// <param name="clickHandlerAction">The action to perform when a recent menu item is clicked.</param>
        /// <param name="hideSplitters">The <see cref="ToolStripItem"/> items which should be hidden if the recent files menu is empty.</param>
        public void CreateRecentFilesMenu(ToolStripMenuItem item, Manina.Windows.Forms.TabControl tabControl,
            Action<object, EventArgs> clickHandlerAction,
            params ToolStripItem [] hideSplitters)
        {
            TidyRecentFileList();
            item.DropDownItems.Clear();

            var result = new List<string>(RecentFiles.ToArray());
            foreach (var tab in tabControl.Tabs)
            {
                var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);
                if (wrapper == null)
                {
                    continue;
                }
                result.Remove(wrapper.FileName);
            }

            result.Reverse();

            foreach (var recentFile in result)
            {
                item.DropDownItems.Add(new ToolStripMenuItem(recentFile, null,
                    delegate(object sender, EventArgs args) { clickHandlerAction(sender, args); }) {Tag = recentFile});
            }

            item.Visible = result.Count > 0;
            foreach (var splitter in hideSplitters)
            {
                splitter.Visible = result.Count > 0;
            }
        }

        #endregion


        #region SpellCheck
        /// <summary>
        /// Gets or sets the initial directory for an open file dialog to open a Hunspell affix file from the <see cref="FormDialogSettings"/> form.
        /// </summary>
        [IsSetting]
        public string FileLocationOpenAffix { get; set; }

        /// <summary>
        /// Gets or sets the initial directory for an open file dialog to open a Hunspell dictionary file from the <see cref="FormDialogSettings"/> form.
        /// </summary>
        [IsSetting]
        public string FileLocationOpenDictionary { get; set; }

        private string editorHunspellDictionaryPath;

        /// <summary>
        /// Gets or sets a value of the Hunspell dictionary file to be used with spell checking for the spell checking.
        /// </summary>
        [IsSetting]
        public string EditorHunspellDictionaryPath
        {
            get
            {
                if (editorHunspellDictionaryPath == default || !Directory.Exists(editorHunspellDictionaryPath))
                {
                    editorHunspellDictionaryPath = Path.Combine(Paths.GetAppSettingsFolder(), "dictionaries", "en");
                }

                return editorHunspellDictionaryPath;
            }

            set
            {
                if (value == default || !Directory.Exists(value))
                {
                    editorHunspellDictionaryPath = Path.Combine(Paths.GetAppSettingsFolder(), "dictionaries", "en");
                    return;
                }

                editorHunspellDictionaryPath = value;
            }
        }

        /// <summary>
        /// Gets or sets a value of the Hunspell dictionary file to be used with spell checking for the card file cards.
        /// </summary>
        [IsSetting]
        public string EditorHunspellDictionaryFile { get; set; }

        /// <summary>
        /// Gets or sets a value of the Hunspell affix file to be used with spell checking for the card file cards.
        /// </summary>
        [IsSetting]
        public string EditorHunspellAffixFile { get; set; }

        /// <summary>
        /// Gets a value indicating whether the spell checking is enabled.
        /// </summary>
        public bool SpellCheckingEnabled
        {
            get
            {
                try
                {
                    return File.Exists(EditorHunspellAffixFile) && File.Exists(EditorHunspellDictionaryFile);
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                    return false;
                }
            }
        }
        #endregion

        #region Colors        
        /// <summary>
        /// Gets or sets the color of the editor button.
        /// </summary>
        [IsSetting]
        public string EditorButtonColor { get; set; }

        /// <summary>
        /// Gets or sets the color of the editor glyph.
        /// </summary>
        [IsSetting]
        public string EditorGlyphColor { get; set; }
        #endregion

        /// <summary>
        /// Sets the files belonging to the current session.
        /// </summary>
        /// <param name="tabControl">The tab control witch the active card files reside.</param>
        public void SetSessionFiles(Manina.Windows.Forms.TabControl tabControl)
        {
            SessionFiles = new List<string>();

            foreach (var tab in tabControl.Tabs)
            {
                var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);

                if (wrapper == null)
                {
                    continue;
                }

                if (!wrapper.IsTemporary)
                {
                    SessionFiles.Add(wrapper.FileName);
                }
            }
        }

        /// <summary>
        /// Sets the splitter distances of the <see cref="CardFileUiWrapper"/> instances to the settings.
        /// </summary>
        /// <param name="tabControl">The tab control witch <see cref="CardFileUiWrapper"/> instances reside.</param>
        /// <param name="mainWindowWidth">The width of the main window of the application to allow relation to to splitter distance result.</param>
        public void SetSplitters(Manina.Windows.Forms.TabControl tabControl, int mainWindowWidth)
        {
            foreach (var tab in tabControl.Tabs)
            {
                var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);

                if (wrapper == null)
                {
                    continue;
                }

                SetSplitter(wrapper, mainWindowWidth);
            }
        }

        /// <summary>
        /// Sets the splitter distance of the <see cref="CardFileUiWrapper"/> instance to the settings.
        /// </summary>
        /// <param name="wrapper">The <see cref="CardFileUiWrapper"/> instance which splitter distance to save.</param>
        /// <param name="mainWindowWidth">The width of the main window of the application to allow relation to to splitter distance result.</param>
        public void SetSplitter(CardFileUiWrapper wrapper, int mainWindowWidth)
        {
            if (wrapper.IsTemporary || !File.Exists(wrapper.FileName))
            {
                return;
            }

            var index = SplitterSettings.FindIndex(f => f.EndsWith(wrapper.FileName));

            if (index != -1)
            {
                SplitterSettings.RemoveAt(index);
            }

            SplitterSettings.Add(wrapper.SplitterDistance + "|" + mainWindowWidth + ":" + wrapper.FileName);
        }

        /// <summary>
        /// Gets the splitter distances for a <see cref="CardFileUiWrapper"/> instances.
        /// </summary>
        /// <param name="tabControl">The tab control witch <see cref="CardFileUiWrapper"/> instances reside.</param>
        /// <param name="mainWindowWidth">The width of the main window of the application to allow relation to to splitter distance result.</param>
        public void GetSplitters(Manina.Windows.Forms.TabControl tabControl, int mainWindowWidth)
        {
            foreach (var tab in tabControl.Tabs)
            {
                var wrapper = CardFileUiWrapper.GetWrapperByTab(tab);

                if (wrapper == null)
                {
                    continue;
                }

                GetSplitter(wrapper, mainWindowWidth);
            }
        }

        /// <summary>
        /// Gets the splitter distance for a <see cref="CardFileUiWrapper"/> instance.
        /// </summary>
        /// <param name="wrapper">The <see cref="CardFileUiWrapper"/> instance which splitter distance to save.</param>
        /// <param name="mainWindowWidth">The width of the main window of the application to allow relation to to splitter distance result.</param>
        public void GetSplitter(CardFileUiWrapper wrapper, int mainWindowWidth)
        {
            var index = SplitterSettings.FindIndex(f => f.EndsWith(wrapper.FileName));

            if (index != -1)
            {
                var distance = SplitterSettings[index].Split(':').FirstOrDefault()?.Split('|');
                if (distance != null && distance.Length == 2)
                {
                    var previousWidth = int.Parse(distance[1]);
                    var splitterDistance = int.Parse(distance[0]);

                    var difference = (double)previousWidth - mainWindowWidth;

                    difference /= mainWindowWidth;
                        difference = 1.0 - difference;

                    var newDistance = (int)(splitterDistance * difference);

                    wrapper.SplitterDistance = newDistance;
                }
            }
        }
    }
}
