using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// External coupon list
    /// </summary>
    public class ExternalCouponList : Base
    {
        /// <summary>
        /// The account ID that external coupon list belongs to
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Name of the external coupon list 
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Description for the external coupon list
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// external coupon list can be shared with the child accounts or not
        /// </summary>
        [DataMember]
        public bool Inheritable { get; set; }

        /// <summary>
        /// Total number of codes available
        /// </summary>
        [DataMember]
        public int TotalCodesAvailable { get; set; }

        /// <summary>
        /// A list of coupon codes
        /// </summary>
        [DataMember]
        public IList<string> CouponCodes { get; set; }
    }
}
