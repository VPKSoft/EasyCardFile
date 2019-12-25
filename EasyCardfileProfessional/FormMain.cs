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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyCardFileProfessional.Database.Entity.Context;
using EasyCardFileProfessional.Database.Entity.Entities;
using LegacySupportQTVersion;
using Manina.Windows.Forms;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;
using VPKSoft.RichTextEdit;
using TabControl = Manina.Windows.Forms.TabControl;

// Icon (C): https://icon-icons.com/icon/card-file-box/109271, Apache 2.0

namespace EasyCardFileProfessional
{
    /// <summary>
    /// The main form of the application.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormMain : DBLangEngineWinforms
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EasyCardFileProfessional.FormMain"/> class.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();


            DBLangEngine.DBName = "lang.sqlite"; // Do the VPKSoft.LangLib == translation..

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitializeLanguage("EasyCardFileProfessional.UtilityClasses.Localization.Messages",
                    Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more..
            }
        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            CreateTabControls(tcCardFiles, "Uusi", "Search:");
        }

        // TODO::parempi containeri!!
        internal static ListBox CreateTabControls(TabControl tabControl, string tabText, string searchText, CardFileDbContext cardFile = null)
        {
            // create a tab for the card file..
            var tab = new Tab {Text = tabText};

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
            var label = new Label {Text = searchText, Padding = new Padding(2), Margin = new Padding(3),};
            tableLayoutPanel.Controls.Add(label, 0, 0);

            // create the search text box..
            var textBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top};
            tableLayoutPanel.Controls.Add(textBox, 1, 0);

            // create the card file list box..
            var listBox = new ListBox {Dock = DockStyle.Fill};
            tableLayoutPanel.Controls.Add(listBox, 0, 1);
            tableLayoutPanel.SetColumnSpan(listBox, 2);

            // weird place to save an instance of the entity framework model..
            listBox.Tag = cardFile;
            if (cardFile != null)
            {
                foreach (var card in cardFile.Cards)
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
                var card = (Card) ((ListBox) sender).SelectedItem;
                richTextBox.Rtf = Encoding.UTF8.GetString(card.CardContents);
            };


            // create a status strip for the card editor/viewer..
            var statusStrip = new StatusStrip {Dock = DockStyle.Fill,};
            tableLayoutPanel.Controls.Add(statusStrip, 0, 1);

            // TODO::Do to morrow ;-) The status strip!

            // add the controls to right split panel..
            splitContainer.Panel2.Controls.Add(tableLayoutPanel);

            tab.Controls.Add(splitContainer);
            tabControl.Tabs.Add(tab);

            return listBox;
        }

        private void mnuImportPrevious_Click(object sender, EventArgs e)
        {
            if (odCardFileLegacy.ShowDialog() == DialogResult.OK && sdCardFile.ShowDialog() == DialogResult.OK)
            {
                var password = "";
                if (CardFileDataReader.IsEncrypted(odCardFileLegacy.FileName))
                {
                    if (string.IsNullOrEmpty(password = MessageBoxQueryPassword.Show(this, "Give a password:", "Password")))
                    {
                        return;
                    }


                    if (!CardFileDataReader.ValidPassword(odCardFileLegacy.FileName, password))
                    {
                        MessageBox.Show(
                            DBLangEngine.GetMessage("msgInvalidPassword",
                                "The given password was invalid|The user gave an invalid password checked by the software's verification logic."),
                            DBLangEngine.GetMessage("msgError",
                                "Error|A message describing that some kind of error occurred."),
                            MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }

                var legacyReader = new CardFileDataReader(odCardFileLegacy.FileName, password);

                var cardFileEntry = legacyReader.GetCardFileData();

                var cardFileNew = CardFileDbContext.InitializeDbContext(sdCardFile.FileName);

                var cardTypes = legacyReader.GetCardTypes();
                foreach (var cardType in cardTypes)
                {
                    cardFileNew.CardTypes.Add(new CardType {CardTypeName = cardType});
                }

                cardFileNew.CardFiles.Add(new CardFile
                {
                    Name = cardFileEntry.databaseName,
                    CardNamingInstruction = cardFileEntry.autoLabelInstructions,
                    Compressed = false,
                    Encrypted = false,
                    DefaultCardType = cardFileNew.CardTypes.FirstOrDefault(f => f.CardTypeName == cardFileEntry.defaultCardType),
                });

                var ordering = 0;

                var cards = legacyReader.GetCards();
                foreach (var card in cards)
                {
                    cardFileNew.Cards.Add(
                        new Card
                        {
                            CardName = card.name,
                            CardType = cardFileNew.CardTypes.FirstOrDefault(f => f.CardTypeName == card.type),
                            Ordering = ordering++,
                            CardContents = Encoding.UTF8.GetBytes(card.cardContents),
                        });
                }

                var templates = legacyReader.GetTemplates();
                foreach (var template in templates)
                {
                    cardFileNew.CardTemplates.Add(
                        new CardTemplate
                        {
                            CardTemplateName = template.name,
                            CardTemplateContents = Encoding.UTF8.GetBytes(template.templateContents),
                        });
                }

                CardFileDbContext.ReleaseDbContext(cardFileNew, true, true);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (odCardFile.ShowDialog() == DialogResult.OK)
            {
                var cardFile = CardFileDbContext.InitializeDbContext(odCardFile.FileName);
                CreateTabControls(tcCardFiles, cardFile.CardFiles.First().Name, "Search:", cardFile);
            }
        }
    }
}
