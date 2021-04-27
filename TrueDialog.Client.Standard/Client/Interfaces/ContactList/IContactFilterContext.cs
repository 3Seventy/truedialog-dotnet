using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContactFilterContext
    {
        List<ContactFilter> GetList(int accountId, int contactListId, int groupId, bool throwIfEmpty = true);

        List<ContactFilter> GetList(int contactListId, int groupId, bool throwIfEmpty = true);

        ContactFilter GetById(int accountId, int contactListId, int groupId, int filterId, bool throwIfEmpty = true);

        ContactFilter GetById(int contactListId, int groupId, int filterId, bool throwIfEmpty = true);

        ContactFilter Update(int accountId, int contactListId, int groupId, int filterId, ContactFilter filter);

        ContactFilter Update(int contactListId, ContactFilter filter);
    }
}
