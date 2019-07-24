using System;

using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// A reserved keyword
    /// </summary>
    /// <remarks>
    /// Keywords provide a way for contacts to text into the system to initiate a campaign.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class Keyword : SoftDeletable
    {
        /// <summary>
        /// The account which owns this keyword.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The channel this keyword is reserved on.
        /// </summary>
        [DataMember]
        public int ChannelId { get; set; }

        /// <summary>
        /// The short or long code this keyword is reserved on.
        /// </summary>
        [DataMember]
        public string ChannelCode { get; set; }

        /// <summary>
        /// The campaign this keyword is currently attached to.
        /// </summary>
        /// <remarks>
        /// If this is NULL then the keyword is not attached to any campaign and will not generate a response.
        /// </remarks>
        [DataMember]
        public int? CampaignId { get; set; }

        /// <summary>
        /// The keyword name to reserve.
        /// </summary>
        /// <remarks>
        /// Keywords cannot contain spaces.
        /// 
        /// Keywords are shared across a channel, so if someone else has a keyword of the same name you will 
        /// have to select a different keyword or use a different channel where it is not already reserved.
        /// </remarks>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Set if a callback should be generated on this keyword.
        /// </summary>
        [DataMember]
        //[JsonProperty("callback_required")] // TODO: Remove this mapping
        public bool CallbackRequired { get; set; }
    }
}
