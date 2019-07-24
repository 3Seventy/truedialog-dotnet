using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Contact attribute category details.
    /// </summary>
    public class ContactAttributeCategory : Base
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
