using Fictionary.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Fictionary.Views
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