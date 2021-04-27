using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class LinkContext : BaseContext, ILinkContext
    {
        internal LinkContext(IApiCaller api) : base(api)
        {
        }

        private const string LIST = "/account/{accountId}/link";
        private const string ITEM = "/account/{accountId}/link/{linkId}";

        public List<Link> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Link>>($"/account/{accountId}/link", throwIfEmpty);
        }

        public List<Link> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public Link GetById(int accountId, int linkId, bool throwIfEmpty = true)
        {
            return Api.Get<Link>($"/account/{accountId}/link/{linkId}", throwIfEmpty);
        }

        public Link GetById(int linkId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, linkId, throwIfEmpty);
        }

        public Link Create(int accountId, Link link)
        {
            return Api.Post($"/account/{accountId}/link", link);
        }

        public Link Create(Link link)
        {
            int accountId = link.AccountId > 0 ? link.AccountId : CurrentAccount;
            return Create(accountId, link);
        }

        public Link Update(int accountId, int linkId, Link link)
        {
            return Api.Put($"/account/{accountId}/link/{linkId}", link);
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
            Api.Delete($"/account/{accountId}/link/{linkId}");
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
