using System;
using System.Collections.Concurrent;

using System.Reflection;

using TrueDialog.Configuration;
using TrueDialog.Configuration.Config;
using TrueDialog.Context;

namespace TrueDialog
{
    public class TrueDialogClient : ITrueDialogClient
    {
        private readonly IApiCaller m_api;

        public TrueDialogClient()
        {
            m_api = new ApiCaller();
        }

        internal TrueDialogClient(IApiCaller api)
        {
            m_api = api;
        }

        public TrueDialogClient(IConfiguration configuration)
        {
            m_api = new ApiCaller(configuration);
        }

        public TrueDialogClient(int accountId, string username, string password)
        {
            AccountId = accountId;
            m_api = new ApiCaller(new TrueDialogConfig { Authorization = new TrueDialogAuth { UserName = username, Password = password } });
        }

        public int AccountId { get; private set; }

        public void SetAccountId(int accountId)
        {
            AccountId = accountId;
        }

        #region Contexts

        private readonly ConcurrentDictionary<string, BaseContext> m_contextDictionary = new ConcurrentDictionary<string, BaseContext>();
        private readonly object m_mutex = new object();

        internal TContext GetContext<TContext>()
            where TContext : BaseContext
        {
            lock (m_mutex)
            {
                string key = typeof(TContext).Name;
                if (m_contextDictionary.ContainsKey(key))
                    return m_contextDictionary[key] as TContext;
                else
                {
                    var constructor = typeof(TContext).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                        null, new Type[] { typeof(ITrueDialogClient) }, null);
                    var context = (TContext)constructor.Invoke(new object[] { m_api });

                    m_contextDictionary[key] = context;
                    return context;
                }
            }
        }

        public IAccountContext Account { get { return GetContext<AccountContext>(); } }

        public IApiKeyContext ApiKey { get { return GetContext<ApiKeyContext>(); } }

        public ICallbackContext Callback { get { return GetContext<CallbackContext>(); } }

        public ICampaignContext Campaign { get { return GetContext<CampaignContext>(); } }

        public IChannelContext Channel { get { return GetContext<ChannelContext>(); } }

        public IChatContext Chat { get { return GetContext<ChatContext>(); } }

        public IContactContext Contact { get { return GetContext<ContactContext>(); } }

        public IContactListContext ContactList { get { return GetContext<ContactListContext>(); } }

        public IImportContext Import { get { return GetContext<ImportContext>(); } }

        public IKeywordContext Keyword { get { return GetContext<KeywordContext>(); } }

        public IAccountMediaContext Media { get { return GetContext<AccountMediaContext>(); } }

        public IMessageContext Message { get { return GetContext<MessageContext>(); } }

        public IReportContext Report { get { return GetContext<ReportContext>(); } }

        public IScheduleContext Schedule { get { return GetContext<ScheduleContext>(); } }

        public ISubscriptionContext Subscription { get { return GetContext<SubscriptionContext>(); } }

        public IUserContext User { get { return GetContext<UserContext>(); } }

        #endregion
    }
}
