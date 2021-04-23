using Newtonsoft.Json;
using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// Api Key details
    /// </summary>
    public class ApiKey : Base
    {
        /// <summary>
        /// User defined identificator
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Api Key (used as username for login)
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// A secret. Used as a login password.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; internal set; }

        /// <summary>
        /// Type of a key
        /// </summary>
        [JsonProperty("typeId")]
        public int TypeId { get; set; }

        /// <summary>
        /// Api key type mapping
        /// </summary>
        [JsonIgnore]
        public ApiKeyType Type
        {
            get { return (ApiKeyType)TypeId; }
            set { TypeId = (int)value; }
        }

        /// <summary>
        /// Optional. A date and time this key is valid to.
        /// Applicable to Temporary keys only.
        /// </summary>
        [JsonProperty("validTo")]
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// A date and time this key was last used.
        /// </summary>
        [JsonProperty("lastActivity")]
        public DateTime LastActivity { get; set; }

        /// <summary>
        /// An account id this key has direct access to.
        /// </summary>
        [JsonProperty("accountId")]
        public int AccountId { get; set; }

        /// <summary>
        /// Username this key belongs to.
        /// Applicable to Master keys only.
        /// </summary>
        [JsonProperty("userName")]
        public string UserName { get; set; }
    }
}
