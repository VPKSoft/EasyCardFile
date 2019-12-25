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

using System.Data.Entity;
using System.Linq;
using EasyCardFileProfessional.Database.Entity.Entities;
using SQLite.CodeFirst;

namespace EasyCardFileProfessional.Database.Entity.Context
{
    /// <summary>
    /// Class ScriptNotepadDbInitializer.
    /// Implements the <see cref="CardFileDbContext" />
    /// </summary>
    /// <seealso cref="CardFileDbContext" />
    public class CardFileDbInitializer : SqliteDropCreateDatabaseWhenModelChanges<CardFileDbContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardFileDbInitializer"/> class.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        public CardFileDbInitializer(DbModelBuilder modelBuilder)
            : base(modelBuilder, typeof(CustomHistory))
        {
        }

        // ReSharper disable once InconsistentNaming
        private const string SPDX_ID = @"MIT";

        /// <summary>
        /// The license of this software.
        /// </summary>
        // ReSharper disable once InconsistentNaming
        private const string LICENSE =
            @"MIT License

Copyright(c) 2019 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the ""Software""), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.";

        /// <summary>
        /// Seeds the database.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="saveChanges">A value indicating whether to call the <see cref="DbContext.SaveChanges"/> method after the call.</param>
        public static void SeedDatabase(CardFileDbContext context, bool saveChanges)
        {
            // and a license is required - (semi-evil) laughs..
            if (!context.Set<SoftwareLicense>().Any())
            {
                context.Set<SoftwareLicense>().Add(new SoftwareLicense
                    {LicenseText = LICENSE, LicenseSpdxIdentifier = SPDX_ID});
            }

            if (saveChanges)
            {
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Seeds the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void Seed(CardFileDbContext context)
        {
            SeedDatabase(context, false);

            // perhaps this puts things in motion..
            base.Seed(context);
        }
    }
}
