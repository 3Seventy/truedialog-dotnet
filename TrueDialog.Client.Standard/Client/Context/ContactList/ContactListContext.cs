using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContactListContext : BaseContext, IContactListContext
    {
        internal ContactListContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        #region SubContexts
        public IFilterGroupContext FilterGroup { get { return GetContext<FilterGroupContext>(); } }

        public IContactFilterContext ContactFilter { get { return GetContext<ContactFilterContext>(); } }
        #endregion

        public List<Contact> GetContactsSubscribedTo(int accountId, int contactListId, int subscriptionId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Contact>>($"account/{accountId}/contactList/{contactListId}/subscription-execute/{subscriptionId}?getCount=false", throwIfEmpty);
        }

        public List<Contact> GetContactsSubscribedTo(int contactListId, int subscriptionId, bool throwIfEmpty = false)
        {
            return GetContactsSubscribedTo(CurrentAccount, contactListId, subscriptionId, throwIfEmpty);
        }

        public int GetCountSubscribedTo(int accountId, int contactListId, int subscriptionId)
        {
            return Api.Get<int>($"account/{accountId}/contactList/{contactListId}/subscription-execute/{subscriptionId}?getCount=true");
        }

        public int GetCountSubscribedTo(int contactListId, int subscriptionId)
        {
            return GetCountSubscribedTo(CurrentAccount, contactListId, subscriptionId);
        }

        public List<Contact> GetTotalContacts(int accountId, int contactListId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Contact>>($"account/{accountId}/contactList/{contactListId}/subscription-execute?getCount=false", throwIfEmpty);
        }

        public List<Contact> GetTotalContact(int contactListId, bool throwIfEmpty = false)
        {
            return GetTotalContacts(CurrentAccount, contactListId, throwIfEmpty);
        }

        public int GetTotalCount(int accountId, int contactListId)
        {
            return Api.Get<int>($"account/{accountId}/contactList/{contactListId}/subscription-execute?getCount=true");
        }

        public int GetTotalCount(int contactListId)
        {
            return GetTotalCount(CurrentAccount, contactListId);
        }

        public List<Contact> GetContacts(int accountId, int contactListId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Contact>>($"account/{accountId}/contactList/{contactListId}/execute?getCount=false", throwIfEmpty);
        }

        public List<Contact> GetContacts(int contactListId, bool throwIfEmpty = false)
        {
            return GetContacts(CurrentAccount, contactListId, throwIfEmpty);
        }

        public int GetCount(int accountId, int contactListId)
        {
            return Api.Get<int>($"account/{accountId}/contactList/{contactListId}/execute?getCount=true");
        }

        public int GetCount(int contactListId)
        {
            return GetCount(CurrentAccount, contactListId);
        }

        public List<ContactList> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ContactList>>($"account/{accountId}/contactList", throwIfEmpty);
        }

        public List<ContactList> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ContactList GetById(int accountId, int contactListId, bool throwIfEmpty = true)
        {
            return Api.Get<ContactList>($"account/{accountId}/contactList/{contactListId}", throwIfEmpty);
        }

        public ContactList GetById(int contactListId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactListId, throwIfEmpty);
        }

        public ContactList Create(int accountId, ContactList contactList)
        {
            return Api.Post($"account/{accountId}/contactList", contactList);
        }

        public ContactList Create(ContactList contactList)
        {
            int accountId = contactList.Id > 0 ? contactList.Id : CurrentAccount;
            return Create(accountId, contactList);
        }

        public ContactList Update(int accountId, int contactListId, ContactList contactList)
        {
            return Api.Put($"account/{accountId}/contactList/{contactListId}", contactList);
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
            Api.Delete($"account/{accountId}/contactList/{contactListId}");
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
