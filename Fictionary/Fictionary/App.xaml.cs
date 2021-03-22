using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fictionary
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Boostrapper.Initialize();
            //MainPage = Resolver.Resolve<MainShell>();
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
