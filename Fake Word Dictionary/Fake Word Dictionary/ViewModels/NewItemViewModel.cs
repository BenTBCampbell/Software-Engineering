using Fictionary.Models;
using Fictionary.Views;
using MySqlConnector;
using System;
using System.IO;
using System.Net.Sockets;
using Xamarin.Forms;
using static Fictionary.DatabaseFunctions;

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

        private async void OnSave()
        {
            // Whether the operation succeeded
            bool succeeded = false;

            try
            {
                // Attempt to add the word to the database
                succeeded = await AddWordtoDb(Word, Definition);
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                await NewItemPage.DisplayAlert("Duplicate Definition",
                    "This definition already exists!\n\nPlease choose a different definition.", "Okay");
            }
            catch (MySqlException ex) when (ex.Number == 1042)
            {
                await NewItemPage.DisplayAlert("Connection Error",
                  "The database refused to connect.\n\nPlease make sure you are connected to the internet.", "Okay");
            }
            catch (MySqlException ex)
            {
                await NewItemPage.DisplayAlert("Database Error",
                 $"A database error occurred. The word could not be added.\n\nError: {ex}", "Okay");
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    if ((x is IOException) && (x.InnerException is SocketException))
                    {
                        NewItemPage.DisplayAlert("Connection Error",
                 "The database refused to connect.\n\nPlease make sure you are connected to the internet.", "Okay");
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                });
            }

            // Only add the word if the operation succeeded
            if (succeeded)
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