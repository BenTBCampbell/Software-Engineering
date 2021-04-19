using Fictionary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Fictionary.Services;

namespace Fictionary.ViewModels
{
    public class CreateWordViewModel : ViewModel
    {
        /// <summary>
        /// The definition object for adding words
        /// </summary>
        public Definition Definition { get; set; }

        public ICommand AddWordCommand => new Command(() =>
        {
            // Add the word to the database
            WordService.AddDefinition(Definition.Word.WordText, Definition.DefinitionText);
            Navigation.PopModalAsync();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            Navigation.PopModalAsync();
        });
    }
}
