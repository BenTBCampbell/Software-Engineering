using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fictionary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Fictionary.Models;

namespace Fictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateAccountView : ContentPage
    {
        public CreateAccountView(CreateAccountViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Account = new Account() { ContactInfo = new ContactInfo() };
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}