using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Fictionary.Views;
using System.Windows.Input;

namespace Fictionary.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        public ICommand OpenMainCommand => new Command(async ()=>
        {
            var view = Resolver.Resolve<MainPage>();
            await Navigation.PushAsync(view);
        });

        public ICommand AddWordCommand => new Command(async () =>
        {
            var view = Resolver.Resolve<CreateWordView>();
            await Navigation.PushModalAsync(view);
        });

        public ICommand ShowSettingsCommand => new Command(async () =>
        {
            var view = Resolver.Resolve<SettingsView>();
            await Navigation.PushAsync(view);
        });

        public ICommand SignInCommand => new Command(async () =>
        {
            var view = Resolver.Resolve<SignInView>();
            await Navigation.PushAsync(view);
        });

        public ICommand CreateAccountCommand => new Command(async () =>
        {
            var view = Resolver.Resolve<CreateAccountView>();
            await Navigation.PushAsync(view);
        });

    }
}
