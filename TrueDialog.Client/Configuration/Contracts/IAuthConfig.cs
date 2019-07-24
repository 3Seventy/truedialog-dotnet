namespace TrueDialog.Configuration
{
    /// <summary>
    /// Details for user authentication
    /// </summary>
    public interface IAuthConfig
    {
        /// <summary>
        /// The user name to use.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// The password to use.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// The API Key to use as a username
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// The API Secret to use as a password
        /// </summary>
        string ApiSecret { get; set; }

        /// <summary>
        /// Default account ID
        /// </summary>
        int AccountId { get; set; }
    }
}
