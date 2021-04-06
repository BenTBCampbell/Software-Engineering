using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Account_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<AccountView>());
        }

        private async void CreateAccount_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<CreateAccountView>());
        }

        private async void CreateWord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<CreateWordView>());
        }

        private async void Credits_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<CreditsView>());
        }

        private async void Home_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<HomeView>());
        }

        private async void Details_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<DetailsView>());
        }

        private async void Search_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<SearchView>());
        }

        private async void Settings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<SettingsView>());
        }

        private async void SignIn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(Resolver.Resolve<SignInView>());
        }
    }
}