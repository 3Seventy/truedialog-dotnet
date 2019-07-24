using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Contact list details
    /// </summary>
    public class ContactList : BaseAudited
    {
        /// <summary>
        /// The account that the contact list runs against.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The first group in the contact filter
        /// </summary>
        [DataMember]
        public FilterGroup RootGroup { get; set; }

        /// <summary>
        /// The name of the contact list.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}
