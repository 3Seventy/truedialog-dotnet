using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueDialog.Model
{
    /// <summary>
    /// Api Key type mapping
    /// </summary>
    public enum ApiKeyType
    {
        /// <summary>
        /// Master key.
        /// </summary>
        Master = 1,

        /// <summary>
        /// Regular key.
        /// </summary>
        Common = 2,

        /// <summary>
        /// Temporary key
        /// </summary>
        Temporary = 3
    }
}
