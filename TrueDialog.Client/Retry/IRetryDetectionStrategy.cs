using System;

namespace TrueDialog.Retry
{
    /// <summary>
    /// Interface for transient error detection.
    /// </summary>
    interface IRetryDetectionStrategy
    {
        /// <summary>
        /// Checks to see if the supplied exception is a transient error.
        /// </summary>
        /// <param name="ex">The exception to check.</param>
        /// <returns>True if this is a transient fault, false if not.</returns>
        bool IsTransient(Exception ex);
    }
}
