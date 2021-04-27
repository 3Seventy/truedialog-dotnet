using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Statics about a coupons redemption rates.
    /// </summary>
    public class CouponRedemptionDetails
    {
        /// <summary>
        /// Total redemptions count
        /// </summary>
        public int RedemptionCount { get; set; }

        /// <summary>
        /// Count of redemptions performed too early
        /// </summary>
        public int TooEarlyCount { get; set; }

        /// <summary>
        /// Count of redemptions performed too late
        /// </summary>
        public int TooLateCount { get; set; }

        /// <summary>
        /// Count of redemptions over MaxUses count
        /// </summary>
        public int TooManyCount { get; set; }

        /// <summary>
        /// Total bad redemptions count
        /// </summary>
        public int TotalBadCount { get; set; }

        /// <summary>
        /// First successful redemption
        /// </summary>
        public CouponRedemption FirstSuccessful { get; set; }

        /// <summary>
        /// Last successful redemption
        /// </summary>
        public CouponRedemption LastSuccessful { get; set; }
    }

    /// <summary>
    /// Returned details of a redeemed coupon
    /// </summary>
    public class CouponRedemption
    {
        [IgnoreDataMember]
        private int m_couponStatus { get; set; }

        /// <summary>
        /// The campaign for which the coupon was defined under.
        /// </summary>
        [DataMember]
        public int? CampaignId { get; set; }

        /// <summary>
        /// The customer who attempted to redeem the coupon.
        /// </summary>
        [DataMember]
        public int? ContactId { get; set; }

        /// <summary>
        /// The actual code submitted for redemption
        /// </summary>
        [DataMember]
        public string CouponCode { get; set; }

        /// <summary>
        /// The status of the redemption attempt.
        /// </summary>
        /// <remarks>
        /// Non zero means failure.
        /// </remarks>
        [DataMember]
        public CouponStatus CouponStatus 
        {
            get { return (CouponStatus)m_couponStatus; }
            set { m_couponStatus = (int)value; }
        }

        /// <summary>
        /// When this coupon redemption was created
        /// </summary>
        [DataMember]
        public DateTime Created { get; set; }
    }
}
