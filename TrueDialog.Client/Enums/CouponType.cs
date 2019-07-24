namespace TrueDialog.Model
{
    /// <summary>
    /// Type of coupon
    /// </summary>
    public enum CouponType
    {
        /// <summary>
        /// Static Coupons
        /// </summary>
        Static = 0,
        
        /// <summary>
        /// Dynamically Generated Coupons
        /// </summary>
        Dynamic = 1,
          
        /// <summary>
        /// Coupon codes generated externally and uploaded
        /// </summary>
        External = 2,
    }
}
