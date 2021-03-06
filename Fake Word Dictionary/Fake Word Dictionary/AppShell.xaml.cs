using Fictionary.ViewModels;
using Fictionary.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Fictionary
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

        private async void OnAddWordClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
            Shell.Current.FlyoutIsPresented = false;
        }
    }
}
