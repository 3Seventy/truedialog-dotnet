using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for creating or updating a template
    /// </summary>
    internal class CreateUpdateContentTemplate
    {
        /// <summary>
        /// The language this template is for.
        /// </summary>
        [DataMember]
        public int LanguageId { get; set; }

        /// <summary>
        /// The type of channel this content can be sent to.
        /// </summary>
        [DataMember]
        public int ChannelTypeId { get; set; }

        /// <summary>
        /// The format of the tempalte data
        /// </summary>
        /// <remarks>
        /// Dictates if this is a plain text or razor template
        /// </remarks>
        [DataMember]
        public int EncodingTypeId { get; set; }

        /// <summary>
        /// The actual template
        /// </summary>
        [DataMember]
        public string Template { get; set; }

        /// <summary>
        /// Email subject if any
        /// </summary>
        [DataMember]
        public string Subject { get; set; }

        /// <summary>
        /// Email from address if any
        /// </summary>
        [DataMember]
        public string From { get; set; }

        /// <summary>
        /// ID of media to send
        /// </summary>
        [DataMember]
        public int? MediaId { get; set; }

        #region Enumeration Aliases

        /// <summary>
        /// Enumeration wrapper for LanguageTypeId
        /// </summary>
        [IgnoreDataMember]
        public LanguageType LanguageType
        {
            get { return (LanguageType)LanguageId; }
            set { LanguageId = (int)value; }
        }

        /// <summary>
        /// Enumeration wrapper for ChannelTypeId
        /// </summary>
        [IgnoreDataMember]
        public ChannelType ChannelType
        {
            get { return (ChannelType)ChannelTypeId; }
            set { ChannelTypeId = (int)value; }
        }

        /// <summary>
        /// Enumeration wrapper for EncodingTypeId
        /// </summary>
        [IgnoreDataMember]
        public EncodingType EncodingType
        {
            get { return (EncodingType)EncodingTypeId; }
            set { EncodingTypeId = (int)value; }
        }

        #endregion Enumeration Aliases
    }
}
