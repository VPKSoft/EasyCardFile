using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasyCardFile.Database.Entity.Entities;

namespace EasyCardFile.Database.NoEntity
{
    /// <summary>
    /// A class to hold the <see cref="Card"/> entity data in a non-database context.
    /// </summary>
    public class CardNoEntity
    {
        /// <summary>
        /// Creates a new <see cref="CardNoEntity"/> instance from a given <see cref="Card"/> entity instance.
        /// </summary>
        /// <param name="card">The card entity to create the instance from.</param>
        /// <param name="replaceCardContents">An optional value for the <see cref="CardContents"/> property value.</param>
        /// <returns>An instance to the <see cref="CardNoEntity"/> class.</returns>
        public static CardNoEntity FromEntity(Card card, byte[] replaceCardContents = null)
        {
            return card == null
                ? new CardNoEntity()
                : new CardNoEntity
                {
                    CardName = card.CardName, 
                    CardContents = replaceCardContents ?? card.CardContents, 
                    Ordering = card.Ordering,
                    CreateDateTime = card.CreateDateTime, 
                    ModifiedDateTime = card.ModifiedDateTime,
                    AdditionalData1 = card.AdditionalData1,
                    CardTypeUniqueId = card.CardType.UniqueId,
                    IntData1 = card.IntData1,
                    WordWrap = card.WordWrap, 
                    UniqueId = card.UniqueId,
                    Id = card.Id,
                };
        }

        /// <summary>
        /// Sets a <see cref="Card"/> entity data from the given <see cref="CardNoEntity"/> data.
        /// </summary>
        /// <param name="card">An instance to a <see cref="Card"/> entity.</param>
        /// <param name="cardNoEntity">An instance to a <see cref="CardNoEntity"/> to set the card data from.</param>
        /// <param name="cardTypes">The card types within the database context to get the card type for the <see cref="Card.CardType"/> property.</param>
        public static void ToEntity(Card card, CardNoEntity cardNoEntity, ICollection<CardType> cardTypes)
        {
            card.CardName = cardNoEntity.CardName;
            card.CardContents = cardNoEntity.CardContents;
            card.Ordering = cardNoEntity.Ordering;
            card.CreateDateTime = cardNoEntity.CreateDateTime;
            card.ModifiedDateTime = cardNoEntity.ModifiedDateTime;
            card.AdditionalData1 = cardNoEntity.AdditionalData1;
            card.CardType = cardTypes.FirstOrDefault(f => f.UniqueId == cardNoEntity.CardTypeUniqueId);
            card.IntData1 = cardNoEntity.IntData1;
            card.WordWrap = cardNoEntity.WordWrap;
        }

        /// <summary>
        /// Sets a <see cref="Card"/> entity data from this <see cref="CardNoEntity"/> data.
        /// </summary>
        /// <param name="card">An instance to a <see cref="Card"/> entity.</param>
        /// <param name="cardTypes">The card types within the database context to get the card type for the <see cref="Card.CardType"/> property.</param>
        public void ToEntity(Card card, ICollection<CardType> cardTypes)
        {
            ToEntity(card, this, cardTypes);
        }

        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the an unique run-time identifier for the class instance.
        /// </summary>
        public int UniqueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the card.
        /// </summary>
        public string CardName { get; set; }

        /// <summary>
        /// Gets or sets the card contents. This is in RTF format and can be compressed and/or encrypted.
        /// </summary>
        public byte [] CardContents { get; set; }

        /// <summary>
        /// Gets or sets the unique id of the card type.
        /// </summary>
        public int CardTypeUniqueId { get; set; }

        /// <summary>
        /// Gets or sets the ordering of the card in a list.
        /// </summary>
        public int Ordering { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use word wrap while displaying the card contents.
        /// </summary>
        public bool WordWrap { get; set; }

        /// <summary>
        /// Gets or sets the date and time the card was created.
        /// </summary>
        /// <value>The create date time.</value>
        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the date and time the card was modified.
        /// </summary>
        public DateTime ModifiedDateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the additional data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public string AdditionalData1 { get; set; }

        /// <summary>
        /// Gets or sets the additional numeric data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public int IntData1 { get; set; }
    }
}
