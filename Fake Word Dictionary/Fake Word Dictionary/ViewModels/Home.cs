using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Fictionary.ViewModels
{
    public class Home : ContentPage
    {
        public Home()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}