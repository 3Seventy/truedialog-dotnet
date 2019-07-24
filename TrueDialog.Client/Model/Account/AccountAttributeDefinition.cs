using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Account attribute definition
    /// </summary>
    public class AccountAttributeDefinition : Base
    {
        /// <summary>
        /// The account which defined this attribute.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Attribute definition category
        /// </summary>
        [DataMember]
        public int CategoryId { get; set; }

        /// <summary>
        /// The data type of the attribute
        /// </summary>
        [DataMember]
        public DataType DataType { get; set; }

        /// <summary>
        /// The name of the attribute.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Set if this attribute is inheritable, that is to say that child accounts will get this value from their parents if not directly set.
        /// </summary>
        [DataMember]
        public bool Inheritable { get; set; }

        /// <summary>
        /// Freeform description of the attribute.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
