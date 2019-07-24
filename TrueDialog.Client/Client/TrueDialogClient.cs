using System;
using System.Collections.Concurrent;

using System.Reflection;
using TrueDialog.Context;

namespace TrueDialog
{
    public class TrueDialogClient
    {
        public TrueDialogClient()
        {
            InternalClient = new InternalClient();
        }

        public TrueDialogClient(int accountId)
        {
            InternalClient = new InternalClient(accountId);
        }

        #region Private members
        public void SetAccountId(int accountId)
        {
            InternalClient.SetAccountId(accountId);
        }

        public TrueDialogClient AsAccount(int accountId)
        {
            InternalClient.AsAccount(accountId);
            return this;
        }

        internal InternalClient InternalClient { get; set; }

        #endregion

        #region Contexts

        private readonly ConcurrentDictionary<string, BaseContext> m_contextDictionary = new ConcurrentDictionary<string, BaseContext>();
        private readonly object m_mutex = new object();

        private TContext GetContext<TContext>()
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
                        null, new Type[] { typeof(InternalClient) }, null);
                    var context = (TContext)constructor.Invoke(new object[] { InternalClient });

                    m_contextDictionary[key] = context;
                    return context;
                }
            }
        }

        public AccountContext Account { get { return GetContext<AccountContext>(); } }

        public ApiKeyContext ApiKey { get { return GetContext<ApiKeyContext>(); } }

        public CallbackContext Callback { get { return GetContext<CallbackContext>(); } }

        public CampaignContext Campaign { get { return GetContext<CampaignContext>(); } }

        public ChannelContext Channel { get { return GetContext<ChannelContext>(); } }

        public ContactContext Contact { get { return GetContext<ContactContext>(); } }

        public ContactListContext ContactList { get { return GetContext<ContactListContext>(); } }

        public ImportContext Import { get { return GetContext<ImportContext>(); } }

        public KeywordContext Keyword { get { return GetContext<KeywordContext>(); } }

        public AccountMediaContext Media { get { return GetContext<AccountMediaContext>(); } }

        public MessageContext Message { get { return GetContext<MessageContext>(); } }

        public ReportContext Report { get { return GetContext<ReportContext>(); } }

        public ScheduleContext Schedule { get { return GetContext<ScheduleContext>(); } }

        public SubscriptionContext Subscription { get { return GetContext<SubscriptionContext>(); } }

        public UserContext User { get { return GetContext<UserContext>(); } }

        #endregion
    }
}
