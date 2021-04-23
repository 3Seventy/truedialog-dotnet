using System;
using System.Configuration;

namespace TrueDialog.Configuration
{
    public class TrueDialogConfigSection : ConfigurationSection
    {
        /// <summary>
        /// Pulls config from the configuration file.
        /// </summary>
        public static TrueDialogConfigSection GetConfig()
        {
            return (TrueDialogConfigSection)ConfigurationManager.GetSection("trueDialog");
        }

        [ConfigurationProperty("auth", IsRequired = true)]
        internal TrueDialogAuthElement InnerAuthorization
        {
            get { return (TrueDialogAuthElement)this["auth"]; }
            set { this["auth"] = value; }
        }

        /// <summary>
        /// Details on how we should connect to the remote service.
        /// </summary>
        public IAuthConfig Authorization
        {
            get { return InnerAuthorization; }
            set { InnerAuthorization = (TrueDialogAuthElement)value; }
        }

        /// <summary>
        /// The base URL to use.
        /// </summary>
        [ConfigurationProperty("baseUrl", DefaultValue = "https://api.truedialog.com/api/v2.1", IsRequired = false)]
        public string BaseUrl
        {
            get { return (string)this["baseUrl"]; }
            set { this["baseUrl"] = value; }
        }

        /// <summary>
        /// The user agent string to use when sending requests.
        /// </summary>
        [ConfigurationProperty("userAgent", IsRequired = false)]
        public string UserAgent
        {
            get { return (string)this["userAgent"]; }
            set { this["userAgent"] = value; }
        }

        /// <summary>
        /// Timespan to wait before we give up on a request.
        /// </summary>
        /// <remarks>
        /// Default is 2 minutes.
        /// </remarks>
        [ConfigurationProperty("timeout", IsRequired = false, DefaultValue = "0:0:20")]
        public TimeSpan Timeout
        {
            get { return (TimeSpan)this["timeout"]; }
            set { this["timeout"] = value; }
        }
    }
}
