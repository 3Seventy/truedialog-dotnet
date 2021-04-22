using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// The type of event which will trigger the callback.
    /// </summary>
    public enum CallbackType
    {
        /// <summary>
        /// Triggers whenever end user texts in a keyword
        /// </summary>
        Keyword = 1,

        /// <summary>
        /// Triggers whenever contact is opting into subscription
        /// </summary>
        Subscription = 2,

        /// <summary>
        /// Triggers whenever end user responses to a survey
        /// </summary>
        Survey = 3,

        /// <summary>
        /// Triggers whenever end user texts in "STOP" or synonym
        /// </summary>
        Stop = 6,

        /// <summary>
        /// Triggers whenever new child account is being created
        /// </summary>
        NewAccount = 8,

        /// <summary>
        /// Triggers whenever end user texts in
        /// </summary>
        IncomingMessage = 11,

        /// <summary>
        /// Triggers for each delivery notice receipt
        /// </summary>
        DeliveryNotice = 12,

        /// <summary>
        /// Triggers if targets have been filtered out during a push
        /// </summary>
        InvalidTargets = 13
    }
}