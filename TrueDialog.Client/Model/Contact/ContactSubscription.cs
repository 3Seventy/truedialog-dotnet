using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for a contact's subscription options.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ContactSubscription
    {
        [IgnoreDataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The ID of the contact that is opted in.
        /// </summary>
        [DataMember]
        public int ContactId { get; set; }

        /// <summary>
        /// The subscription ID the contact is a member of.
        /// </summary>
        [DataMember]
        public int SubscriptionId { get; set; }

        /// <summary>
        /// Set if the contact wishes to receive SMS messages.
        /// </summary>
        [DataMember]
        public bool SmsEnabled { get; set; }

        /// <summary>
        /// Set if the contact wishes to receive MMS messages.
        /// </summary>
        [DataMember]
        [Obsolete("Not implemented, do not use")]
        public bool MmsEnabled { get; set; }

        /// <summary>
        /// Set if the contact wishes to receive email messages.
        /// </summary>
        [DataMember]
        public bool EmailEnabled { get; set; }

        /// <summary>
        /// Set if the contact wishes to receive voice messages.
        /// </summary>
        [DataMember]
        [Obsolete("Not implemented, do not use")]
        public bool VoiceEnabled { get; set; }
    }
}
