using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContactSubscriptionContext : BaseContext, IContactSubscriptionContext
    {
        internal ContactSubscriptionContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public ContactSubscription GetById(int accountId, int contactId, int subscriptionId, bool throwIfEmpty = false)
        {
            return Api.Get<ContactSubscription>($"account/{accountId}/contact/{contactId}/subscription/{subscriptionId}", throwIfEmpty);
        }

        public ContactSubscription GetById(int contactId, int subscriptionId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, contactId, subscriptionId, throwIfEmpty);
        }

        public List<ContactSubscription> GetList(int accountId, int contactId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ContactSubscription>>($"account/{accountId}/contact/{contactId}/subscription", throwIfEmpty);
        }

        public List<ContactSubscription> GetList(int contactId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, contactId, throwIfEmpty);
        }
    }
}
