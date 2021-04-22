using System;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Base for (almost) all model classes.
    /// </summary>
    [Serializable]
    [DataContract]
    public abstract class Base
    {
        /// <summary>
        /// Primary key for the model.
        /// </summary>
        [DataMember]
        public int Id { get; set; }
    }
}
