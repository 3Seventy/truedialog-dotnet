using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IImportContext
    {
        List<ActionImportContacts> GetList(int accountId, bool throwIfEmpty = false);

        List<ActionImportContacts> GetList(bool throwIfEmpty = false);

        ActionImportContacts GetById(int accountId, int actionId, bool throwIfEmpty = false);

        ActionImportContacts GetById(int actionId, bool throwIfEmpty = false);

        ActionImportContacts Create(int accountId, ActionImportContacts action);

        ActionImportContacts Create(ActionImportContacts action);

        ActionImportContacts Import(int accountId, string url, List<ContactSubscription> subscriptions = null);

        ActionImportContacts Import(string url, List<ContactSubscription> subscriptions = null);

        void Stop(int accountId, int actionId);

        void Stop(int actionId);
    }
}
