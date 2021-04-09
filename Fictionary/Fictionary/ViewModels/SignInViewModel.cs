using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Fictionary.Views;

namespace Fictionary.ViewModels
{
    public class SignInViewModel : ViewModel 
    {
        public ICommand SignInCommand => new Command(async () =>
        {
            await Navigation.PopAsync();
        });

        public ICommand CancelCommand => new Command(async () =>
        {
            await Navigation.PopAsync();
        });
    }
}
