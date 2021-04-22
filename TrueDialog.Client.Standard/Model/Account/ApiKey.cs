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
        public string Label { get; set; }

        /// <summary>
        /// Api Key (used as username for login)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// A secret. Used as a login password.
        /// </summary>
        public string Secret { get; internal set; }

        /// <summary>
        /// Type of a key
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Api key type mapping
        /// </summary>
        public ApiKeyType Type
        {
            get { return (ApiKeyType)TypeId; }
            set { TypeId = (int)value; }
        }

        /// <summary>
        /// Optional. A date and time this key is valid to.
        /// Applicable to Temporary keys only.
        /// </summary>
        public DateTime? ValidTo { get; set; }

        /// <summary>
        /// A date and time this key was last used.
        /// </summary>
        public DateTime LastActivity { get; set; }

        /// <summary>
        /// An account id this key has direct access to.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Username this key belongs to.
        /// Applicable to Master keys only.
        /// </summary>
        public string UserName { get; set; }
    }
}
