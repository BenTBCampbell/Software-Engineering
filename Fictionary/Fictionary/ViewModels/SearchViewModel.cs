using Fictionary.Models;
using Fictionary.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Fictionary.ViewModels
{
    public class SearchViewModel : ViewModel
    {
        public List<Definition> SearchResults { get; set; }

        public string SearchQuery { get; set; }

        public ICommand SearchCommand => new Command(async () =>
        {
            List<Word> searchWordResults;

            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                // search for all words
                searchWordResults = WordService.GetAllWords();
            }
            else
            {
                //search for some words using the query.
                searchWordResults = WordService.SearchForWords(SearchQuery);
            }

            // sort the words in alphabetical order
            searchWordResults.Sort(delegate (Word x, Word y)
            {
                return String.Compare(x.WordText, y.WordText, comparisonType: StringComparison.OrdinalIgnoreCase);
            });

            // add the first definition for each word to searchResults
            List<Definition> searchDefinitions = new();
            foreach (var word in searchWordResults)
            {
                var defs = WordService.GetDefinitionsForWord(word);
                if (defs.Count >= 1) 
                {
                    //// trim the text to 20 characters.
                    //if (defs[0].DefinitionText.Length > 20)
                    //{
                    //    defs[0].DefinitionText = defs[0].DefinitionText.Substring(0, 20) + "...";
                    //}

                    searchDefinitions.Add(defs[0]); 
                }
            }

            SearchResults = searchDefinitions;
        });
    }
}
