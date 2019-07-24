using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    public class Channel : Base
    {
        /// <summary>
        /// The account that the channels belongs to.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Set if we can send handset verifications on.
        /// </summary>
        [DataMember]
        public bool AllowVerify { get; set; }

        /// <summary>
        /// Enumeration mapping for ChannelTypeId
        /// </summary>
        [IgnoreDataMember]
        public ChannelType ChannelType { get; set; }

        /// <summary>
        /// The default language type for a channel.
        /// </summary>
        [IgnoreDataMember]
        public LanguageType DefaultLanguage { get; set; }

        /// <summary>
        /// The default language type for a channel.
        /// </summary>
        [DataMember]
        public int DefaultLanguageId { get; set; }
        
        /// <summary />
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Set if the channel is currently active and running.
        /// </summary>
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Set if the channel supports MMS.
        /// </summary>
        [DataMember]
        public bool IsMediaEnabled { get; set; }
        
        /// <summary />
        [DataMember]
        public string Label { get; set; }

        /// <summary/>
        [DataMember]
        public string Name { get; set; }
        
        /// <summary>
        /// Set if this channel uses long codes or not.
        /// </summary>
        /// <remarks>
        /// Used to find out if we should pull a list of long codes when we push to the
        /// channel ID or name instead of a specific long code.
        /// </remarks>
        [DataMember]
        public bool UseLongCodes { get; set; }
    }
}
