﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MySqlConnector;
using PCLAppConfig;

namespace Fictionary.Services
{
    /// <summary>
    /// Contains functions to access the database
    /// </summary>
    public static class MySqlManager
    {
        /// <summary>
        /// The connection to the database
        /// </summary>
        private static MySqlConnection Connection;

        /// <summary>
        /// The string to connect to the database
        /// </summary>
        private static string dbConnection =
            $"server={ConfigurationManager.AppSettings["database-ip"]};" +
            $"uid={ConfigurationManager.AppSettings["database-username"]};" +
            $"pwd={ConfigurationManager.AppSettings["database-password"]};" +
            $"database={ConfigurationManager.AppSettings["database-name"]}";

        /// <summary>
        /// Closes the connection to the database
        /// </summary>
        public static void CloseConnection()
        {
            Connection.Close();
        }

        /// <summary>
        /// Creates a new connection to the database and opens it
        /// </summary>
        public static void InitializeConnection()
        {
            Connection = new MySqlConnection(dbConnection);
            Connection.Open();
        }

        /// <summary>
        /// Requests information from the database
        /// </summary>
        /// <param name="command">The SQL command</param>
        /// <returns>A 2D list of the results</returns>
        public static List<List<object>> GetResults(string command)
        {
            // Create the command object, to execute SQL commands.
            var sqlCommand = new MySqlCommand() { Connection = Connection, CommandText = command };

            // Read all the values and put them into a 2D list
            var result = new List<List<object>>();
            var reader = sqlCommand.ExecuteReader();

            int r = 0;
            // for each row...
            while (reader.Read())
            {
                // add a new row to results
                result.Add(new List<object>());

                // for each column in that row
                for(int c = 0; c < reader.FieldCount; c++)
                {
                    // add that element to the last row in results
                    result[result.Count - 1].Add(reader.GetValue(c));
                }

                r++;
            }

            reader.Close();

            // insert the value into the array at [row, column]
            return result;
        }

        /// <summary>
        /// Executes commands that modify the database
        /// </summary>
        /// <param name="command">The SQL command to execute</param>
        /// <returns>The number of rows modified</returns>
        public static int ModifyDatabase(string command)
        {
            var sqlCommand = new MySqlCommand() { Connection = Connection, CommandText = command };
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
