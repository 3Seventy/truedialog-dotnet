using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// The status of a processing event object.
    /// </summary>
    public enum ProcessStatus
    {
        /// <summary>
        /// The event has not yet run.
        /// </summary>
        Pending = 0,

        /// <summary>
        /// The event is currently being processed on.
        /// </summary>
        Processing = 1,
        
        /// <summary>
        /// The event has completed successfully.
        /// </summary>
        Completed = 2,
        
        /// <summary>
        /// The event was aborted by a user.
        /// </summary>
        Aborted = 3,
        
        /// <summary>
        /// The event failed in some way.
        /// </summary>
        Failed = 4,
    }
}
