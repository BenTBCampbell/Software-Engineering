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
        /// The account of the user that made the comment
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// The definition that the comment is about
        /// </summary>
        public Definition Definition { get; set; }

        /// <summary>
        /// The contents of the comment
        /// </summary>
        public string CommentText { get; set; }

        /// <summary>
        /// The optional comment this comment responds to
        /// </summary>
        public Comment ReplyComment { get; set; }

        public override string ToString()
        {

            var accName = Account == null ? "null" : Account.UserName;
            var defText = Definition == null ? "null" : Definition.DefinitionText;

            // trim the text to 100 chars for printing
            var commText = CommentText.Length < 100 ? CommentText : CommentText.Substring(0, 100) + "...";
            defText = defText.Length < 100 ? defText : defText.Substring(0, 100) + "...";

            return $"Comment {{ ID: {ID}, Account: {accName}, Definition: {defText}, CommentText: {commText}}}";
        }
    }
}
