﻿#region License
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

using EasyCardFile.CardFileHandler.CardFileNaming;
using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Context.ContextEncryption;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.UtilityClasses.Localization;
using EasyCardFile.UtilityClasses.ProjectControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EasyCardFile.Database.NoEntity;
using EasyCardFile.UtilityClasses.Miscellaneous;
using VPKSoft.LangLib;
using VPKSoft.MessageBoxExtended;

namespace EasyCardFile.CardFileHandler.CardFilePreferences
{
    /// <summary>
    /// A dialog form for to set preferences to the current card file.
    /// Implements the <see cref="VPKSoft.LangLib.DBLangEngineWinforms"/>
    /// </summary>
    /// <seealso cref="VPKSoft.LangLib.DBLangEngineWinforms" />
    public partial class FormDialogCardFilePreferences : DBLangEngineWinforms
    {
        /// <summary>Initializes a new instance of the <see cref="T:EasyCardFile.CardFileHandler.CardFilePreferences.FormDialogCardFilePreferences"/> class.</summary>
        public FormDialogCardFilePreferences()
        {
            InitializeComponent();

            MessageBoxQueryPrimitiveValue.ValidateTypeValue += MessageBoxQueryPrimitiveValue_ValidateTypeValue;
        }

        #region PrivateProperties        
        /// <summary>
        /// Gets the card file which was set by calling the ShowDialog method.
        /// </summary>
        private CardFile CardFile => CardFileDbContext?.CardFile;

