using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Fictionary
{
    public static class Filter
    {
        private static string[] blacklist =
        {
            "asshole","bitch","bullshit", "cock","damn","effing",
            "fuck","shit","nigga","nigger", "prick","slut"
        };

        /// <summary>
        /// Checks to see if a message contains a bad word. Filters out leet (replacing letters with numbers), spaces, and uppercase letters.
        /// </summary>
        public static bool IsClean(string message)
        {
            message = message
                // leet replacements
                .Replace("4", "a")
                .Replace("8", "b")
                .Replace("3", "e")
                .Replace("9", "g")
                .Replace("1", "l")
                .Replace("0", "o")
                .Replace("2", "r")
                .Replace("5", "s")
                .Replace("7", "t")
                // remove spaces in case people just insert a 
                // space in the middle of a bad word.
                .Replace(" ", "")
                .ToLower();

            // Loop through the blacklist and see if the message has any bad words.
            foreach (string badWord in blacklist)
            {
                if (message.Contains(badWord))
                {
                    // If it does, the message is not clean.
                    return false;
                }
            }

            // If it doesn't, the message is clean.
            return true;
        }

        /// <summary>
        /// Replaces instances of bad words with a "?"
        /// NOTE: does not catch bad words with a space in the middle!
        /// </summary>
        public static string RemoveBadWords(string message)
        {
            // a copy of the message with wierd characters replaced
            // with normal ones for filtering purposes
            string normalizedMessage = message
                // leet replacements
                .Replace("4", "a")
                .Replace("8", "b")
                .Replace("3", "e")
                .Replace("9", "g")
                .Replace("1", "l")
                .Replace("0", "o")
                .Replace("2", "r")
                .Replace("5", "s")
                .Replace("7", "t")
                .ToLower();

            // a StringBuilder with the normal message so the 
            // wierd character replacements don't show up in the 
            // final output
            var cleanMessageSB = new StringBuilder();
            cleanMessageSB.Append(message);

            foreach (string badWord in blacklist)
            {
                // if there is an occurence of the bad word, replace it with ???s
                while (normalizedMessage.IndexOf(badWord) != -1)
                {
                    // a string of ???s the same length as badWord
                    string replacement = new string('?', badWord.Length);

                    int i = normalizedMessage.IndexOf(badWord);

                    normalizedMessage = normalizedMessage.Remove(i, badWord.Length);
                    normalizedMessage = normalizedMessage.Insert(i, replacement);

                    cleanMessageSB.Remove(i, badWord.Length);
                    cleanMessageSB.Insert(i, replacement);
                }
            }

            string cleanMessage = cleanMessageSB.ToString();
            // replace strings of ??? to just one ?
            while (cleanMessage.IndexOf("??") != -1)
            {
                cleanMessage = cleanMessage.Replace("??", "?");
            }

            // return the clean message
            return cleanMessage;
        }
    }
}
