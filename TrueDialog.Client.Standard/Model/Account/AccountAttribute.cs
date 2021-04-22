using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    public class AccountAttribute : Base
    {
        /// <summary>
        /// The ID of the account this attribute is directly set on.
        /// </summary>
        /// <remarks>
        /// Account attributes are inherited, this value can be used to determine which account a value is set on so inheritance and overrides can be easily
        /// tracked.
        /// </remarks>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The name of the attribute
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The value of the attribute
        /// </summary>
        [DataMember]
        public object Value { get; set; }
    }
}
