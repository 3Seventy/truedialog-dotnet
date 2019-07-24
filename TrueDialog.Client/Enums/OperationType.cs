using System;

namespace TrueDialog.Model
{
    public enum OperationType
    {
        GreaterThan = 0,
        LessThan = 1,
        GraterThanOrEqual = 2,
        LessThanOrEqual = 3,
        NotEqual = 4,
        Equal = 5,
        Like = 6,
        AnyBits = 7,
        AllBits = 8,
        NoBits = 9,
        BeginsWith = 10,
        EndsWith = 11,
        None = 12
    }
}
