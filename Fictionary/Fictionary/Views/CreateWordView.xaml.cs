﻿using System;
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
    public partial class CreateWordView : ContentPage
    {
        public CreateWordView(CreateWordViewModel viewModel)
        {
            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}