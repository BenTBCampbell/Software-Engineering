using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fake_Word_Dictionary.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/BenTBCampbell/Software-Engineering/issues"));
        }

        public ICommand OpenWebCommand { get; }
    }
}