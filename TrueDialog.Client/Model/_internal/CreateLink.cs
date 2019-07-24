namespace TrueDialog.Model
{
    /// <summary>
    /// Used for creating or updating a link
    /// </summary>
    internal class CreateLink
    {
        /// <summary>
        /// The campaign ID that the link is attached to.
        /// </summary>
        internal int? CampaignId { get; set; }

        /// <summary>
        /// The type of link this is.
        /// </summary>
        internal int LinkTypeId { get; set; }

        /// <summary>
        /// Set if we should collect user's location when they click the link
        /// </summary>
        internal bool RequestLocation { get; set; }

        /// <summary>
        /// The name of this link which is used when creating razor templates.
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// The URL we should redirect to.
        /// </summary>
        internal string RedirectURL { get; set; }

        /// <summary>
        /// A contact attribute ID or name to append as a URL query string.
        /// </summary>
        internal string ContactAttributeDefinitionId { get; set; }

        /// <summary>
        /// The Contact Attribute ID to be updated 
        /// </summary>
        internal int? UpdateContactAttributeDefinitionId { get; set; }

        /// <summary>
        /// Contact Attribute value to update
        /// </summary>
        internal string UpdateContactAttributeValue { get; set; }
    }
}
