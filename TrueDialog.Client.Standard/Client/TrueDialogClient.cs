using System;

using TrueDialog.Configuration;
using TrueDialog.Context;

namespace TrueDialog
{
    public class TrueDialogClient : ITrueDialogClient
    {
        private readonly IApiCaller m_api;
        private readonly ContextBuilder m_contextBuilder;

        internal TrueDialogClient(IApiCaller api)
        {
            m_api = api;
            m_contextBuilder = new ContextBuilder(api);
        }

        public TrueDialogClient(ITrueDialogConfigProvider configFactory)
            : this(new ApiCaller(configFactory))
        {
        }

        public TrueDialogClient(string username, string password)
            : this(new ApiCaller(new TrueDialogConfig { Username = username, Password = password }))
        {
        }

        public TrueDialogClient(string apiKey, string apiSecret, int accountId)
            : this(new ApiCaller(new TrueDialogConfig { ApiKey = apiKey, ApiSecret = apiSecret, AccountId = accountId }))
        {
        }

        public int AccountId { get { return m_api.AccountId; } }

        public void SetAccountId(int accountId)
        {
            m_api.AccountId = accountId;
        }

        #region Contexts

        internal TContext GetContext<TContext>()
            where TContext : BaseContext
        {
            CheckAuthenticated();
            return m_contextBuilder.GetContext<TContext>();
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
