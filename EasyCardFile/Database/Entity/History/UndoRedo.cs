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

using EasyCardFile.Database.Entity.Context;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.Database.NoEntity;
using System.Collections.Generic;
using System.Linq;

namespace EasyCardFile.Database.Entity.History
{
    /// <summary>
    /// A class for undo/redo options for <see cref="Card"/> changes.
    /// </summary>
    internal class UndoRedo
    {
        /// <summary>
        /// Saves the card data to for the undo/redo possibility.
        /// </summary>
        /// <param name="card">The card.</param>
        /// <param name="type">The type of the change save for an undo/redo possibility.</param>
        /// <param name="previousCardOrdering">The previous card ordering before the card was changed.</param>
        /// <param name="previousCardContents">The previous card contents before the card was changed.</param>
        /// <param name="previousCardTypeUniqueId">The value of <see cref="CardType.UniqueId"/> before the card type was changed.</param>
        /// <param name="newCardTypeUniqueId">The value of <see cref="CardType.UniqueId"/> after the card type was changed.</param>
        internal void AddChange(Card card, UndoRedoType type, int previousCardOrdering, byte[] previousCardContents,
            int previousCardTypeUniqueId, int newCardTypeUniqueId = -1)
        {
            if (card == null)
            {
                return;
            }

            if (UndoCursorPosition != 0)
            {
                CardChanges.RemoveRange(0, UndoCursorPosition - 1);
                UndoCursorPosition = 0;
            }

            // only modifications have these rules that..
            if (type == UndoRedoType.Modified)
            {
                // ..the first change needs to be saved to the buffer to be able to redo the change in case of undo operation..
                if (CardChanges.All(f => f.CardItemChanged.UniqueId != card.UniqueId))
                {
                    if (type == UndoRedoType.Modified) // no reverse action except moving in the time line..
                    {
                        var cardItem = new UndoRedoItem
                            {CardItemBeforeChange = CardNoEntity.FromEntity(card, previousCardContents), UndoRedoType = type};
                        cardItem.CardItemBeforeChange.CardTypeUniqueId = previousCardTypeUniqueId;

                        cardItem.CardItemChanged = CardNoEntity.FromEntity(card);
                        cardItem.CardItemChanged.CardTypeUniqueId =
                            newCardTypeUniqueId != -1 ? newCardTypeUniqueId : card.CardType.UniqueId;

                        CardChanges.Insert(0, cardItem);
                    }
                }
                else
                {
                    if (type == UndoRedoType.Modified) // no reverse action except moving in the time line..
                    {
                        var cardItem = new UndoRedoItem
                            {CardItemChanged = CardNoEntity.FromEntity(card, previousCardContents), UndoRedoType = type};

                        CardChanges.Insert(0, cardItem);
                    }
                }
            }
            
            if (type == UndoRedoType.Added || type == UndoRedoType.Deleted)
            {
                var cardItem = new UndoRedoItem
                    {CardItemChanged = CardNoEntity.FromEntity(card), UndoRedoType = type};

                cardItem.CardItemChanged.CardTypeUniqueId =
                    newCardTypeUniqueId != -1 ? newCardTypeUniqueId : card.CardType.UniqueId;

                CardChanges.Insert(0, cardItem);
            }

            // clean up the buffer if the maximum amount is exceeded..
            while (CardChanges.Count > MaximumChangeAmount)
            {
                CardChanges.RemoveAt(CardChanges.Count - 1);
            }
        }

        /// <summary>
        /// Gets or sets the maximum change amount saved for each card.
        /// </summary>
        public static int MaximumChangeAmount { get; set; } = 1000000;

        /// <summary>
        /// Gets or sets the undo cursor position within the <see cref="CardChanges"/> buffer containing the history.
        /// </summary>
        /// <value>The undo cursor position.</value>
        private int UndoCursorPosition { get; set; }

        /// <summary>
        /// Gets a value whether the class has stored changes that can be undone.
        /// </summary>
        internal bool CanUndo => UndoCursorPosition < CardChanges.Count;

        /// <summary>
        /// Gets a value whether the class has stored changes that can be redone.
        /// </summary>
        internal bool CanRedo => UndoCursorPosition > 0;

