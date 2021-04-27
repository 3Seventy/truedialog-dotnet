using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Used to Create or Get an Action
    /// </summary>
    [Serializable]
    [DataContract]
    public class Action : SoftDeletable
    {
        /// <summary>
        /// Action Type Id
        /// </summary>
        [DataMember]
        public int TypeId { get; set; }

        /// <summary>
        /// Action Type
        /// </summary>
        [IgnoreDataMember]
        public ActionType ActionType
        {
            get { return (ActionType) TypeId; }
            set { TypeId = (int) value; }
        }

        /// <summary>
        /// Account Id
        /// </summary>
        [DataMember]
        public int AccountId { get; internal set; }
    }
}
