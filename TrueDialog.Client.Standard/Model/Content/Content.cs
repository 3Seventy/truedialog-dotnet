using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Provides a container for a group of templates.
    /// </summary>
    /// <remarks>
    /// Content objects group a set of related templates.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class Content : BaseAudited
    {
        /// <summary>
        /// The account which owns this content object.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The name of this content object.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// A free form description field.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
