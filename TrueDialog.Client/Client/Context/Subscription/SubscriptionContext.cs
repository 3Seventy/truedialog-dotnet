using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class SubscriptionContext : BaseContext
    {
        internal SubscriptionContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/subscription";
        private const string ITEM = "account/{accountId}/subscription/{subscriptionId}";

        public List<Subscription> GetList(bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Subscription>(LIST, new { accountId = CurrentAccount }, throwIfEmpty);
            return rval;
        }

        public Subscription GetById(int subscriptionId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Subscription>(ITEM, new { accountId = CurrentAccount, subscriptionId }, throwIfEmpty);
            return rval;
        }
    }
}
