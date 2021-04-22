using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContactAttributeContext
    {
        ContactAttribute GetByName(int accountId, int contactId, string name, bool throwIfEmpty = false);

        ContactAttribute GetByName(int contactId, string name, bool throwIfEmpty = false);

        List<ContactAttribute> GetList(int accountId, int contactId, bool throwIfEmpty = false);

        List<ContactAttribute> GetList(int contactId, bool throwIfEmpty = false);

        ContactAttribute CreateOrUpdate(int accountId, int contactId, string name, string value);

        ContactAttribute CreateOrUpdate(int contactId, string name, string value);

        ContactAttribute CreateOrUpdate(int contactId, ContactAttribute attribute);

        ContactAttribute CreateOrUpdate(ContactAttribute attribute);

        void Delete(int accountId, int contactId, string name);

        void Delete(int contactId, string name);

        void Delete(ContactAttribute attribute);
    }
}
