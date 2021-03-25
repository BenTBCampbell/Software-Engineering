using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Models
{
    /// <summary>
    /// Represents a comment on a definition
    /// </summary>
    public class Comment
    {
        /// <summary>
        /// The unique identifier representing a specific Comment instance
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The ID of the user object that made the comment
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// The contents of the comment
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// The ID of the optional comment this comment responds to
        /// </summary>
        public long? RespondCommentID { get; set; }
    }
}
