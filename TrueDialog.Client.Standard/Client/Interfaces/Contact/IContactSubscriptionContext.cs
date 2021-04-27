using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContactSubscriptionContext
    {
        ContactSubscription GetById(int accountId, int contactId, int subscriptionId, bool throwIfEmpty = false);

        ContactSubscription GetById(int contactId, int subscriptionId, bool throwIfEmpty = false);

        List<ContactSubscription> GetList(int accountId, int contactId, bool throwIfEmpty = false);

        List<ContactSubscription> GetList(int contactId, bool throwIfEmpty = false);
    }
}
