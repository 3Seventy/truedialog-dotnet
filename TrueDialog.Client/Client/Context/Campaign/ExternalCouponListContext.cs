using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ExternalCouponListContext : BaseContext
    {
        internal ExternalCouponListContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/external-couponlist";
        private const string ITEM = "/account/{accountId}/external-couponlist/{listId}";
        private const string CODE_LIST = "/account/{accountId}/external-couponlist/{listId}/code";

        public List<ExternalCouponList> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ExternalCouponList>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<ExternalCouponList> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ExternalCouponList GetById(int accountId, int listId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ExternalCouponList>(ITEM, new { accountId, listId }, throwIfEmpty);
            return rval;
        }

        public ExternalCouponList GetById(int listId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, listId, throwIfEmpty);
        }

        public ExternalCouponList Create(int accountId, ExternalCouponList list)
        {
            var rval = TDClient.Add(LIST, new { accountId }, list);
            return rval;
        }

        public ExternalCouponList Create(ExternalCouponList list)
        {
            int accountId = list.AccountId > 0 ? list.AccountId : CurrentAccount;
            return Create(accountId, list);
        }

        public ExternalCouponList Update(int accountId, int listId, ExternalCouponList list)
        {
            var rval = TDClient.Update(ITEM, new { accountId, listId }, list);
            return rval;
        }

        public ExternalCouponList Update(int listId, ExternalCouponList list)
        {
            int accountId = list.AccountId > 0 ? list.AccountId : CurrentAccount;
            return Update(accountId, listId, list);
        }

        public ExternalCouponList Update(ExternalCouponList list)
        {
            if (list.Id == 0)
                throw new ArgumentException("List ID is missing.");

            int accountId = list.AccountId > 0 ? list.AccountId : CurrentAccount;
            return Update(accountId, list.Id, list);
        }

        public void Delete(int accountId, int listId)
        {
            TDClient.Delete(ITEM, new { accountId, listId });
        }

        public void Delete(int listId)
        {
            Delete(CurrentAccount, listId);
        }

        public void Delete(ExternalCouponList list)
        {
            if (list.Id == 0)
                throw new ArgumentException("List ID is missing.");

            int accountId = list.AccountId > 0 ? list.AccountId : CurrentAccount;
            Delete(accountId, list.Id);
        }

        public List<ExternalCouponCode> GetCodes(int accountId, int listId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ExternalCouponCode>(CODE_LIST, new { accountId, listId }, throwIfEmpty);
            return rval;
        }

        public List<ExternalCouponCode> GetCodes(int listId, bool throwIfEmpty = false)
        {
            return GetCodes(CurrentAccount, listId, throwIfEmpty);
        }

        public List<ExternalCouponCode> GetCodes(ExternalCouponList list, bool throwIfEmpty = false)
        {
            if (list.Id == 0)
                throw new ArgumentException("List ID is missing.");

            int accountId = list.AccountId > 0 ? list.AccountId : CurrentAccount;
            return GetCodes(accountId, list.Id, throwIfEmpty);
        }
    }
}
