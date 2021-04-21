namespace TrueDialog.Model
{
    /// <summary>
    /// Enumeration for identifying the type of campaign we are working with.
    /// </summary>
    public enum CampaignType
    {
        /// <summary>
        /// A campaign with no content for pushing out unformated messages.
        /// </summary>
        Gateway = 0,

        /// <summary>
        /// A campaign with preformated content.
        /// </summary>
        Basic = 1,

        /// <summary>
        /// A campaign which contains a group of question campaigns.
        /// </summary>
        Dialog = 2,

        /// <summary>
        /// A campaign that asks a single question in a survey.
        /// </summary>
        Question = 3,

        /// <summary>
        /// A campaign which sends a coupon code to a customer.
        /// </summary>
        Coupon = 4,

        /// <summary>
        /// Reserved, do not use.
        /// </summary>
        Sweapstakes = 5,

        /// <summary>
        /// Chat campaign
        /// </summary>
        Chat = 6
    }
}