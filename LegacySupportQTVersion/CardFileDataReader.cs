using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using MarkupConverter;
using VPKSoft.Utils;
using Xxtea;

namespace LegacySupportQTVersion
{
    public class CardFileDataReader
    {
        public CardFileDataReader(string fileName, string passwordString)
        {
            password = passwordString;
            this.fileName = fileName;
            compressed = IsCompressed();
            encrypted = IsEncrypted(fileName);
        }

        public CardFileDataReader(string fileName)
        {
            password = "";
            this.fileName = fileName;
            compressed = IsCompressed();
            encrypted = IsEncrypted(fileName);
        }

        private readonly bool compressed;
        private readonly bool encrypted;

        private readonly string fileName;

        private readonly string password;

        // (C)::https://github.com/xxtea/xxtea-dotnet
        private byte [] DecryptBytes(byte [] value, int realLength)
        {
            return DecryptBytes(value, realLength, password);
        }

        // (C)::https://github.com/xxtea/xxtea-dotnet
        private static byte [] DecryptBytes(byte [] value, int realLength, string password)
        {
            if (password == "")
            {
                return value;
            }

            var result =  XXTEA.Decrypt(value, password);

            var newResult = new byte[realLength];
            Array.Copy(result, newResult, realLength);
            
            return newResult;
        }


        // (C)::https://benfoster.io/blog/zlib-compression-net-core
        private byte[] Decompress(byte[] data)
        {
            if (!compressed)
            {
                return data;
            }

            var newData = new byte [data.Length - 4];

            Array.Copy(data, 4, newData, 0, newData.Length);


            var outputStream = new MemoryStream();
            using (var compressedStream = new MemoryStream(newData))
            {
                using (var inputStream = new InflaterInputStream(compressedStream))
                {
                    inputStream.CopyTo(outputStream);
                    outputStream.Position = 0;
                    return outputStream.ToArray();
                }
            }
        }

        private static string ConnectionStringFromFileName(string fileName)
        {
            return "Data Source=" + fileName +
                   ";Pooling=true;FailIfMissing=false;";
        }

