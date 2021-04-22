using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details needed to create a new campaign.
    /// </summary>
    internal class CreateCampaign
    {
        private IEnumerable<CreateLink> m_links = new List<CreateLink>();

        /// <summary>
        /// The subscription that contacts who respond to
        /// this campaign are opted into..
        /// </summary>
        [DataMember]
        public int? SubscriptionId { get; set; }

        /// <summary>
        /// The campaigns name
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The type of campaign
        /// </summary>
        [DataMember]
        public int CampaignTypeId { get; set; }

        /// <summary>
        /// Content that this campaign sends.
        /// </summary>
        [DataMember]
        public int? ContentId { get; set; }

        /// <summary>
        /// Content to add to this campaign.
        /// </summary>
        /// <remarks>
        /// This replaces ContentID, and cannot appear with ContentID
        /// </remarks>
        [DataMember]
        public CreateUpdateContent Content { get; set; }

        /// <summary>
        /// Arbitrary user data field
        /// </summary>
        [DataMember]
        public string UserData { get; set; }

        /// <summary>
        /// This Flag is for checking Single Send Campaign.
        /// default value is False.
        /// </summary> 
        [DataMember]
        public bool SingleUse { get; set; }

        /// <summary>
        /// This is set to the content Id for Single Send Campaign response.
        /// </summary> 
        [DataMember]
        public int? SingleUseContentId { get; set; }

        /// <summary>
        /// A list of links to create along with this campaign.
        /// </summary>
        [DataMember]
        public IEnumerable<CreateLink> Links
        {
            get { return m_links; }
            set { m_links = value ?? new List<CreateLink>(); }
        }

        /// <summary>
        /// Indicates if its a default campaign
        /// </summary>
        [DataMember]
        public bool IsDefault { get; set; }

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
