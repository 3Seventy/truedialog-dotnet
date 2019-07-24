using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class LongCodeContext : BaseContext
    {
        internal LongCodeContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/long-code/";
        private const string DIRECT_LIST = "account/{accountId}/long-code-direct/";
        private const string FORWARDING = "/account/{accountId}/long-code/{longCode}/callforwarding";
        private const string FORWARDING_VERIFICATION = "account/{accountId}/long-code/{longCode}/callforwardingverification";


        public List<string> GetRawList(int accountId, bool throwIfEmpty = false)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, LIST, new { accountId });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                if (throwIfEmpty)
                {
                    throw new HttpException(string.Format("Empty list response for {0}: {1} {2} {3}",
                        typeof(LongCode).Name,
                        request.Resource,
                        response.StatusCode,
                        response.StatusDescription));
                }

                return new List<string>();
            }

            return response.Deserialize<List<string>>();
        }

        public List<string> GetRawList(bool throwIfEmpty = false)
        {
            return GetRawList(CurrentAccount, throwIfEmpty);
        }

        public List<LongCode> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<LongCode>(DIRECT_LIST, new { accountId }, throwIfEmpty);
            return rval;
        }
        
        public List<LongCode> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public LongCode AddForwarding(int accountId, string longCode, string forwardingNumber)
        {
            IRestRequest request = TDClient.BuildRequest(Method.POST, FORWARDING, 
                new { accountId, longCode = Utils.SoftReadPhoneNumber(longCode) }, new { ForwardingNumber = Utils.ReadPhoneNumber(forwardingNumber) });
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<LongCode>(request, response, "add forwarding");
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

        public LongCode RemoveForwarding(int accountId, string longCode)
        {
            IRestRequest request = TDClient.BuildRequest(Method.DELETE, FORWARDING, new { accountId, longCode = Utils.SoftReadPhoneNumber(longCode) });
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<LongCode>(request, response, "remove forwarding");
        }

        public LongCode RemoveForwarding(string longCode)
        {
            return RemoveForwarding(CurrentAccount, longCode);
        }

        public LongCode RemoveForwarding(LongCode longCode)
        {
            if (string.IsNullOrEmpty(longCode.Code))
                throw new ArgumentException("Long code number is missing.");

            int accountId = longCode.AccountId > 0 ? longCode.AccountId : CurrentAccount;

            return RemoveForwarding(accountId, longCode.Code);
        }

        public LongCode VerifyForwarding(int accountId, string longCode, string verificationCode)
        {
            IRestRequest request = TDClient.BuildRequest(Method.POST, FORWARDING_VERIFICATION, 
                new { accountId, longCode = Utils.SoftReadPhoneNumber(longCode) }, new { VerificationCode = verificationCode });
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<LongCode>(request, response, "verify forwarding");
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
