using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary.Models
{
    /// <summary>
    /// Represents a person's account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// The unique identifier representing a specific Account instance
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The person's username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The person's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// The person's contact info
        /// </summary>
        public ContactInfo ContactInfo { get; set; }

        /// <summary>
        /// Whether the account has administrator permissions
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// The account's rating, on a scale of 1-100
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// All the definitions created under this account
        /// </summary>
        public List<Definition> Definitions { get; set; }

        /// <summary>
        /// All this account's comments
        /// </summary>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// All this account's upvotes
        /// </summary>
        public List<Definition> Upvotes { get; set; }

        /// <summary>
        /// All accounts which account is following
        /// </summary>
        public List<Account> FollowedAccounts { get; set; }
    }
}
