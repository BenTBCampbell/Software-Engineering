using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Fictionary.Views;
using Fictionary.Models;

namespace Fictionary.ViewModels
{
    public class CreateAccountViewModel : ViewModel
    {
        public Account Account { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand CreateAccountCommand => new Command(async () =>
        {
            // TODO: Implement create account code here
            await Navigation.PopAsync();
        });

        public ICommand CancelCommand => new Command(async () =>
        {
            await Navigation.PopAsync();
        });
    }
}
