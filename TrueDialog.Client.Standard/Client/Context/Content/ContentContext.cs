using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContentContext : BaseContext, IContentContext
    {
        internal ContentContext(IApiCaller api) : base(api)
        {
        }

        #region SubContext
        public IContentTemplateContext Template { get { return GetContext<ContentTemplateContext>(); } }
        #endregion

        public List<Content> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Content>>($"account/{accountId}/content", throwIfEmpty);
        }

        public List<Content> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public Content GetById(int accountId, int contentId, bool throwIfEmpty = true)
        {
            return Api.Get<Content>($"account/{accountId}/content/{contentId}", throwIfEmpty);
        }

        public Content GetById(int contentId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contentId, throwIfEmpty);
        }

        public Content Create(int accountId, Content content)
        {
            return Api.Post($"account/{accountId}/content", content);
        }

        public Content Create(Content content)
        {
            return Create(CurrentAccount, content);
        }

        public Content Update(int accountId, int contentId, Content content)
        {
            return Api.Put($"account/{accountId}/content/{contentId}", content);
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
            Api.Delete($"account/{accountId}/content/{contentId}");
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
