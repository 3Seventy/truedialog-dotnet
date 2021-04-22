using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ImportContext : BaseContext, IImportContext
    {
        internal ImportContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public List<ActionImportContacts> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ActionImportContacts>>($"/account/{accountId}/action-importContacts", throwIfEmpty);
        }

        public List<ActionImportContacts> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ActionImportContacts GetById(int accountId, int actionId, bool throwIfEmpty = false)
        {
            return Api.Get<ActionImportContacts>($"/account/{accountId}/action-importContacts/{actionId}", throwIfEmpty);
        }

        public ActionImportContacts GetById(int actionId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, actionId, throwIfEmpty);
        }

        public ActionImportContacts Create(int accountId, ActionImportContacts action)
        {
            return Api.Post($"/account/{accountId}/action-importContacts", action);
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
            Api.Delete($"/account/{accountId}/action-importContacts/{actionId}");
        }

        public void Stop(int actionId)
        {
            Stop(CurrentAccount, actionId);
        }
    }
}
