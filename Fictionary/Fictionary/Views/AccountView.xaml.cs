using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fictionary.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fictionary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountView : ContentPage
    {
        public AccountView(AccountViewModel viewModel)
        {
            InitializeComponent();
            viewModel.Navigation = Navigation;
            this.BindingContext = viewModel;
        }
    }
}