using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Models
{
    /// <summary>
    /// Represents a definition for a word
    /// </summary>
    public class Definition
    {
        private string _definitionText;

        /// <summary>
        /// The unique identifier representing a specific Definition instance
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The word this is a defintion for.
        /// </summary>
        public Word Word { get; set; }

        /// <summary>
        /// The ID of the user who created the definition
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// The definition text
        /// </summary>
        public string DefinitionText
        {
            get => _definitionText;
            set => _definitionText = value.ToLower();
        }

        /// <summary>
        /// The total number of upvotes for the definition
        /// </summary>
        public int TotalUpvotes { get; set; }

        /// <summary>
        /// Returns the string representation of the object
        /// </summary>
        /// <returns>The string representation of the object</returns>
        public override string ToString()
        {
            var wText = Word == null ? "null" : Word.WordText;
            var accName = Account == null ? "null" : Account.UserName;

            // trim the text to 100 chars for printing
            var defText = DefinitionText.Length < 100 ? DefinitionText : DefinitionText.Substring(0, 100) + "...";

            return $"Definition {{ID: {ID}, Word: {wText}, Account: {accName}, DefinitionText: {defText}}}";
        }
    }
}
