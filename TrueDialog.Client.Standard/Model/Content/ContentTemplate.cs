using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// A specific template for a given content.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ContentTemplate : BaseAudited
    {
        /// <summary>
        /// The account which owns this template object.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The content to which this template falls under.
        /// </summary>
        [DataMember]
        public int ContentId { get; set; }

        /// <summary>
        /// The language this template is in.
        /// </summary>
        [DataMember]
        public int LanguageId { get; set; }

        /// <summary>
        /// The type of channel this template is intended to be sent on.
        /// </summary>
        [DataMember]
        public int ChannelTypeId { get; set; }

        /// <summary>
        /// The format of the template data.
        /// </summary>
        [DataMember]
        public int EncodingTypeId { get; set; }

        /// <summary>
        /// The actual template
        /// </summary>
        [DataMember]
        public string Template { get; set; }

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
