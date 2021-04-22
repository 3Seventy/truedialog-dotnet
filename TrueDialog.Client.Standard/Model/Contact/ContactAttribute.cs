using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// User defined attribute data.
    /// </summary>
    /// <remarks>
    /// Contact attributes provide a way to save data to contacts via the API or a Dialog.
    /// 
    /// Attributes must be defined defined before they can be used.
    /// 
    /// TODO: Add contact attribute defintion support.
    /// 
    /// The name of the attribute must be unique, and must follow standard programming naming
    /// conventions (must start with an underscore or letter, followed by letters, numbers, and underscores)
    /// 
    /// Child accounts inherit those attribute definitions defined by their parent.
    /// </remarks>
    [Serializable]
    [DataContract]
    public class ContactAttribute : Base
    {
        /// <summary>
        /// The account which the contact is owned by
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The contact to which the property belongs.
        /// </summary>
        [DataMember]
        public int ContactId { get; set; }

        /// <summary>
        /// The name of the attribute that is set.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// The value set for this attribute.
        /// </summary>
        [DataMember]
        public string Value { get; set; }
    }
}