        /// <summary>
        /// Gets or sets the card file database context which was set by calling the ShowDialog method.
        /// </summary>
        private CardFileDbContext CardFileDbContext { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the item check handler of the check list box containing the card types should be suspended.
        /// </summary>
        private bool SuspendItemCheckHandler { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the change events are suspended (values are being set programmatically).
        /// </summary>
        private bool EventsSuspended { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the change password box is enabled in the GUI.
        /// </summary>
        private bool ChangePasswordEnabled
        {
            set
            {
                pbChangePassword.Enabled = value;
                pnChangePassword.Enabled = value;
                lbChangePassword.Enabled = value;
            }

            // ReSharper disable once UnusedMember.Local
            get => pbChangePassword.Enabled || pnChangePassword.Enabled || lbChangePassword.Enabled;
        }
        #endregion

        #region ShowMethods
        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// <param name="owner">Any object that implements <see cref="T:System.Windows.Forms.IWin32Window" /> that represents the top-level window that will own the modal dialog box. </param>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.ArgumentException">The form specified in the <paramref name="owner" /> parameter is the same as the form being shown.</exception>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        public static DialogResult ShowDialog(IWin32Window owner, CardFileDbContext cardFileDbContext)
        {
            if (cardFileDbContext == null)
            {
                return DialogResult.Cancel;
            }

            var form = new FormDialogCardFilePreferences {CardFileDbContext = cardFileDbContext};

            form.Text = form.Text + @" - " + cardFileDbContext.CardFile?.Name;

            return form.ShowDialog(owner);
        }

        /// <summary>Shows the form as a modal dialog box with the specified owner.</summary>
        /// <param name="cardFileDbContext">The card file database context.</param>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DialogResult" /> values.</returns>
        /// <exception cref="T:System.InvalidOperationException">The form being shown is already visible.-or- The form being shown is disabled.-or- The form being shown is not a top-level window.-or- The form being shown as a dialog box is already a modal form.-or-The current process is not running in user interactive mode (for more information, see <see cref="P:System.Windows.Forms.SystemInformation.UserInteractive" />).</exception>
        // ReSharper disable once UnusedMember.Global
        public static DialogResult ShowDialog(CardFileDbContext cardFileDbContext)
        {
            return ShowDialog(null, cardFileDbContext);
        }
        #endregion

        #region HelperMethods                
        /// <summary>
        /// Applies the card type changes to the <see cref="CardFile"/> in case the dialog is accepted.
        /// </summary>
        /// <returns><c>true</c> if the user accepted the card type changes, <c>false</c> otherwise.</returns>
        private bool ApplyCardTypeChanges()
        {
            foreach (var typeToBeRemoved in CardTypesRemoved)
            {
                var cardTypeNoEntity = (object)CardTypes.FirstOrDefault(f => f.DefaultCardType);
                if (MessageBoxQueryPrimitiveValue.Show(this,
                    string.Format(LocalizeStaticProperties.CartTypeSelectTypeNewForDeleted, typeToBeRemoved),
                    LocalizeStaticProperties.CardTypeSelectTypeNewTitle,
                    MessageBoxIcon.Question,
                    "CardTypeName",
                    ComboBoxStyle.DropDownList,
                    AutoCompleteMode.Suggest, CardTypes,
                    ref cardTypeNoEntity) == DialogResultExtended.OK)
                {
                    ReplacementPairs.Add(new Pair<CardTypeNoEntity, CardTypeNoEntity>(typeToBeRemoved,
                        (CardTypeNoEntity) cardTypeNoEntity));
                }
                else
                {
                    return false;
                }
            }

            CardFileDbContext.CardFile.DefaultCardType =
                CardFileDbContext.CardFile.CardTypes.FirstOrDefault(f =>
                    f.CardTypeName == DefaultCardType.CardTypeName);

            return true;
        }

        /// <summary>
        /// Enables or disables the disable card type buttons based on the changes made to the card types, etc.
        /// </summary>
        private void EnableDisableCardTypeButtons()
        {
            tsbRemoveCardType.Enabled = clbCardTypes.SelectedItem != null && !clbCardTypes.SelectedItemChecked &&
                                        clbCardTypes.Items.Count > 1;

            tsbUndo.Enabled = CardTypesChanged;

            tsbRename.Enabled = clbCardTypes.SelectedItem != null;

            tsbTypeSpecificCardNaming.Enabled = clbCardTypes.SelectedItem != null;
        }

        /// <summary>
        /// Lists the card types from the <see cref="CardFileDbContext"/> property. This method will also work as an undo method for the card type changes.
        /// </summary>
        private void ListCardTypes()
        {
            clbCardTypes.Items.Clear();
            CardTypes.Clear();

            foreach (var cardType in CardFile.CardTypes)
            {
                clbCardTypes.Items.Add(cardType.CardTypeName,
                    CardFile.DefaultCardType != null && CardFile.DefaultCardType.Id == cardType.Id);

                CardTypes.Add(CardTypeNoEntity.FromEntity(cardType,
                    CardFile.DefaultCardType != null && CardFile.DefaultCardType.Id == cardType.Id));
            }

            // this null-check is intended for the legacy card files..
            DefaultCardType = CardTypeNoEntity.FromEntity(
                CardFile.DefaultCardType == null
                    ? CardFileDbContext.CardFile.CardTypes.FirstOrDefault()
                    : CardFileDbContext.CardFile.DefaultCardType, true);

            if (CardFile.DefaultCardType == null && clbCardTypes.Items.Count == 0)
            {
                clbCardTypes.Items.Add(DefaultCardType.CardTypeName,
                    true);

                CardTypes.Add(DefaultCardType);
            }
            else if (CardFile.DefaultCardType == null)
            {
                clbCardTypes.SetItemChecked(0, true);
                CardTypes[0].DefaultCardType = true;
            }

            if (clbCardTypes.Items.Count > 0)
            {
                clbCardTypes.SelectedIndex = 0;
            }
            CardTypesChanged = false;
            EnableDisableCardTypeButtons();
        }
        #endregion

        #region CardFileTemporaryProperties
        /// <summary>
        /// Gets or sets the name of the card file.
        /// </summary>
        private string CardFileName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the card file is encrypted.
        /// </summary>
        private bool CardFileEncrypted { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the card file is compressed.
        /// </summary>
        private bool CardFileCompressed { get; set; }

        /// <summary>
        /// Gets or sets the card naming instruction.
        /// </summary>
        private string CardFileNamingInstruction { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a card can be named alphabetically between other cards.
        /// </summary>
        private bool CardFileNamingDropBetween { get; set; }

        // a field for the private CardFilePasswordHash property..
        private string cardFilePasswordHash;

        /// <summary>
        /// Gets or sets the password hash as a base64 encoded string.
        /// </summary>
        private string CardFilePasswordHash { get => cardFilePasswordHash; set => cardFilePasswordHash = value; }

        // a field for the private CardFileEncryptionPasswordValidationRandomizedBase64 property..
        private string cardFileEncryptionPasswordValidationRandomizedBase64;

        /// <summary>
        /// Gets or sets the encryption password validation randomized value. This is Base64 encoded binary data.
        /// </summary>
        public string CardFileEncryptionPasswordValidationRandomizedBase64 { get => cardFileEncryptionPasswordValidationRandomizedBase64; set => cardFileEncryptionPasswordValidationRandomizedBase64 = value; }

        // a field for the private cardFileEncryptionHashAlgorithmValueBase64 property..
        private string cardFileEncryptionHashAlgorithmValueBase64;

        /// <summary>
        /// Gets or sets the encryption hash algorithm value containing the hash
        /// value of unencrypted <see cref="CardFileEncryptionPasswordValidationRandomizedBase64"/> property value. This is Base64 encoded binary data.
        /// </summary>
        public string CardFileEncryptionHashAlgorithmValueBase64 { get => cardFileEncryptionHashAlgorithmValueBase64; set => cardFileEncryptionHashAlgorithmValueBase64 = value; }

        /// <summary>
        /// Gets a copy of the card types within the current <see cref="CardFile"/> being modified.
        /// </summary>
        private List<CardTypeNoEntity> CardTypes { get; } = new List<CardTypeNoEntity>();

        /// <summary>
        /// Gets the card types about to be removed in case the dialog is accepted.
        /// </summary>
        private List<CardTypeNoEntity> CardTypesRemoved { get; } = new List<CardTypeNoEntity>();

        private bool cardTypesChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the temporary card types have been changed.
        /// </summary>
        private bool CardTypesChanged { get => cardTypesChanged;
            set
            {
                cardTypesChanged = value;
                EnableDisableCardTypeButtons();
            }
        }

        /// <summary>
        /// Gets the replacement pairs for removed card types to be replaced with existing card types.
        /// </summary>
        private List<Pair<CardTypeNoEntity, CardTypeNoEntity>> ReplacementPairs { get; } =
            new List<Pair<CardTypeNoEntity, CardTypeNoEntity>>();

        /// <summary>
        /// Gets or sets the default card type.
        /// </summary>
        private CardTypeNoEntity DefaultCardType { get; set; }
        #endregion

        #region InternalEvents
        // the user wants to enter a card naming instruction for the card file..
        private void tbbCardNamingInstruction_Click(object sender, EventArgs e)
        {
            // query a new card naming instruction..
            var naming = tbbCardNamingInstruction.Text;
            if (FormDialogCardFileNaming.ShowDialog(this, ref naming) == DialogResult.OK)
            {
                tbbCardNamingInstruction.Text = naming;
            }
        }

        // the form is shown, display the card file data..
        private void FormDialogCardFilePreferences_Shown(object sender, EventArgs e)
        {
            EventsSuspended = true;
            tbCardFileName.Text = CardFile.Name;
            cbEncryption.Checked = CardFile.Encrypted;
            cbCompression.Checked = CardFile.Compressed;
            tbbCardNamingInstruction.Text = CardFile.CardNamingInstruction;
            cbCardsDropBetween.Checked = CardFile.CardNamingDropBetween;

            CardFileName = CardFile.Name;
            CardFileEncrypted = CardFile.Encrypted;
            CardFileCompressed = CardFile.Compressed;
            CardFileNamingInstruction = CardFile.CardNamingInstruction;
            CardFileNamingDropBetween = CardFile.CardNamingDropBetween;
            CardFilePasswordHash = CardFile.PasswordHash;
            CardFileEncryptionPasswordValidationRandomizedBase64 =
                CardFile.EncryptionPasswordValidationRandomizedBase64;

            CardFileEncryptionHashAlgorithmValueBase64 = 
                CardFile.EncryptionHashAlgorithmValueBase64;

            ChangePasswordEnabled = CardFile.Encrypted;

            ListCardTypes();

            EventsSuspended = false;
            SuspendItemCheckHandler = false;
        }

        // the default card type was changed..
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EventsSuspended)
            {
                return;
            }

            var checkBox = (CheckBox) sender;

            if (checkBox.Equals(cbEncryption))
            {
                EventsSuspended = true;
                if (checkBox.Checked)
                {
                    var result = ContextEncryptDecryptHelper.EnableEncryption(Encoding.UTF8, this);

                    if (result != default)
                    {
                        CardFilePasswordHash = result.passwordHash;
                        CardFileEncryptionHashAlgorithmValueBase64 = result.valueBase64;
                        CardFileEncryptionPasswordValidationRandomizedBase64 = result.validationBase64;
                        CardFileEncrypted = true;
                    }
                    else
                    {
                        checkBox.Checked = false;
                    }
                }
                else
                {
                    if (ContextEncryptDecryptHelper.DisableEncryption(Encoding.UTF8,
                        CardFileEncryptionHashAlgorithmValueBase64,
                        CardFileEncryptionPasswordValidationRandomizedBase64, this))
                    {
                        CardFileEncrypted = false;
                    }
                    else
                    {
                        checkBox.Checked = true;
                    }
                }

                ChangePasswordEnabled = checkBox.Checked;
            }
            else if (checkBox.Equals(cbCompression))
            {
                CardFileCompressed = checkBox.Checked;
            }
            else if (checkBox.Equals(cbCardsDropBetween))
            {
                CardFileNamingDropBetween = checkBox.Checked;
            }
        }

        // the user accepted the dialog, so do apply the changes..
        private void btOk_Click(object sender, EventArgs e)
        {
            if (!ApplyCardTypeChanges())
            {
                return;
            }

            CardFile.Name = CardFileName;
            CardFile.Encrypted = CardFileEncrypted;
            CardFile.Compressed = CardFileCompressed;
            CardFile.CardNamingInstruction = CardFileNamingInstruction;
            CardFile.CardNamingDropBetween = CardFileNamingDropBetween;
            CardFile.PasswordHash = CardFilePasswordHash;

            CardFile.EncryptionPasswordValidationRandomizedBase64 =
                CardFileEncryptionPasswordValidationRandomizedBase64;

            CardFile.EncryptionHashAlgorithmValueBase64 =
                CardFileEncryptionHashAlgorithmValueBase64;

            foreach (var removedCard in CardTypesRemoved)
            {
                var removeCardEntity =
                    CardFileDbContext.CardFile.CardTypes.FirstOrDefault(f =>
                        f.CardTypeName == removedCard.CardTypeName);

                var replaceCard = ReplacementPairs
                    .FirstOrDefault(f => f.PairFirst.CardTypeName == removedCard.CardTypeName)
                    ?.PairSecond;

                CardFileDbContext.CardFile.Cards.Where(f => f.CardType.CardTypeName == removedCard.CardTypeName)
                    .ToList()
                    .ForEach(f =>
                        f.CardType =
                            CardFileDbContext.CardFile.CardTypes.FirstOrDefault(t =>
                                replaceCard != null && t.CardTypeName == replaceCard.CardTypeName));


                CardFileDbContext.CardFile.CardTypes.Remove(removeCardEntity);
            }

            CardFileDbContext.CardFile.DefaultCardType =
                CardFileDbContext.CardFile.CardTypes.FirstOrDefault(f =>
                    f.CardTypeName == DefaultCardType.CardTypeName);

            // set the changed values and add the new ones..
            foreach (var cardTypeNoEntity in CardTypes) 
            {
                var cardType = CardFileDbContext.CardFile.CardTypes.FirstOrDefault(f => f.Id == cardTypeNoEntity.Id);
                if (cardType != default)
                {
                    CardTypeNoEntity.SetToEntity(cardTypeNoEntity, ref cardType);
                }
                else
                {
                    CardFileDbContext.CardFile.CardTypes.Add(new CardType
                    {
                        CardTypeName = cardTypeNoEntity.CardTypeName,
                        CardNamingInstruction = cardTypeNoEntity.CardNamingInstruction,
                        AdditionalData1 = cardTypeNoEntity.AdditionalData1
                    });
                }
            }

            DialogResult = DialogResult.OK;
        }

        // the card file name was changed..
        private void tbCardFileName_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox) sender;
            CardFileName = textBox.Text;
            btOk.Enabled = CardFileName.Trim() != string.Empty;
        }

        // the card naming instructions changed..
        private void tbbCardNamingInstruction_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBoxButton) sender;
            CardFileNamingInstruction = textBox.Text;
        }

