using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Describes a link that can be sent in a razor template.
    /// </summary>
    /// <remarks>
    /// Links are shortened when we send them. This is to save characters when readling
    /// with SMS messages.
    /// </remarks>
    public class Link : BaseAudited
    {
        /// <summary>
        /// The account ID which owns the link
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The campaign this link is part of.
        /// </summary>
        [DataMember]
        public int? CampaignId { get; set; }

        /// <summary>
        /// The contact attribute ID to append to the URL if desired.
        /// </summary>
        [DataMember]
        public int? ContactAttributeDefinitionId { get; set; }

        /// <summary>
        /// Enumeration mapping to LinkTypeId
        /// </summary>
        [DataMember]
        public LinkType LinkType
        {
            get { return (LinkType)LinkTypeId; }
            set { LinkTypeId = (int)value; }
        }

        /// <summary>
        /// The type of link this is. Either Static or Dynamic
        /// </summary>
        [DataMember]
        public int LinkTypeId { get; set; }

        /// <summary>
        /// The name of the link.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The URL we should redirect to.
        /// </summary>
        [DataMember]
        public string RedirectURL { get; set; }
        
        /// <summary>
        /// Set if we should request the user's location before redirecting.
        /// </summary>
        [DataMember]
        public bool RequestLocation { get; set; }

        /// <summary>
        /// The short URL to use.
        /// </summary>
        [DataMember]
        public string ShortBaseURL { get; set; }

        /// <summary>
        /// The contact attribute ID to be updated.
        /// </summary>
        [DataMember]
        public int? UpdateContactAttributeDefinitionId { get; set; }

        /// <summary>
        /// The value to update the contact attribute to.
        /// </summary>
        [DataMember]
        public string UpdateContactAttributeValue { get; set; }
    }
}
