using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// Link processing type
    /// </summary>
    public enum LinkType
    {
        /// <summary>
        /// Links are static and don't have any dynamic properties.
        /// </summary>
        Static = 0,

        /// <summary>
        /// Links contain some dynamic properties.
        /// </summary>
        Dynamic = 1,
    }
}