        /// <summary>
        /// Undoes the the changes to a specified card <see cref="CardFileDbContext"/>.
        /// </summary>
        /// <param name="context">The database context of which changes to undo.</param>
        /// <param name="cardAmountChanged">A value indicating whether the redo operation changed the amount of cards in the card file.</param>
        /// <returns><see cref="Card.UniqueId"/> if the changes were undone, <c>default</c> otherwise.</returns>
        internal int Undo(CardFileDbContext context, out bool cardAmountChanged)
        {
            cardAmountChanged = false;

            if (!CanUndo)
            {
                return default;
            }

            if (CardChanges[UndoCursorPosition].UndoRedoType == UndoRedoType.Modified)
            {
                var card = context.CardFile.Cards.FirstOrDefault(f =>
                    f.UniqueId == CardChanges[UndoCursorPosition].CardItemChanged.UniqueId);

                CardNoEntity.ToEntity(card,
                    CardChanges[UndoCursorPosition].CardItemBeforeChange != null
                        ? CardChanges[UndoCursorPosition].CardItemBeforeChange
                        : CardChanges[UndoCursorPosition].CardItemChanged, context.CardFile.CardTypes);

                UndoCursorPosition++;
                return card?.UniqueId ?? default;
            }
            
            // invert the deletion..
            if (CardChanges[UndoCursorPosition].UndoRedoType == UndoRedoType.Deleted) 
            {
                var card = new Card();
                CardNoEntity.ToEntity(card, CardChanges[UndoCursorPosition].CardItemChanged, context.CardFile.CardTypes);
                card.UniqueId = CardChanges[UndoCursorPosition].CardItemChanged.UniqueId;
                card.CardFile = context.CardFile;
                context.CardFile.Cards.Add(card);
                UndoCursorPosition++;
                cardAmountChanged = true;
                return card.UniqueId;
            }

            // invert the addition..
            if (CardChanges[UndoCursorPosition].UndoRedoType == UndoRedoType.Added)
            {
                var card = context.CardFile.Cards.FirstOrDefault(f =>
                    f.UniqueId == CardChanges[UndoCursorPosition].CardItemChanged.UniqueId);

                context.CardFile.Cards.Remove(card);
                UndoCursorPosition++;
                cardAmountChanged = true;
                return card?.UniqueId ?? default;
            }

            return default;
        }

        /// <summary>
        /// Redoes the the changes to a specified card <see cref="CardFileDbContext"/>.
        /// </summary>
        /// <param name="context">The database context of which changes to redo.</param>
        /// <param name="cardAmountChanged">A value indicating whether the redo operation changed the amount of cards in the card file.</param>
        /// <returns><see cref="Card.UniqueId"/> if the changes were undone, <c>default</c> otherwise.</returns>
        internal int Redo(CardFileDbContext context, out bool cardAmountChanged)
        {
            cardAmountChanged = true;

            if (!CanRedo)
            {
                return default;
            }

            UndoCursorPosition--;

            if (CardChanges[UndoCursorPosition].UndoRedoType == UndoRedoType.Modified)
            {
                var card = context.CardFile.Cards.FirstOrDefault(f =>
                    f.UniqueId == CardChanges[UndoCursorPosition].CardItemChanged.UniqueId);
                CardNoEntity.ToEntity(card, CardChanges[UndoCursorPosition].CardItemChanged, context.CardFile.CardTypes);
                return card?.UniqueId ?? default;
            }

            // to redo a deletion would be to delete a card, I hope..
            if (CardChanges[UndoCursorPosition].UndoRedoType == UndoRedoType.Deleted)
            {
                var card = context.CardFile.Cards.FirstOrDefault(f =>
                    f.UniqueId == CardChanges[UndoCursorPosition].CardItemChanged.UniqueId);

                context.CardFile.Cards.Remove(card);
                cardAmountChanged = true;
                return card?.UniqueId ?? default;
            }

            // to redo an addition would be to add a card, I hope..
            if (CardChanges[UndoCursorPosition].UndoRedoType == UndoRedoType.Added)
            {
                var card = new Card();
                CardNoEntity.ToEntity(card, CardChanges[UndoCursorPosition].CardItemChanged, context.CardFile.CardTypes);
                card.UniqueId = CardChanges[UndoCursorPosition].CardItemChanged.UniqueId;
                card.CardFile = context.CardFile;
                context.CardFile.Cards.Add(card);
                cardAmountChanged = true;
                return card.UniqueId;
            }

            return default;
        }

        /// <summary>
        /// Clears the undo / redo buffer of this instance.
        /// </summary>
        internal void Clear()
        {
            CardChanges.Clear();
        }

        /// <summary>
        /// A collection of the card changes made to the card file.
        /// </summary>
        private List<UndoRedoItem> CardChanges { get; } = new List<UndoRedoItem>();
    }
}
