namespace TrueDialog.Model
{
    public class ContactLookupOptions
    {
        /// <summary>
        /// Type of value to compare with needle
        /// 0 - All
        /// 1 - Phone Number
        /// 2 - Email
        /// 3 - Chat Name
        /// 4 - Contact Attribute
        /// </summary>
        public int LookupType { get; set; }

        /// <summary>
        /// Needle to search
        /// </summary>
        public string Needle { get; set; }

        /// <summary>
        /// ID of an attribute to compare with needle
        /// Respected with LookupType = 4 ONLY
        /// </summary>
        public int? AttrDefId { get; set; }

        /// <summary>
        /// Count of records to take
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// Count of records to skip
        /// </summary>
        public int Skip { get; set; }
    }
}
