﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Models
{
    /// <summary>
    /// Represents a definition for a word
    /// </summary>
    public class Definition
    {
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

        private string _definitionText;
        /// <summary>
        /// The definition
        /// </summary>
        public string DefinitionText { 
            get => _definitionText; 
            set
            {
                // TODO: code for setting definitions
                _definitionText = value;
            }
        }

        /// <summary>
        /// The total number of upvotes for the definition
        /// </summary>
        public int TotalUpvotes { get; set; }

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
