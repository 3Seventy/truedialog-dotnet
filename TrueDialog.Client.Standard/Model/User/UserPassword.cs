using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Used for updating a user's password.
    /// </summary>
    public class UserPassword
    {
        /// <summary>
        /// The account the user falls under.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// The new login password for the user.
        /// </summary>
        [DataMember]
        public string NewPassword { get; set; }

        /// <summary>
        /// Confirmation password.  Must match NewPassword.
        /// </summary>
        [DataMember]
        public string ConfirmPassword { get; set; }
    }
}
