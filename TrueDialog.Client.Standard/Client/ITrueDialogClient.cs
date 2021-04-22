using TrueDialog.Model;

namespace TrueDialog
{
    public interface ITrueDialogClient
    {
        void SetAccountId(int accountId);

        int AccountId { get; }

        void Authorize(string username, string password);

        bool Authorize(string username, string password, out UserInfo user);

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
