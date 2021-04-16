﻿namespace Fictionary.Models
{
    /// <summary>
    /// Represents a set of contact information
    /// </summary>
    public class ContactInfo
    {
        /// <summary>
        /// The unique identifier representing a specific ContactInfo instance
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The person's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The person's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The person's phone number
        /// </summary>
        public int Phone { get; set; }
    }
}