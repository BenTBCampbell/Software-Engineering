using System;
using System.Text;

namespace Fictionary
{
    /// <summary>
    /// Contains functions to remove vulgar words from database
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// The list of words to remove
        /// </summary>
        private static readonly string[] blacklist =
        {
            "asshole","bitch","bullshit", "cock","damn","effing",
            "fuck","shit","nigga","nigger", "prick","slut"
        };

        /// <summary>
        /// Checks to see if a string contains a bad word.
        /// Also filters out leet, spaces, and uppercase letters.
        /// </summary>
        /// <param name="str">The string to check for bad words</param>
        public static bool IsClean(string str)
        {
            StringBuilder builder = new StringBuilder(str.ToLower());

            // Filter out leet
            builder.Replace("4", "a");
            builder.Replace("8", "b");
            builder.Replace("3", "e");
            builder.Replace("9", "g");
            builder.Replace("1", "l");
            builder.Replace("0", "o");
            builder.Replace("2", "r");
            builder.Replace("5", "s");
            builder.Replace("7", "t");
            builder.Replace(" ", "");

            // Set string to modified version
            str = builder.ToString();

            // Loop through the blacklist and see if the message has any bad words.
            foreach (string badWord in blacklist)
            {
                if (str.Contains(badWord))
                {
                    // If it does, the message is not clean.
                    return false;
                }
            }

            // If we've reached this point, the message is clean
            return true;
        }

        /// <summary>
        /// Replaces instances of bad words with a "?".
        /// </summary>
        /// <param name="str">The string to remove bad words from</param>
        public static string RemoveBadWords(string str)
        {
            StringBuilder builder = new StringBuilder(str.ToLower());

            // Filter out leet
            builder.Replace("4", "a");
            builder.Replace("8", "b");
            builder.Replace("3", "e");
            builder.Replace("9", "g");
            builder.Replace("1", "l");
            builder.Replace("0", "o");
            builder.Replace("2", "r");
            builder.Replace("5", "s");
            builder.Replace("7", "t");
            builder.Replace(" ", "");

            // Now remove bad words
            foreach (string item in blacklist)
            {
                builder.Replace(item, "?");
            }

            // Return the clean message
            return builder.ToString();
        }
    }
}
