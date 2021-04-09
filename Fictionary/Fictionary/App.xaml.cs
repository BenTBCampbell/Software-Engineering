using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fictionary.Views;
using Fictionary.Services;

namespace Fictionary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Boostrapper.Initialize();

            // Start the application
            // Also, update the top bar color
            var navPage = new NavigationPage(Resolver.Resolve<HomeView>());
            DependencyService.Get<IStatusBarService>().SetStatusBarColor(navPage.BarBackgroundColor);
            MainPage = navPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
