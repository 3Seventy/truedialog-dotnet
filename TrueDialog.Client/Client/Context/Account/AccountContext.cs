using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class AccountContext : BaseContext
    {
        internal AccountContext(InternalClient client) : base(client)
        {
        }

        #region SubContexts
        public AccountAttributeContext Attribute { get { return GetContext<AccountAttributeContext>(); } }
        public AccountAttributeDefinitionContext AttributeDefinition { get { return GetContext<AccountAttributeDefinitionContext>(); } }
        #endregion

        private const string ACCOUNT = "/account/{accountId}";
        private const string ACCOUNT_LIST = "/account";

        public Account GetById(int accountId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Account>(ACCOUNT, new { accountId }, throwIfEmpty);

            return rval;
        }

        public Account GetCurrentAccount(bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, throwIfEmpty);
        }

        /// <summary>
        /// Get list of all available accounts
        /// </summary>
        /// <param name="throwIfEmpty">Set to throw exception on empty response.</param>
        /// <exception cref="System.Web.HttpException">On HTTP error</exception>
        /// <returns>List of accounts</returns>
        public List<Account> GetList(bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Account>(ACCOUNT_LIST, null, throwIfEmpty);
            return rval;
        }

        public Account Create(Account account)
        {
            var rval = TDClient.Add(ACCOUNT_LIST, null, account);
            return rval;
        }

        public Account Update(Account account)
        {
            var rval = TDClient.Update(ACCOUNT, new { accountId = account.Id }, account);
            return rval;
        }

        public void Delete(int accountId)
        {
            TDClient.Delete(ACCOUNT, new { accountId });
        }

        public void Delete(Account account)
        {
            Delete(account.Id);
        }
    }
}
