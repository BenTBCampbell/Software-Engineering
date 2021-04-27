using Fictionary.Models;
using System;
using System.Collections.Generic;

namespace Fictionary.Services
{
    public static class WordService
    {
        /// <summary>
        /// Gets a word from the database by its id
        /// </summary>
        /// <param name="id">The id of the word</param>
        /// <returns>The word</returns>
        public static Word GetWordFromID(int id)
        {
            var result = MySqlManager.GetResults($"SELECT word_text FROM Word WHERE word_id = \"{id}\"");

            if (result.Count == 0)
            {
                // no result came up, something went wrong.
                return null;
            }

            Word theWord = new Word();
            theWord.ID = id;
            theWord.WordText = (string)result[0][0];

            return theWord;
        }

        /// <summary>
        /// Gets a word from the database by the word text
        /// </summary>
        /// <param name="word_text">The word text</param>
        /// <returns>The word</returns>
        public static Word GetWord(string word_text)
        {
            var result = MySqlManager.GetResults($"SELECT word_id FROM Word WHERE word_text = \"{word_text}\"");

            if (result.Count == 0)
            {
                // no result came up, something went wrong.
                return null;
            }

            Word theWord = new Word();
            theWord.ID = (int)result[0][0];
            theWord.WordText = word_text;

            return theWord;
        }

        /// <summary>
        /// Adds a definition to the database
        /// </summary>
        /// <param name="word">The word text</param>
        /// <param name="definition">The definition text</param>
        /// <returns>If the definition was successfully added</returns>
        public static bool AddDefinition(string word, string definition)
        {
            if
                (
                // if the word or definition is empty...
                String.IsNullOrEmpty(word) || String.IsNullOrEmpty(definition)

                // or it contains bad words...
                || ! Services.Filter.IsClean(word) || ! Services.Filter.IsClean(definition)
                )
            {
                // don't add it
                return false;
            }

            // add the word to the database
            Word newWord = new() { WordText = word};

            // add the word to the database (if it doesn't already exist)
            MySqlManager.ModifyDatabase(
                $"INSERT IGNORE INTO Word (word_text) VALUES (\"{newWord.WordText}\");");

            // get its id so we can link the definition to it
            var result = MySqlManager.GetResults($"SELECT word_id FROM Word WHERE word_text = \"{newWord.WordText}\"");
            if (result.Count == 0)
            {
                // no result came up, something went wrong when adding the word.
                return false;
            }

            // set the id in the new word object so we can use it in the definition later
            newWord.ID = (int)result[0][0];

            Definition newDefinition = new()
            {
                Word = newWord,
                DefinitionText = definition
            };

            // add the definition to the database
            string addDefinitionQuery = $"INSERT INTO Definition (definition_text, word_id) " +
                $"VALUES (\"{newDefinition.DefinitionText}\", {newDefinition.Word.ID})";
            bool insertDefinitionSucceeded = MySqlManager.ModifyDatabase(addDefinitionQuery) != 0;
            return insertDefinitionSucceeded;
        }

        /// <summary>
        /// Get all the words from the database
        /// </summary>
        /// <returns></returns>
        public static List<Word> GetAllWords()
        {
            List<Word> allWords = new List<Word>();

            var result = MySqlManager.GetResults("SELECT word_id, word_text FROM Word;");

            foreach (var row in result)
            {
                var word = new Word
                {
                    ID = (int)row[0],
                    WordText = (string)row[1]
                };

                allWords.Add(word);
            }

            return allWords;
        }

        public static List<Definition> GetDefinitionsForWord(Word word)
        {
            List<Definition> allDefinitions = new();
            string query = $"SELECT definition_id, account_id, definition_text " +
                           $"FROM Definition WHERE word_id = {word.ID};";

            var result = MySqlManager.GetResults(query);

            foreach (var row in result)
            {
                Definition definition = new()
                {
                    ID = (int)row[0],
                    Word = word,
                    // Account = AccountService.GetAccountFromID((int)row[1]),
                    DefinitionText = (string)row[2]
                };

                allDefinitions.Add(definition);
            }

            return allDefinitions;
        }

        public static List<Word> SearchForWords(string searchText)
        {
            searchText = searchText.ToLower();
            List<Word> allWords = new List<Word>();

            // get all the words in the database that contain searchText
            var result = MySqlManager.GetResults(
                $"SELECT word_id, word_text FROM Word where word_text like \"%{searchText}%\";");

            foreach (var row in result)
            {
                var word = new Word
                {
                    ID = (int)row[0],
                    WordText = (string)row[1]
                };

                allWords.Add(word);
            }

            return allWords;
        }
    }
}
