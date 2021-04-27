using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details of survey specific campaign type.
    /// </summary>
    public class CampaignSurvey : BaseAudited
    {
        /// <summary>
        /// The account ID which owns this survey
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Pointer to the campaign which defines the first question of the survey.
        /// </summary>
        [DataMember]
        public int FirstQuestionId { get; set; }
    }
}
