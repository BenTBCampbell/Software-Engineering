using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fictionary.ViewModels
{
    public class CreateWordViewModel : ViewModel
    {
        public ICommand AddWordCommand => new Command(() =>
        {
            // TODO: Code needed to add word to database
            Navigation.PopModalAsync();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            Navigation.PopModalAsync();
        });
    }
}
