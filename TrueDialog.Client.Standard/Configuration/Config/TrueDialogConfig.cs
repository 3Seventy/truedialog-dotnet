using System;
using System.Reflection;

namespace TrueDialog.Configuration.Config
{
    public class TrueDialogConfig
    {
        public IAuthConfig Authorization { get; set; }

        public string BaseUrl { get; set; }

        public string UserAgent { get; set; }

        public TimeSpan Timeout { get; set; }

        public IRetryConfig RetryPolicy { get; set; }

        public static TrueDialogConfig Default
        {
            get
            {
                Assembly thisAssembly = Assembly.GetCallingAssembly();
                AssemblyName asmName = thisAssembly.GetName();
                var version = asmName.Version.ToString();

                return new TrueDialogConfig
                {
                    BaseUrl = "https://api.truedialog.com/api/v2.1",
                    UserAgent = String.Format("TrueDialog SDK.NET {0}", version),
                    Timeout = TimeSpan.FromSeconds(20),
                    RetryPolicy = TrueDialogRetry.Default,
                    Authorization = TrueDialogAuth.Empty
                };
            }
        }
    }
}
