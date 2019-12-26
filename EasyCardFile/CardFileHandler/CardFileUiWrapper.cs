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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.Database.Entity.ModelHelpers;
using EasyCardFile.UtilityClasses.ErrorHandling;
using Manina.Windows.Forms;
using VPKSoft.LangLib;
using VPKSoft.RichTextEdit;
using TabControl = Manina.Windows.Forms.TabControl;

namespace EasyCardFile.CardFileHandler
{
    /// <summary>
    /// A class for creating the GUI controls with the <see cref="CardFileDbContext"/> class instance.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class CardFileUiWrapper: ErrorHandlingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardFileUiWrapper"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file where the card file is located.</param>
        /// <param name="tabControl">The tab control where the card file visually is located.</param>
        public CardFileUiWrapper(string fileName, TabControl tabControl)
        {
            OpenCardFile(fileName);
            CreateTabControls(tabControl);
            UiWrappers.Add(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardFileUiWrapper"/> class.
        /// </summary>
        /// <param name="tabControl">The tab control where the card file visually is located.</param>
        public CardFileUiWrapper(TabControl tabControl)
        {
            string fileName = Path.Combine(TemporaryPath, Path.GetRandomFileName());
            OpenCardFile(fileName);
            var cardType = new CardType {CardTypeName = NewCardTypeDescription};
            CardFileDb.CardTypes.Add(cardType);
            CardFileDb.CardFiles.Add(new CardFile
                {Name = string.Format(NewFileDescription, NewCounter++), DefaultCardType = cardType});
            CardFileDb.SaveChanges();
            CreateTabControls(tabControl);
            UiWrappers.Add(this);
        }

        internal static int NewCounter { get; set; }

        internal static string NewFileDescription { get; set; } = "New {0}";

        private static string NewCardTypeDescription { get; set; } = "CARD TYPE";

        /// <summary>
        /// Gets or sets the localized search description text.
        /// </summary>
        private static string SearchDescription { get; set; } = "Search:";

        /// <summary>
        /// Localizes the texts used with the CardFile UI.
        /// </summary>
        internal static void LocalizeTexts()
        {
            SearchDescription = DBLangEngine.GetStatMessage("msgSearchTextDescription",
                "Search:|A text for a label near a search text box.");

            NewFileDescription = DBLangEngine.GetStatMessage("msgNewCardFileName",
                "New {0}|A text for a new file name or a new card file internal name.");

            NewCardTypeDescription = DBLangEngine.GetStatMessage("msgNewCardType",
                "CARD TYPE|A default name for a type of a card in a new card file.");
        }

        /// <summary>
        /// Gets or sets the card file database context.
        /// </summary>
        public CardFileDbContext CardFileDb { get; set; }

        /// <summary>
        /// Gets or sets the current instances of the <see cref="CardFileUiWrapper"/> class.
        /// </summary>
        public static List<CardFileUiWrapper> UiWrappers { get; set; } = new List<CardFileUiWrapper>();

        /// <summary>
        /// Gets or sets the temporary path to store new files before saving.
        /// </summary>
        internal static string TemporaryPath { get; set; }

        /// <summary>
        /// Opens an existing card file.
        /// </summary>
        /// <param name="fileName">Name of the file to open.</param>
        /// <returns><c>true</c> if the file was opened successfully, <c>false</c> otherwise.</returns>
        public bool OpenCardFile(string fileName)
        {
            try
            {
                CardFileDb = CardFileDbContext.InitializeDbContext(fileName);
                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        // TODO::parempi containeri!!
        internal void CreateTabControls(TabControl tabControl)
        {
            // create a tab for the card file..
            var tab = new Tab {Text = CardFileDb.CardFiles.FirstOrDefault()?.Name};

            // create a split container for the card file container..
            var splitContainer = new SplitContainer {Dock = DockStyle.Fill,};

            // create a table layout panel for the search box and for the card list..
            var tableLayoutPanel = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 2,};
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            splitContainer.Panel1.Controls.Add(tableLayoutPanel);
            
            // create the search label to indicate that the next control will search something..
            var label = new Label {Text = SearchDescription, Padding = new Padding(2), Margin = new Padding(3),};
            tableLayoutPanel.Controls.Add(label, 0, 0);

            // create the search text box..
            var textBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top};
            tableLayoutPanel.Controls.Add(textBox, 1, 0);

            // create the card file list box..
            var listBox = new ListBox {Dock = DockStyle.Fill};
            tableLayoutPanel.Controls.Add(listBox, 0, 1);
            tableLayoutPanel.SetColumnSpan(listBox, 2);

            // weird place to save an instance of the entity framework model..
            if (CardFileDb != null)
            {
                foreach (var card in CardFileDb.GetCardNameId())
                {
                    listBox.Items.Add(card);
                }
            }

            // create another table layout panel for the card editor and for the status strip..
            tableLayoutPanel = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1,};
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle( SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});

            // create a RichTextBoxWithToolStrip for the card file card contents..
            var richTextBox = new RichTextBoxWithToolStrip {Dock = DockStyle.Fill,};
            tableLayoutPanel.Controls.Add(richTextBox, 0, 0);

            listBox.SelectedValueChanged += delegate(object sender, EventArgs args)
            {
                var pair = (NameIdOrdering) ((ListBox) sender).SelectedItem;
                var card = CardFileDb.Cards.FirstOrDefault(f => f.Id == pair.Id);

                if (card != null)
                {
                    richTextBox.Rtf = Encoding.UTF8.GetString(card.CardContents);
                }
            };

            // create a status strip for the card editor/viewer..
            var statusStrip = new StatusStrip {Dock = DockStyle.Fill,};
            tableLayoutPanel.Controls.Add(statusStrip, 0, 1);

            // TODO::Do to morrow ;-) The status strip!

            // add the controls to right split panel..
            splitContainer.Panel2.Controls.Add(tableLayoutPanel);

            tab.Controls.Add(splitContainer);
            tabControl.Tabs.Add(tab);
        }
    }
}