        // the user wishes to change the password of a card file..
        private void pnChangePassword_Click(object sender, EventArgs e)
        {
            ContextEncryptDecryptHelper.ChangeEncryptionPassword(Encoding.UTF8, ref cardFilePasswordHash,
                ref cardFileEncryptionHashAlgorithmValueBase64,
                ref cardFileEncryptionPasswordValidationRandomizedBase64, this);
        }

        // the user wants to change the default card type, validate and act accordingly..
        private void clbCardTypes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (SuspendItemCheckHandler)
            {
                return;
            }

            SuspendItemCheckHandler = true;

            lbRowErrorText.Text = string.Empty;

            // check that there is always one default card..
            if (clbCardTypes.CheckedItems.Count == 0 && e.NewValue != CheckState.Checked ||
                clbCardTypes.CheckedItems.Count == 1 && clbCardTypes.GetItemCheckState(e.Index) == 
                CheckState.Checked && e.NewValue == CheckState.Unchecked)
            {
                lbRowErrorText.Text = LocalizeStaticProperties.CardTypeDefaultRequired;

                SuspendItemCheckHandler = false;
                btOk.Enabled = false;
                return;
            }

            // set the default card type..
            DefaultCardType = 
                CardTypes.FirstOrDefault(f => f.CardTypeName == 
                                              clbCardTypes.Items[e.Index].ToString());

