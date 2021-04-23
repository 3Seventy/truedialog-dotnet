using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ApiKeyContext : BaseContext, IApiKeyContext
    {
        internal ApiKeyContext(IApiCaller api) : base(api)
        {
        }

        public List<ApiKey> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ApiKey>>($"/account/{accountId}/api-key", throwIfEmpty);
        }

        public List<ApiKey> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ApiKey GetById(int accountId, int keyId, bool throwIfEmpty = false)
        {
            return Api.Get<ApiKey>($"/account/{accountId}/api-key/{keyId}", throwIfEmpty);
        }

        public ApiKey GetById(int keyId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, keyId, throwIfEmpty);
        }

        private ApiKey Create(int accountId, ApiKey key)
        {
            return Api.Post($"/account/{accountId}/api-key", key);
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
            return Api.Put<ApiKey>($"/account/{accountId}/api-key/{keyId}", null);
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
            Api.Delete($"/account/{accountId}/api-key/{keyId}");
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
