using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for when a new account is created on a root account.
    /// </summary>
    [Serializable]
    [DataContract]
    public class NewAccountCallbackEvent : BaseCallbackEvent
    {
        /// <summary>
        /// The name of the new account.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The ID of the account this new account will be a subacount of.
        /// </summary>
        [DataMember]
        public int ParentId { get; set; }
    }
}
