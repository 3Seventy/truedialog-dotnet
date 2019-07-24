using System;

namespace TrueDialog
{
    public sealed partial class Client
    {
        public static TrueDialogClient Singleton { get { return m_client.Value; } }

        private static Lazy<TrueDialogClient> m_client = new Lazy<TrueDialogClient>(() => {
            return new TrueDialogClient();
        });
    }
}
