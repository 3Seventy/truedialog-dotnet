using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for when a contact texts STOP.
    /// </summary>
    [Serializable]
    [DataContract]
    public class StopCallbackEvent : BaseCallbackEvent
    {
        /// <summary>
        /// The name of the account which the callback was preformed on.
        /// </summary>
        [DataMember]
        public string AccountName { get; set; }

        /// <summary>
        /// The ID of the channel the STOP message was received on.
        /// </summary>
        [DataMember]
        public int ChannelId { get; set; }

        /// <summary>
        /// The ID of the contact which is opting out.
        /// </summary>
        [DataMember]
        public int ContactId { get; set; }

        /// <summary>
        /// The account ID which owns the contact.
        /// </summary>
        [DataMember]
        public int ContactAccountId { get; set; }

        /// <summary>
        /// The name of the account which owns the contact.
        /// </summary>
        [DataMember]
        public string ContactAccountName { get; set; }

        /// <summary>
        /// The phone number of the contact.
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The ID of the subscription the contact is being opted out of.
        /// </summary>
        [DataMember]
        public int SubscriptionId { get; set; }
    }
}
