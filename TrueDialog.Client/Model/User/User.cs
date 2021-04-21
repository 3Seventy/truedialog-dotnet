using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    public class User
    {
        /// <summary>
        /// The login name for the user.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// The login password for the user.
        /// </summary>
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation password, must match Password.
        /// </summary>
        [DataMember]
        public string PasswordConfirmation { get; set; }

        /// <summary>
        /// The account this user is allowed to access.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Email address of the user.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// The user's first or given name.
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last or family name.
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// The user's mobile phone number.
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// User is as chat agent
        /// </summary>
        /// <remarks>
        /// Chat agent has access to Call Center only.
        /// </remarks>
        [DataMember]
        public bool IsChatUser { get; set; }

        /// <summary>
        /// User is as report agent
        /// </summary>
        [DataMember]
        public bool ReportOnly { get; set; }

        /// <summary>
        /// User can create contact
        /// </summary>
        [DataMember]
        public bool CanCreateContact { get; set; }

        /// <summary> 
        /// Gets or sets application-specific information for the membership user. 
        /// </summary> 
        ///  
        /// <returns> 
        /// Application-specific information for the membership user. 
        /// </returns> 
        [DataMember]
        public virtual string Comment { get; set; }

        /// <summary> 
        /// Gets or sets whether the membership user can be authenticated. 
        /// </summary> 
        ///  
        /// <returns> 
        /// true if the user can be authenticated; otherwise, false. 
        /// </returns> 
        [DataMember]
        public virtual bool IsApproved { get; set; }

        /// <summary> 
        /// Gets a value indicating whether the membership user is locked out and unable to be validated. 
        /// </summary> 
        ///  
        /// <returns> 
        /// true if the membership user is locked out and unable to be validated; otherwise, false. 
        /// </returns> 
        [DataMember]
        public virtual bool IsLockedOut { get; set; }

        /// <summary>
        /// Gets the most recent date and time that the membership user was locked out.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime"/> object that represents the most recent date and time that the membership user was locked out.
        /// </returns>
        [DataMember]
        public virtual DateTime LastLockoutDate { get; set; }

        /// <summary>
        /// Gets the date and time when the user was added to the membership data store.
        /// </summary>
        /// <returns>
        /// The date and time when the user was added to the membership data store.
        /// </returns>
        [DataMember]
        public virtual DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the user was last authenticated.
        /// </summary>
        /// <returns>
        /// The date and time when the user was last authenticated.
        /// </returns>
        [DataMember]
        public virtual DateTime LastLoginDate { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the membership user was last authenticated or accessed the application.
        /// </summary>
        /// <returns>
        /// The date and time when the membership user was last authenticated or accessed the application.
        /// </returns>
        [DataMember]
        public virtual DateTime LastActivityDate { get; set; }

        /// <summary>
        /// Gets the date and time when the membership user's password was last updated.
        /// </summary>
        /// <returns>
        /// The date and time when the membership user's password was last updated.
        /// </returns>
        [DataMember]
        public virtual DateTime LastPasswordChangedDate { get; set; }
    }
}
