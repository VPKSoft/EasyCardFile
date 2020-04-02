using System;

namespace EasyCardFile.Database.Entity.Enumerations
{
    /// <summary>
    /// An enumeration of how the cards should be sorted in the card list.
    /// </summary>
    [Flags]
    public enum CardSortType
    {
        /// <summary>
        /// No sorting is used for the cards.
        /// </summary>
        None = 0,

        /// <summary>
        /// Alphabetical ascending sorting.
        /// </summary>
        Alphabetical = 1,

        /// <summary>
        /// Alphabetical ascending sorting.
        /// </summary>
        AlphabeticalDescending = 2,

        /// <summary>
        /// Sorting by modified date ascending.
        /// </summary>
        Modified = 4,

        /// <summary>
        /// Sorting by modified date descending.
        /// </summary>
        ModifiedDescending = 8,

        /// <summary>
        /// Sorting by created date ascending.
        /// </summary>
        Created = 16,

        /// <summary>
        /// Sorting by created date descending.
        /// </summary>
        CreatedDescending = 32,

        /// <summary>
        /// Whether to ignore case in <see cref="Alphabetical"/> and <see cref="AlphabeticalDescending"/> sorting.
        /// </summary>
        IgnoreCase = 64,

        /// <summary>
        /// Sorting by card type name ascending.
        /// </summary>
        CardType,

        /// <summary>
        /// Sorting by card type name descending.
        /// </summary>
        CardTypeDescending,

        /// <summary>
        /// Sorting by a user defined order number.
        /// </summary>
        Custom,

        /// <summary>
        /// Sorting by a user defined order number descending.
        /// </summary>
        CustomDescending,
    }
}
