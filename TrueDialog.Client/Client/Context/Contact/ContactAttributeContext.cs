using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContactAttributeContext : BaseContext
    {
        internal ContactAttributeContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/contact/{contactId}/attribute";
        private const string ITEM = "/account/{accountId}/contact/{contactId}/attribute/{name}";

        public ContactAttribute GetByName(int accountId, int contactId, string name, bool throwIfEmpty = false)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, ITEM, new { accountId, name });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                if (throwIfEmpty)
                {
                    throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                        typeof(ContactAttribute).Name,
                        request.Resource,
                        response.StatusCode,
                        response.StatusDescription));
                }

                return null;
            }

            return new ContactAttribute
            {
                Name = name,
                AccountId = accountId,
                Value = response.Content
            };
        }

        public ContactAttribute GetByName(int contactId, string name, bool throwIfEmpty = false)
        {
            return GetByName(CurrentAccount, contactId, name, throwIfEmpty);
        }

        public List<ContactAttribute> GetList(int accountId, int contactId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ContactAttribute>(LIST, new { accountId, contactId }, throwIfEmpty);
            return rval;
        }

        public List<ContactAttribute> GetList(int contactId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, contactId, throwIfEmpty);
        }

        public ContactAttribute CreateOrUpdate(int accountId, int contactId, string name, string value)
        {
            IRestRequest request = TDClient.BuildRequest(Method.POST, ITEM, new { accountId, contactId, name }, value);
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<ContactAttribute>(request, response, "create or update");
        }

        public ContactAttribute CreateOrUpdate(int contactId, string name, string value)
        {
            return CreateOrUpdate(CurrentAccount, contactId, name, value);
        }

        public ContactAttribute CreateOrUpdate(int contactId, ContactAttribute attribute)
        {
            string name = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Attribute name is missing.");

            return CreateOrUpdate(CurrentAccount, contactId, name, attribute.Value);
        }

        public ContactAttribute CreateOrUpdate(ContactAttribute attribute)
        {
            if (attribute.ContactId == 0)
                throw new ArgumentException("Contact ID is missing");

            return CreateOrUpdate(attribute.ContactId, attribute);
        }

        public void Delete(int accountId, int contactId, string name)
        {
            TDClient.Delete(ITEM, new { accountId, contactId, name });
        }

        public void Delete(int contactId, string name)
        {
            Delete(CurrentAccount, contactId, name);
        }

        public void Delete(ContactAttribute attribute)
        {
            if (attribute.ContactId == 0)
                throw new ArgumentException("Contact ID is missing.");

            string name = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Attribute name is missing.");

            Delete(attribute.ContactId, name);
        }
    }
}
