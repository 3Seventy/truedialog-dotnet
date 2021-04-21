using TrueDialog.Configuration;
using TrueDialog.Model;

namespace TrueDialog
{
    public sealed partial class Client
    {
        private static readonly object m_mutex = new object();
        private static TrueDialogClient m_client;
        private static IConfiguration Configuration;

        public static TrueDialogClient Singleton
        {
            get
            {
                if (m_client == null)
                {
                    lock (m_mutex)
                    {
                        m_client = new TrueDialogClient();
                    }
                }
                return m_client;
            }
        }

        public static void SetConfig(IConfiguration config)
        {
            Configuration = config;
        }

        public static bool Authorize(string username, string password, out UserInfo userInfo)
        {
            var rval = false;
            userInfo = null;

            lock (m_mutex)
            {
                var internalClient = new InternalClient(Configuration, 0, username, password, false);
                try
                {
                    userInfo = internalClient.GetItem<UserInfo>("/userinfo", null);
                    if (userInfo != null)
                    {
                        rval = true;

                        var auth = new TrueDialogAuthElement
                        {
                            AccountId = userInfo.AccountId,
                            ApiKey = userInfo.ApiKey.Key,
                            ApiSecret = userInfo.ApiKey.Secret,
                            UserName = username,
                            Password = password
                        };
                        m_client = new TrueDialogClient(new InternalClient(Configuration, auth));
                    }
                }
                catch (System.Exception)
                {
                    // just ignore
                }
            }

            return rval;
        }
    }
}
