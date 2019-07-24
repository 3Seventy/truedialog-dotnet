using System.Configuration;

namespace TrueDialog.Configuration
{
    public class TrueDialogAuthElement : ConfigurationElement, IAuthConfig
    {
        /// <summary>
        /// The user name that should be sent.
        /// </summary>
        [ConfigurationProperty("username", IsRequired = true)]
        public string UserName
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        /// <summary>
        /// The password that should be sent.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = true)]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }

        /// <summary>
        /// The API Key to use as a username
        /// </summary>
        [ConfigurationProperty("apiKey", IsRequired = false)]
        public string ApiKey
        {
            get { return (string)this["apiKey"]; }
            set { this["apiKey"] = value; }
        }

        /// <summary>
        /// The API Secret to use as a password
        /// </summary>
        [ConfigurationProperty("apiSecret", IsRequired = false)]
        public string ApiSecret
        {
            get { return (string)this["apiSecret"]; }
            set { this["apiSecret"] = value; }
        }

        /// <summary>
        /// Default account ID
        /// </summary>
        [ConfigurationProperty("defaultAccountId", DefaultValue = 0, IsRequired = false)]
        public int AccountId
        {
            get { return (int)this["defaultAccountId"]; }
            set { this["defaultAccountId"] = value; }
        }
    }
}
