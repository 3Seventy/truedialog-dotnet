using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class AccountAttributeContext : BaseContext, IAccountAttributeContext
    {
        internal AccountAttributeContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public AccountAttribute GetById(int accountId, int attributeId, bool throwIfEmpty = false)
        {
            return GetByName(accountId, attributeId.ToString(), throwIfEmpty);
        }

        public AccountAttribute GetById(int attributeId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, attributeId, throwIfEmpty);
        }

        public AccountAttribute GetByName(int accountId, string attributeName, bool throwIfEmpty = false)
        {
            var response = Api.Get<string>($"account/{accountId}/attribute/${attributeName}", throwIfEmpty);

            return new AccountAttribute
            {
                Name = attributeName,
                AccountId = accountId,
                Value = response
            };
        }

        public AccountAttribute GetByName(string attributeName, bool throwIfEmpty = false)
        {
            return GetByName(CurrentAccount, attributeName, throwIfEmpty);
        }

        public List<AccountAttribute> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public List<AccountAttribute> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<AccountAttribute>>($"/account/{accountId}/attribute", throwIfEmpty);
        }

        public AccountAttribute Create(int accountId, AccountAttribute attribute)
        {
            var nameOrId = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;
            return Api.Post<AccountAttribute>($"/account/{accountId}/attribute/{nameOrId}", attribute.Value);
        }

        public AccountAttribute Create(AccountAttribute attribute)
        {
            return Create(CurrentAccount, attribute);
        }

        public AccountAttribute Update(AccountAttribute attribute)
        {
            var nameOrId = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;
            return Api.Put<AccountAttribute>($"/account/{attribute.AccountId}/attribute/{nameOrId}", attribute.Value);
        }

        public void Delete(int accountId, int attributeId)
        {
            Delete(accountId, attributeId.ToString());
        }

        public void Delete(int accountId, string attributeName)
        {
            Api.Delete($"/account/{accountId}/attribute/{attributeName}");
        }

        public void Delete(AccountAttribute attribute)
        {
            if (attribute.Id > 0)
                Delete(attribute.AccountId, attribute.Id);
            else
                Delete(attribute.AccountId, attribute.Name);
        }

        public void Delete(int attributeId)
        {
            Delete(CurrentAccount, attributeId);
        }

        public void Delete(string attributeName)
        {
            Delete(CurrentAccount, attributeName);
        }
    }
}
