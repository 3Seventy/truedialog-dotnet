using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class FilterGroupContext : BaseContext
    {
        internal FilterGroupContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/contactlist/{contactListId}/group";
        private const string ITEM = "/account/{accountId}/contactlist/{contactListId}/group/{groupId}";

        public List<FilterGroup> GetList(int accountId, int contactListId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetList<FilterGroup>(LIST, new { accountId, contactListId }, throwIfEmpty);
            return rval;
        }

        public List<FilterGroup> GetList(int contactListId, bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, contactListId, throwIfEmpty);
        }

        public FilterGroup GetById(int accountId, int contactListId, int groupId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<FilterGroup>(ITEM, new { accountId, contactListId, groupId }, throwIfEmpty);
            return rval;
        }

        public FilterGroup GetById(int contactListId, int groupId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactListId, groupId, throwIfEmpty);
        }
    }
}
