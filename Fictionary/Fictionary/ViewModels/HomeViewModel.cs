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
        public ICommand OpenMain => new Command(async ()=>
        {
            var mainView = Resolver.Resolve<MainPage>();
            await Navigation.PushAsync(mainView);
        }); 
    }
}
