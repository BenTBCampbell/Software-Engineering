using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fictionary.Views;

namespace Fictionary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Start the application
            Boostrapper.Initialize();
            MainPage = new NavigationPage(Resolver.Resolve<MainPage>());
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
