using System;
using System.Collections.Generic;
using System.Net;

using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContactContext : BaseContext, IContactContext
    {
        internal ContactContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        #region SubContexts
        public IContactAttributeContext Attribute { get { return GetContext<ContactAttributeContext>(); } }

        public IContactAttributeDefinitionContext AttributeDefinition { get { return GetContext<ContactAttributeDefinitionContext>(); } }

        public IContactSubscriptionContext Subscription { get { return GetContext<ContactSubscriptionContext>(); } }
        #endregion

        public Contact GetById(int accountId, int contactId, bool throwIfEmpty = true)
        {
            return Api.Get<Contact>($"account/{accountId}/contact/{contactId}", throwIfEmpty);
        }

        public Contact GetById(int contactId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactId, throwIfEmpty);
        }

        public List<Contact> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Contact>>($"account/{accountId}/contact");
        }

        public List<Contact> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public List<Contact> Search(int accountId, string needle)
        {
            return Api.Post<List<Contact>>($"account/{accountId}/contact-search", needle);
        }

        public List<Contact> Search(string needle)
        {
            return Search(CurrentAccount, needle);
        }

        public Contact Create(int accountId, Contact contact)
        {
            return Api.Post($"account/{accountId}/contact", contact);
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
            return Api.Put($"account/{accountId}/contact/{contactId}", contact);
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
            Api.Delete($"account/{accountId}/contact/{contactId}");
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
