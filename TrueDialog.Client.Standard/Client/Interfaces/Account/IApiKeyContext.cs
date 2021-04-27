using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IApiKeyContext
    {
        List<ApiKey> GetList(int accountId, bool throwIfEmpty = false);

        List<ApiKey> GetList(bool throwIfEmpty = false);

        ApiKey GetById(int accountId, int keyId, bool throwIfEmpty = false);

        ApiKey GetById(int keyId, bool throwIfEmpty = false);

        ApiKey CreateTemporary(int accountId, string label, DateTime validTo);

        ApiKey CreateTemporary(string label, DateTime validTo);

        ApiKey CreateCommon(int accountId, string label);

        ApiKey CreateCommon(string label);

        ApiKey UpdateSecret(int accountId, int keyId);

        ApiKey UpdateSecret(ApiKey key);

        ApiKey UpdateSecret(int keyId);

        void Revoke(int accountId, int keyId);

        void Revoke(ApiKey key);

        void Revoke(int keyId);
    }
}
