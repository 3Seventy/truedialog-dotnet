using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICallbackContext
    {
        Account EnableCallbacks(int accountId);

        Account DisableCallbacks(int accountId);

        List<Callback> GetList(int accountId, bool throwIfEmpty = false);

        List<Callback> GetList(bool throwIfEmpty = false);

        Callback GetById(int accountId, int callbackId, bool throwIfEmpty = true);

        Callback GetById(int callbackId, bool throwIfEmpty = true);

        Callback Create(int accountId, Callback callback);

        Callback Create(Callback callback);

        Callback Create(int accountId, CallbackType type, string url);

        Callback Create(CallbackType type, string url);

        Callback Update(int accountId, int callbackId, Callback callback);

        Callback Update(int callbackId, Callback callback);

        Callback UpdateUrl(int accountId, int callbackId, string newUrl);

        Callback UpdateUrl(int callbackId, string newUrl);

        void Delete(int accountId, int callbackId);

        void Delete(int callbackId);

        void Delete(Callback callback);
    }
}
