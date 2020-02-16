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

namespace EasyCardFile.Database.Entity.Entities
{
    /// <summary>
    /// A class representing a single template for a card file card in the database.
    /// Implements the <see cref="EasyCardFile.Database.Entity.IEntity" />
    /// </summary>
    /// <seealso cref="EasyCardFile.Database.Entity.IEntity" />
    public class CardTemplate: IEntity
    {
        /// <summary>
        /// Gets or sets the identifier for the entity.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the card template.
        /// </summary>
        public string CardTemplateName { get; set; }

        /// <summary>
        /// Gets or sets the card template contents in RTF format.
        /// </summary>
        public byte [] CardTemplateContents { get; set; }

        /// <summary>
        /// Gets or sets the additional data 1. This property is currently not in use and is intended to be used if there are some missing properties with the model.
        /// </summary>
        public string AdditionalData1 { get; set; }
    }
}
