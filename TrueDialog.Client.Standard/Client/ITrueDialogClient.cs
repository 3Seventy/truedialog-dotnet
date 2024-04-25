namespace TrueDialog
{
    public interface ITrueDialogClient
    {
        void SetAccountId(int accountId);
        
        void SetSource(string source);

        int AccountId { get; }

        #region Contexts

        IAccountContext Account { get; }

        IApiKeyContext ApiKey { get; }

        ICallbackContext Callback { get; }

        ICampaignContext Campaign { get; }

        IChannelContext Channel { get; }

        IChatContext Chat { get; }

        IContactContext Contact { get; }

        IContactListContext ContactList { get; }

        IImportContext Import { get; }

        IKeywordContext Keyword { get; }

        IAccountMediaContext Media { get; }

        IMessageContext Message { get; }

        IReportContext Report { get; }

        IScheduleContext Schedule { get; }

        ISubscriptionContext Subscription { get; }

        IUserContext User { get; }

        #endregion Contexts
    }
}
