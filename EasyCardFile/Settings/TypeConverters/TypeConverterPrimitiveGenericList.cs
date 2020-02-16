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
using System.Globalization;
using System.Text.RegularExpressions;

namespace EasyCardFile.Settings.TypeConverters
{
    /// <summary>
    /// A type converter for generic <see cref="List{T}"/> using primitive types or a string.
    /// Implements the <see cref="System.ComponentModel.TypeConverter" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="System.ComponentModel.TypeConverter" />
    //[TypeConverter(typeof(List<>))]
    public class TypeConverterPrimitiveGenericList<T>: TypeConverter where T: class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeConverterPrimitiveGenericList{T}"/> class.
        /// </summary>
        /// <exception cref="Exception">The type must be a primitive type.</exception>
        public TypeConverterPrimitiveGenericList()
        {
            if (!typeof(T).IsGenericType && typeof(T) != typeof(string))
            {
                throw new Exception("The type must be a primitive type or a string.");
            }
        }

        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type you want to convert to.</param>
        /// <returns><see langword="true" /> if this converter can perform the conversion; otherwise, <see langword="false" />.</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns whether this converter can convert an object of the given type to the type of this converter, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="sourceType">A <see cref="T:System.Type" /> that represents the type you want to convert from.</param>
        /// <returns><see langword="true" /> if this converter can perform the conversion; otherwise, <see langword="false" />.</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" />. If <see langword="null" /> is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type" /> to convert the <paramref name="value" /> parameter to.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                List<T> list = (List<T>) value;
                List<string> stringValues = new List<string>();
                for (int i = 0; i < list.Count; i++)
                {
                    stringValues.Add(i + ": \"" + Convert.ToString(list[i], culture)?.
                                         Replace('\"', '�') + "\""); // a hack to allow '"'-characters in a string list (U+FFFD)..
                }

                var stringValueArray = stringValues.ToArray();

                return string.Join(", ", stringValueArray) + (stringValueArray.Length > 0 ? ", " : "");
            }

            return null;
        }

        /// <summary>
        /// Converts the given object to the type of this converter, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> to use as the current culture.</param>
        /// <param name="value">The <see cref="T:System.Object" /> to convert.</param>
        /// <returns>An <see cref="T:System.Object" /> that represents the converted value.</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var result = new List<T>();
            if (value == null)
            {
                return result;
            }

            var typeCode = typeCodeDictionary[typeof(T)];

            if (value is string str)
            {
                var matches = Regex.Matches(str, @"\d: ""[^""]+"",");
                foreach (Match match in matches)
                {
                    var valueToConvert = Regex.Replace(match.Value, "\\d+: \"", "");
                    valueToConvert = valueToConvert.Substring(0, valueToConvert.Length - 2);
                    valueToConvert = valueToConvert.Replace('�', '\"'); // a hack to allow '"'-characters in a string list (U+FFFD)..


                    result.Add((T)Convert.ChangeType(valueToConvert, typeCode));
                }
            }

            return result;
        }

        /// <summary>
        /// A <see cref="Dictionary{TKey,TValue}"/> for possible <see cref="Type"/>-<see cref="TypeCode"/> pairs.
        /// </summary>
        private readonly Dictionary<Type, TypeCode> typeCodeDictionary =
            new Dictionary<Type, TypeCode>
            {
                {typeof(Boolean), TypeCode.Boolean},
                {typeof(Byte), TypeCode.Byte},
                {typeof(Char), TypeCode.Char},
                {typeof(DateTime), TypeCode.DateTime},
                {typeof(DBNull), TypeCode.DBNull},
                {typeof(Decimal), TypeCode.Decimal},
                {typeof(Double), TypeCode.Double},
                {typeof(Int16), TypeCode.Int16},
                {typeof(Int32), TypeCode.Int32},
                {typeof(Int64), TypeCode.Int64},
                {typeof(Object), TypeCode.Object},
                {typeof(SByte), TypeCode.SByte},
                {typeof(Single), TypeCode.Single},
                {typeof(String), TypeCode.String},
                {typeof(UInt16), TypeCode.UInt16},
                {typeof(UInt32), TypeCode.UInt32},
                {typeof(UInt64), TypeCode.UInt64},
            };
    }
}
