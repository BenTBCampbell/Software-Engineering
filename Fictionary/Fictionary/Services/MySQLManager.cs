using System;
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
        private static MySqlConnection Connection;

        private static string dbConnection =
            $"server={ConfigurationManager.AppSettings["database-ip"]};" +
            $"uid={ConfigurationManager.AppSettings["database-username"]};" +
            $"pwd={ConfigurationManager.AppSettings["database-password"]};" +
            $"database={ConfigurationManager.AppSettings["database-name"]}";

        public static void InitializeConnection()
        {
            Connection = new MySqlConnection(dbConnection);
            Connection.Open();
        }

        public static List<List<Object>> ExecuteQuery(string command)
        {
            // Create the command object, to execute SQL commands.
            var sqlCommand = new MySqlCommand() { Connection = Connection, CommandText = command };

            // Read all the values and put them into a 2D list
            var result = new List<List<Object>>();
            var reader = sqlCommand.ExecuteReader();

            int r = 0;
            // for each row...
            while (reader.Read())
            {
                // add a new row to results
                result.Add(new List<Object>());

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

        public static int ExecuteNonQuery(string command)
        {
            var sqlCommand = new MySqlCommand() { Connection = Connection, CommandText = command };
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
