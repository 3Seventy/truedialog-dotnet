using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContactFilterContext : BaseContext
    {
        internal ContactFilterContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/contactlist/{contactListId}/group/{groupId}/filter";
        private const string ITEM = "/account/{accountId}/contactlist/{contactListId}/group/{groupId}/filter/{filterId}";

        public List<ContactFilter> GetList(int accountId, int contactListId, int groupId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetList<ContactFilter>(LIST, new { accountId, contactListId, groupId }, throwIfEmpty);
            return rval;
        }

        public List<ContactFilter> GetList(int contactListId, int groupId, bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, contactListId, groupId, throwIfEmpty);
        }

        public ContactFilter GetById(int accountId, int contactListId, int groupId, int filterId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ContactFilter>(ITEM, new { accountId, contactListId, groupId, filterId }, throwIfEmpty);
            return rval;
        }

        public ContactFilter GetById(int contactListId, int groupId, int filterId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactListId, groupId, filterId, throwIfEmpty);
        }

        public ContactFilter Update(int accountId, int contactListId, int groupId, int filterId, ContactFilter filter)
        {
            var rval = TDClient.Update(ITEM, new { accountId, contactListId, groupId, filterId }, filter);
            return rval;
        }

        public ContactFilter Update(int contactListId, ContactFilter filter)
        {
            if (filter.Id == 0)
                throw new ArgumentException("Filter ID is missing.");

            if (filter.GroupId == 0)
                throw new ArgumentException("Filter group ID is missing.");

            int accountId = filter.AccountId > 0 ? filter.AccountId : CurrentAccount;

            return Update(accountId, contactListId, filter.GroupId, filter.Id, filter);
        }
    }
}
