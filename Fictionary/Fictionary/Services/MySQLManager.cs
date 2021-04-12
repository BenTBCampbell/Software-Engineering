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

        static MySQLManager()
        {
            Connection = new MySqlConnection(dbConnection);
            Connection.Open();
        }

        public static MySqlDataReader ExecuteQuery(string command)
        {
            // Create the command object, to execute SQL commands
            var sqlCommand = new MySqlCommand() { Connection = Connection, CommandText = command };

            // Gets the words that are currently in the database
            return sqlCommand.ExecuteReader();
        }

        public static int ExecuteNonQuery(string command)
        {
            var sqlCommand = new MySqlCommand() { Connection = Connection, CommandText = command };
            return sqlCommand.ExecuteNonQuery();
        }
    }
}
