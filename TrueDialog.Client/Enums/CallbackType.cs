using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// The type of event which will trigger the callback.
    /// </summary>
    public enum CallbackType
    {
        /// <summary>
        /// Execute when a contact texts into a keyword.
        /// </summary>
        Keyword = 1,

        /// <summary>
        /// Reserved by 3Seventy, do not use.
        /// </summary>
        [Obsolete("Reserved, do not use")]
        Reserved0 = 2,

        /// <summary>
        /// Executes when a contact texts in a valid response to a dialog question.
        /// </summary>
        Dialog = 3,

        /// <summary>
        /// Execute when a contact is sent a sweepstakes campaign.
        /// </summary>
        /// <remarks>
        /// Not supported yet.  Do not use.
        /// </remarks>
        [Obsolete("Not supported yet, do not use.")]
        Sweepstakes = 4,

        /// <summary>
        /// Execute when a contact is sent a coupon campaign.
        /// </summary>
        /// <remarks>
        /// Not supported yet.  Do not use.
        /// </remarks>
        [Obsolete("Not supported yet, do not use.")]
        Coupon = 5,

        /// <summary>
        /// Execute when a contact is opts out of a subscription.
        /// </summary>
        Stop = 6,

        /// <summary>
        /// Reserved by 3Seventy, do not use.
        /// </summary>
        [Obsolete("Reserved, do not use")]
        Reserved1 = 7,

        /// <summary>
        /// Executes when a new sub-account is created under a master account.
        /// </summary>
        NewAccount = 8,

        /// <summary>
        /// Reserved by 3Seventy, do not use.
        /// </summary>
        [Obsolete("Reserved, do not use")]
        Reserved2  = 9,

        /// <summary>
        /// Reserved by 3Seventy, do not use.
        /// </summary>
        [Obsolete("Reserved, do not use")]
        Reserved3 = 10
    }
}