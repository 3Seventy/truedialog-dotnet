using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Used to Execute an Action
    /// </summary>
    [Serializable]
    [DataContract]
    public class ActionExecute : SoftDeletable
    {
        /// <summary>
        /// Account Id
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// Action Id
        /// </summary>
        [DataMember]
        public int ActionId { get; set; }


        /// <summary>
        /// When the Action was started
        /// </summary>
        [DataMember]
        public DateTime Started { get; set; }


        /// <summary>
        /// When the Action was Finished
        /// </summary>
        [DataMember]
        public DateTime Finished { get; set; }

        /// <summary>
        /// Approval status
        /// </summary>
        [DataMember]
        public bool Approved { get; set; }

        /// <summary>
        /// Declined status
        /// </summary>
        [DataMember]
        public bool Declined { get; set; }
    }
}
