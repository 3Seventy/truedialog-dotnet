using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContactListContext
    {
        #region SubContexts
        IFilterGroupContext FilterGroup { get; }

        IContactFilterContext ContactFilter { get; }
        #endregion

        List<Contact> GetContactsSubscribedTo(int accountId, int contactListId, int subscriptionId, bool throwIfEmpty = false);

        List<Contact> GetContactsSubscribedTo(int contactListId, int subscriptionId, bool throwIfEmpty = false);

        int GetCountSubscribedTo(int accountId, int contactListId, int subscriptionId);

        int GetCountSubscribedTo(int contactListId, int subscriptionId);

        List<Contact> GetTotalContacts(int accountId, int contactListId, bool throwIfEmpty = false);

        List<Contact> GetTotalContact(int contactListId, bool throwIfEmpty = false);

        int GetTotalCount(int accountId, int contactListId);

        int GetTotalCount(int contactListId);

        List<Contact> GetContacts(int accountId, int contactListId, bool throwIfEmpty = false);

        List<Contact> GetContacts(int contactListId, bool throwIfEmpty = false);

        int GetCount(int accountId, int contactListId);

        int GetCount(int contactListId);

        List<ContactList> GetList(int accountId, bool throwIfEmpty = false);

        List<ContactList> GetList(bool throwIfEmpty = false);

        ContactList GetById(int accountId, int contactListId, bool throwIfEmpty = true);

        ContactList GetById(int contactListId, bool throwIfEmpty = true);

        ContactList Create(int accountId, ContactList contactList);

        ContactList Create(ContactList contactList);

        ContactList Update(int accountId, int contactListId, ContactList contactList);

        ContactList Update(int contactListId, ContactList contactList);

        ContactList Update(ContactList contactList);

        void Delete(int accountId, int contactListId);

        void Delete(int contactListId);

        void Delete(ContactList contactList);
    }
}
