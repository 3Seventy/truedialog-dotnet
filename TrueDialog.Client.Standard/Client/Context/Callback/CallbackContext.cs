using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CallbackContext : BaseContext, ICallbackContext
    {
        internal CallbackContext(IApiCaller api) : base(api)
        {
        }
        
        public List<Callback> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Callback>>($"/account/{accountId}/callback", throwIfEmpty);
        }

        public List<Callback> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public Callback GetById(int accountId, int callbackId, bool throwIfEmpty = true)
        {
            return Api.Get<Callback>($"/account/{accountId}/callback/{callbackId}", throwIfEmpty);
        }

        public Callback GetById(int callbackId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, callbackId, throwIfEmpty);
        }

        public Callback Create(int accountId, Callback callback)
        {
            return Api.Post($"/account/{accountId}/callback", callback);
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
            return Api.Put($"/account/{accountId}/callback/{callbackId}", callback);
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

        public void Delete(int accountId, int callbackId)
        {
            Api.Delete($"/account/{accountId}/callback/{callbackId}");
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
