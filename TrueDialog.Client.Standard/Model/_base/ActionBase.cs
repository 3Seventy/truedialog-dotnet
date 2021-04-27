using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    public class ActionBase : BaseAudited
    {
        public ActionBase()
        {
            Schedules = new List<ActionSchedule>();
        }

        /// <summary>
        /// The account ID that the action reports under.
        /// </summary>
        [DataMember]
        public int AccountId { get; internal set; }

        /// <summary>
        /// The list of schedules associated with the action
        /// </summary>
        [DataMember]
        public List<ActionSchedule> Schedules { get; set; }

        /// <summary>
        /// Set true if the action should be executed on creation
        /// </summary>
        [DataMember]
        public bool Execute { get; set; }
    }
}
