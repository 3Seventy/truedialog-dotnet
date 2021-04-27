using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for when a contact texts in on a keyword.
    /// </summary>
    [Serializable]
    [DataContract]
    public class KeywordCallbackEvent : BaseCallbackEvent
    {
        /// <summary>
        /// The contact ID which texted in.
        /// </summary>
        [DataMember]
        public int ContactId { get; set; }

        /// <summary>
        /// The phone number of the contact
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// The channel ID we receved the message on.
        /// </summary>
        [DataMember]
        public int ChannelId { get; set; }

        /// <summary>
        /// The ID of the keyword that was recognized.
        /// </summary>
        [DataMember]
        public int KeywordId { get; set; }

        /// <summary>
        /// The keyword that was received by Vector.
        /// </summary>
        [DataMember]
        public string Keyword { get; set; }

        /// <summary>
        /// The campaign ID to which the keyword is attached.
        /// </summary>
        /// <remarks>
        /// Note that the keyword MUST be attached to a campaign before a callback will be triggered.
        /// 
        /// You can attach a gateway campaign to the keyword, preventing any automatic response by
        /// the Vector server if you wish to send your own detailed response via PushCampaign.
        /// </remarks>
        [DataMember]
        public int CampaignId { get; set; }
        
        /// <summary>
        /// The subscription ID which is on the campaign attached to the keyword.
        /// </summary>
        [DataMember]
        public int SubscriptionId { get; set; }
    }
}
