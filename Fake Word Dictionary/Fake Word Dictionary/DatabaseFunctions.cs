using Fictionary.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Fictionary
{
    public class DatabaseFunctions
    {
        // Login instructions
        private const string dbConnection = "server=208.97.162.28;uid=ben_db;" +
                "pwd=Thomas1154;database=software_engineering";

        /// <summary>
        /// Loads the words from the database, asynchronously
        /// </summary>
        /// <returns>A list containing the words from the database</returns>
        /// <exception cref="MySqlException"></exception>
        public async static Task<List<Item>> LoadWordsfromDb()
        {
            List<Item> collection = new List<Item>();

            // SQL Query
            string sql = "SELECT Word.word, Definition.definition FROM Word " +
                "JOIN Definition ON Definition.word_id = Word.word_id " +
                "ORDER BY Word.word, Definition.definition;";

            // Establish the database connection and automatically close when complete
            using MySqlConnection conn = new MySqlConnection(dbConnection);

            // Open the connnection
            conn.Open();

            // Create the command object, to execute SQL commands
            MySqlCommand command = new MySqlCommand() { Connection = conn };

            // Gets the words that are currently in the database
            command.CommandText = sql;
            using (var reader = await command.ExecuteReaderAsync())
            {
                bool rowsLeft = true;

                while (rowsLeft)
                {
                    rowsLeft = await reader.ReadAsync();
                    if (rowsLeft)
                    {
                        collection.Add(new Item() { Text = reader.GetString(0), Description = reader.GetString(1) });
                    }
                }
            }
            return collection;
        }

        /// <summary>
        /// Adds a word to the database and then to the list, asynchronously
        /// </summary>
        /// <param name="word">The word to add</param>
        /// <param name="definition">The definition for the word</param>
        /// <returns>Whether the operation succeeded</returns>
        /// <exception cref="MySqlException"></exception>
        public async static Task<bool> AddWordtoDb(string word, string definition)
        {
            #region Variables
            // Query for adding the new word. If a duplicate word already exists, ignore it.
            string sql1 = $"INSERT IGNORE INTO Word (word) VALUES (\"{word.ToLower()}\");";

            // Query for finding the primary key id of the new word.
            string sql2 = $"SELECT word_id FROM Word WHERE word = \"{word.ToLower()}\";";

            // We'll initialize these later, to add the definition.
            string sql3;
            int word_id;
            #endregion

            // Establish the database connection and automatically close when complete
            using MySqlConnection conn = new MySqlConnection(dbConnection);

            // Open the connnection
            conn.Open();

            // Create the command object, to execute SQL commands
            MySqlCommand command = new MySqlCommand() { Connection = conn };

            // Add the word to the database
            // If the word already exists, a MySql Exception will be thrown (Code: 1062)
            command.CommandText = sql1;
            await command.ExecuteNonQueryAsync();

            // Get the primary key id of the word and store it in word_id
            command.CommandText = sql2;
            using (var reader = await command.ExecuteReaderAsync())
            {
                reader.Read();
                word_id = reader.GetInt32(0);
            }

            // Add the definition to the database
            // If the definition already exists, we will notify the user via error handling
            sql3 = $"INSERT INTO Definition (definition, word_id) VALUES (\"{definition.ToLower()}\", {word_id});";
            command.CommandText = sql3;
            await command.ExecuteNonQueryAsync();

            // If we made to this point without hitting an exception, return true
            return true;
        }
    }
}
