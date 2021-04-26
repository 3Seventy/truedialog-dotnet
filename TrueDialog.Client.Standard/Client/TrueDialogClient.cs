using System;
using System.Collections.Concurrent;

using System.Reflection;
using System.Threading;

using TrueDialog.Configuration;
using TrueDialog.Context;

namespace TrueDialog
{
    public class TrueDialogClient : ITrueDialogClient
    {
        private readonly IApiCaller m_api;

        internal TrueDialogClient(IApiCaller api)
        {
            m_api = api;
        }

        public TrueDialogClient(ITrueDialogConfigProvider configFactory)
        {
            m_api = new ApiCaller(configFactory);
        }

        public int AccountId { get { return m_api.AccountId; } }

        public void SetAccountId(int accountId)
        {
            m_api.AccountId = accountId;
        }

        #region Contexts

        private readonly ConcurrentDictionary<string, BaseContext> m_contextDictionary = new ConcurrentDictionary<string, BaseContext>();
        private readonly SemaphoreSlim m_semaphore = new SemaphoreSlim(1);

        internal TContext GetContext<TContext>()
            where TContext : BaseContext
        {
            try
            {
                m_semaphore.Wait();
                string key = typeof(TContext).Name;
                if (m_contextDictionary.ContainsKey(key))
                    return m_contextDictionary[key] as TContext;
                else
                {
                    var constructor = typeof(TContext).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                        null, new Type[] { typeof(IApiCaller) }, null);
                    var context = (TContext)constructor.Invoke(new object[] { m_api });

                    m_contextDictionary[key] = context;
                    return context;
                }
            }
            finally
            {
                m_semaphore.Release();
            }
        }

        private void CheckAuthenticated()
        {
            if (m_api == null)
                throw new Exception("Not authenticated!");
        }

        public IAccountContext Account { get { CheckAuthenticated(); return GetContext<AccountContext>(); } }

        public IApiKeyContext ApiKey { get { CheckAuthenticated(); return GetContext<ApiKeyContext>(); } }

        public ICallbackContext Callback { get { CheckAuthenticated(); return GetContext<CallbackContext>(); } }

        public ICampaignContext Campaign { get { CheckAuthenticated(); return GetContext<CampaignContext>(); } }

        public IChannelContext Channel { get { CheckAuthenticated(); return GetContext<ChannelContext>(); } }

        public IChatContext Chat { get { CheckAuthenticated(); return GetContext<ChatContext>(); } }

        public IContactContext Contact { get { CheckAuthenticated(); return GetContext<ContactContext>(); } }

        public IContactListContext ContactList { get { CheckAuthenticated(); return GetContext<ContactListContext>(); } }

        public IImportContext Import { get { CheckAuthenticated(); return GetContext<ImportContext>(); } }

        public IKeywordContext Keyword { get { CheckAuthenticated(); return GetContext<KeywordContext>(); } }

        public IAccountMediaContext Media { get { CheckAuthenticated(); return GetContext<AccountMediaContext>(); } }

        public IMessageContext Message { get { CheckAuthenticated(); return GetContext<MessageContext>(); } }

        public IReportContext Report { get { CheckAuthenticated(); return GetContext<ReportContext>(); } }

        public IScheduleContext Schedule { get { CheckAuthenticated(); return GetContext<ScheduleContext>(); } }

        public ISubscriptionContext Subscription { get { CheckAuthenticated(); return GetContext<SubscriptionContext>(); } }

        public IUserContext User { get { CheckAuthenticated(); return GetContext<UserContext>(); } }

        #endregion
    }
}
