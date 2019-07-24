using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ExternalCouponCodeContext : BaseContext
    {
        internal ExternalCouponCodeContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/external-couponlist/{listId}/code";
        private const string ITEM = "/account/{accountId}/external-couponlist/{listId}/code/{couponcode}";

        public List<ExternalCouponCode> GetList(int accountId, int listId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ExternalCouponCode>(LIST, new { accountId, listId }, throwIfEmpty);
            return rval;
        }

        public List<ExternalCouponCode> GetList(int listId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, listId, throwIfEmpty);
        }

        public List<ExternalCouponCode> GetList(ExternalCouponList list, bool throwIfEmpty = false)
        {
            if (list.Id == 0)
                throw new ArgumentException("List ID is missing.");

            int accountId = list.AccountId > 0 ? list.AccountId : CurrentAccount;
            return GetList(accountId, list.Id, throwIfEmpty);
        }

        public ExternalCouponCode GetById(int accountId, int listId, string couponCode, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetItem<ExternalCouponCode>(ITEM, new { accountId, listId, couponCode }, throwIfEmpty);
            return rval;
        }

        public ExternalCouponCode GetById(int listId, string couponCode, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, listId, couponCode, throwIfEmpty);
        }

        public void Delete(int accountId, int listId, string couponCode)
        {
            TDClient.Delete(ITEM, new { accountId, listId, couponCode });
        }

        public void Delete(int listId, string couponCode)
        {
            Delete(CurrentAccount, listId, couponCode);
        }
    }
}
