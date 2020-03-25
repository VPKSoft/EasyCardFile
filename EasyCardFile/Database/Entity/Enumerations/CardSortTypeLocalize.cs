using System;
using System.Collections.Generic;
using System.Linq;
using EasyCardFile.UtilityClasses.ErrorHandling;
using VPKSoft.LangLib;

namespace EasyCardFile.Database.Entity.Enumerations
{
    /// <summary>
    /// A class to localize the enumeration values for the card sorting styles, <see cref="CardSortType"/>.
    /// </summary>
    internal static class CardSortTypeLocalize
    {
        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.None"/> enumeration value.
        /// </summary>
        internal static string EnumNone { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.Alphabetical"/> enumeration value.
        /// </summary>
        internal static string EnumAlphabetical { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.AlphabeticalDescending"/> enumeration value.
        /// </summary>
        internal static string EnumAlphabeticalDescending { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.Modified"/> enumeration value.
        /// </summary>
        internal static string EnumModified { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.ModifiedDescending"/> enumeration value.
        /// </summary>
        internal static string EnumModifiedDescending { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.Created"/> enumeration value.
        /// </summary>
        internal static string EnumCreated { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.CreatedDescending"/> enumeration value.
        /// </summary>
        internal static string EnumCreatedDescending { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.IgnoreCase"/> enumeration value.
        /// </summary>
        internal static string EnumIgnoreCase { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.CardType"/> enumeration value.
        /// </summary>
        internal static string EnumCardType { get; set; }

        /// <summary>
        /// Gets or sets the localized name for the <see cref="CardSortType.CardTypeDescending"/> enumeration value.
        /// </summary>
        internal static string CardTypeDescending { get; set; }

        /// <summary>
        /// Gets or sets the localized <see cref="CardSortType"/> enum-string pairs.
        /// </summary>
        internal static List<KeyValuePair<CardSortType, string>> LocalizedEnum { get; set; } = new List<KeyValuePair<CardSortType, string>>();

        /// <summary>
        /// Gets or sets a value indicating whether the enumeration values have already been localize.
        /// </summary>
        private static bool Localized { get; set; }

        /// <summary>
        /// Gets the localized value for the a <see cref="CardSortType"/> enumeration.
        /// </summary>
        /// <param name="cardSortType">A value to get a localized string representation for.</param>
        /// <returns>A localized string representation for for the give <paramref name="cardSortType"/> value.</returns>
        internal static string GetLocalizedValue(CardSortType cardSortType)
        {
            try
            {
                return LocalizedEnum.FirstOrDefault(f => f.Key == cardSortType).Value;
            }
            catch (Exception ex)
            {
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return string.Empty;
            }
        }

        /// <summary>
        /// Localizes the enumeration values of the <see cref="CardSortType"/> enum.
        /// </summary>
        internal static void LocalizeEnums()
        {
            if (Localized)
            {
                return;
            }

            EnumNone = DBLangEngine.GetStatMessage("msgEnumSortNone",
                "None|A localized enumeration value for card sort style of: None.");
            EnumAlphabetical = DBLangEngine.GetStatMessage("msgEnumAlphabeticalSort",
                "Alphabetical|A localized enumeration value for card sort style of: Alphabetical.");
            EnumAlphabeticalDescending = DBLangEngine.GetStatMessage("msgEnumAlphabeticalDescendingSort",
                "Alphabetical descending|A localized enumeration value for card sort style of: Alphabetical Descending.");
            EnumModified = DBLangEngine.GetStatMessage("msgEnumModifiedSort",
                "Modified|A localized enumeration value for card sort style of: Modified.");
            EnumModifiedDescending = DBLangEngine.GetStatMessage("msgEnumModifiedDescendingSort",
                "Modified descending|A localized enumeration value for card sort style of: Modified Descending.");
            EnumCreated = DBLangEngine.GetStatMessage("msgEnumCreatedSort",
                "Created|A localized enumeration value for card sort style of: Created.");
            EnumCreatedDescending = DBLangEngine.GetStatMessage("msgEnumCreatedDescendingSort",
                "Created descending|A localized enumeration value for card sort style of: Created Descending.");
            EnumIgnoreCase = DBLangEngine.GetStatMessage("msgEnumIgnoreCaseSort",
                "Ignore case|A localized enumeration value for card sort style of: Ignore Case.");
            EnumCardType = DBLangEngine.GetStatMessage("msgEnumCardTypeSort",
                "Card type|A localized enumeration value for card sort style of: Card Type.");
            CardTypeDescending = DBLangEngine.GetStatMessage("msgEnumCardTypeDescendingSort",
                "Card type descending|A localized enumeration value for card sort style of: Card Type Descending.");


            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.None, EnumNone));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.Alphabetical, EnumAlphabetical));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.AlphabeticalDescending, EnumAlphabeticalDescending));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.Modified, EnumModified));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.ModifiedDescending, EnumModifiedDescending));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.Created, EnumCreated));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.CreatedDescending, EnumCreatedDescending));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.CardType, EnumCardType));
            LocalizedEnum.Add(new KeyValuePair<CardSortType, string>(CardSortType.CardTypeDescending, CardTypeDescending));
            // This is more of a flag: LocalizedEnum.Add(CardSortType.IgnoreCase, EnumIgnoreCase);

            Localized = true;
        }
    }
}
