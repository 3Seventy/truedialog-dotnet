using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// Return value for a user chat token request.
    /// </summary>
    public class ChatToken
    {
        /// <summary>
        /// The login token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// The user name this token is for (for reference)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// When this token will no longer be valid.  Time is in UTC.
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}
