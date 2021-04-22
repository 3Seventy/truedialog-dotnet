using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details of a campaign that are returned to a user.
    /// </summary>
    [Serializable]
    [DataContract]
    public class Campaign : SoftDeletable
    {
        /// <summary>
        /// The account to which the campaign belongs.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The subscription that contacts who respond to
        /// this campaign are opted into.
        /// </summary>
        [DataMember]
        public int SubscriptionId { get; set; }

        /// <summary>
        /// The campaign's name.
        /// </summary>
        /// <remarks>
        /// This is a free form name.
        /// </remarks>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The type of campaign.
        /// </summary>
        [DataMember]
        public int CampaignTypeId { get; set; }

        /// <summary>
        /// Content that this campaign sends.
        /// </summary>
        [DataMember]
        public int? ContentId { get; set; }

        /// <summary>
        /// Indicates if this campaign will start a new session
        /// </summary>
        /// <remarks>
        /// Currently this value cannot be customized.
        /// </remarks>
        [DataMember]
        public bool Session { get; internal set; }

        /// <summary>
        /// The durration of sessions in miliseconds from start.
        /// </summary>
        /// <remarks>
        /// Currently this value cannot be customized.
        /// </remarks>
        [DataMember]
        public int? SessionLength { get; internal set; }

        /// <summary>
        /// Arbitrary user data field.
        /// </summary>
        /// <remarks>
        /// This an area to store free form data.
        /// 
        /// The Vector Portal uses this field to store some UI hints.
        /// </remarks>
        [DataMember]
        public string UserData { get; set; }

        /// <summary>
        /// This Flag is for checking Single Send Campaign.
        /// </summary>
        /// <remarks>
        /// The default for this field is false.
        /// </remarks>
        [DataMember]
        public bool SingleUse { get; set; }

        /// <summary>
        /// This is set to the content id for response to send when the campaign is used more than once.
        /// </summary> 
        [DataMember]
        public int? SingleUseContent { get; set; }

        /// <summary>
        /// Enumeration mapping for CampaignTypeId
        /// </summary>
        [IgnoreDataMember]
        public CampaignType CampaignType
        {
            get { return (CampaignType)CampaignTypeId; }
            set { CampaignTypeId = (int)value; }
        }
    }
}
