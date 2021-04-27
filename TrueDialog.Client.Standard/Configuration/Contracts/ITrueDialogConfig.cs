namespace TrueDialog.Configuration
{
    /// <summary>
    /// Set of configuration values to use for configuring TrueDialog client.
    /// </summary>
    public interface ITrueDialogConfig
    {
        /// <summary>
        /// The user name to use.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The password to use.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// The API key to use.
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// The API secret to use.
        /// </summary>
        string ApiSecret { get; set; }

        /// <summary>
        /// Default account ID to use.
        /// </summary>
        int? AccountId { get; set; }

        /// <summary>
        /// The base URL to use.
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// The user agent to use.
        /// </summary>
        string UserAgent { get; set; }

        /// <summary>
        /// Timespan to wait before we give up on a request (in milliseconds).
        /// </summary>
        int? Timeout { get; set; }
    }
}
