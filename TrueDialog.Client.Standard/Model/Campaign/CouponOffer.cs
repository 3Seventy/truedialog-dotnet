using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Holds details of coupon offer (used for landing page)
    /// </summary>
    public class CouponOffer : SoftDeletable
    {
        /// <summary>
        /// The account this offer belongs to
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The campaign this offer is for
        /// </summary>
        [DataMember]
        public int CampaignId { get; set; }

        /// <summary>
        /// Regular offer (without coupon)
        /// </summary>
        [DataMember]
        public string RegularOffer { get; set; }

        /// <summary>
        /// Coupon offer (when coupon applied)
        /// </summary>
        [DataMember]
        public string NewOffer { get; set; }

        /// <summary>
        /// Offer image URL
        /// </summary>
        [DataMember]
        public string ImageURL { get; set; }

        /// <summary>
        /// Terms and conditions of this offer
        /// </summary>
        [DataMember]
        public string TermsAndConditions { get; set; }

        /// <summary>
        /// URL to use as base when sending to user
        /// </summary>
        [DataMember]
        public string UrlBase { get; set; }
    }
}