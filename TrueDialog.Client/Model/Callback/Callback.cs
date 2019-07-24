using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details of a callback the Vector servers will make when an event occurs.
    /// </summary>
    /// <remarks>
    /// Callbacks provide a way to greatly customize the behavior of a campaign.
    /// 
    /// For example, you could attach a keyword to a gateway campaign and then
    /// respond to the keyword callback to define your own campaign logic.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class Callback : Base
    {
        /// <summary>
        /// The account to which this callback will occur.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The type of event which will trigger the callback.
        /// </summary>
        /// <remarks>
        /// Different callback types will send different sets of data.
        /// </remarks>
        [DataMember]
        [JsonProperty("CallbackType")]
        public int CallbackTypeId { get; set; }

        /// <summary>
        /// The URL that will be called back when the callback type event occurs.
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// Set if the callback is currently active.
        /// </summary>
        /// <remarks>
        /// This flag allows you to quickly turn a callback on and off.
        /// </remarks>
        [DataMember]
        public bool Active { get; set; }

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
