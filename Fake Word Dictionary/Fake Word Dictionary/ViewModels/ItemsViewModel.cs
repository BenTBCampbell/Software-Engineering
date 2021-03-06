using Fictionary.Models;
using Fictionary.Views;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Fictionary.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;
        private ItemsPage itemsPage;

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Item>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        public ItemsPage ItemsPage
        {
            get => itemsPage;
            set => SetProperty(ref itemsPage, value);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            // Clear all items
            Items.Clear();

            try
            {
                // Load the items
                var items = await LoadWordsfromDB();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task<ObservableCollection<Item>> LoadWordsfromDB()
        {
            ObservableCollection<Item> collection = new ObservableCollection<Item>();

            // Login details for database
            const string dbConnection = "server=208.97.162.28;uid=ben_db;" +
                "pwd=Thomas1154;database=software_engineering";

            // SQL Query
            string sql = "SELECT Word.word, Definition.definition FROM Word " +
                "JOIN Definition ON Definition.word_id = Word.word_id " +
                "ORDER BY Word.word, Definition.definition;";

            try
            {
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
            }
            catch (MySqlException ex) when (ex.Number == 1042)
            {
                await ItemsPage.DisplayAlert("Connection Error",
                  "The database refused to connect.\n\nPlease make sure you are connected to the internet.", "Okay");
            }
            catch (MySqlException ex)
            {
                await ItemsPage.DisplayAlert("Database Error",
                 $"A database error occurred. The words could not be loaded.\n\nError: {ex}", "Okay");
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    if ((x is IOException) && (x.InnerException is SocketException))
                    {
                        ItemsPage.DisplayAlert("Connection Error",
                 "The database refused to connect.\n\nPlease make sure you are connected to the internet.", "Okay");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }

            return collection;
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }
    }
}