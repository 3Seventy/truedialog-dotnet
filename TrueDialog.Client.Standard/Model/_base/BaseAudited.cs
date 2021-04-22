using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Base class for objects with audit information.
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class BaseAudited : Base
    {
        /// <summary>
        /// When this object was first created.
        /// </summary>
        [DataMember]
        public DateTime Created { get; internal set; }

        /// <summary>
        /// When this object was last modified.
        /// </summary>
        [DataMember]
        public DateTime Modified { get; internal set; }

        /// <summary>
        /// Who created this object.
        /// </summary>
        /// <remarks>
        /// Not yet used.
        /// </remarks>
        [DataMember]
        public string CreatedBy { get; internal set; }

        /// <summary>
        /// Who last modified this object
        /// </summary>
        /// <remarks>
        /// Not yet used.
        /// </remarks>
        [DataMember]
        public string ModifiedBy { get; internal set; }
    }
}
