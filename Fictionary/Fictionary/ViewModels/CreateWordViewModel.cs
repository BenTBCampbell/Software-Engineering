using Fictionary.Models;
using Fictionary.Services;
using System.Windows.Input;
using Xamarin.Forms;

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
            if (Definition.Word.WordText != null && Definition.DefinitionText != null)
            {
                // Add the word to the database
                WordService.AddDefinition(Definition.Word.WordText, Definition.DefinitionText);
            }

            Navigation.PopModalAsync();
        });

        public ICommand CancelCommand => new Command(() =>
        {
            Navigation.PopModalAsync();
        });
    }
}
