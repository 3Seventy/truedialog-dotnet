using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace TrueDialog.Model
{
    /// <summary>
    /// Base details for the data that is sent when a callback is performed.
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class BaseCallbackEvent
    {
        /// <summary>
        /// The account ID which this callback belongs.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The time (in UTC) the callback occurred.
        /// </summary>
        /// <remarks>
        /// This value is sent as a string in the ISO 8601 format.
        /// </remarks>
        /// <example>
        /// 2014-08-21T17:27:30
        /// </example>
        [DataMember]
        [JsonProperty("CallbackTimestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The user supplied GUID.
        /// </summary>
        /// <remarks>
        /// This will be set to the value found in the account's CallbackToken value.
        /// </remarks>
        [DataMember]
        [JsonProperty("CallbackToken")]
        public Guid? AccountCallbackToken { get; set; }

        /// <summary>
        /// The type of callback that is being sent.
        /// </summary>
        /// <remarks>
        /// Normally this would be set to "internal" and not "public", but it 
        /// is likely this class will get deserialized outside of this library.
        /// </remarks>
        [DataMember]
        [JsonProperty("CallbackType")]
        public int CallbackTypeId { get; set; }

        /// <summary>
        /// The URL this callback was sent to.
        /// </summary>
        /// <remarks>
        /// This is for reference
        /// </remarks>
        [DataMember]
        [JsonProperty("CallbackUrl")]
        public string Url { get; set; }

        /// <summary>
        /// A unique ID for this call.
        /// </summary>
        [DataMember]
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Enumeration mapping for CallbackTypeId
        /// </summary>
        [IgnoreDataMember]
        public CallbackType CallbackType
        {
            get { return (CallbackType)CallbackTypeId; }
            set { CallbackTypeId = (int)value; }
        }
    }
}
