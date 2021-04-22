using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class AccountContext : BaseContext, IAccountContext
    {
        internal AccountContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        #region SubContexts
        public IAccountAttributeContext Attribute { get { return GetContext<AccountAttributeContext>(); } }
        public IAccountAttributeDefinitionContext AttributeDefinition { get { return GetContext<AccountAttributeDefinitionContext>(); } }
        #endregion

        public Account GetById(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<Account>($"/account/${accountId}", throwIfEmpty);
        }

        public Account GetCurrentAccount()
        {
            return GetById(CurrentAccount, true);
        }

        /// <summary>
        /// Get list of all available accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        public List<Account> GetList(bool throwIfEmpty = false)
        {
            return Api.Get<List<Account>>("/account", throwIfEmpty);
        }

        public Account Create(Account account)
        {
            return Api.Post("/account", account);
        }

        public Account Update(Account account)
        {
            return Api.Put($"/account/${account.Id}", account);
        }

        public void Delete(int accountId)
        {
            Api.Delete($"/account/${accountId}");
        }

        public void Delete(Account account)
        {
            Delete(account.Id);
        }
    }
}
