using System;
using System.Collections.Generic;

using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class LongCodeContext : BaseContext, ILongCodeContext
    {
        internal LongCodeContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public List<string> GetRawList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<string>>($"/account/{accountId}/long-code", throwIfEmpty);
        }

        public List<string> GetRawList(bool throwIfEmpty = false)
        {
            return GetRawList(CurrentAccount, throwIfEmpty);
        }

        public List<LongCode> GetList(int accountId, bool includeChildren = false, bool throwIfEmpty = false)
        {
            return Api.Get<List<LongCode>>($"/account/{accountId}/long-code-direct?includeChildren={includeChildren}", throwIfEmpty);
        }
        
        public List<LongCode> GetList(bool includeChildren = false, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, includeChildren, throwIfEmpty);
        }

        public LongCode AddForwarding(int accountId, string longCode, string forwardingNumber)
        {
            return Api.Post<LongCode>($"/account/{accountId}/long-code/{Utils.SoftReadPhoneNumber(longCode)}/callforwarding",
                new { ForwardingNumber = Utils.ReadPhoneNumber(forwardingNumber) });
        }

        public LongCode AddForwarding(string longCode, string forwardingNumber)
        {
            return AddForwarding(CurrentAccount, longCode, forwardingNumber);
        }

        public LongCode AddForwarding(LongCode longCode, string forwardingNumber)
        {
            if (string.IsNullOrEmpty(longCode.Code))
                throw new ArgumentException("Long code number is missing.");

            return AddForwarding(longCode.Code, forwardingNumber);
        }

        public LongCode UpdateForwarding(int accountId, string longCode, string forwardingNumber)
        {
            return AddForwarding(accountId, longCode, forwardingNumber);
        }

        public LongCode UpdateForwarding(string longCode, string forwardingNumber)
        {
            return AddForwarding(CurrentAccount, longCode, forwardingNumber);
        }

        public LongCode UpdateForwarding(LongCode longCode, string forwardingNumber)
        {
            if (string.IsNullOrEmpty(longCode.Code))
                throw new ArgumentException("Long code number is missing.");

            return AddForwarding(longCode.Code, forwardingNumber);
        }

        public void RemoveForwarding(int accountId, string longCode)
        {
            Api.Delete($"/account/{accountId}/long-code/{Utils.SoftReadPhoneNumber(longCode)}/callforwarding");
        }

        public void RemoveForwarding(string longCode)
        {
            RemoveForwarding(CurrentAccount, longCode);
        }

        public void RemoveForwarding(LongCode longCode)
        {
            if (string.IsNullOrEmpty(longCode.Code))
                throw new ArgumentException("Long code number is missing.");

            int accountId = longCode.AccountId > 0 ? longCode.AccountId : CurrentAccount;

            RemoveForwarding(accountId, longCode.Code);
        }

        public LongCode VerifyForwarding(int accountId, string longCode, string verificationCode)
        {
            return Api.Post<LongCode>($"/account/{accountId}/long-code/{longCode}/callforwardingverification", new { VerificationCode = verificationCode });
        }

        public LongCode VerifyForwarding(string longCode, string verificationCode)
        {
            return VerifyForwarding(CurrentAccount, longCode, verificationCode);
        }

        public LongCode VerifyForwarding(LongCode longCode, string verificationCode)
        {
            if (string.IsNullOrEmpty(longCode.Code))
                throw new ArgumentException("Long code number is missing.");

            int accountId = longCode.AccountId > 0 ? longCode.AccountId : CurrentAccount;

            return VerifyForwarding(accountId, longCode.Code, verificationCode);
        }
    }
}
