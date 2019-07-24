using System;

namespace TrueDialog.Configuration
{
    /// <summary>
    /// Set of configuration values to use for configuring TrueDialog client.
    /// </summary>
    public interface IConfiguration
    {
        /// <summary>
        /// The authorization config
        /// </summary>
        IAuthConfig Authorization { get; set; }

        /// <summary>
        /// The base URL to use.
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// The user agent to use.
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Timespan to wait before we give up on a request.
        /// </summary>
        TimeSpan Timeout { get; set; }

        /// <summary>
        /// The retry policy configuration.
        /// </summary>
        IRetryConfig RetryPolicy { get; set; }
    }
}
