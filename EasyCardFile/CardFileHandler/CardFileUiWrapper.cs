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
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Context.ContextCompression;
using EasyCardFile.Database.Entity.Context.ContextEncryption;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.ErrorHandling;
using EasyCardFile.UtilityClasses.Miscellaneous;
using EasyCardFile.UtilityClasses.ProjectControls;
using Manina.Windows.Forms;
using VPKSoft.LangLib;
using VPKSoft.RichTextEdit;
using VPKSoft.WinFormsRtfPrint;
using TabControl = Manina.Windows.Forms.TabControl;

namespace EasyCardFile.CardFileHandler
{
    /// <summary>
    /// A class for creating the GUI controls with the <see cref="CardFileDbContext"/> class instance.
    /// Implements the <see cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    /// </summary>
    /// <seealso cref="EasyCardFile.UtilityClasses.ErrorHandling.ErrorHandlingBase" />
    public class CardFileUiWrapper: ErrorHandlingBase, IContainer
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
            if (!OpenCardFile(fileName))
            {
                throw new InvalidOperationException("Failed to open the card file.");
            }
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

            var cardName = string.Format(NewFileDescription, ++NewCounter);

            while (UiWrappers.Any(f => f.CardFileDb.CardFile.Name == cardName))
            {
                cardName = string.Format(NewFileDescription, NewCounter++);
            }

            var cardFile = new CardFile
                {Name = cardName, DefaultCardType = cardType};

            CardFileDb.CardFiles.Add(cardFile);
            CardFileDb.SaveChanges();

            if (CardFileDb.CardFile.CardTypes == null)
            {
                CardFileDb.CardFile.CardTypes = new List<CardType> {cardType};
                cardType.CardFile = CardFileDb.CardFile;
                cardFile.DefaultCardType = cardType;
            }

            if (cardFile.Cards == null)
            {
                cardFile.Cards = new List<Card>();
            }

            //CardFileDb.CardFile.CardTypes.Add(cardType);
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
        /// Gets or sets the localized text for the text editor's row, column and selection length.
        /// </summary>
        private static string TextEditorRowColumnSelection { get; set; }

        /// <summary>
        /// Gets or sets the localized text for the text editor's status strip when the card was changed.
        /// </summary>
        private static string TextEditorCardChangedDate { get; set; }

        /// <summary>
        /// Gets or sets the localized text for the text editor's status strip when the card was created.
        /// </summary>
        private static string TextEditorCardCreatedDate { get; set; }

        /// <summary>
        /// A ToolStrip color selection drop down text for "More colors...".
        /// </summary>
        private static string MoreColorsText { get; set; }

        /// <summary>
        /// A ToolStrip color selection drop down text for Automatic.
        /// </summary>
        private static string AutomaticColorText { get; set; }

        /// <summary>
        /// Gets or sets the localized print preview dialog title.
        /// </summary>
        private static string PrintPreviewDialogTitle { get; set; }

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

            TextEditorRowColumnSelection = DBLangEngine.GetStatMessage("msgTextEditorRowColumnSelection",
                "Row: {0}, Column: {1}, Selection {2}|A message for a status strip to describe a row, column and a selection length of a text editor.");

            MoreColorsText = DBLangEngine.GetStatMessage("msgMoreColorsText",
                "More colors..|A message for a ToolStrip color selection drop down text for more colors.");

            AutomaticColorText = DBLangEngine.GetStatMessage("msgAutomaticColorText",
                "Automatic|A message for a ToolStrip color selection drop down text for automatic.");

            PrintPreviewDialogTitle = DBLangEngine.GetStatMessage("msgPrintPreview",
                "Print preview|A message for a print preview window title");
            
            TextEditorCardChangedDate = DBLangEngine.GetStatMessage("msgEditorCardModified",
                "Modified: {0}|A message for a status strip to indicate a date and time the card was modified.");

