using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// The status of the coupon.
    /// </summary>
    public enum CouponStatus
    {
        /// <summary>
        /// The coupon has been redeemed
        /// </summary>
        Redeemed = 0,

        /// <summary>
        /// The coupon code was not found
        /// </summary>
        NotFound = 1,

        /// <summary>
        /// The coupon has expired
        /// </summary>
        Expired = 2,
        
        /// <summary>
        /// The number of times this coupon can be used has been reached.
        /// </summary>
        LimitReached = 3,
        
        /// <summary>
        /// The coupon is not yet valid.
        /// </summary>
        NotStarted = 4,
    }
}
