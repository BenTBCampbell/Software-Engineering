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
        /// <summary>
        /// The unique identifier representing a specific Definition instance
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// The ID of the word which this definition refers to
        /// </summary>
        int WordID { get; set; }

        /// <summary>
        /// The ID of the user who created the definition
        /// </summary>
        int UserID { get; set; }

        /// <summary>
        /// The definition
        /// </summary>
        string DefinitionText { get; set; }

        /// <summary>
        /// The total number of upvotes for the definition
        /// </summary>
        int TotalUpvotes { get; set; }
    }
}
