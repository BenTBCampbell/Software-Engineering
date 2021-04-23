using Fictionary.Models;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
using System.Text;
=======
using Fictionary.Services;
>>>>>>> ce0171af18d6e36135e58ca052dea2408f816a82
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
<<<<<<< HEAD
            // Add the word to the database
            WordService.AddDefinition(Definition.Word.WordText, Definition.DefinitionText);
=======
            if (Definition.Word.WordText != null && Definition.DefinitionText != null)
            {
                // Add the word to the database
                WordService.AddDefinition(Definition.Word.WordText, Definition.DefinitionText);
            }

>>>>>>> ce0171af18d6e36135e58ca052dea2408f816a82
            Navigation.PopModalAsync();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            Navigation.PopModalAsync();
        });
    }
}
