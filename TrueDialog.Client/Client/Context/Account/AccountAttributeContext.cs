using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Web;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class AccountAttributeContext : BaseContext
    {
        internal AccountAttributeContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/attribute";
        private const string ITEM = "account/{accountId}/attribute/{nameOrId}";

        public AccountAttribute GetById(int accountId, int attributeId, bool throwIfEmpty = true)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, ITEM, new { accountId, nameOrId = attributeId });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                if (throwIfEmpty)
                {
                    throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                        typeof(AccountAttribute).Name,
                        request.Resource,
                        response.StatusCode,
                        response.StatusDescription));
                }

                return null;
            }

            return new AccountAttribute
            {
                Id = attributeId,
                AccountId = accountId,
                Value = response.Content
            };
        }

        public AccountAttribute GetById(int attributeId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, attributeId, throwIfEmpty);
        }

        public AccountAttribute GetByName(int accountId, string attributeName, bool throwIfEmpty = true)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, ITEM, new { accountId, nameOrId = attributeName });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                if (throwIfEmpty)
                {
                    throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                        typeof(AccountAttribute).Name,
                        request.Resource,
                        response.StatusCode,
                        response.StatusDescription));
                }

                return null;
            }

            return new AccountAttribute
            {
                Name = attributeName,
                AccountId = accountId,
                Value = response.Content
            };
        }

        public AccountAttribute GetByName(string attributeName, bool throwIfEmpty = true)
        {
            return GetByName(CurrentAccount, attributeName, throwIfEmpty);
        }

        public List<AccountAttribute> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public List<AccountAttribute> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<AccountAttribute>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public AccountAttribute Create(int accountId, AccountAttribute attribute)
        {
            var nameOrId = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;

            IRestRequest request = TDClient.BuildRequest(Method.POST, ITEM, new { accountId, nameOrId }, attribute.Value);
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<AccountAttribute>(request, response, "add");
        }

        public AccountAttribute Create(AccountAttribute attribute)
        {
            return Create(CurrentAccount, attribute);
        }

        public AccountAttribute Update(AccountAttribute attribute)
        {
            IRestRequest request = TDClient.BuildRequest(Method.PUT, ITEM, new { accountId = attribute.AccountId, nameOrId = attribute.Id }, attribute.Value);
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<AccountAttribute>(request, response, "update");
        }

        public void Delete(int accountId, int attributeId)
        {
            TDClient.Delete(ITEM, new { accountId, nameOrId = attributeId });
        }

        public void Delete(int accountId, string attributeName)
        {
            TDClient.Delete(ITEM, new { accountId, nameOrId = attributeName });
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
