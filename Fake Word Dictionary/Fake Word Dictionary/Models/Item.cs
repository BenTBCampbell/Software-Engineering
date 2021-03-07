using System;
using System.Collections.Generic;

namespace Fictionary.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class ItemComparer : IComparer<Item>
    {
        /// <summary>
        /// Compares two items based on their text and description properties
        /// </summary>
        /// <param name="x">The first item to compare</param>
        /// <param name="y">The second item to compare</param>
        /// <returns>A negative number if x appears before y, or a positive number if y appears before x</returns>
        public int Compare(Item x, Item y)
        {
            int comparison = x.Text.CompareTo(y.Text);

            if (comparison != 0)
            {
                return comparison;
            }
            else
            {
                return x.Description.CompareTo(y.Description);
            }

        }
    }
}