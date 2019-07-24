using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary />
    public class FilterGroup : Base
    {
        /// <summary>
        /// The account that owns the group.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The owning contact list of this filter group.
        /// </summary>
        [DataMember]
        public int ContactListId { get; set; }

        /// <summary>
        /// The parent group, if any.  NULL for root groups.
        /// </summary>
        [DataMember]
        public int? ParentId { get; set; }

        /// <summary>
        /// The operation to perform on each child item.
        /// </summary>
        /// <remarks>
        /// Must either be 'AND' or 'OR'
        /// </remarks>
        // TODO: XOR?   ((A or B) AND NOT (A and B))
        [DataMember]
        public string Operator { get; set; }

        /// <summary>
        /// List of sub groups
        /// </summary>
        [DataMember]
        public List<FilterGroup> Groups { get; set; }

        /// <summary>
        /// List of filters directly in this group.
        /// </summary>
        [DataMember]
        public List<ContactFilter> Filters { get; set; }
    }
}
