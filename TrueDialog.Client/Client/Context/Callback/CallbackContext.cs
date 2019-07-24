using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CallbackContext : BaseContext
    {
        internal CallbackContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/callback";
        private const string ITEM = "/account/{accountId}/callback/{callbackId}";
        
        public List<Callback> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Callback>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<Callback> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public Callback GetById(int accountId, int callbackId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Callback>(ITEM, new { accountId, callbackId }, throwIfEmpty);
            return rval;
        }

        public Callback GetById(int callbackId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, callbackId, throwIfEmpty);
        }

        public Callback Create(int accountId, Callback callback)
        {
            var rval = TDClient.Add(LIST, new { accountId }, callback);
            return rval;
        }

        public Callback Create(Callback callback)
        {
            return Create(CurrentAccount, callback);
        }

        public Callback Create(int accountId, CallbackType type, string url)
        {
            return Create(accountId, new Callback
            {
                CallbackType = type,
                Url = url,
                Active = true
            });
        }

        public Callback Create(CallbackType type, string url)
        {
            return Create(CurrentAccount, new Callback
            {
                CallbackType = type,
                Url = url,
                Active = true
            });
        }

        public Callback Update(int accountId, int callbackId, Callback callback)
        {
            var rval = TDClient.Update(ITEM, new { accountId, callbackId }, callback);
            return rval;
        }

        public Callback Update(int callbackId, Callback callback)
        {
            return Update(CurrentAccount, callbackId, callback);
        }

        public Callback UpdateUrl(int accountId, int callbackId, string newUrl)
        {
            return Update(accountId, callbackId, new Callback
            {
                Url = newUrl,
                Active = true
            });
        }

        public Callback UpdateUrl(int callbackId, string newUrl)
        {
            return Update(CurrentAccount, callbackId, new Callback
            {
                Url = newUrl,
                Active = true
            });
        }

        public Callback Disable(Callback callback)
        {
            if (callback.Id == 0)
                throw new ArgumentException("Callback ID is missing.");

            if (string.IsNullOrEmpty(callback.Url))
                throw new ArgumentException("Callback URL is missing.");

            int accountId = callback.AccountId > 0 ? callback.AccountId : CurrentAccount;

            callback.Active = false;
            return Update(accountId, callback.Id, callback);
        }

        public void Delete(int accountId, int callbackId)
        {
            TDClient.Delete(ITEM, new { accountId, callbackId });
        }

        public void Delete(int callbackId)
        {
            Delete(CurrentAccount, callbackId);
        }

        public void Delete(Callback callback)
        {
            if (callback.Id == 0)
                throw new ArgumentException("Callback ID is missing.");

            int accountId = callback.AccountId > 0 ? callback.AccountId : CurrentAccount;
            Delete(accountId, callback.Id);
        }
    }
}
