using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary />
    public class ContactFilter : Base
    {
        /// <summary>
        /// The ID of account that this filter belongs to.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The group ID this filter falls under
        /// </summary>
        [DataMember]
        public int GroupId { get; set; }

        /// <summary>
        /// The type that we're filtering against.
        /// </summary>
        [DataMember]
        public int FilterTypeId { get; set; }

        /// <summary>
        /// Specific column to filter against.
        /// </summary>
        [DataMember]
        public int OperandId { get; set; }

        /// <summary>
        /// The operator this filter applies to the Operand and the value.
        /// </summary>
        [DataMember]
        public string Operation { get; set; }

        /// <summary>
        /// A function that can be run on an operand.
        /// </summary>
        /// <remarks>
        /// The function will have to run on SQL, and will only be able
        /// to accept just one parameter.  If null, we perform no additional
        /// operation on the column.
        /// </remarks>
        [DataMember]
        public string OperandFunction { get; set; }

        /// <summary>
        /// The target value the operation works on.
        /// </summary>
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// A scripted value for the above.
        /// </summary>
        /// <example>DateAdd(Today(), 0, 0, -1, 0, 0, 0)</example>
        [DataMember]
        public string DynamicValue { get; set; }


        #region Enumeration wrappers

        /// <summary>
        /// Enum wrapper for FilterTypeId
        /// </summary>
        [IgnoreDataMember]
        public FilterType FilterType
        {
            get
            {
                return (FilterType)FilterTypeId;
            }
            set
            {
                FilterTypeId = (int)value;
            }
        }

        /// <summary>
        /// Enum wrapper for OperandId
        /// </summary>
        [IgnoreDataMember]
        public Operand Operand
        {
            get
            {
                return (Operand)OperandId;
            }
            set
            {
                OperandId = (int)value;
            }
        }

        /// <summary>
        /// Enum wrapper for Operation
        /// </summary>
        [IgnoreDataMember]
        public OperationType OperationType
        {
            get
            {
                return OperationValueToEnum(Operation);
            }
            set
            {
                Operation = OperationEnumToValue(value);
            }
        }

        private string OperationEnumToValue(OperationType operationType)
        {
            switch(operationType){
                case OperationType.AllBits: return "allbits";
                case OperationType.AnyBits: return "anybits";
                case OperationType.BeginsWith: return "^";
                case OperationType.EndsWith: return "$";
                case OperationType.Equal: return "=";
                case OperationType.GraterThanOrEqual: return ">=";
                case OperationType.GreaterThan: return ">";
                case OperationType.LessThan: return "<";
                case OperationType.LessThanOrEqual: return "<=";
                case OperationType.Like: return "LIKE";
                case OperationType.NoBits: return "nobits";
                case OperationType.NotEqual: return "<>";
                default: return "";
            }
        }

        private OperationType OperationValueToEnum(string operation)
        {
            switch (operation)
            {
                case "allbits": return OperationType.AllBits;
                case "anybits": return OperationType.AnyBits;
                case "^": return OperationType.BeginsWith;
                case "$": return OperationType.EndsWith;
                case "=": return OperationType.Equal;
                case ">=": return OperationType.GraterThanOrEqual;
                case ">": return OperationType.GreaterThan;
                case "<": return OperationType.LessThan;
                case "<=": return OperationType.LessThanOrEqual;
                case "LIKE": return OperationType.Like;
                case "nobits": return OperationType.NoBits;
                case "<>": return OperationType.NotEqual;
                default: return OperationType.None;
            }
        }

        #endregion
    }
}
