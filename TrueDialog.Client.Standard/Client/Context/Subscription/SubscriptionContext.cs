using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class SubscriptionContext : BaseContext, ISubscriptionContext
    {
        internal SubscriptionContext(IApiCaller api) : base(api)
        {
        }

        public List<Subscription> GetList(int accountId, bool includeChildren = false, bool throwIfEmpty = false)
        {
            return Api.Get<List<Subscription>>($"account/{accountId}/subscription?includeChildren={includeChildren}", throwIfEmpty);

        }
        public List<Subscription> GetList(bool includeChildren = false, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, includeChildren, throwIfEmpty);
        }

        public Subscription GetById(int accountId, int subscriptionId, bool throwIfEmpty = true)
        {
            return Api.Get<Subscription>($"account/{accountId}/subscription/{subscriptionId}");
        }

        public Subscription GetById(int subscriptionId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, subscriptionId, throwIfEmpty);
        }
    }
}
