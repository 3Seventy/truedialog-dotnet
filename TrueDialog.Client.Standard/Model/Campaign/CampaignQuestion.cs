using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Campaign question
    /// </summary>
    public class CampaignQuestion : Base
    {
        [IgnoreDataMember]
        private IEnumerable<CampaignAnswer> m_answers = new List<CampaignAnswer>();

        /// <summary>
        /// The account which owns the campaign.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The survey this question belongs to.
        /// </summary>
        [DataMember]
        public int SurveyId { get; set; }

        /// <summary>
        /// The question's response type.
        /// </summary>
        [DataMember]
        public int QuestionTypeId { get; set; }

        /// <summary>
        /// Enumeration mapping for QuestionTypeId
        /// </summary>
        [IgnoreDataMember]
        public QuestionType QuestionType
        {
            get { return (QuestionType)QuestionTypeId; }
            set { QuestionTypeId = (int)value; }
        }

        /// <summary>
        /// The contact attribute that answers should be stored in.
        /// </summary>
        [DataMember]
        public int ContactAttributeDefinitionId { get; set; }

        /// <summary>
        /// A list of answers for this question. (OPTIONAL)
        /// </summary>
        [DataMember]
        public IEnumerable<CampaignAnswer> Answers
        {
            get { return m_answers; }
            set { m_answers = value ?? new List<CampaignAnswer>(); }
        }

        #region UI Stuff

        /// <summary>
        /// The label for the question in the UI
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// The description of the question.
        /// </summary>
        /// <remarks>
        /// Extra field for UI stuff.
        /// </remarks>
        [DataMember]
        public string Description { get; set; }

        #endregion
    }
}
