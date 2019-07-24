using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContactSubscriptionContext : BaseContext
    {
        internal ContactSubscriptionContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "account/{accountId}/contact/{contactId}/subscription/{subscriptionId}";
        private const string LIST = "account/{accountId}/contact/{contactId}/subscription";

        public ContactSubscription GetById(int contactId, int subscriptionId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetItem<ContactSubscription>(ITEM, new { accountId = CurrentAccount, contactId, subscriptionId }, throwIfEmpty);
            return rval;
        }

        public List<ContactSubscription> GetList(int contactId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ContactSubscription>(LIST, new { accountId = CurrentAccount, contactId }, throwIfEmpty);
            return rval;
        }
    }
}
