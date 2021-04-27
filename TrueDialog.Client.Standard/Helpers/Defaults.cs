using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TrueDialog
{
    internal sealed class Defaults
    {
        public static string UserAgent { get { return $"TrueDialog SDK.NET {Assembly.GetCallingAssembly().GetName().Version}"; } }

        public static string BaseUrl { get { return "https://api.truedialog.com/api/v2.1/"; } }

        public static int Timeout { get { return 20000; } }
    }
}
