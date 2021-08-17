using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Represents a subscription that a contact can opt into and out of.
    /// </summary>
    /// <remarks>
    /// Subscriptions provide your contacts a way to select what 
    /// types messages they wish to, or not to, receive.  It also allows
    /// them to specify how they wish to receive these messages.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class Subscription : SoftDeletable
    {
        /// <summary />
        public Subscription()
        {
            // By default most subscriptions will be recurring.
            SubscriptionType = SubscriptionType.Recurring;
            Frequency = 30;
        }

        /// <summary>
        /// This is the account which owns the subscription object.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The name of this subscription
        /// </summary>
        /// <remarks>
        /// This is the name that is used when asking contacts to select a subscription to opt out of 
        /// (in the case where they are opted into more than one subscription)
        /// 
        /// The name cannot contain spaces.
        /// </remarks>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The pretty display name for the susbscription.
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// The type of subscription, either one-time or recurring.
        /// </summary>
        /// <remarks>
        /// Recurring subscriptions are for situations where multiple messages are going to be sent to a contact on an
        /// ongoing basis.  Most types of susbscriptions will fall into this category.  A good example is for a marketing
        /// campaign where events and coupons might be sent out to a list of interested customers.
        /// 
        /// OneTime subscriptions are for one off messages where the intention is to send a single message to that
        /// customer once.  A good example would be to notify specific people they have a package waiting in an office,
        /// or that their scheduled service call will be arriving shortly.
        /// </remarks>
        [DataMember]
        public int SubscriptionTypeId { get; set; }

        /// <summary>
        /// Number of messages (on average) per month a contact can expect to get on this subscription.
        /// </summary>
        /// <remarks>
        /// This value is only relevant to Recurring subscriptions.  It is ignored for OneTime subscriptions.
        /// The default is 30 messages per month.
        /// </remarks>
        [DataMember]
        public int Frequency { get; set; }

        /// <summary>
        /// This is an enumeration wrapper around SubscriptionTypeId
        /// </summary>
        [IgnoreDataMember]
        public SubscriptionType SubscriptionType
        {
            get { return (SubscriptionType)SubscriptionTypeId; }
            set { SubscriptionTypeId = (int)value; }
        }

        /// <summary>
        /// Chat subscription flag
        /// </summary>
        [DataMember]
        public bool IsChat { get; set; }

        /// <summary>
        /// Default subscription flag
        /// </summary>
        [DataMember]
        public bool IsDefault { get; set; }
    }
}