            TextEditorCardCreatedDate = DBLangEngine.GetStatMessage("msgEditorCardCreated",
                "Created: {0}|A message for a status strip to indicate a date and time the card was created.");
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
                if (CardFileDb.CardFile != null && CardFileDb.CardFile.Compressed)
                {
                    if (!CardFileDb.LoadWithCompression(Encoding.UTF8))
                    {
                        CardFileDbContext.ReleaseDbContext(CardFileDb, false);
                        return false;
                    }
                }

                if (CardFileDb.CardFile != null && CardFileDb.CardFile.Encrypted)
                {
                    if (!CardFileDb.LoadWithEncryption(Encoding.UTF8, Application.OpenForms[0]))
                    {
                        CardFileDbContext.ReleaseDbContext(CardFileDb, false);
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
                CardFileDbContext.ReleaseDbContext(CardFileDb, false);
                return false;
            }
        }

        #region Events        
        /// <summary>
        /// Occurs when the <see cref="CardFile"/> of this UI wrapper has changed.
        /// </summary>
        public EventHandler CardFileChanged;
        #endregion

        #region Interaction                
        /// <summary>
        /// <summary>Gets or sets the location of the splitter, in pixels, from the left or top edge of the <see cref="CardFileUiWrapper.SplitContainer" />.</summary>
        /// </summary>
        public int SplitterDistance 
        { 
            get => SplitContainer.SplitterDistance;

            set
            {
                try
                {
                    SplitContainer.SplitterDistance = value;
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ExceptionLogAction?.Invoke(ex);
                }
            }
        }

        /// <summary>
        /// Updates the title of the card file tab.
        /// </summary>
        public void UpdateTitle()
        {
            UpdateTabText();
        }

        /// <summary>
        /// Refreshes the card list box.
        /// </summary>
        public void RefreshCardList()
        {
            ListBoxCards?.RefreshItems();
        }

        /// <summary>
        /// Deletes the selected card from the card file.
        /// </summary>
        /// <returns><c>true</c> if the card was successfully deleted, <c>false</c> otherwise.</returns>
        public bool DeleteCard()
        {
            var card = (Card) ListBoxCards.SelectedItem;
            if (card != null)
            {
                var index = ListBoxCards.SelectedIndex;

                CardFileDb.CardFile.Cards.Remove(card);
                ListBoxCards.Items.Remove(card);

                if (index >= ListBoxCards.Items.Count)
                {
                    index--;
                }

                if (index < ListBoxCards.Items.Count)
                {
                    ListBoxCards.SelectedIndex = index;
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets the selected card in the GUI.
        /// </summary>
        /// <value>The selected card.</value>
        public Card SelectedCard => (Card) ListBoxCards.SelectedItem;
        #endregion

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
            SplitContainer = new SplitContainer {Dock = DockStyle.Fill,};

            // create a table layout panel for the search box and for the card list..
            var tableLayoutPanel = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 3, ColumnCount = 2,};
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            SplitContainer.Panel1.Controls.Add(tableLayoutPanel);

            // create the search label to indicate that the next control will search something..
            var label = new Label {Text = SearchDescription, Padding = new Padding(2), Margin = new Padding(3),};
            tableLayoutPanel.Controls.Add(label, 0, 0);

            // create the search text box..
            SearchTextBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top};
            tableLayoutPanel.Controls.Add(SearchTextBox, 1, 0);
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;

            ToolTip = new ToolTip(this); // we do need a tool tip!

            // create the card file list box..
            ListBoxCards = new RefreshListBoxCards(CardFileDb.CardFile) {Dock = DockStyle.Fill};
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
            RichTextBox.RichTextBox.SelectionChanged += RichTextBox_SelectionChanged;

            // localize the few properties..
            RichTextBox.AutomaticColorText = AutomaticColorText;
            RichTextBox.MoreColorsText = MoreColorsText;

            tableLayoutPanel.Controls.Add(RichTextBox, 0, 0);

            // subscribe the selected cardEntity changed event handler..
            ListBoxCards.SelectedValueChanged += ListBoxCards_SelectedValueChanged;
            ListBoxCards.MouseMove += ListBoxCards_MouseMove;

            // create a status strip for the card editor/viewer..
            var statusStrip = new StatusStrip {Dock = DockStyle.Fill,};
            tableLayoutPanel.Controls.Add(statusStrip, 0, 1);

            ItemRowColumnSelection = statusStrip.Items.Add(string.Format(TextEditorRowColumnSelection, 1, 1, 0));
            ItemModifiedDateTime = statusStrip.Items.Add("");
            ItemCreatedDateTime = statusStrip.Items.Add("");

            // add the controls to right split panel..
            SplitContainer.Panel2.Controls.Add(tableLayoutPanel);

            Tab.Controls.Add(SplitContainer);
            tabControl.Tabs.Add(Tab);
            tabControl.SelectedTab = Tab;
            var splitterDistance = tabControl.ClientSize.Width * 25 / 100; // size about 25%..

            try
            {
                SplitContainer.SplitterDistance = splitterDistance;
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
            }

            // select the first card..
            if (ListBoxCards.Items.Count > 0)
            {
                ListBoxCards.SelectedIndex = 0;
            }
        }

