using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// Message log report row
    /// </summary>
    public class MessageReportRow
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Account ID
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Account Name
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Campaign ID
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// True if sent, false if received
        /// </summary>
        public bool Sent { get; set; }

        /// <summary>
        /// When message was sent
        /// </summary>
        public DateTime LogDate { get; set; }

        /// <summary>
        /// Channel name
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// Target phone number
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Contact ID
        /// </summary>
        public int ContactId { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Delivery status ID
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// Action tied to this message
        /// </summary>
        public int ActionId { get; set; }
    }
}
