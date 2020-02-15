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
using EasyCardFile.Database.Entity.Context.ContextCompression;
using EasyCardFile.Database.Entity.Context.ContextEncryption;
using EasyCardFile.Database.Entity.Entities;
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
    public class CardFileUiWrapper: ErrorHandlingBase, IDisposable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CardFileUiWrapper"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file where the card file is located.</param>
        /// <param name="tabControl">The tab control where the card file visually is located.</param>
        public CardFileUiWrapper(string fileName, TabControl tabControl)
        {
            FileName = fileName;
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
            IsTemporary = true;
            FileName = Path.Combine(TemporaryPath, Path.GetRandomFileName());
            OpenCardFile(FileName);
            var cardType = new CardType {CardTypeName = NewCardTypeDescription};
            CardFileDb.CardFile.CardTypes.Add(cardType);
            CardFileDb.CardFiles.Add(new CardFile
                {Name = string.Format(NewFileDescription, NewCounter++), DefaultCardType = cardType});
            CardFileDb.SaveChanges();
            CreateTabControls(tabControl);
            UiWrappers.Add(this);
        }
        #endregion

        #region Localization
        /// <summary>
        /// Gets or sets the counter cardEntity for new file names.
        /// </summary>
        internal static int NewCounter { get; set; }

        /// <summary>
        /// Gets or sets the localized description (instruction) for naming new card files.
        /// </summary>
        /// <cardEntity>The new file description.</cardEntity>
        internal static string NewFileDescription { get; set; }

        /// <summary>
        /// Gets or sets the localized name for a new card file default card type for user rename later on.
        /// </summary>
        private static string NewCardTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets the localized search description text.
        /// </summary>
        private static string SearchDescription { get; set; }

        /// <summary>
        /// Gets or sets the localized card type description text.
        /// </summary>
        private static string CardTypeDescription { get; set; }

        /// <summary>
        /// Gets or sets the card changed indicator text.
        /// </summary>
        private static string FileChangedIndicator { get; set; }

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

            CardTypeDescription = DBLangEngine.GetStatMessage("msgCardTypeDescription",
                "Card type:|A description text for a card type selection combo box.");

            FileChangedIndicator = DBLangEngine.GetStatMessage("msgFileChangedIndicatorText",
                " [•]|An indicator text to be used with the card file's file name to indicate that the file has been changed.");
        }
        #endregion

        #region StaticProperties
        /// <summary>
        /// Gets or sets the current instances of the <see cref="CardFileUiWrapper"/> class.
        /// </summary>
        public static List<CardFileUiWrapper> UiWrappers { get; set; } = new List<CardFileUiWrapper>();

        /// <summary>
        /// Gets or sets the temporary path to store new files before saving.
        /// </summary>
        internal static string TemporaryPath { get; set; }
        #endregion

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
                if (CardFileDb.CardFile.Compressed)
                {
                    if (!CardFileDb.LoadWithCompression(Encoding.UTF8))
                    {
                        return false;
                    }
                }

                if (CardFileDb.CardFile.Encrypted)
                {
                    if (!CardFileDb.LoadWithEncryption(Encoding.UTF8, Application.OpenForms[0]))
                    {
                        return false;
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

        #region GUI
        /// <summary>
        /// Performs the creation and the layout for a single card file tab to the <see cref="Manina.Windows.Forms.TabControl"/>
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        internal void CreateTabControls(TabControl tabControl)
        {
            // create a tab for the card file..
            Tab = new Tab {Text = CardFileDb.CardFiles.FirstOrDefault()?.Name};

            // create a split container for the card file container..
            var splitContainer = new SplitContainer {Dock = DockStyle.Fill,};

            // create a table layout panel for the search box and for the card list..
            var tableLayoutPanel = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 2,};
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            splitContainer.Panel1.Controls.Add(tableLayoutPanel);

            // create the search label to indicate that the next control will search something..
            var label = new Label {Text = SearchDescription, Padding = new Padding(2), Margin = new Padding(3),};
            tableLayoutPanel.Controls.Add(label, 0, 0);

            // create the search text box..
            SearchTextBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top};
            tableLayoutPanel.Controls.Add(SearchTextBox, 1, 0);
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;

            // create the card file list box..
            ListBoxCards = new ListBox {Dock = DockStyle.Fill};
            tableLayoutPanel.Controls.Add(ListBoxCards, 0, 1);
            tableLayoutPanel.SetColumnSpan(ListBoxCards, 2);

            // add the cards within the card file to the list box..
            if (CardFileDb.CardFile.Cards != null)
            {
                foreach (var card in CardFileDb.CardFile.Cards)
                {
                    ListBoxCards.Items.Add(card);
                }
            }

            // create the label to indicate that the next control will be the card type combo box..
            label = new Label {Text = CardTypeDescription, Padding = new Padding(2), Margin = new Padding(3),};
            tableLayoutPanel.Controls.Add(label, 0, 2);

            // create the combo box for the card type..
            CardTypeComboBox = new ComboBox
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                AutoCompleteMode = AutoCompleteMode.Suggest, 
                AutoCompleteSource = AutoCompleteSource.ListItems, 
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            CardTypeComboBox.SelectedValueChanged += ComboBoxCardType_SelectedValueChanged;

            tableLayoutPanel.Controls.Add(CardTypeComboBox, 1, 2);
            foreach (var cardType in CardFileDb.CardFile.CardTypes)
            {
                CardTypeComboBox.Items.Add(cardType);
            }

            // create another table layout panel for the card editor and for the status strip..
            tableLayoutPanel = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1,};
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle( SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});

            // create a RichTextBoxWithToolStrip for the card file card contents..
            RichTextBox = new RichTextBoxWithToolStrip {Dock = DockStyle.Fill,};
            RichTextBox.TextChanged += RichTextBox_TextChanged;

            tableLayoutPanel.Controls.Add(RichTextBox, 0, 0);

            // subscribe the selected cardEntity changed event handler..
            ListBoxCards.SelectedValueChanged += ListBoxCards_SelectedValueChanged;

            // create a status strip for the card editor/viewer..
            var statusStrip = new StatusStrip {Dock = DockStyle.Fill,};
            tableLayoutPanel.Controls.Add(statusStrip, 0, 1);

            // TODO::Do to morrow ;-) The status strip!

            // add the controls to right split panel..
            splitContainer.Panel2.Controls.Add(tableLayoutPanel);

            Tab.Controls.Add(splitContainer);
            tabControl.Tabs.Add(Tab);
            splitContainer.SplitterDistance = splitContainer.Width * 25 / 100; // size about 25%..
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the card file database context.
        /// </summary>
        public CardFileDbContext CardFileDb { get; set; }

        private bool changed;

        /// <summary>
        /// Gets or sets a cardEntity indicating whether the <see cref="CardFileDb"/> database context representing this card file has been changed.
        /// </summary>
        internal bool Changed
        {
            get => changed;

            set
            {
                foreach (var card in CardFileDb.CardFile.Cards)
                {
                    if (!value)
                    {
                        card.Changed = false;
                    }
                }

                changed = value;
            }
        }

        /// <summary>
        /// Gets or sets a cardEntity indicating whether the controls manipulating the <see cref="Card"/> card file card should be tracking the selected card content changes.
        /// </summary>
        internal bool SuspendCardChanged { get; set; }

        /// <summary>
        /// Gets or set the file name of the card file.
        /// </summary>
        internal string FileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this card file is saved into a temporary file.
        /// </summary>
        internal bool IsTemporary { get; set; }
        #endregion

        #region EventHandlers
        private void ListBoxCards_SelectedValueChanged(object sender, EventArgs e)
        {
            DisplayCard(((ListBox) sender).SelectedItem);
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            SetCardChanges(ListBoxCards.SelectedItem, null);
        }

        private void ComboBoxCardType_SelectedValueChanged(object sender, EventArgs e)
        {
            SetCardChanges(ListBoxCards.SelectedItem, ((ComboBox)sender).SelectedItem);
        }


        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox) sender;
            FilterCards(textBox.Text);
        }
        #endregion

        #region Controls
        /// <summary>
        /// The <see cref="RichTextBoxWithToolStrip"/> control to edit and display the selected card contents within the card file.
        /// </summary>
        private RichTextBoxWithToolStrip RichTextBox { get; set; }

        /// <summary>
        /// The <see cref="ListBox"/> control with a filtered list of card within the card file.
        /// </summary>
        private ListBox ListBoxCards { get; set; }

        /// <summary>
        /// The <see cref="TextBox"/> control to filter the cards within the card list.
        /// </summary>
        private TextBox SearchTextBox { get; set; }

        /// <summary>
        /// The <see cref="ComboBox"/> control to select and indicate the selected card type from the card list within the card file.
        /// </summary>
        private ComboBox CardTypeComboBox { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Manina.Windows.Forms.Tab"/> to which this <see cref="CardFileDb"/> belongs to.
        /// </summary>
        private Tab Tab { get; set; }
        #endregion

        #region HeplerMethods
        /// <summary>
        /// Refreshes the UI if the was saved as or a non-existing file was saved.
        /// </summary>
        internal void RefreshUi()
        {
            var index = ListBoxCards.SelectedIndex;

            ListBoxCards.Items.Clear();

            // add the cards within the card file to the list box..
            if (CardFileDb.CardFile.Cards != null)
            {
                foreach (var card in CardFileDb.CardFile.Cards)
                {
                    ListBoxCards.Items.Add(card);
                }
            }

            ListBoxCards.SelectedIndex = index;
        }

        /// <summary>
        /// Gets the <see cref="CardFileUiWrapper"/> associated with the tab control.
        /// </summary>
        /// <param name="tab">The <see cref="Manina.Windows.Forms.Tab"/> instance which associated UI wrapper to get.</param>
        /// <returns>An instance to a <see cref="CardFileUiWrapper"/> class if one was found associated to the given tab; null otherwise.</returns>
        internal static CardFileUiWrapper GetWrapperByTab(Tab tab)
        {
            foreach (var wrapper in UiWrappers)
            {
                if (wrapper.Tab.Equals(tab))
                {
                    return wrapper;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the active card file in the tab control.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        /// <returns>An instance to a <see cref="CardFile"/> entity.</returns>
        internal static CardFile GetActiveCardFile(TabControl tabControl)
        {
            var tab = tabControl.SelectedTab;

            return tab == null ? null : GetWrapperByTab(tab).CardFileDb.CardFile;
        }

        /// <summary>
        /// Gets the active database context for the card file.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        /// <returns>An instance to a <see cref="CardFileDbContext"/> class.</returns>
        internal static CardFileDbContext GetActiveDbContext(TabControl tabControl)
        {
            var tab = tabControl.SelectedTab;

            return tab == null ? null : GetWrapperByTab(tab).CardFileDb;
        }

        /// <summary>
        /// Displays the card's contents suspending the changed event handlers so the displayed card doesn't flag it self as changed.
        /// </summary>
        /// <param name="cardEntity"></param>
        private void DisplayCard(object cardEntity)
        {
            var card = (Card) cardEntity;
            if (card != null)
            {
                SuspendCardChanged = true;
                RichTextBox.Rtf = Encoding.UTF8.GetString(card.CardContents);
                CardTypeComboBox.SelectedItem = card.CardType;
                SuspendCardChanged = false;
            }
        }

        /// <summary>
        /// Updates the changes to a card file card if the changes have not been suspended setting the <see cref="SuspendCardChanged"/> property value to true.
        /// </summary>
        /// <param name="cardEntity"></param>
        /// <param name="cardTypeEntity"></param>
        /// <param name="wordWrap"></param>
        private void SetCardChanges(object cardEntity, object cardTypeEntity, bool? wordWrap = null)
        {
            try
            {
                if (SuspendCardChanged)
                {
                    return;
                }

                var card = (Card) cardEntity;

                var cardType = (CardType) cardTypeEntity;

                if (card != null)
                {
                    if (wordWrap != null)
                    {
                        card.WordWrap = (bool) wordWrap;
                    }

                    card.CardContents = Encoding.UTF8.GetBytes(RichTextBox.Rtf);

                    if (cardTypeEntity != null)
                    {
                        card.CardType = cardType;
                    }

                    card.Changed = true;
                    Changed = true;
                    Tab.Text = CardFileDb.CardFiles.FirstOrDefault()?.Name + FileChangedIndicator;
                }
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }
        }

        /// <summary>
        /// Filters the card file list box <see cref="ListBoxCards"/> contents based on the given <paramref name="filterText"/> text.
        /// </summary>
        /// <param name="filterText">The optional search text text to filter the cards. If set to an empty string all the cards within the card file are listed.</param>
        private void FilterCards(string filterText = "")
        {
            if (CardFileDb != null)
            {
                ListBoxCards.Items.Clear();
                if (filterText == string.Empty)
                {
                    foreach (var card in CardFileDb.CardFile.Cards)
                    {
                        ListBoxCards.Items.Add(card);
                    }
                }
                else
                {
                    foreach (var card in CardFileDb.CardFile.Cards)
                    {
                        if (card.CardName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) != -1 ||
                            card.GetCardContentsPlain().IndexOf(filterText, StringComparison.OrdinalIgnoreCase) != -1 ||
                            card.CardType.CardTypeName.IndexOf(filterText, StringComparison.OrdinalIgnoreCase) != -1)
                        {
                            ListBoxCards.Items.Add(card);
                        }
                    }
                }
            }
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // no need to store this in the static instance list..
            UiWrappers.Remove(this);

            if (disposing)
            {
                RichTextBox.TextChanged -= RichTextBox_TextChanged;
                SearchTextBox.TextChanged -= SearchTextBox_TextChanged;
                ListBoxCards.SelectedValueChanged -= ListBoxCards_SelectedValueChanged;
                CardFileDbContext.ReleaseDbContext(CardFileDb, false, true);

                try
                {
                    if (IsTemporary && File.Exists(FileName))
                    {
                        File.Delete(FileName);
                    }
                }
                catch (Exception ex)
                {
                    // report the exception..
                    ExceptionLogAction?.Invoke(ex);
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
