using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IFilterGroupContext
    {
        List<FilterGroup> GetList(int accountId, int contactListId, bool throwIfEmpty = true);

        List<FilterGroup> GetList(int contactListId, bool throwIfEmpty = true);

        FilterGroup GetById(int accountId, int contactListId, int groupId, bool throwIfEmpty = true);

        FilterGroup GetById(int contactListId, int groupId, bool throwIfEmpty = true);
    }
}
