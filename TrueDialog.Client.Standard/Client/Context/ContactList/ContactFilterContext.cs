using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContactFilterContext : BaseContext, IContactFilterContext
    {
        internal ContactFilterContext(IApiCaller api) : base(api)
        {
        }

        public List<ContactFilter> GetList(int accountId, int contactListId, int groupId, bool throwIfEmpty = true)
        {
            return Api.Get<List<ContactFilter>>($"account/{accountId}/contactlist/{contactListId}/group/{groupId}/filter", throwIfEmpty);
        }

        public List<ContactFilter> GetList(int contactListId, int groupId, bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, contactListId, groupId, throwIfEmpty);
        }

        public ContactFilter GetById(int accountId, int contactListId, int groupId, int filterId, bool throwIfEmpty = true)
        {
            return Api.Get<ContactFilter>($"account/{accountId}/contactlist/{contactListId}/group/{groupId}/filter/{filterId}", throwIfEmpty);
        }

        public ContactFilter GetById(int contactListId, int groupId, int filterId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contactListId, groupId, filterId, throwIfEmpty);
        }

        public ContactFilter Update(int accountId, int contactListId, int groupId, int filterId, ContactFilter filter)
        {
            return Api.Put($"account/{accountId}/contactlist/{contactListId}/group/{groupId}/filter/{filterId}", filter);
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
