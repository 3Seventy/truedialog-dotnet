using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContentContext : BaseContext
    {
        internal ContentContext(InternalClient client) : base(client)
        {
        }

        #region SubContext
        public ContentTemplateContext Template { get { return GetContext<ContentTemplateContext>(); } }
        #endregion

        private const string LIST = "/account/{accountId}/content";
        private const string ITEM = "/account/{accountId}/content/{contentId}";

        public List<Content> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Content>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<Content> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public Content GetById(int accountId, int contentId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Content>(ITEM, new { accountId, contentId }, throwIfEmpty);
            return rval;
        }

        public Content GetById(int contentId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contentId, throwIfEmpty);
        }

        public Content Create(int accountId, Content content)
        {
            var rval = TDClient.Add(LIST, new { accountId }, content);
            return rval;
        }

        public Content Create(Content content)
        {
            return Create(CurrentAccount, content);
        }

        public Content Update(int accountId, int contentId, Content content)
        {
            var rval = TDClient.Update(ITEM, new { accountId, contentId }, content);
            return rval;
        }

        public Content Update(int contentId, Content content)
        {
            int accountId = content.AccountId > 0 ? content.AccountId : CurrentAccount;
            return Update(accountId, contentId, content);
        }

        public Content Update(Content content)
        {
            if (content.Id == 0)
                throw new ArgumentException("Content ID is missing.");

            int accountId = content.AccountId > 0 ? content.AccountId : CurrentAccount;
            return Update(accountId, content.Id, content);
        }

        public void Delete(int accountId, int contentId)
        {
            TDClient.Delete(ITEM, new { accountId, contentId });
        }

        public void Delete(int contentId)
        {
            Delete(CurrentAccount, contentId);
        }

        public void Delete(Content content)
        {
            if (content.Id == 0)
                throw new ArgumentException("Content ID is missing.");

            int accountId = content.AccountId > 0 ? content.AccountId : CurrentAccount;
            Delete(accountId, content.Id);
        }
    }
}
