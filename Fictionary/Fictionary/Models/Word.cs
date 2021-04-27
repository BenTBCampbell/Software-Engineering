using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Models
{
    /// <summary>
    /// Represents a word in the dictionary
    /// </summary>
    public class Word
    {
        private string _wordText;

        // The unique identifier representing a specific Word instance
        public int ID { get; set; }

        /// <summary>
        /// The Word's text
        /// </summary>
        public string WordText
        {
            get => _wordText;
            set { _wordText = value.ToLower(); }
        }

        /// <summary>
        /// Returns the string representation of the object
        /// </summary>
        /// <returns>The string representation of the object</returns>
        public override string ToString()
        {
            return $"Word {{ID: {ID}, WordText: {WordText}}}";
        }
    }
}
