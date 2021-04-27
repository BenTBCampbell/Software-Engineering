using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fictionary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        public SearchView(SearchViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Update search whenever a key is pressed
            // First wait a little to make sure no more keys are pressed
            await Task.Delay(150);
            var viewModel = (SearchViewModel)BindingContext;

            if (e.NewTextValue == viewModel.SearchQuery)
            {
                viewModel.SearchCommand.Execute(null);
            }
        }
    }
}