using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details of a response to a dailog question that was sent.
    /// </summary>
    [Serializable]
    [DataContract]
    public class DialogCallbackEvent : BaseCallbackEvent
    {
        /// <summary>
        /// The account name that sent the question.
        /// </summary>
        [DataMember]
        public string AccountName { get; set; }

        /// <summary>
        /// The ID of the channel we received the answer on.
        /// </summary>
        [DataMember]
        public int ChannelId { get; set; }

        /// <summary>
        /// The ID of the contact who responded.
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
        /// The phone number which sent the response.
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The response that was sent.
        /// </summary>
        [DataMember]
        public string Answer { get; set; }

        /// <summary>
        /// The question that the response is to.
        /// </summary>
        [DataMember]
        public string QuestionText { get; set; }
        
        /// <summary>
        /// The ID of the dialog campaign that we are processing on.
        /// </summary>
        [DataMember]
        [JsonProperty("SurveyCampaignId")]
        public int DialogCampaignId { get; set; }

        /// <summary>
        /// The ID of the subscription attached to the dialog campaign.
        /// </summary>
        [DataMember]
        public int SubscriptionId { get; set; }

        /// <summary>
        /// The ID of the question the response is to.
        /// </summary>
        [DataMember]
        public int QuestionCampaignId { get; set; }
    }
}
