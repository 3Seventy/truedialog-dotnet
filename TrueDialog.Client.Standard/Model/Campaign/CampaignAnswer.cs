using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Campaign question answer definition
    /// </summary>
    public class CampaignAnswer : Base
    {
        /// <summary>
        /// Account question answer belogs to
        /// </summary>
        [IgnoreDataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Campaign question answer belogs to
        /// </summary>
        [IgnoreDataMember]
        public int CampaignId { get; set; }

        [IgnoreDataMember]
        private string m_validator = String.Empty;

        /// <summary>
        /// The next campaign to run in the survey.
        /// </summary>
        [DataMember]
        public int NextCampaignId { get; set; }

        /// <summary>
        /// The ID of the text message content.
        /// </summary>
        [DataMember]
        public int? ContentId { get; set; }

        /// <summary>
        /// The content of the answer.
        /// </summary>
        [DataMember]
        public Content Content { get; set; }

        /// <summary>
        /// A regular expression that is used to validate the user's
        /// response to the answer.
        /// </summary>
        [DataMember]
        public string Validator
        {
            get { return m_validator; }
            set { m_validator = value ?? String.Empty; }
        }

        /// <summary>
        /// A user definable ID to order the answers by on multiple choise questions.
        /// </summary>
        [DataMember]
        public int OrderingId { get; set; }

        /// <summary>
        /// The value that is actually saved when we receive this answer.
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Set to start chat session when we receive this answer.
        /// </summary>
        [DataMember]
        public bool StartChat { get; set; }
        
        /// <summary>
        /// List of accounts (or one account) to start chat session with.
        /// </summary>
        [DataMember]
        public string TargetAccounts { get; set; }
        
        /// <summary>
        /// Set to ignore value if AssignedId already exists
        /// </summary>
        [DataMember]
        public bool OverrideAccountId { get; set; }
        
        /// <summary>
        /// Set to reassign AssignedId to new value
        /// </summary>
        [DataMember]
        public bool ReassignAccountId { get; set; }

        #region UI Stuff

        /// <summary>
        /// The lable to display in the user interface.
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// The description of the answer.
        /// </summary>
        /// <remarks>
        /// Extra field for UI stuff.
        /// </remarks>
        [DataMember]
        public string Description { get; set; }

        #endregion
    }
}
