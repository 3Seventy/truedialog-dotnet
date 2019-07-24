using System;
using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ApiKeyContext : BaseContext
    {
        internal ApiKeyContext(InternalClient client) : base(client, true)
        {
        }

        private const string LIST = "account/{accountId}/api-key";
        private const string ITEM = "account/{accountId}/api-key/{keyId}";

        public List<ApiKey> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ApiKey>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<ApiKey> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ApiKey GetById(int accountId, int keyId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ApiKey>(ITEM, new { accountId, keyId }, throwIfEmpty);
            return rval;
        }

        public ApiKey GetById(int keyId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, keyId, throwIfEmpty);
        }

        private ApiKey Create(int accountId, ApiKey key)
        {
            var rval = TDClient.Add(LIST, new { accountId }, key);
            return rval;
        }

        public ApiKey CreateTemporary(int accountId, string label, DateTime validTo)
        {
            return Create(accountId, new ApiKey
            {
                Label = label,
                Type = ApiKeyType.Temporary,
                ValidTo = validTo
            });
        }

        public ApiKey CreateTemporary(string label, DateTime validTo)
        {
            return CreateTemporary(CurrentAccount, label, validTo);
        }

        public ApiKey CreateCommon(int accountId, string label)
        {
            return Create(accountId, new ApiKey
            {
                Label = label,
                Type = ApiKeyType.Common
            });
        }

        public ApiKey CreateCommon(string label)
        {
            return CreateCommon(CurrentAccount, label);
        }

        public ApiKey UpdateSecret(int accountId, int keyId)
        {
            var rval = TDClient.Update<ApiKey>(ITEM, new { accountId, keyId }, null);
            return rval;
        }

        public ApiKey UpdateSecret(ApiKey key)
        {
            return UpdateSecret(key.AccountId, key.Id);
        }

        public ApiKey UpdateSecret(int keyId)
        {
            return UpdateSecret(CurrentAccount, keyId);
        }

        public void Revoke(int accountId, int keyId)
        {
            TDClient.Delete(ITEM, new { accountId, keyId });
        }

        public void Revoke(ApiKey key)
        {
            Revoke(key.AccountId, key.Id);
        }

        public void Revoke(int keyId)
        {
            Revoke(CurrentAccount, keyId);
        }
    }
}
