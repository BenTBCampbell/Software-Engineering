﻿using System;

namespace Fictionary.Models
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
        /// The person's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The person's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The person's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The person's phone number
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Returns string representation of the object
        /// </summary>
        /// <returns> The string representation of the object </returns>
        public override string ToString()
        {
            return $"ContactInfo {{ ID: {ID}, Name {FirstName}, Email: {Email}, Phone: {Phone}}}";
        }
    }
}