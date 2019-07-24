using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Lets you import conatcts 
    /// </summary>
    [DataContract]
    [Serializable]
    public class ActionImportContacts : ActionBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ActionImportContacts()
        {
            Subscriptions = new List<ContactSubscription>();
        }

        /// <summary>
        /// Points to a BLOB url that contains the file to parse.
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// A list of subscriptions that should be added or modified for each of the contacts in the supplied file.
        /// </summary>
        /// 
        [DataMember]
        public IList<ContactSubscription> Subscriptions { get; set; }

        /// <summary>
        /// Set to create contact list out of this import
        /// </summary>
        [DataMember]
        public bool CreateList { get; set; }

        /// <summary>
        /// Set to include contacts that have been created during this import only
        /// </summary>
        [DataMember]
        public bool CreatedOnly { get; set; }

        /// <summary>
        /// Created list name
        /// </summary>
        [DataMember]
        public string ListName { get; set; }
    }
}
