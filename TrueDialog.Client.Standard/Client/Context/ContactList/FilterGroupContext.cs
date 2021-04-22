using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class FilterGroupContext : BaseContext, IFilterGroupContext
    {
        internal FilterGroupContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public List<FilterGroup> GetList(int accountId, int contactListId, bool throwIfEmpty = true)
        {
            return Api.Get<List<FilterGroup>>($"account/{accountId}/contactlist/{contactListId}/group", throwIfEmpty);
        }

        public List<FilterGroup> GetList(int contactListId, bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, contactListId, throwIfEmpty);
        }

        public FilterGroup GetById(int accountId, int contactListId, int groupId, bool throwIfEmpty = true)
        {
            return Api.Get<FilterGroup>($"account/{accountId}/contactlist/{contactListId}/group/{groupId}", throwIfEmpty);
        }

        public FilterGroup GetById(int contactListId, int groupId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactListId, groupId, throwIfEmpty);
        }
    }
}
