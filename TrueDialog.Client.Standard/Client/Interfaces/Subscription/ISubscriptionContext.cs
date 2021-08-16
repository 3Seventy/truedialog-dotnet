using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ISubscriptionContext
    {
        List<Subscription> GetList(int accountId, bool includeChildren = false, bool throwIfEmpty = false);

        List<Subscription> GetList(bool includeChildren = false, bool throwIfEmpty = false);

        Subscription GetById(int accountId, int subscriptionId, bool throwIfEmpty = true);

        Subscription GetById(int subscriptionId, bool throwIfEmpty = true);
    }
}
