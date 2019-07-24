using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Contact details
    /// </summary>
    /// <remarks>
    /// A contact is a unique phone number and/or email address per account.
    /// 
    /// Note that either PhoneNumber or Email are required.  You may have both, but you must have at least one of these two.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class Contact : SoftDeletable
    {
        private IList<ContactAttribute> m_attributes = new List<ContactAttribute>();

        private IList<ContactSubscription> m_subscriptions = new List<ContactSubscription>();
        
        /// <summary>
        /// The account that this contact belongs to.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Mobile number if available.
        /// </summary>
        /// <remarks>
        /// Either this or the Email field are _REQUIRED_
        /// </remarks>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email address of the contact.
        /// </summary>
        /// <remarks>
        /// Either this or the PhoneNumber field are _REQUIRED_
        /// </remarks>
        [DataMember]
        public string Email { get; set; }

        // TODO: Add subscription info

        /// <summary>
        /// List of attributes set on this contact
        /// </summary>
        [DataMember]
        public IList<ContactAttribute> Attributes
        {
            get { return m_attributes; }
            set { m_attributes = value ?? new List<ContactAttribute>(); }
        }

        /// <summary>
        /// List of subscriptions details for this contact.
        /// </summary>
        [DataMember]
        public IList<ContactSubscription> Subscriptions
        {
            get { return m_subscriptions; }
            set { m_subscriptions = value ?? new List<ContactSubscription>(); }
        }

    }
}
