using System;
using System.Configuration;
using TrueDialog.Retry;

namespace TrueDialog.Configuration
{
    /// <summary>
    /// Details about the retry policy for errored requests.
    /// </summary>
    public class RetryStrategyElement : ConfigurationElement, IRetryConfig
    {
        private readonly static Type s_retryStrategyType = typeof(RetryStrategy);

        [ConfigurationProperty("enabled", DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)this["enabled"]; }
            set { this["enabled"] = value; }
        }

        /// <summary>
        /// The type of retry policy object to use.
        /// </summary>
        [ConfigurationProperty("type", IsRequired = true)]
        private String TypeName
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        /// <summary>
        /// The type of retry policy object to use.
        /// </summary>
        public Type Type
        {
            get
            {
                Type rval = Type.GetType(TypeName);

                if (rval == null)
                    throw new Exception("Unknown type: " + TypeName);

                if (!s_retryStrategyType.IsAssignableFrom(rval))
                    throw new Exception("Type must be an IRetryPolicy");

                return rval;
            }
            set
            {
                if (!s_retryStrategyType.IsAssignableFrom(value))
                    throw new Exception("Type must be an IRetryPolicy");

                TypeName = value.FullName;
            }
        }

        /// <summary>
        /// The maximum number of times we should attempt to retry the request before giving up.
        /// </summary>
        [ConfigurationProperty("maxTries", DefaultValue = 3)]
        [IntegerValidator(MinValue = 0, MaxValue = 100)]
        public int MaxTries
        {
            get { return (int)this["maxTries"]; }
            set { this["maxTries"] = value; }
        }

        /// <summary>
        /// The minimum allowed value for timeouts.
        /// </summary>
        /// <remarks>
        /// For incremental, and exponential policies this value is the base value.
        /// </remarks>
        [ConfigurationProperty("minInterval", DefaultValue = "0:0:0.5")]
        public TimeSpan MinInterval
        {
            get { return (TimeSpan)this["minInterval"]; }
            set { this["minInterval"] = value; }
        }

        /// <summary>
        /// The maximum allowed value for timeouts.
        /// </summary>
        /// <remarks>
        /// For incremental, and exponential policies this value is the base value.
        /// </remarks>
        [ConfigurationProperty("maxInterval", DefaultValue = "0:0:10")]
        public TimeSpan MaxInterval
        {
            get { return (TimeSpan)this["maxInterval"]; }
            set { this["maxInterval"] = value; }
        }

        /// <summary>
        /// How often (in miliseconds) we should attempt to retry.
        /// </summary>
        /// <remarks>
        /// For incremental, and exponential policies this value is the base value.
        /// </remarks>
        [ConfigurationProperty("interval", IsRequired = true)]
        public TimeSpan Interval
        {
            get { return (TimeSpan)this["interval"]; }
            set { this["interval"] = value; }
        }
    }
}
