using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ImportContext : BaseContext
    {
        internal ImportContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/action-importContacts";
        private const string ITEM = "account/{accountId}/action-importContacts/{actionId}";

        public List<ActionImportContacts> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ActionImportContacts>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<ActionImportContacts> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ActionImportContacts GetById(int accountId, int actionId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ActionImportContacts>(ITEM, new { accountId, actionId }, throwIfEmpty);
            return rval;
        }

        public ActionImportContacts GetById(int actionId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, actionId, throwIfEmpty);
        }

        public ActionImportContacts Create(int accountId, ActionImportContacts action)
        {
            var rval = TDClient.Add(LIST, new { accountId }, action);
            return rval;
        }

        public ActionImportContacts Create(ActionImportContacts action)
        {
            return Create(CurrentAccount, action);
        }

        public ActionImportContacts Import(int accountId, string url, List<ContactSubscription> subscriptions = null)
        {
            return Create(accountId, new ActionImportContacts
            {
                Url = url,
                Subscriptions = subscriptions,
                Execute = true
            });
        }

        public ActionImportContacts Import(string url, List<ContactSubscription> subscriptions = null)
        {
            return Create(CurrentAccount, new ActionImportContacts
            {
                Url = url,
                Subscriptions = subscriptions,
                Execute = true
            });
        }

        public void Stop(int accountId, int actionId)
        {
            TDClient.Delete(ITEM, new { accountId, actionId });
        }

        public void Stop(int actionId)
        {
            Stop(CurrentAccount, actionId);
        }
    }
}
