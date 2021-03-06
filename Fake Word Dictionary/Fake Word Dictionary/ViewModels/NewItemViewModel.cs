using Fictionary.Models;
using Fictionary.Views;
using MySqlConnector;
using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fictionary.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private NewItemPage newItemPage;
        private string word;
        private string definition;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(word)
                && !String.IsNullOrWhiteSpace(definition);
        }

        public string Word
        {
            get => word;
            set => SetProperty(ref word, value);
        }

        public string Definition
        {
            get => definition;
            set => SetProperty(ref definition, value);
        }

        public NewItemPage NewItemPage
        {
            get => newItemPage;
            set => SetProperty(ref newItemPage, value);
        }


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task<bool> AddWordtoDb()
        {
            // Login details for database
            const string dbConnection = "server=208.97.162.28;uid=ben_db;" +
                "pwd=Thomas1154;database=software_engineering";

            // Query for adding the new word. If a duplicate word already exists, ignore it.
            string sql1 = $"INSERT IGNORE INTO Word (word) VALUES (\"{Word.ToLower()}\");";

            // Query for finding the primary key id of the new word.
            string sql2 = $"SELECT word_id FROM Word WHERE word = \"{Word.ToLower()}\";";

            // We'll initialize these later, to add the definition.
            string sql3;
            int word_id;

            try
            {
                // Establish the database connection and automatically close when complete
                using (MySqlConnection conn = new MySqlConnection(dbConnection))
                {
                    // Open the connnection
                    conn.Open();

                    // Create the command object, to execute SQL commands
                    MySqlCommand command = new MySqlCommand() { Connection = conn };

                    // Add the word to the database
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
                    sql3 = $"INSERT INTO Definition (definition, word_id) VALUES (\"{Definition}\", {word_id});";
                    command.CommandText = sql3;
                    await command.ExecuteNonQueryAsync();
                    return true;
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                await newItemPage.DisplayAlert("Duplicate Definition",
                    "This definition already exists!\n\nPlease choose a different definition.", "Okay");
            }
            catch (MySqlException ex) when (ex.Number == 1042)
            {
                await newItemPage.DisplayAlert("Connection Error",
                  "The database refused to connect.\n\nPlease make sure you are connected to the internet.", "Okay");
            }
            catch (MySqlException ex)
            {
                await newItemPage.DisplayAlert("Database Error",
                 $"A database error occurred. The word could not be added.\n\nError: {ex}", "Okay");
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    if ((x is IOException) && (x.InnerException is SocketException))
                    {
                        newItemPage.DisplayAlert("Connection Error",
                 "The database refused to connect.\n\nPlease make sure you are connected to the internet.", "Okay");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }

            // If we reach this point, an exception occurred
            return false;
        }

        private async void OnSave()
        {
            // Add item to the database
            // If this succeeds, add it to the list
            if (await AddWordtoDb())
            {
                Item newItem = new Item()
                {
                    Id = Guid.NewGuid().ToString(),
                    Text = Word,
                    Description = Definition
                };

                await DataStore.AddItemAsync(newItem);
            }

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}