﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Models
{
    /// <summary>
    /// Represents a word in the dictionary
    /// </summary>
    public class Word
    {
        // The unique identifier representing a specific Word instance
        public int ID { get; set; }

        // The text for the word
        public string WordText { get; set; }
    }
}