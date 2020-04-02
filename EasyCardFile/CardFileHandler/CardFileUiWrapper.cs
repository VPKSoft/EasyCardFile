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
using EasyCardFile.CardFileHandler.CardFileNaming;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Context.ContextCompression;
using EasyCardFile.Database.Entity.Context.ContextEncryption;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.Database.Entity.Enumerations;
using EasyCardFile.Database.Entity.History;
using EasyCardFile.UtilityClasses.ErrorHandling;
using EasyCardFile.UtilityClasses.Localization;
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
        /// Gets or sets the localized custom card ordering description text.
        /// </summary>
        private static string CardOrderingDescription { get; set; }

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
        /// Gets or sets the localized card delete confirmation query.
        /// </summary>
        private static string ConfirmDeleteCardQuery { get; set; }

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

            ConfirmDeleteCardQuery = DBLangEngine.GetStatMessage("msgQueryConfirmDeleteCard",
                "Delete the card: '{0}'?|A message asking from the user for confirmation of deletion of a card from the card file.");

            CardOrderingDescription = DBLangEngine.GetStatMessage("msgCardOrderingDescription",
                "Card ordering:|A description text for a card ordering selection in a numeric query control.");
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

        #region Events        
        /// <summary>
        /// Occurs when the <see cref="CardFile"/> of this UI wrapper has changed.
        /// </summary>
        public EventHandler CardFileChanged;

        /// <summary>
        /// Occurs when the <see cref="CardFile"/> undo and redo possibility if of the card file has been changed.
        /// </summary>
        public EventHandler UndoRedoChanged;
        #endregion

        #region InteractionProperties
        /// <summary>
        /// Gets a value indicating whether the selected card changes can be undone.
        /// </summary>
        public bool CanUndo => UndoRedo.CanUndo;

        /// <summary>
        /// Gets a value indicating whether the selected card changes can be redone.
        /// </summary>
        public bool CanRedo => UndoRedo.CanRedo;

        /// <summary>
        /// Gets a value indicating whether the selected card has changed.
        /// </summary>
        public bool CardChanged => CanRedo | CanUndo;

        /// <summary>
        /// Determines whether you can paste information from the <see cref="Clipboard"/> to the <see cref="RichTextBox"/> control.
        /// </summary>
        public bool CanPaste => RichTextBox.RichTextBox.CanPaste();

        /// <summary>
        /// Gets a value indicating whether this card file has any cards.
        /// </summary>
        public bool HasCards => ListBoxCards.Items.Count > 0;

        /// <summary>
        /// Determines whether you can copy/cut information to the <see cref="Clipboard"/> from the <see cref="RichTextBox"/> control.
        /// </summary>
        /// <value><c>true</c> if this instance can copy; otherwise, <c>false</c>.</value>
        public bool CanCopyCut => RichTextBox.RichTextBox.SelectionLength > 0;

        /// <summary>
        /// Gets the name of the card as a valid file name, which can be used to save the card contents as Rtf document.
        /// </summary>
        /// <value>The name of the card file save RTF.</value>
        public string CardFileSaveRtfName
        {
            get
            {
                var name = SelectedCard?.CardName;
                var split = name?.Split(Path.GetInvalidFileNameChars());
                if (split != null)
                {
                    if (split.Length == 1)
                    {
                        return split[0];
                    }

                    return string.Join("_", split);
                }

                return "";
            }
        }
        #endregion

        #region Interaction        
        /// <summary>
        /// Undoes the changes to the card selected card.
        /// </summary>
        /// <returns><c>true</c> if the changes were undone, <c>false</c> otherwise.</returns>
        public bool Undo()
        {
            if (RichTextBox.RichTextBox.CanUndo)
            {
                RichTextBox.RichTextBox.Undo();
                return true;
            }

            var result = UndoRedo.Undo(CardFileDb, out var reListItems);

            SuspendTextHandler = true;

            if (reListItems)
            {
                RefreshUi(null, true);
            }
            else
            {
                ListBoxCards?.ClearCache();
                ListBoxCards?.RefreshItems();
            }

            if (result != default)
            {
                var displayCard = CardFileDb.CardFile.Cards.FirstOrDefault(f => f.UniqueId == result);
                if (displayCard != null && ListBoxCards != null)
                {
                    ListBoxCards.SelectedItem = displayCard;
                    DisplayCardContents(displayCard);    
                }
            }

            SuspendTextHandler = false;
            UndoRedoChanged?.Invoke(this, new EventArgs());
            return result != default;
        }

        /// <summary>
        /// Redoes the changes to the card selected card.
        /// </summary>
        /// <returns><c>true</c> if the changes were redone, <c>false</c> otherwise.</returns>
        public bool Redo()
        {
            if (RichTextBox.RichTextBox.CanRedo)
            {
                RichTextBox.RichTextBox.Redo();
                return true;
            }

            var result = UndoRedo.Redo(CardFileDb, out var reListItems);

            if (reListItems)
            {
                RefreshUi(null, true);
            }
            else
            {
                ListBoxCards?.ClearCache();
                ListBoxCards?.RefreshItems();
            }

            if (result != default)
            {
                var displayCard = CardFileDb.CardFile.Cards.FirstOrDefault(f => f.UniqueId == result);
                if (displayCard != null && ListBoxCards != null)
                {
                    ListBoxCards.SelectedItem = displayCard;
                }
            }
            UndoRedoChanged?.Invoke(this, new EventArgs());
            return result != default;
        }

        /// <summary>
        /// Clears the undo buffer of the <see cref="CardFileDb"/> of this <see cref="CardFileUiWrapper"/> instance.
        /// </summary>
        public void ClearUndo()
        {
            UndoRedo.Clear();
            UndoRedoChanged?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// Exports the the contents of the selected card to a given Rtf document.
        /// </summary>
        /// <param name="fileName">Name of the file to export the card contents to.</param>
        /// <returns><c>true</c> if the card contents were successfully exported, <c>false</c> otherwise.</returns>
        public bool ExportRtf(string fileName)
        {
            if (SelectedCard != null)
            {
                try
                {
                    RichTextBox.RichTextBox.SaveFile(fileName);
                    return true;
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ExceptionLogAction?.Invoke(ex);
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Imports the the contents of a given file name to the selected card contents.
        /// </summary>
        /// <param name="fileName">Name of the file to import the card contents from.</param>
        /// <returns><c>true</c> if the card contents were successfully imported, <c>false</c> otherwise.</returns>
        public bool ImportRtf(string fileName)
        {
            if (SelectedCard != null)
            {
                try
                {
                    if (fileName != null)
                    {
                        // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.richtextbox.loadfile
                        // ...
                        // UTF not ASCII: "Loads a rich text format (RTF) or standard ASCII text file into the RichTextBox control."
                        // ...
                        if (!string.Equals(Path.GetExtension(fileName), ".rtf", StringComparison.OrdinalIgnoreCase))
                        {
                            RichTextBox.RichTextBox.Text = File.ReadAllText(fileName);
                        }
                        else
                        {
                            RichTextBox.RichTextBox.LoadFile(fileName);
                        }

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ExceptionLogAction?.Invoke(ex);
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Moves the current selection in the text box to the <see cref="Clipboard"/>.
        /// </summary>
        public void Cut()
        {
            RichTextBox.RichTextBox.Cut();
        }

        /// <summary>
        /// Copies the current selection in the text box to the <see cref="Clipboard"/>.
        /// </summary>
        public void Copy()
        {
            RichTextBox.RichTextBox.Copy();
        }

        /// <summary>
        /// Replaces the current selection in the text box with the contents of the <see cref="Clipboard"/>.
        /// </summary>
        public void Paste()
        {
            RichTextBox.RichTextBox.Paste();
        }

        /// <summary>
        /// Replaces the current selection in the text box with the contents of the <see cref="Clipboard"/> as unformatted text.
        /// </summary>
        public void PasteWithoutFormatting()
        {
            try
            {
                RichTextBox.RichTextBox.SelectedText = (string) Clipboard.GetData(DataFormats.Text);
            }
            catch (Exception ex)
            {
                // log the exception..
                ExceptionLogAction?.Invoke(ex);
            }
        }

        /// <summary>
        /// Sets input focus to the <see cref="RichTextBox"/> control text area.
        /// </summary>
        /// <returns><see langword="true" /> if the input focus request was successful; otherwise, <see langword="false" />.</returns>
        public bool FocusRichTextBox()
        {
            return RichTextBox.RichTextBox.Focus();
        }

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

        /// <summary>
        /// Repaints the card ListBox.
        /// </summary>
        public void RepaintCardListBox()
        {
            ListBoxCards.ClearCache();
        }

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
                if (MessageBox.Show(Application.OpenForms[0], string.Format(ConfirmDeleteCardQuery, card.CardName),
                    LocalizeStaticProperties.DialogConfirmTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                {
                    return false;
                }

                var index = ListBoxCards.SelectedIndex;

                // add the deletion to the undo / redo class..
                UndoRedo.AddChange(card, UndoRedoType.Deleted, card.Ordering, card.CardContents,
                    card.CardType.UniqueId);

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

                FocusRichTextBox();

                Changed = true;
                // notify of the change..
                UndoRedoChanged?.Invoke(this, new EventArgs());
                return true;
            }

            return false;
        }

        /// <summary>
        /// Adds a new card to the card file.
        /// </summary>
        /// <returns><c>true</c> if a card was successfully added, <c>false</c> otherwise.</returns>
        public bool AddCard()
        {
            if (FormDialogAddRenameCard.ShowDialog(Application.OpenForms[0], CardFileDb.CardFile, out var card) == DialogResult.OK)
            {
                Changed = true;
                RefreshUi(card, true);
                FocusRichTextBox();

                // add the new card addition to the undo / redo class..
                UndoRedo.AddChange(card, UndoRedoType.Added, card.Ordering, card.CardContents, 
                    card.CardType.UniqueId);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Sets the visibility to control the custom ordering based on the value whether it's used within the card file or not.
        /// </summary>
        public void SetCustomOrdering()
        {
            var display =
                CardFileDb.CardFile.CardSortType1.HasFlag(CardSortType.Custom) ||
                CardFileDb.CardFile.CardSortType1.HasFlag(CardSortType.CustomDescending) ||
                CardFileDb.CardFile.CardSortType2.HasFlag(CardSortType.Custom) ||
                CardFileDb.CardFile.CardSortType2.HasFlag(CardSortType.CustomDescending) ||
                CardFileDb.CardFile.CardSortType3.HasFlag(CardSortType.Custom) ||
                CardFileDb.CardFile.CardSortType3.HasFlag(CardSortType.CustomDescending) ||
                CardFileDb.CardFile.CardSortType4.HasFlag(CardSortType.Custom) ||
                CardFileDb.CardFile.CardSortType4.HasFlag(CardSortType.CustomDescending);

            LabelCardOrdering.Visible = display;
            CardOrdering.Visible = display;
        }

        /// <summary>
        /// Gets the selected card in the GUI.
        /// </summary>
        /// <value>The selected card.</value>
        public Card SelectedCard => (Card) ListBoxCards.SelectedItem;
        #endregion

        #region InteractionEvents
        /// <summary>
        /// Occurs when the selected card was changed.
        /// </summary>
        public EventHandler SelectedCardChanged;
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
            TableLayoutMain = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 4, ColumnCount = 2,};
            TableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            TableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            TableLayoutMain.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            TableLayoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            TableLayoutMain.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            TableLayoutMain.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});
            SplitContainer.Panel1.Controls.Add(TableLayoutMain);

            // create the search label to indicate that the next control will search something..
            var label = new Label {Text = SearchDescription, Padding = new Padding(2), Margin = new Padding(3),};
            TableLayoutMain.Controls.Add(label, 0, 0);

            // create the search text box..
            SearchTextBox = new TextBox { Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top};
            TableLayoutMain.Controls.Add(SearchTextBox, 1, 0);
            SearchTextBox.TextChanged += SearchTextBox_TextChanged;

            ToolTip = new ToolTip(this); // we do need a tool tip!

            // create the card file list box..
            ListBoxCards = new RefreshListBoxCards(CardFileDb.CardFile) {Dock = DockStyle.Fill};
            TableLayoutMain.Controls.Add(ListBoxCards, 0, 1);
            TableLayoutMain.SetColumnSpan(ListBoxCards, 2);

            CardFileDb.CardFile.SortCards();

            // add the cards within the card file to the list box..
            if (CardFileDb.CardFile.Cards != null)
            {
                foreach (var card in CardFileDb.CardFile.Cards)
                {
                    ListBoxCards.Items.Add(card);
                }
            }

            // create the label to indicate that the next control will be the custom card ordering numeric up-down..
            LabelCardOrdering = new Label {Text = CardOrderingDescription, Padding = new Padding(2), Margin = new Padding(3),};
            TableLayoutMain.Controls.Add(LabelCardOrdering, 0, 2);

            CardOrdering = new NumericUpDown
            {
                TextAlign = HorizontalAlignment.Right,
                Minimum = 0,
                Maximum = int.MaxValue,
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
            };

            CardOrdering.ValueChanged += CardOrdering_ValueChanged;

            TableLayoutMain.Controls.Add(CardOrdering, 1, 2);

            // create the label to indicate that the next control will be the card type combo box..
            label = new Label {Text = CardTypeDescription, Padding = new Padding(2), Margin = new Padding(3),};
            TableLayoutMain.Controls.Add(label, 0, 3);

            // create the combo box for the card type..
            CardTypeComboBox = new ComboBox
            {
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                AutoCompleteMode = AutoCompleteMode.Suggest, 
                AutoCompleteSource = AutoCompleteSource.ListItems, 
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            CardTypeComboBox.SelectedValueChanged += ComboBoxCardType_SelectedValueChanged;

            TableLayoutMain.Controls.Add(CardTypeComboBox, 1, 3);
            foreach (var cardType in CardFileDb.CardFile.CardTypes)
            {
                CardTypeComboBox.Items.Add(cardType);
            }

            // create another table layout panel for the card editor and for the status strip..
            TableLayoutMain = new TableLayoutPanel {Dock = DockStyle.Fill, RowCount = 2, ColumnCount = 1,};
            TableLayoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            TableLayoutMain.RowStyles.Add(new RowStyle( SizeType.Percent, 100));
            TableLayoutMain.RowStyles.Add(new RowStyle{ SizeType = SizeType.AutoSize});

            // create a RichTextBoxWithToolStrip for the card file card contents..
            RichTextBox = new RichTextBoxWithToolStrip {Dock = DockStyle.Fill, Tag = false,};
            RichTextBox.TextChanged += RichTextBox_TextChanged;
            RichTextBox.RichTextBox.SelectionChanged += RichTextBox_SelectionChanged;

            // localize the few properties..
            RichTextBox.AutomaticColorText = AutomaticColorText;
            RichTextBox.MoreColorsText = MoreColorsText;

            TableLayoutMain.Controls.Add(RichTextBox, 0, 0);

            // subscribe the selected cardEntity changed event handler..
            ListBoxCards.SelectedValueChanged += ListBoxCards_SelectedValueChanged;
            ListBoxCards.MouseMove += ListBoxCards_MouseMove;

            // create a status strip for the card editor/viewer..
            var statusStrip = new StatusStrip {Dock = DockStyle.Fill,};
            TableLayoutMain.Controls.Add(statusStrip, 0, 1);

            ItemRowColumnSelection = statusStrip.Items.Add(string.Format(TextEditorRowColumnSelection, 1, 1, 0));
            ItemModifiedDateTime = statusStrip.Items.Add("");
            ItemCreatedDateTime = statusStrip.Items.Add("");

            // add the controls to right split panel..
            SplitContainer.Panel2.Controls.Add(TableLayoutMain);

            // create a simple context menu for the rich text box area of the control..
            RichTextBoxContextMenu = new ContextMenuStrip();
            Add(RichTextBoxContextMenu);
            CreateContextMenu();
            RichTextBoxContextMenu.Opening += RichTextBoxContextMenu_Opening;

            RichTextBox.RichTextBox.ContextMenuStrip = RichTextBoxContextMenu;

            // hide or show the custom ordering controls if a custom numeric ordering is used..
            SetCustomOrdering();

            // add the split container to the tab..
            Tab.Controls.Add(SplitContainer);
            tabControl.Tabs.Add(Tab);
            tabControl.SelectedTab = Tab;
            var splitterDistance = tabControl.ClientSize.Width * 25 / 100; // size about 25%..

            // there is always a change that this splitter distance will be assigned a screwed-up (?!)..
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

        /// <summary>
        /// Creates the menu items for the <see cref="RichTextBoxContextMenu"/> context menu.
        /// </summary>
        private void CreateContextMenu()
        {
            var menuText = DBLangEngine.GetStatMessage("msgCut",
                "Cut|A message for a menu item indicating a cut function.");

            RichTextBoxContextMenu.Items.Add(new ToolStripMenuItem(menuText, null,
                    (sender, args) => Cut())
                {ShortcutKeys = Keys.Control | Keys.X, Tag = 0, Image = Properties.Resources.Cut});

            menuText = DBLangEngine.GetStatMessage("msgCopy",
                "Copy|A message for a menu item indicating a copy function.");

            RichTextBoxContextMenu.Items.Add(new ToolStripMenuItem(menuText, null,
                    (sender, args) => Copy())
                {ShortcutKeys = Keys.Control | Keys.C, Tag = 1, Image = Properties.Resources.Copy});

            menuText = DBLangEngine.GetStatMessage("msgPaste",
                "Paste|A message for a menu item indicating a paste function.");

            RichTextBoxContextMenu.Items.Add(new ToolStripMenuItem(menuText, null,
                    (sender, args) => Paste())
                {ShortcutKeys = Keys.Control | Keys.V, Tag = 2, Image = Properties.Resources.Paste});

            menuText = DBLangEngine.GetStatMessage("msgPasteWithoutFormatting",
                "Paste without formatting|A message for a menu item indicating a paste without formatting function.");

            RichTextBoxContextMenu.Items.Add(new ToolStripMenuItem(menuText, null,
                (sender, args) => PasteWithoutFormatting())
            {
                ShortcutKeys = Keys.Control | Keys.Alt | Keys.Shift | Keys.V, Tag = 3,
                Image = Properties.Resources.edit_paste_3
            });
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

                try
                {
                    // inform the event subscriber(s) of the changes..
                    CardFileChanged?.Invoke(this, new EventArgs());
                }
                catch (Exception ex)
                {
                    // log the exception..
                    ExceptionLogAction?.Invoke(ex);
                }
                
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

        #region PrivateProperties                
        /// <summary>
        /// Gets or sets the previously selected item from the <see cref="ListBoxCards"/> list box.
        /// </summary>
        private object PreviousSelectedItem { get; set; }

        /// <summary>
        /// Gets or sets the undo/redo class instance.
        /// </summary>
        private UndoRedo UndoRedo { get; } = new UndoRedo();

        /// <summary>
        /// Gets or sets the card contents before they were changed.
        /// </summary>
        private byte[] PreviousCardContents { get; set; }

        /// <summary>
        /// Gets or sets the previous card ordering in case the ordering was changed.
        /// </summary>
        private int PreviousCardOrdering { get; set; }
        #endregion

        #region EventHandlers
        private void RichTextBoxContextMenu_Opening(object sender, CancelEventArgs e)
        {
            var menu = (ContextMenuStrip) sender;
            foreach (ToolStripMenuItem menuItem in menu.Items)
            {
                menuItem.Enabled =
                    (int) menuItem.Tag == 0 && CanCopyCut ||
                    (int) menuItem.Tag == 1 && CanCopyCut ||
                    (int) menuItem.Tag == 2 && CanPaste ||
                    (int) menuItem.Tag == 3 && CanPaste;
            }
        }


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
            if (SuspendTextHandler || SuspendCardChanged)
            {
                return;
            }

            RichTextBox.Tag = true;

            UpdateRowColumnSelection();
            SetCardChanges(ListBoxCards.SelectedItem, null);
        }

        private void RichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            UpdateRowColumnSelection();
        }

        private void ComboBoxCardType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (SuspendCardChanged)
            {
                return;
            }

            var card = (Card) ListBoxCards.SelectedItem;
            UndoRedo.AddChange(card, UndoRedoType.Modified, PreviousCardOrdering, PreviousCardContents,
                card.CardType.UniqueId,
                ((CardType) ((ComboBox) sender).SelectedItem).UniqueId);
            SelectedCardChanged?.Invoke(this, new EventArgs());
            SetCardChanges(card, ((ComboBox)sender).SelectedItem);
            if (!SuspendCardChanged)
            {
                ListBoxCards.Invalidate();
            }
        }

        private void CardOrdering_ValueChanged(object sender, EventArgs e)
        {
            if (SuspendCardChanged)
            {
                return;
            }

            var numericUpDown = (NumericUpDown) sender;

            var value = (int) numericUpDown.Value;

            // TODO::Save the first ordering of the card!

            var card = (Card) ListBoxCards.SelectedItem;

            if (card != null && card.Ordering != PreviousCardOrdering)
            {
                UndoRedo.AddChange(card, UndoRedoType.Modified, PreviousCardOrdering, PreviousCardContents,
                    card.CardType.UniqueId);
            }

            SetCardChanges(card, card?.CardType);
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox) sender;
            FilterCards(textBox.Text);
        }
        #endregion

        #region Controls                
        /// <summary>
        /// Gets or sets the rich text box context menu.
        /// </summary>
        internal ContextMenuStrip RichTextBoxContextMenu { get; set; }

        /// <summary>
        /// The <see cref="RichTextBoxWithToolStrip"/> control to edit and display the selected card contents within the card file.
        /// </summary>
        internal RichTextBoxWithToolStrip RichTextBox { get; set; }

        /// <summary>
        /// Gets or sets the split container of the card file UI wrapper.
        /// </summary>
        internal SplitContainer SplitContainer { get; set; }

        /// <summary>
        /// Gets or sets the main <see cref="TableLayoutPanel"/> instance.
        /// </summary>
        internal TableLayoutPanel TableLayoutMain { get; set; }

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
        /// Gets or sets the <see cref="NumericUpDown"/> control to adjust the card ordering in case a custom ordering is to be used.
        /// </summary>
        private NumericUpDown CardOrdering { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Label"/> control indicating to adjust the card ordering in case a custom ordering is to be used.
        /// </summary>
        private Label LabelCardOrdering { get; set; }

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

        #region HelperMethods        
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
        /// <param name="sort">A value indicating whether the card list should be sorted.</param>
        /// <param name="clearListBoxImageCache">A value indicating whether the image cache of the <see cref="RefreshListBoxCards"/> instance should be cleared.</param>
        internal void RefreshUi(Card selectCard = null, bool sort = false, bool clearListBoxImageCache = false)
        {
            SuspendTextHandler = true;

            var index = ListBoxCards.SelectedIndex;

            if (sort)
            {
                CardFileDb.CardFile.SortCards();
            }

            if (clearListBoxImageCache)
            {
                ListBoxCards.ClearCache();
            }

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
            RepaintCardListBox();
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
        /// Displays the card contents.
        /// </summary>
        /// <param name="cardEntity">The card entity <see cref="Card"/> which contents to display.</param>
        private void DisplayCardContents(object cardEntity)
        {
            var card = (Card) cardEntity;
            if (card != null)
            {
                PreviousCardContents = card.CardContents;
                PreviousCardOrdering = card.Ordering;
                SuspendCardChanged = true;
                if (card.CardContents != null)
                {
                    var rtf = Encoding.UTF8.GetString(card.CardContents);
                    RichTextBox.Rtf = rtf;
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
        /// Displays the card's contents suspending the changed event handlers so the displayed card doesn't flag it self as changed.
        /// </summary>
        /// <param name="cardEntity"></param>
        private void DisplayCard(object cardEntity)
        {
            if (SuspendTextHandler)
            {
                PreviousSelectedItem = cardEntity;
                PreviousCardContents = null;
                PreviousCardOrdering = default;
                RichTextBox.Tag = false;
                RichTextBox.Clear();
                return;
            }

            if ((bool)RichTextBox.Tag)
            {
                var previousCard = (Card) PreviousSelectedItem;
                var newCard = (Card) cardEntity;
                if (previousCard != null && newCard != null && previousCard != newCard)
                {
                    UndoRedo.AddChange(previousCard, UndoRedoType.Modified,
                        PreviousCardOrdering, PreviousCardContents,
                        previousCard.CardType.UniqueId);

                    SelectedCardChanged?.Invoke(this, new EventArgs());
                    UndoRedoChanged?.Invoke(this, new EventArgs());
                }
            }

            PreviousSelectedItem = cardEntity;

            RichTextBox.Tag = false;

            DisplayCardContents(cardEntity);
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
            try
            {
                var name = CardFileDb.CardFiles.FirstOrDefault()?.Name;
                var changedText = Changed ? FileChangedIndicator : string.Empty;

                Tab.Text = name + changedText;
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
                RichTextBoxContextMenu.Opening -= RichTextBoxContextMenu_Opening;

                CardFileDbContext.ReleaseDbContext(CardFileDb, !IsTemporary && SaveChangesOnClose, true);
                CardFileDb = null;
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