            btOk.Enabled = true;

            // there can be only one default..
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < clbCardTypes.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        clbCardTypes.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }

            CardTypesChanged = true;

            SuspendItemCheckHandler = false;
        }

        // the user wants to add a new card type..
        private void tsbAddCardType_Click(object sender, EventArgs e)
        {
            string newCardTypeName = string.Empty;
            if (MessageBoxQueryPrimitiveValue.Show(this,
                    LocalizeStaticProperties.CardTypeNameQuery,
                    LocalizeStaticProperties.CardTypeNameQueryTitle,
                    MessageBoxIcon.Question, ref newCardTypeName) == DialogResultExtended.OK)
            {
                var cardType = new CardTypeNoEntity {CardTypeName = newCardTypeName, Id = -1};
                CardTypes.Add(cardType);
                CardTypesChanged = true;
                clbCardTypes.Items.Add(cardType.CardTypeName, cardType.DefaultCardType);
            }

            EnableDisableCardTypeButtons();
        }

        // the validation event for the value given in the MessageBoxQueryPrimitiveValue class..
        private void MessageBoxQueryPrimitiveValue_ValidateTypeValue(object sender, VPKSoft.MessageBoxExtended.Events.TypeValueValidationEventArgs e)
        {
            // card types in a combo box don't need validation..
            if (e.TypeValue.GetType() == typeof(CardTypeNoEntity)) 
            {
                return;
            }

            // validate that the car type name is unique and not white space.,.
            var compareValue = e.TypeValue?.ToString();

            if (string.IsNullOrWhiteSpace(compareValue))
            {
                e.IsValid = false;
                e.ValidationErrorMessage = LocalizeStaticProperties.CardTypeNameUniqueError;
                return;
            }

            foreach (var item in clbCardTypes.Items)
            {
                if (item.ToString() == e.TypeValue.ToString())
                {
                    e.IsValid = false;
                    e.ValidationErrorMessage = LocalizeStaticProperties.CardTypeNameUniqueError;
                    return;
                }
            }
        }

        // remove a card type..
        private void tsbRemoveCardType_Click(object sender, EventArgs e)
        {
            if (clbCardTypes.Items.Count <= 1) // verify that one exists..
            {
                MessageBoxExtended.Show(this,
                    LocalizeStaticProperties.CardTypeOneRequired,
                    LocalizeStaticProperties.CardTypeOneRequiredTitle,
                    MessageBoxButtonsExtended.OK, MessageBoxIcon.Error);
                return;
            }

            if (clbCardTypes.SelectedIndex != -1 && // verify that the default card file is not being deleted..
                clbCardTypes.GetItemCheckState(clbCardTypes.SelectedIndex) == CheckState.Checked)
            {
                MessageBoxExtended.Show(this,
                    LocalizeStaticProperties.CardTypeCanNotDeleteDefault,
                    LocalizeStaticProperties.CardTypeCanNotDeleteDefaultTitle,
                    MessageBoxButtonsExtended.OK, MessageBoxIcon.Error);
                return;
            }

            // validations passed so remove the card type..
            var saveIndex = clbCardTypes.SelectedIndex;

            var selectedCardTypeName = clbCardTypes.SelectedItem?.ToString();
            var removeCardType = CardTypes.FirstOrDefault(f => f.CardTypeName == selectedCardTypeName);
            CardTypesRemoved.Add(removeCardType);
            CardTypes.Remove(removeCardType);
            if (removeCardType != null)
            {
                clbCardTypes.Items.Remove(removeCardType.CardTypeName);
            }

            CardTypesChanged = true;

            if (saveIndex < clbCardTypes.Items.Count)
            {
                clbCardTypes.SelectedIndex = saveIndex;
            }
            else
            {
                clbCardTypes.SelectedIndex = --saveIndex;
            }
            EnableDisableCardTypeButtons();
        }

        // undo changes to the card types..
        private void tsbUndo_Click(object sender, EventArgs e)
        {
            ListCardTypes();
        }

        // rename a card type..
        private void tsbRename_Click(object sender, EventArgs e)
        {
            if (clbCardTypes.SelectedItem != null)
            {
                string newCardTypeName = clbCardTypes.SelectedItem.ToString();

                var carType = CardTypes.FirstOrDefault(f => f.CardTypeName == newCardTypeName);

                if (MessageBoxQueryPrimitiveValue.Show(this,
                        LocalizeStaticProperties.CardTypeNameQuery,
                        LocalizeStaticProperties.CardTypeNameQueryTitle,
                        MessageBoxIcon.Question, ref newCardTypeName) == DialogResultExtended.OK)
                {
                    if (carType != null)
                    {
                        carType.CardTypeName = newCardTypeName;
                        clbCardTypes.Items[clbCardTypes.SelectedIndex] = newCardTypeName;
                        clbCardTypes.RefreshItems();
                        CardTypesChanged = true;
                    }
                }
            }

            EnableDisableCardTypeButtons();
        }

        // the user wants to give different naming instruction to a card type..
        private void tsbTypeSpecificCardNaming_Click(object sender, EventArgs e)
        {
            // query a new card naming instruction..
            var cardType = CardTypes.FirstOrDefault(f => f.CardTypeName == clbCardTypes.SelectedItem.ToString());
            if (cardType != null)
            {
                var naming = cardType.CardNamingInstruction;
                if (FormDialogCardFileNaming.ShowDialog(this, ref naming) == DialogResult.OK)
                {
                    cardType.CardNamingInstruction = naming;
                    CardTypesChanged = true;
                    EnableDisableCardTypeButtons();
                }
            }
        }

        // the selected item changed in the check list box containing card types, set the manipulation buttons accordingly..
        private void clbCardTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            EnableDisableCardTypeButtons();
        }
        #endregion
    }
}
