using System;
using System.Collections.Generic;
using System.Text;
using Fictionary.Models;

namespace Fictionary.ViewModels
{
    public class DetailsViewModel : ViewModel
    {
        /// <summary>
        /// The word and definition that will be displayed
        /// </summary>
        public Definition Definition { get; set; }
    }
}
