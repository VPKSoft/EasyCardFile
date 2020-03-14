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
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using EasyCardFile.Database.Entity.Context.ContextCompression;
using EasyCardFile.Database.Entity.Context.ContextEncryption;
using EasyCardFile.Database.Entity.Entities;
using EasyCardFile.Database.Entity.Model;
using EasyCardFile.UtilityClasses.ErrorHandling;

namespace EasyCardFile.Database.Entity.Context
{
    /// <summary>
    /// The database context for the ScriptNotepad <see cref="DbContext"/>.
    /// Implements the <see cref="System.Data.Entity.DbContext" />
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class CardFileDbContext: DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CardFileDbContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string for a SQLite database.</param>
        public CardFileDbContext(string connectionString)
            : base(connectionString)
        {
            Configure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CardFileDbContext"/> class.
        /// </summary>
        /// <param name="connection">A database connection for the <see cref="DbContext"/>.</param>
        /// <param name="contextOwnsConnection">if set to <c>true</c> the <see cref="DbContext"/> owns the connection. I.e. the connection is disposed by the <see cref="DbContext"/>.</param>
        public CardFileDbContext(DbConnection connection, bool contextOwnsConnection)
            : base(connection, contextOwnsConnection)
        {
            Configure();
        }

        /// <summary>
        /// Initializes a new <see cref="CardFileDbContext"/> context.
        /// </summary>
        /// <param name="fileName">The name of the file where the SQLite database containing the card file is.</param>
        /// <returns>An instance to a <see cref="CardFileDbContext"/> class if the operation was successful, null otherwise.</returns>
        public static CardFileDbContext InitializeDbContext(string fileName)
        {
            var connection = new SQLiteConnection(ConnectionStringFromFileName(fileName));
            connection.Open();

            try
            {
                return new CardFileDbContext(connection, false)
                {
                    SqLiteConnection = connection,
                    FileName = fileName,
                };
            }
            catch (Exception ex) // report the exception and return false..
            {
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the SQLite connection for the Entity Framework Code First database.
        /// </summary>
        private SQLiteConnection SqLiteConnection { get; set; }

        /// <summary>
        /// Gets or sets the name of the file of this card file database context.
        /// </summary>
        /// <value>The name of the file.</value>
        internal string FileName { get; set; }

        /// <summary>
        /// Performs the SQLite Vacuum command to the underlying database connection.
        /// </summary>
        /// <returns>True if the operation was successful; otherwise false.</returns>
        public bool VacuumDatabase()
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand("VACUUM;", SqLiteConnection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // log the exception.
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Saves the database context with compression if enabled and with encryption if enabled.
        /// </summary>
        /// <param name="context">An instance to a <see cref="CardFileDbContext"/> class to save.</param>
        /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
        public static bool SaveDbContextWithCompressionEncryption(CardFileDbContext context)
        {
            try
            {
                if (context != null) // null check..
                {
                    if (context.CardFile.Encrypted)
                    {
                        context.SaveWithEncryption();
                    }

                    if (context.CardFile.Compressed)
                    {
                        context.SaveWithCompression(Encoding.UTF8);
                    }

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex) // report the exception and return false..
            {
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Releases the database <see cref="CardFileDbContext"/> context.
        /// </summary>
        /// <param name="context">An instance to a <see cref="CardFileDbContext"/> class to dispose of.</param>
        /// <param name="save">if set to <c>true</c> a the context is requested to save the changes before disposing of the context.</param>
        /// <param name="forceGarbageCollection">A value indicating whether to force the <see cref="SqLiteConnection"/> immediately to be garbage-collected.</param>
        /// <param name="newFileName">A new file name if the card file is supposed to be renamed.</param>
        /// <param name="leavePreviousFile">A value indicating whether to leave the previous file to the file system in case of a save as operation.</param>
        /// <returns><c>true</c> if the operation was successful, <c>false</c> otherwise.</returns>
        public static bool ReleaseDbContext(CardFileDbContext context, bool save = true, bool forceGarbageCollection = false, string newFileName = null, bool leavePreviousFile = false)
        {
            try
            {
                if (context != null) // null check..
                {
                    // get the file name in case of rename => move..
                    var fileName = context.FileName; 

                    var connection = context.SqLiteConnection;

                    using (context) // dispose of the context..
                    {
                        if (save) // ..if set to save, then save..
                        {
                            SaveDbContextWithCompressionEncryption(context);
                        }
                    }

                    using (connection)
                    {
                        context.VacuumDatabase();

                        connection.Close();
                        if (forceGarbageCollection)
                        {
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                        }
                    }

                    if (save && !string.IsNullOrWhiteSpace(newFileName))
                    {
                        if (File.Exists(newFileName))
                        {
                            File.Delete(newFileName);
                        }

                        if (!leavePreviousFile)
                        {
                            File.Move(fileName, newFileName);
                        }
                        else
                        {
                            File.Copy(fileName, newFileName, true);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex) // report the exception and return false..
            {
                ErrorHandlingBase.ExceptionLogAction?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Copies the specified old database context to a new one and disposes the old database context without saving the changes.
        /// </summary>
        /// <param name="dbContextOld">The old database context.</param>
        /// <param name="fileName">Name of the file of the new database context.</param>
        /// <returns>The new copied database context.</returns>
        public static CardFileDbContext Copy(CardFileDbContext dbContextOld, string fileName)
        {
            CardFile cardFileEntityNew = null;
            var dbContextNew = InitializeDbContext(fileName);

            foreach (var cardFile in dbContextOld.CardFiles)
            {
                cardFileEntityNew = new CardFile
                {
                    Name = cardFile.Name, Compressed = cardFile.Compressed,
                    CardNamingInstruction = cardFile.CardNamingInstruction,
                    DefaultCardType = 
                        cardFile.CardTypes?.FirstOrDefault(f =>
                            f.CardTypeName == cardFile.DefaultCardType.CardTypeName),
                    Encrypted = cardFile.Encrypted,
                    EncryptionHashAlgorithmValueBase64 = cardFile.EncryptionHashAlgorithmValueBase64,
                    EncryptionPasswordValidationRandomizedBase64 =
                        cardFile.EncryptionPasswordValidationRandomizedBase64,
                };

                dbContextNew.CardFiles.Add(cardFileEntityNew);
            }

            foreach (var cardType in dbContextOld.CardFile.CardTypes)
            {
                cardFileEntityNew?.CardTypes.Add(new CardType
                    {CardTypeName = cardType.CardTypeName, CardFile = cardFileEntityNew});
            }

            foreach (var cardFileCard in dbContextOld.CardFile.Cards)
            {
                dbContextNew.CardFile.Cards.Add(new Card
                {
                    CardName = cardFileCard.CardName, 
                    CardContents = cardFileCard.CardContents,
                    CardType = 
                        cardFileEntityNew?.CardTypes.FirstOrDefault(f =>
                            f.CardTypeName == cardFileCard.CardType.CardTypeName), 
                    CardFile = dbContextNew.CardFile, 
                    WordWrap = cardFileCard.WordWrap, 
                    Ordering = cardFileCard.Ordering,
                });
            }

            foreach (var cardTemplate in dbContextOld.CardTemplates)
            {
                dbContextNew.CardTemplates.Add(new CardTemplate
                {
                    CardTemplateName = cardTemplate.CardTemplateName,
                    CardTemplateContents = cardTemplate.CardTemplateContents,
                });
            }

            ReleaseDbContext(dbContextOld, false, true);

            return dbContextNew;
        }

        /// <summary>
        /// Configures this <see cref="DbContext"/> class instance.
        /// </summary>
        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context. The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        /// <remarks>Typically, this method is called only once when the first instance of a derived context
        /// is created.  The model for that context is then cached and is for all further instances of
        /// the context in the app domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuilder, but note that this can seriously degrade performance.
        /// More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        /// classes directly.</remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ModelConfiguration.Configure(modelBuilder);
            var initializer = new CardFileDbInitializer(modelBuilder);
            System.Data.Entity.Database.SetInitializer(initializer);
        }

        /// <summary>
        /// Creates a SQLite connection string from a given file name.
        /// </summary>
        /// <param name="fileName">The name of the file to create the SQLite connection string from.</param>
        /// <returns>A SQLite connection string created from a given file name.</returns>
        private static string ConnectionStringFromFileName(string fileName)
        {
            return "Data Source=" + fileName +
                   ";Pooling=true;FailIfMissing=false;";
        }

        /// <summary>
        /// Gets or sets the <see cref="CardFile"/> instances in the database. There should however be only one of them.
        /// </summary>
        public DbSet<CardFile> CardFiles { get; set; }

        /// <summary>
        /// Gets the card file.
        /// </summary>
        public CardFile CardFile => CardFiles.FirstOrDefault();
        
        /// <summary>
        /// Gets or sets the <see cref="CardTemplate"/> instances in the database.
        /// </summary>
        public DbSet<CardTemplate> CardTemplates { get; set; }
    }
}
