using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class SubscriptionContext : BaseContext, ISubscriptionContext
    {
        internal SubscriptionContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public List<Subscription> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Subscription>>($"account/{accountId}/subscription", throwIfEmpty);

        }
        public List<Subscription> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
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
