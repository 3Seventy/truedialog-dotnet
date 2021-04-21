using System;

namespace TrueDialog.Configuration.Config
{
    public class TrueDialogRetry : IRetryConfig
    {
        public bool Enabled { get; set; }
        public Type Type { get; set; }
        public int MaxTries { get; set; }
        public TimeSpan MinInterval { get; set; }
        public TimeSpan MaxInterval { get; set; }
        public TimeSpan Interval { get; set; }

        public static TrueDialogRetry Default
        {
            get
            {
                return new TrueDialogRetry
                {
                    Enabled = true,
                    Type = typeof(Retry.Strategy.FixedRetryStrategy),
                    Interval = TimeSpan.FromSeconds(1),
                    MaxTries = 3
                };
            }
        }
    }
}
