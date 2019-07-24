using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContactListContext : BaseContext
    {
        internal ContactListContext(InternalClient client) : base(client)
        {
        }

        #region SubContexts
        public FilterGroupContext FilterGroup { get { return GetContext<FilterGroupContext>(); } }

        public ContactFilterContext ContactFilter { get { return GetContext<ContactFilterContext>(); } }
        #endregion

        private const string LIST = "/account/{accountId}/contactlist";
        private const string ITEM = "/account/{accountId}/contact/{contactListId}";
        private const string EXECUTE = "/account/{accountId}/contactList/{contactListId}/execute?getCount={getCount}";
        private const string EXECUTE_SUBSCRIPTIONLESS = "/account/{accountId}/contactList/{contactListId}/subscription-execute?getCount={getCount}";
        private const string EXECUTE_SUBSCRIPTION = "/account/{accountId}/contactList/{contactListId}/subscription-execute/{subscriptionId}?getCount={getCount}";

        public List<Contact> GetContactsSubscribedTo(int accountId, int contactListId, int subscriptionId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Contact>(EXECUTE_SUBSCRIPTION, new { accountId, contactListId, subscriptionId, getCount = false }, throwIfEmpty);
            return rval;
        }

        public List<Contact> GetContactsSubscribedTo(int contactListId, int subscriptionId, bool throwIfEmpty = false)
        {
            return GetContactsSubscribedTo(CurrentAccount, contactListId, subscriptionId, throwIfEmpty);
        }

        public int GetCountSubscribedTo(int accountId, int contactListId, int subscriptionId)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, EXECUTE_SUBSCRIPTION, new { accountId, contactListId, subscriptionId, getCount = true });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null || response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                    typeof(ContactList).Name,
                    request.Resource,
                    response.StatusCode,
                    response.StatusDescription));
            }

            if (Int32.TryParse(response.Content, out int rval))
                return rval;

            return 0;
        }

        public int GetCountSubscribedTo(int contactListId, int subscriptionId)
        {
            return GetCountSubscribedTo(CurrentAccount, contactListId, subscriptionId);
        }

        public List<Contact> GetTotalContacts(int accountId, int contactListId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Contact>(EXECUTE_SUBSCRIPTIONLESS, new { accountId, contactListId, getCount = false }, throwIfEmpty);
            return rval;
        }

        public List<Contact> GetTotalContact(int contactListId, bool throwIfEmpty = false)
        {
            return GetTotalContacts(CurrentAccount, contactListId, throwIfEmpty);
        }

        public int GetTotalCount(int accountId, int contactListId)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, EXECUTE_SUBSCRIPTIONLESS, new { accountId, contactListId, getCount = true });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null || response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                    typeof(ContactList).Name,
                    request.Resource,
                    response.StatusCode,
                    response.StatusDescription));
            }

            if (Int32.TryParse(response.Content, out int rval))
                return rval;

            return 0;
        }

        public int GetTotalCount(int contactListId)
        {
            return GetTotalCount(CurrentAccount, contactListId);
        }

        public List<Contact> GetContacts(int accountId, int contactListId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Contact>(EXECUTE, new { accountId, contactListId, getCount = false }, throwIfEmpty);
            return rval;
        }

        public List<Contact> GetContacts(int contactListId, bool throwIfEmpty = false)
        {
            return GetContacts(CurrentAccount, contactListId, throwIfEmpty);
        }

        public int GetCount(int accountId, int contactListId)
        {
            IRestRequest request = TDClient.BuildRequest(Method.GET, EXECUTE, new { accountId, contactListId, getCount = true });
            IRestResponse response = TDClient.InnerExecute(request);

            if (response == null || response.StatusCode == HttpStatusCode.NoContent)
            {
                throw new HttpException(string.Format("Empty response for {0}: {1} {2} {3}",
                    typeof(ContactList).Name,
                    request.Resource,
                    response.StatusCode,
                    response.StatusDescription));
            }

            if (Int32.TryParse(response.Content, out int rval))
                return rval;

            return 0;
        }

        public int GetCount(int contactListId)
        {
            return GetCount(CurrentAccount, contactListId);
        }

        public List<ContactList> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ContactList>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<ContactList> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ContactList GetById(int accountId, int contactListId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ContactList>(ITEM, new { accountId, contactListId }, throwIfEmpty);
            return rval;
        }

        public ContactList GetById(int contactListId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactListId, throwIfEmpty);
        }

        public ContactList Create(int accountId, ContactList contactList)
        {
            var rval = TDClient.Add(LIST, new { accountId }, contactList);
            return rval;
        }

        public ContactList Create(ContactList contactList)
        {
            int accountId = contactList.Id > 0 ? contactList.Id : CurrentAccount;
            return Create(accountId, contactList);
        }

        public ContactList Update(int accountId, int contactListId, ContactList contactList)
        {
            var rval = TDClient.Update(ITEM, new { accountId, contactListId }, contactList);
            return rval;
        }

        public ContactList Update(int contactListId, ContactList contactList)
        {
            int accountId = contactList.Id > 0 ? contactList.Id : CurrentAccount;
            return Update(accountId, contactListId, contactList);
        }

        public ContactList Update(ContactList contactList)
        {
            if (contactList.Id == 0)
                throw new ArgumentException("Contact list ID is missing.");
            int accountId = contactList.Id > 0 ? contactList.Id : CurrentAccount;

            return Update(accountId, contactList.Id, contactList);
        }

        public void Delete(int accountId, int contactListId)
        {
            TDClient.Delete(ITEM, new { accountId, contactListId });
        }

        public void Delete(int contactListId)
        {
            Delete(CurrentAccount, contactListId);
        }

        public void Delete(ContactList contactList)
        {
            if (contactList.Id == 0)
                throw new ArgumentException("Contact list ID is missing.");
            int accountId = contactList.Id > 0 ? contactList.Id : CurrentAccount;
            Delete(accountId, contactList.Id);
        }
    }
}
