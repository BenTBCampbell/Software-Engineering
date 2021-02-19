using Fake_Word_Dictionary.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Fake_Word_Dictionary.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}