using System;

namespace EasyCardFile.Database.Entity.Enumerations
{
    /// <summary>
    /// An enumeration of how the cards should be sorted in the card list.
    /// </summary>
    [Flags]
    public enum CardSortType: long
    {
        /// <summary>
        /// Alphabetical ascending sorting.
        /// </summary>
        Alphabetical = 0,

        /// <summary>
        /// Alphabetical ascending sorting.
        /// </summary>
        AlphabeticalDescending = 1,

        /// <summary>
        /// Sorting by modified date ascending.
        /// </summary>
        Modified = 2,

        /// <summary>
        /// Sorting by modified date descending.
        /// </summary>
        ModifiedDescending = 4,

        /// <summary>
        /// Sorting by created date ascending.
        /// </summary>
        Created = 8,

        /// <summary>
        /// Sorting by created date descending.
        /// </summary>
        CreatedDescending = 16,

    }
}
