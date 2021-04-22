using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary>
    /// Details for an error message returned by the HTTP endpoints.
    /// </summary>
    [Serializable]
    [DataContract]
    public class ErrorDetail
    {
        /// <summary>
        /// A generic error code for looking up the details.  Useful for i18n.
        /// </summary>
        [IgnoreDataMember]
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Integer version of the above to better support (de)serialization.
        /// </summary>
        [DataMember]
        public UInt32 ErrorCodeId
        {
            get { return (UInt32)ErrorCode; }
            set { ErrorCode = (ErrorCode)value; }
        }

        /// <summary>
        /// A basic error message to use if looking up by error code does not succeed.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// The type of object that was being validated.
        /// </summary>
        [DataMember]
        public string ObjectType { get; set; }

        /// <summary>
        /// Details the property name that the error specifically applies to.
        /// This can be NULL if the error does not apply to any one property or no properties at all.
        /// </summary>
        [DataMember]
        public string PropertyName { get; set; }
    }
}
