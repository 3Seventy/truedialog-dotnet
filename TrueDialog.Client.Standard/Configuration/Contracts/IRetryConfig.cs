using System;

namespace TrueDialog.Configuration
{
    /// <summary>
    /// Details about the retry policy configuration for errored requests.
    /// </summary>
    public interface IRetryConfig
    {
        /// <summary>
        /// Set to false to disable retry policy
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// The type of retry policy object to use.
        /// </summary>
        Type Type { get; set; }

        /// <summary>
        /// The maximum number of times we should attempt to retry the request before giving up.
        /// </summary>
        int MaxTries { get; set; }

        /// <summary>
        /// The minimum allowed value for timeouts.
        /// </summary>
        /// <remarks>
        /// For incremental, and exponential policies this value is the base value.
        /// </remarks>
        TimeSpan MinInterval { get; set; }

        /// <summary>
        /// The maximum allowed value for timeouts.
        /// </summary>
        /// <remarks>
        /// For incremental, and exponential policies this value is the base value.
        /// </remarks>
        TimeSpan MaxInterval { get; set; }

        /// <summary>
        /// How often (in miliseconds) we should attempt to retry.
        /// </summary>
        /// <remarks>
        /// For incremental, and exponential policies this value is the base value.
        /// </remarks>
        TimeSpan Interval { get; set; }
    }
}
