using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class LinkContext : BaseContext
    {
        internal LinkContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/link";
        private const string ITEM = "/account/{accountId}/link/{linkId}";

        public List<Link> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Link>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<Link> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public Link GetById(int accountId, int linkId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Link>(ITEM, new { accountId, linkId }, throwIfEmpty);
            return rval;
        }

        public Link GetById(int linkId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, linkId, throwIfEmpty);
        }

        public Link Create(int accountId, Link link)
        {
            var rval = TDClient.Add(LIST, new { accountId }, link);
            return rval;
        }

        public Link Create(Link link)
        {
            int accountId = link.AccountId > 0 ? link.AccountId : CurrentAccount;
            return Create(accountId, link);
        }

        public Link Update(int accountId, int linkId, Link link)
        {
            var rval = TDClient.Update(ITEM, new { accountId, linkId }, link);
            return rval;
        }

        public Link Update(int linkId, Link link)
        {
            return Update(CurrentAccount, linkId, link);
        }

        public Link Update(Link link)
        {
            if (link.Id == 0)
                throw new ArgumentException("Link ID is missing.");

            int accountId = link.AccountId > 0 ? link.AccountId : CurrentAccount;
            return Update(accountId, link.Id, link);
        }
        
        public void Delete(int accountId, int linkId)
        {
            TDClient.Delete(ITEM, new { accountId, linkId });
        }

        public void Delete(int linkId)
        {
            Delete(CurrentAccount, linkId);
        }
        
        public void Delete(Link link)
        {
            if (link.Id == 0)
                throw new ArgumentException("Link ID is missing.");

            int accountId = link.AccountId > 0 ? link.AccountId : CurrentAccount;
            Delete(accountId, link.Id);
        }
    }
}
