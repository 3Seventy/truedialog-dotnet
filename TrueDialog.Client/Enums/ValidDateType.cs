namespace TrueDialog.Model
{
    public enum ValidDateType
    {
        /// <summary>
        /// Coupon Code with no FROM and TO dates.
        /// </summary>
        None = 0,
        
        /// <summary>
        /// Coupon Code with static FROM and TO dates.
        /// </summary>
        Static = 1,
        
        /// <summary>
        /// Coupon Code with rolling FROM and TO dates.
        /// </summary>
        Rolling = 2,
    }
}
