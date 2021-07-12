using System.Threading;

using TrueDialog.Configuration;
using TrueDialog.Model;

namespace TrueDialog
{
    public sealed class Client
    {
        private static TrueDialogClient m_client;

        private static readonly SemaphoreSlim m_semaphore = new SemaphoreSlim(1);

        public static TrueDialogClient Singleton
        {
            get
            {
                if (m_client == null)
                {
                    try
                    {
                        m_semaphore.Wait();

                        if (m_client == null)
                            m_client = new TrueDialogClient(new ClassicTrueDialogConfigProvider());
                    }
                    finally
                    {
                        m_semaphore.Release();
                    }
                }
                return m_client;
            }
        }

        public static bool Authorize(string username, string password, out UserInfo userInfo)
        {
            var rval = false;
            userInfo = null;

            try
            {
                m_semaphore.Wait();

                var api = new ApiCaller(new RawTrueDialogConfigProvider(username, password));

                userInfo = api.AsUser().Get<UserInfo>("userinfo");
                if (userInfo != null)
                {
                    rval = true;

                    var config = new TrueDialogConfig
                    {
                        AccountId = userInfo.AccountId,
                        ApiKey = userInfo.ApiKey.Key,
                        ApiSecret = userInfo.ApiKey.Secret,
                        Username = username,
                        Password = password,
                        BaseUrl = Defaults.BaseUrl,
                        Timeout = Defaults.Timeout,
                        UserAgent = Defaults.UserAgent
                    };
                    m_client = new TrueDialogClient(new ApiCaller(config));
                }
            }
            catch
            {
                // just ignore
            }
            finally
            {
                m_semaphore.Release();
            }

            return rval;
        }
    }
}
