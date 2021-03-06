using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Fictionary
{
    class DictionaryContext : DbContext
    {
        /// <summary>
        /// Creates a new instance of the WordContext class
        /// </summary>
        /// <param name="options">A DbContextOptions object, containing options for the program</param>
        public DictionaryContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Represents the list of words in the dictionary
        /// </summary>
        public DbSet<CatalogWord> CatalogWords { get; set; }

        /// <summary>
        /// Represents the list of definitions in the dictionary
        /// </summary>
        public DbSet<CatalogDefinition> CatalogDefinitions { get; set; }
    }
}
