using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for a long code
    /// </summary>
    public class LongCode : SoftDeletable
    {
        /// <summary>
        /// The account which owns this long code.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The channel which handles this long code.
        /// </summary>
        [DataMember]
        public int ChannelId { get; set; }

        /// <summary>
        /// The ANI for this long code.
        /// </summary>
        [DataMember]
        public string Code { get; set; }

        /// <summary>
        /// Call Forwarding number
        /// </summary>
        [DataMember]
        public string ForwardNumber { get; internal set; }

        /// <summary>
        /// Random 6 digit Code that is sent in order to verify forwarding number
        /// </summary>
        [DataMember]
        public string ForwardVerificationCode { get; internal set; }

        /// <summary>
        /// Status of call forwarding
        /// </summary>
        [DataMember]
        public int? ForwardStatus { get; internal set; }
    }
}