        private bool IsCompressed()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine,
                    "SELECT Compressed FROM Properties;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0) == 1;
                        }
                    }
                }
            }

            return false;
        }

        public static bool IsEncrypted(string fileName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine,
                    "SELECT Encrypted FROM Properties;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0) == 1;
                        }
                    }
                }
            }

            return false;
        }

        public static bool ValidPassword(string fileName, string password)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine,
                    "SELECT CryptoRand, CryptoHash FROM Properties;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            var cryptoRandBytes = 
                                DecryptBytes(GetBlobBytesCiphered(reader.GetStream(0), out var realLength, out _), 
                                    realLength, password);

                            var cryptoHash = "0x" + Encoding.UTF8.GetString(
                                DecryptBytes(GetBlobBytesCiphered(reader.GetStream(1), out realLength, out _), 
                                    realLength, password)).ToUpper();

                            MD5 md5 = MD5.Create();

                            IoHash.MD5AppendBytes(cryptoRandBytes, ref md5);
                            var cryptoRand = IoHash.MD5GetHashString(ref md5);

                            return cryptoRand == cryptoHash;
                        }
                    }
                }
            }

            return false;
        }

        public IEnumerable<string> GetCardTypes()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine,
                    "SELECT CardType AS Type FROM Cards",
                    "UNION",
                    "SELECT Type FROM CardTypes;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (encrypted)
                            {
                                yield return Encoding.UTF8.GetString(
                                    DecryptBytes(GetBlobBytesCiphered(reader.GetStream(0), out var realLength, out _),
                                        realLength));
                            }
                            else
                            {
                                yield return reader.GetString(0);
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<(string name, string templateContents)> GetTemplates()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine,
                    "SELECT Name, Template FROM Templates;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (encrypted)
                            {
                                yield return (
                                    Encoding.UTF8.GetString(
                                        DecryptBytes(
                                            GetBlobBytesCiphered(reader.GetStream(0), out var realLength, out _),
                                            realLength)),
                                    Encoding.UTF8.GetString(
                                        DecryptBytes(
                                            GetBlobBytesCiphered(reader.GetStream(1), out realLength, out _),
                                            realLength))
                                );
                            }
                            else
                            {
                                yield return (
                                    reader.GetString(0),
                                    reader.GetString(0)
                                );
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<(string name, string type, string cardContents, bool wordWrap)> GetCards()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine,
                    // ReSharper disable once StringLiteralTypo
                    "SELECT CardName, CardType, CardContents, WordWrap FROM Cards ORDER BY CardName COLLATE NOCASE;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                    {
                        while (reader.Read())
                        {
                            if (encrypted)
                            {
                                var cardName = Encoding.UTF8.GetString(
                                    DecryptBytes(GetBlobBytesCiphered(reader.GetStream(0), out var realLength, out _),
                                        realLength));

                                var cardType = Encoding.UTF8.GetString(
                                    DecryptBytes(GetBlobBytesCiphered(reader.GetStream(0), out realLength, out _), 
                                        realLength));

                                var cardContents = 
                                    Decompress(
                                        DecryptBytes(GetBlobBytesCiphered(reader.GetStream(2), out realLength, out _), 
                                            realLength));

                                yield return (
                                    cardName,
                                    cardType,
                                    HtmlToRtfConverter.ConvertHtmlToRtf(Encoding.UTF8.GetString(cardContents)),
                                    reader.GetInt32(3) == 1);
                            }
                            else
                            {
                                var cardName = reader.GetString(0);
                                var cardType = reader.GetString(1);
                                var cardContents = reader.GetString(2);
                                var wordWrap = reader.GetInt32(3) == 1;

                                // some weird <[drive-letter]:\\> -tags in one of my old card files..
                                cardContents = Regex.Replace(cardContents, @"<\w:\\*>", ":");

                                yield return (
                                    cardName, 
                                    cardType, 
                                    HtmlToRtfConverter.ConvertHtmlToRtf(cardContents),
                                    wordWrap);
                            }
                        }
                    }
                }
            }
        }

        public (string databaseName, string autoLabelInstructions, string defaultCardType, bool wordWrapDefault, bool
            encrypted, bool compressed) GetCardFileData()
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnectionStringFromFileName(fileName)))
            {
                connection.Open();
                string sql = string.Join(Environment.NewLine, 
                    "SELECT DatabaseName, AutoLabelInstructions, CardDefaultType,",
                    "IFNULL(WordWrapDefault, 0), IFNULL(Encrypted, 0), IFNULL(Compressed, 0)",
                    "FROM Properties;");

#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (encrypted)
                            {

                                return
                                (
                                    Encoding.UTF8.GetString(
                                        DecryptBytes(
                                            GetBlobBytesCiphered(reader.GetStream(0), out var realLength, out _),
                                            realLength)),

                                    Encoding.UTF8.GetString(
                                        DecryptBytes(GetBlobBytesCiphered(reader.GetStream(1), out realLength, out _),
                                            realLength)),

                                    Encoding.UTF8.GetString(
                                        DecryptBytes(GetBlobBytesCiphered(reader.GetStream(2), out realLength, out _),
                                            realLength)),

                                    reader.GetInt32(3) == 1,
                                    reader.GetInt32(4) == 1,
                                    reader.GetInt32(5) == 1
                                );
                            }

                            return
                            (
                                reader.GetString(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetInt32(3) == 1,
                                reader.GetInt32(4) == 1,
                                reader.GetInt32(5) == 1
                            );
                        }
                    }
                }
            }

            return default;
        }

        private static byte[] GetBlobBytesCiphered(Stream stream, out int realLength, out int fixedLength)
        {
            using (stream)
            {
                using (BinaryReader binaryReader = new BinaryReader(stream))
                {
                    fixedLength = binaryReader.ReadInt32();
                    realLength = binaryReader.ReadInt32();
                    var bytes = binaryReader.ReadBytes(fixedLength);
                    return bytes;
                }
            }
        }

        /*
        private static byte[] GetBlobBytes(Stream stream)
        {
            using (stream)
            {
                stream.Seek(0, SeekOrigin.Begin);
                return (stream as MemoryStream).ToArray();
            }
        }
        */
    }
}