        private Card PreviousItemAtMousePoint { get; set; }

        private void ListBoxCards_MouseMove(object sender, MouseEventArgs e)
        {
            var listBox = (RefreshListBox) sender;
            var item = (Card)listBox.GetItemAtPoint(e.Location);

            if (Equals(PreviousItemAtMousePoint, item))
            {
                return;
            }

            PreviousItemAtMousePoint = item;

            ToolTip.SetToolTip(listBox, item?.CardName);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the card file database context.
        /// </summary>
        public CardFileDbContext CardFileDb { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to save the file in the application closing state.
        /// </summary>
        public bool SaveFile { get; set; }

        /// <summary>
        /// A new file name if the card file is supposed to be renamed.
        /// </summary>
        public string NewFileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to save the changes on the card file upon closing it.
        /// </summary>
        public bool SaveChangesOnClose { get; set; }

        private bool changed;

        private bool firstSetChanged = true;

        /// <summary>
        /// Gets or sets a value if changes have been made to the card file.
        /// </summary>
        internal bool Changed
        {
            get => changed;
            set
            {
                if (changed == value && firstSetChanged)
                {
                    return; // the no changes case..
                }

                firstSetChanged = false;
                changed = value;

                // inform the event subscriber(s) of the changes..
                CardFileChanged?.Invoke(this, new EventArgs());
                UpdateTabText();
            }
        }

        /// <summary>
        /// Gets or sets the name of the card file.
        /// </summary>
        internal string CardFileName
        {
            get => CardFileDb?.CardFile?.Name;
            set
            {
                if (CardFileDb?.CardFile != null)
                {
                    CardFileDb.CardFile.Name = value;
                }
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
            if (SuspendCardChanged)
            {
                return;
            }

            var listBox = (ListBox) sender;

            DisplayCard(listBox.SelectedItem);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="RichTextBox"/> should be tracking the text changes within.
        /// </summary>
        public bool SuspendTextHandler { get; set; }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SuspendTextHandler)
            {
                return;
            }

            UpdateRowColumnSelection();
            SetCardChanges(ListBoxCards.SelectedItem, null);
        }

        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            UpdateRowColumnSelection();
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
        internal RichTextBoxWithToolStrip RichTextBox { get; set; }

        /// <summary>
        /// Gets or sets the split container of the card file UI wrapper.
        /// </summary>
        internal SplitContainer SplitContainer { get; set; }

        /// <summary>
        /// The <see cref="RefreshListBox"/> control with a filtered list of card within the card file.
        /// </summary>
        private RefreshListBoxCards ListBoxCards { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolTip"/> used by the card file list box.
        /// </summary>
        /// <value>The tool tip.</value>
        private ToolTip ToolTip { get; set; }

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

        /// <summary>
        /// Gets or sets the <see cref="ToolStripItem"/> indicating row, column, and the selection length of the card file edit box.
        /// </summary>
        private ToolStripItem ItemRowColumnSelection { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolStripItem"/> indicating the date and time the card was modified.
        /// </summary>
        private ToolStripItem ItemModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ToolStripItem"/> indicating the date and time the card was created.
        /// </summary>
        private ToolStripItem ItemCreatedDateTime { get; set; }
        #endregion

        #region HeplerMethods        
        /// <summary>
        /// Updates the row, column and selection length to the status strip of the tab.
        /// </summary>
        private void UpdateRowColumnSelection()
        {
            var richTextBox = RichTextBox.RichTextBox;

            var line = richTextBox.GetLineFromCharIndex(richTextBox.SelectionStart);
            var column = richTextBox.SelectionStart - richTextBox.GetFirstCharIndexFromLine(line);
            
            ItemRowColumnSelection.Text = string.Format(TextEditorRowColumnSelection,
                line + 1, column + 1, richTextBox.SelectionLength);
        }

        /// <summary>
        /// Refreshes the UI if the was saved as or a non-existing file was saved.
        /// </summary>
        /// <param name="selectCard">An optional instance to a <see cref="Card"/> to select from the list box.</param>
        internal void RefreshUi(Card selectCard = null)
        {
            SuspendTextHandler = true;

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

            if (selectCard != null)
            {
                ListBoxCards.SelectedItem = selectCard;
            }
            else
            {
                ListBoxCards.SelectedIndex = index;
            }

            SuspendTextHandler = false;

            CardTypeComboBox.Items.Clear();
            foreach (var cardType in CardFileDb.CardFile.CardTypes)
            {
                CardTypeComboBox.Items.Add(cardType);
            }

            DisplayCard(ListBoxCards.SelectedItem);
        }

        /// <summary>
        /// Displays a <see cref="PrintDialog"/> and in case the user accepts the print dialog, prints the card contents.
        /// </summary>
        internal void Print()
        {
            if (ListBoxCards.SelectedItem != null)
            {
                RichTextBox.RichTextBox.Print(false, true);
            }
        }

        /// <summary>
        /// Displays a <see cref="PrintPreviewDialog"/> of the selected card contents.
        /// </summary>
        internal void PrintPreview()
        {
            RichTextBox?.RichTextBox.PrintPreview(null, PrintPreviewDialogTitle);
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
                if (wrapper.Tab != null && wrapper.Tab.Equals(tab))
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
        /// Gets the active UI wrapper of the tab control.
        /// </summary>
        /// <param name="tabControl">The tab control to get the active UI wrapper from.</param>
        /// <returns>An instance to a <see cref="CardFileUiWrapper"/> class if the operation was successful; otherwise false.</returns>
        internal static CardFileUiWrapper GetActiveUiWrapper(TabControl tabControl)
        {
            var tab = tabControl.SelectedTab;

            return tab == null ? null : GetWrapperByTab(tab);
        }

        /// <summary>
        /// Gets the list of <see cref="CardFileUiWrapper"/> instances within the given <see cref="Manina.Windows.Forms.TabControl"/>.
        /// </summary>
        /// <param name="tabControl">The tab control to get the <see cref="CardFileUiWrapper"/> instances from.</param>
        /// <returns>A List&lt;CardFileUiWrapper&gt; containing the <see cref="CardFileUiWrapper"/> instances.</returns>
        internal static List<CardFileUiWrapper> GetTabList(TabControl tabControl)
        {
            List<CardFileUiWrapper> result = new List<CardFileUiWrapper>();
            foreach (var tabControlTab in tabControl.Tabs)
            {
                var wrapper = GetWrapperByTab(tabControlTab);
                if (wrapper != null)
                {
                    result.Add(wrapper);
                }
            }

            return result;
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
        /// Sets the active database context to the active tab <see cref="CardFileUiWrapper"/> instance.
        /// </summary>
        /// <param name="tabControl">The tab control.</param>
        /// <param name="context">The card file database context.</param>
        /// <param name="newFileName">An optional new file name if the card file is was renamed.</param>
        /// <returns><c>true</c> if the database context was set successfully, <c>false</c> otherwise.</returns>
        internal static bool SetActiveDbContext(TabControl tabControl, CardFileDbContext context, string newFileName = null)
        {
            var tab = tabControl.SelectedTab;

            if (tab == null)
            {
                return false;
            }

            var wrapper = GetWrapperByTab(tab);

            if (wrapper == null)
            {
                return false;
            }

            if (File.Exists(newFileName))
            {
                wrapper.FileName = newFileName;
            }

            wrapper.CardFileDb = context;

            return true;
        }

        /// <summary>
        /// Displays the card's contents suspending the changed event handlers so the displayed card doesn't flag it self as changed.
        /// </summary>
        /// <param name="cardEntity"></param>
        private void DisplayCard(object cardEntity)
        {
            if (SuspendTextHandler)
            {
                RichTextBox.Clear();
                return;
            }

            var card = (Card) cardEntity;
            if (card != null)
            {
                SuspendCardChanged = true;
                if (card.CardContents != null)
                {
                    RichTextBox.Rtf = Encoding.UTF8.GetString(card.CardContents);
                }
                else
                {
                    RichTextBox.Clear();
                }
                CardTypeComboBox.SelectedItem = card.CardType;
                SuspendCardChanged = false;

                ItemCreatedDateTime.Text = string.Format(TextEditorCardCreatedDate, card.CreateDateTime);
                ItemModifiedDateTime.Text = string.Format(TextEditorCardChangedDate, card.ModifiedDateTime);
            }
            else
            {
                RichTextBox.Clear();
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

                    card.ModifiedDateTime = DateTime.Now; // track the change time..

                    ItemModifiedDateTime.Text = string.Format(TextEditorCardChangedDate, card.ModifiedDateTime);

                    Changed = true;
                }
            }
            catch (Exception ex)
            {
                // report the exception..
                ExceptionLogAction?.Invoke(ex);
            }
        }

        /// <summary>
        /// Updates the tab text.
        /// </summary>
        internal void UpdateTabText()
        {
            var name = CardFileDb.CardFiles.FirstOrDefault()?.Name;
            var changedText = Changed ? FileChangedIndicator : string.Empty;

            Tab.Text = name + changedText;
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
                CardFileDbContext.ReleaseDbContext(CardFileDb, !IsTemporary && SaveChangesOnClose, true);

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
        #pragma warning disable CA1063 // Implement IDisposable Correctly
        public void Dispose()
        #pragma warning restore CA1063 // Implement IDisposable Correctly
        {
            foreach (var component in components)
            {
                component.PairFirst.Dispose();
            }
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region IComponent
        /// <summary>
        /// Adds the specified <see cref="T:System.ComponentModel.IComponent" /> to the <see cref="T:System.ComponentModel.IContainer" /> at the end of the list.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to add.</param>
        public void Add(IComponent component)
        {
            components.Add(new Pair<IComponent, string>(component, null));
        }

        /// <summary>
        /// Adds the specified <see cref="T:System.ComponentModel.IComponent" /> to the <see cref="T:System.ComponentModel.IContainer" /> at the end of the list, and assigns a name to the component.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to add.</param>
        /// <param name="name">The unique, case-insensitive name to assign to the component.-or-
        /// <see langword="null" /> that leaves the component unnamed.</param>
        public void Add(IComponent component, string name)
        {
            components.Add(new Pair<IComponent, string>(component, name));
        }

        /// <summary>
        /// Removes a component from the <see cref="T:System.ComponentModel.IContainer" />.
        /// </summary>
        /// <param name="component">The <see cref="T:System.ComponentModel.IComponent" /> to remove.</param>
        public void Remove(IComponent component)
        {
            components.RemoveWhere(f => f.PairFirst.Equals(component));
        }

        /// <summary>
        /// A container for the <see cref="IComponent"/> <see cref="Components"/> property.
        /// </summary>
        private readonly HashSet<Pair<IComponent, string>> components = new HashSet<Pair<IComponent, string>>();

        /// <summary>
        /// Gets all the components in the <see cref="T:System.ComponentModel.IContainer" />.
        /// </summary>
        /// <value>The components.</value>
        public ComponentCollection Components => new ComponentCollection(components.Select(f => f.PairFirst).ToArray());
        #endregion
    }
}
