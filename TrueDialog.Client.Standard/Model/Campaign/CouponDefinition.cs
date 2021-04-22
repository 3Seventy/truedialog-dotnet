using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Coupon definition
    /// </summary>
    public class CouponDefinition
    {

        /// <summary />
        public CouponDefinition()
        {
            MaxUses = 1; // Default to one use per customer.

            // Some sane defails to help prevent 500 errors when inserting into DB.
            Prefix = "";
            StaticCode = "";
            Name = "";
            Description = "";
        }

        /// <summary>
        /// Account this coupon belongs to
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Campaign this coupon belongs to
        /// </summary>
        [DataMember]
        public int CampaignId { get; set; }

        /// <summary>
        /// The type of coupon that's being defined, Static or Dynamic. (REQUIRED)
        /// </summary>
        [DataMember]
        public int CouponTypeId { get; set; }

        /// <summary>
        /// The prefix code for the coupon. (OPTIONAL)
        /// </summary>
        [DataMember]
        public string Prefix { get; set; }

        /// <summary>
        /// The static code for the coupon.
        /// </summary>
        /// <remarks>
        /// This field is required if the coupon type is Static
        /// </remarks>
        [DataMember]
        public string StaticCode { get; set; }

        /// <summary>
        /// A user definable ID value. (OPTIONAL)
        /// </summary>
        [DataMember]
        public string ExternalId1 { get; set; }

        /// <summary>
        /// A second user definable ID value. (OPTIONAL)
        /// </summary>
        [DataMember]
        public string ExternalId2 { get; set; }

        /// <summary>
        /// The date we should start allowing coupons to be redeemed. (OPTIONAL)
        /// </summary>
        /// <remarks>
        /// NULL indicates no start date.  I.e. accept immediately.
        /// </remarks>
        [DataMember]
        public DateTime? ValidFrom { get; set; }

        /// <summary>
        /// THe date we should stop allowing coupons to be redeemed. (OPTIONAL)
        /// </summary>
        /// <remarks>
        /// NULL indicates no expiration date.
        /// </remarks>
        [DataMember]
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// The maximum number of allowed uses per customer. (OPTIONAL)
        /// </summary>
        /// <remarks>
        /// Zero indicates that there is no maximum.  Default is 1 if not specified.
        /// </remarks>
        [DataMember]
        public int MaxUses { get; set; }

        /// <summary>
        /// Coupon Code valid DateTypeId i.e. None or Static or Rolling (OPTIONAL)
        /// </summary>
        [DataMember]
        public int? ValidDateTypeId { get; set; }

        /// <summary>
        /// Number of days that coupon code is valid for the Rolling date type Coupon Code 
        /// </summary>
        ///  <remarks>
        ///  This property is required if ValidDateType is Rolling
        /// </remarks>
        [DataMember]
        public int? ValidRollingDays { get; set; }

        /// <summary>
        /// Rolling offset days of the coupon code
        /// </summary>
        /// <remarks>
        /// This property is required if ValidDateType is Rolling
        /// </remarks>
        [DataMember]
        public int? ValidRollingOffSet { get; set; }

        /// <summary>
        /// External Coupon List Id value
        /// </summary>
        /// <remarks>
        /// Either ExternalListId or ExternalCouponList is Required if the CouponType is External
        /// </remarks>
        [DataMember]
        public int? ExternalListId { get; set; }

        /// <summary>
        /// External Coupon List details
        /// </summary>
        /// <remarks>
        /// Either ExternalCouponList or ExternalListId is Required if the CouponType is External
        /// </remarks>
        [DataMember]
        public ExternalCouponList ExternalCouponList { get; set; }


        #region UI Items

        /// <summary>
        /// User definable name for this coupon. (OPTIONAL)
        /// </summary>
        [DataMember]
        public string Name { get; set;}

        /// <summary>
        /// User definable coupon description. (OPTIONAL)
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        #endregion

        /// <summary>
        /// Enumeration mapping for CouponTypeId
        /// </summary>
        [IgnoreDataMember]
        public CouponType CouponType
        {
            get { return (CouponType)CouponTypeId; }
            set { CouponTypeId = (int)value; }
        }

        /// <summary>
        /// Enumeration mapping for ValidDateTypeId
        /// </summary>
        [IgnoreDataMember]
        public ValidDateType ValidDateType
        {
            get { return ValidDateTypeId.HasValue ? (ValidDateType)ValidDateTypeId.Value : ValidDateType.None; }
            set { ValidDateTypeId = (int)value; }
        }
    }
}
