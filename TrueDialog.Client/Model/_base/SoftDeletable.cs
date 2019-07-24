using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Base type for objects that are not removed when delete is called, but rather are placed in a deleted state.
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class SoftDeletable : BaseAudited
    {
        /// <summary>
        /// The current status of the object.
        /// </summary>
        [DataMember]
        public int StatusId { get; internal set; }
        
        /// <summary>
        /// Enumeration wrapper for StatusId
        /// </summary>
        [IgnoreDataMember]
        public ResourceStatus Status
        {
            get { return (ResourceStatus)StatusId; }
        }
    }
}
