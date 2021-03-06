using Fictionary.Models;
using Fictionary.Views;
using MySqlConnector;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Fictionary.DatabaseFunctions;

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
            // The interface is currently busy
            IsBusy = true;

            // Clear all items
            Items.Clear();

            try
            {
                // Load the items
                var items = await LoadWordsfromDb();
                items.ForEach((item) => Items.Add(item));
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
            finally
            {
                IsBusy = false;
            }
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