using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class CampaignReportRow
    {
        /// <summary>
        /// Account ID
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Campaign ID
        /// </summary>
        public int CampaignId { get; set; }

        /// <summary>
        /// Campaign Name
        /// </summary>
        public string CampaignName { get; set; }

        /// <summary>
        /// Campaign created date
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Campaign type
        /// </summary>
        public int CampaignTypeId { get; set; }

        /// <summary>
        /// Count of delivered messages
        /// </summary>
        public long Delivered { get; set; }

        /// <summary>
        /// Count of undelivered messages
        /// </summary>
        public long Undelivered { get; set; }

        /// <summary>
        /// Count of unknown messages
        /// </summary>
        public long Unknown { get; set; }

        /// <summary>
        /// Count of clicks
        /// </summary>
        public int Clicks { get; set; }

        /// <summary>
        /// Count of total messages sent
        /// </summary>
        public long TotalSent { get; set; }

        /// <summary>
        /// Count of total messages received
        /// </summary>
        public long TotalReceived { get; set; }
    }
}
