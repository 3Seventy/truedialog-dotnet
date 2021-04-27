using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Coupon Code assosiated with the External Coupon List
    /// </summary>
    public class ExternalCouponCode : Base
    {
        /// <summary>
        /// Account this code belongs to
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The Customer who received the external coupon code
        /// </summary>
        [DataMember]
        public int? ContactId { get; set; }
        
        /// <summary>
        /// The external coupon code
        /// </summary>
        [DataMember]
        public string CouponCode { get; set; }
        
        /// <summary>
        /// The date when the external coupon code is created
        /// </summary>
        [DataMember]
        public DateTime Created { get; set; }
        
        /// <summary>
        /// External Coupon list Id associated with this Coupon Code
        /// </summary>
        [DataMember]
        public int ListId { get; set; }
        
        /// <summary>
        /// Reservation token Identifier for this coupon code
        /// </summary>
        [DataMember]
        public Guid? ReservationToken { get; set; }
    }
}
