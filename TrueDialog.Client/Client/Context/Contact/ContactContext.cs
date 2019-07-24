using System;
using System.Collections.Generic;
using System.Net;

using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContactContext : BaseContext
    {
        internal ContactContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "account/{accountId}/contact/{contactId}";
        private const string LIST = "account/{accountId}/contact";
        private const string SEARCH = "account/{accountId}/contact-search";

        #region SubContexts
        public ContactAttributeContext Attribute { get { return GetContext<ContactAttributeContext>(); } }

        public ContactAttributeDefinitionContext AttributeDefinition { get { return GetContext<ContactAttributeDefinitionContext>(); } }

        public ContactSubscriptionContext Subscription { get { return GetContext<ContactSubscriptionContext>(); } }
        #endregion

        public Contact GetById(int accountId, int contactId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Contact>(ITEM, new { accountId, contactId }, throwIfEmpty);
            return rval;
        }

        public Contact GetById(int contactId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactId, throwIfEmpty);
        }

        public List<Contact> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Contact>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<Contact> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public List<Contact> Search(int accountId, string needle)
        {
            var request = TDClient.BuildRequest(RestSharp.Method.POST, SEARCH, new { accountId }, needle);
            var response = TDClient.InnerExecute(request);

            if (response == null)
                return null;

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return new List<Contact>();
            }

            return response.Deserialize<List<Contact>>();
        }

        public List<Contact> Search(string needle)
        {
            return Search(CurrentAccount, needle);
        }

        public Contact Create(int accountId, Contact contact)
        {
            var rval = TDClient.Add(LIST, new { accountId }, contact);
            return rval;
        }

        public Contact Create(Contact contact)
        {
            int accountId = contact.AccountId > 0 ? contact.AccountId : CurrentAccount;
            return Create(accountId, contact);
        }

        public Contact Create(int accountId, string phoneNumber, string email = null, List<ContactAttribute> attributes = null, List<ContactSubscription> subscriptions = null)
        {
            if (string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(email))
                throw new ArgumentException("phoneNumber and email are missing. Need at least one.");

            return Create(accountId, new Contact
            {
                AccountId = CurrentAccount,
                Attributes = attributes ?? new List<ContactAttribute>(),
                Email = email,
                PhoneNumber = Utils.ReadPhoneNumber(phoneNumber),
                Subscriptions = subscriptions ?? new List<ContactSubscription>()
            });
        }

        public Contact Create(string phoneNumber, string email = null, List<ContactAttribute> attributes = null, List<ContactSubscription> subscriptions = null)
        {
            return Create(CurrentAccount, phoneNumber, email, attributes, subscriptions);
        }

        public Contact Update(int accountId, int contactId, Contact contact)
        {
            var rval = TDClient.Update(ITEM, new { accountId, contactId }, contact);
            return rval;
        }

        public Contact Update(int contactId, Contact contact)
        {
            return Update(CurrentAccount, contactId, contact);
        }

        public Contact Update(Contact contact)
        {
            if (contact.Id == 0)
                throw new ArgumentException("Contact ID is missing.");

            int accountId = contact.AccountId > 0 ? contact.AccountId : CurrentAccount;

            return Update(accountId, contact.Id, contact);
        }

        public void Delete(int accountId, int contactId)
        {
            TDClient.Delete(ITEM, new { accountId, contactId });
        }

        public void Delete(int contactId)
        {
            Delete(CurrentAccount, contactId);
        }

        public void Delete(Contact contact)
        {
            if (contact.Id == 0)
                throw new ArgumentException("Contact ID is missing.");

            int accountId = contact.AccountId > 0 ? contact.AccountId : CurrentAccount;
            Delete(accountId, contact.Id);
        }
    }
}
