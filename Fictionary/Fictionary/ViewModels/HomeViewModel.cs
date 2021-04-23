using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Fictionary.Views;
using System.Windows.Input;
using System.Threading.Tasks;

namespace Fictionary.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        public string SearchQuery { get; set; }

        public ICommand OpenMainCommand => new Command(async () =>
        {
            // Navigate unless MainPage is already opened
            int lastEl = Navigation.NavigationStack.Count - 1;
            if (Navigation.NavigationStack[lastEl].GetType() != typeof(MainPage))
            {
                var view = Resolver.Resolve<MainPage>();
                await Navigation.PushAsync(view);
            }
        });

        public ICommand AddWordCommand => new Command(async () =>
        {
            // Return if AddWord is already opened
            int lastEl = Navigation.ModalStack.Count - 1;
            if ((lastEl != -1) && (Navigation.ModalStack[lastEl].GetType() == typeof(CreateWordView)))
            {
                return;
            }

            var view = Resolver.Resolve<CreateWordView>();
            await Navigation.PushModalAsync(view);
        });

        public ICommand BrowseCommand => new Command(async () =>
        {
            // Return if Search is already opened
            int lastEl = Navigation.ModalStack.Count - 1;
            if ((lastEl != -1) && (Navigation.ModalStack[lastEl].GetType() == typeof(SearchView)))
            {
                return;
            }

            var view = Resolver.Resolve<SearchView>();

            // set the search query in the new page to * (display all words), and execute the search command.
            var viewModel = view.BindingContext as SearchViewModel;
            viewModel.SearchQuery = string.Empty;
            viewModel.SearchCommand.Execute(null);

            await Navigation.PushModalAsync(view);
        });

        public ICommand SearchCommand => new Command(async () =>
        {
            // Return if Search is already opened
            int lastEl = Navigation.ModalStack.Count - 1;
            if ((lastEl != -1) && (Navigation.ModalStack[lastEl].GetType() == typeof(SearchView)))
            {
                return;
            }

            var view = Resolver.Resolve<SearchView>();

            // set the search query in the new page, and execute the search command.
            var viewModel = view.BindingContext as SearchViewModel;
            viewModel.SearchQuery = this.SearchQuery;
            viewModel.SearchCommand.Execute(null);

            // load the new page
            await Navigation.PushModalAsync(view);
        });

        public ICommand ShowSettingsCommand => new Command(async () =>
        {
            // Navigate unless ShowSettings is already opened
            int lastEl = Navigation.NavigationStack.Count - 1;
            if (Navigation.NavigationStack[lastEl].GetType() != typeof(SettingsView))
            {
                var view = Resolver.Resolve<SettingsView>();
                await Navigation.PushAsync(view);
            }
        });

        public ICommand SignInCommand => new Command(async () =>
        {
            // Return if SignIn is already opened
            int lastEl = Navigation.ModalStack.Count - 1;
            if ((lastEl != -1) && (Navigation.ModalStack[lastEl].GetType() == typeof(SignInView)))
            {
                return;
            }

            var view = Resolver.Resolve<SignInView>();
            await Navigation.PushModalAsync(view);

        });

        public ICommand CreateAccountCommand => new Command(async () =>
        {
            // Navigate unless CreateAccount is already opened
            int lastEl = Navigation.NavigationStack.Count - 1;
            if (Navigation.NavigationStack[lastEl].GetType() != typeof(CreateAccountView))
            {
                var view = Resolver.Resolve<CreateAccountView>();
                await Navigation.PushAsync(view);
            }
        });

    }
}
