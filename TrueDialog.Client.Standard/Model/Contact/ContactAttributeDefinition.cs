using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    public class ContactAttributeDefinition : BaseAudited
    {
        /// <summary>
        /// The Account ID that owns this attribute.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The ID of the data type for this attribute.
        /// </summary>
        [DataMember]
        public int DataTypeId { get; set; }

        /// <summary>
        /// Enumeration mapping for DataTypeId
        /// </summary>
        [IgnoreDataMember]
        public DataType DataType 
        {
            get { return (DataType)DataTypeId; }
            set { DataTypeId = (int)value; }
        }

        /// <summary>
        /// The Id of category
        /// </summary>
        [DataMember]
        public int CategoryId { get; internal set; }

        /// <summary>
        /// Name of the attribute definition.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// A full description of this attribute.
        /// </summary>
        [DataMember]
        public string Description { get; set; }
    }
}
