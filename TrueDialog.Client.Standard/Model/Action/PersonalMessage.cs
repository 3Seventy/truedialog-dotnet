using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    [DataContract]
    [Serializable]
    public class PersonalMessage
    {
        [DataMember]
        public string Target { get; set; }

        [DataMember]
        public string Message { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PersonalMessage message &&
                   Target == message.Target &&
                   Message == message.Message;
        }

        public override int GetHashCode()
        {
            int hashCode = -1268511956;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Target);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            return hashCode;
        }
    }
}
