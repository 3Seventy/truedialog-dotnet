using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Account attribute category details.
    /// </summary>
    public class AccountAttributeCategory : Base
    {
        /// <summary>
        /// The name of this category.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The description of this category.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
