using Fictionary.Models;
using Fictionary.Services;
using Fictionary.Views;
using System.Diagnostics;
using Xamarin.Forms;

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
            MySqlManager.InitializeConnection();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
