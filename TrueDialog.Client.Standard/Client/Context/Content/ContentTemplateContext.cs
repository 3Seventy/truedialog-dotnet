using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContentTemplateContext : BaseContext, IContentTemplateContext
    {
        internal ContentTemplateContext(IApiCaller api) : base(api)
        {
        }

        public List<ContentTemplate> GetList(int accountId, int contentId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ContentTemplate>>($"account/{accountId}/content/{contentId}/template", throwIfEmpty);
        }

        public List<ContentTemplate> GetList(int contentId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, contentId, throwIfEmpty);
        }

        public ContentTemplate GetById(int accountId, int contentId, int templateId, bool throwIfEmpty = true)
        {
            return Api.Get<ContentTemplate>($"account/{accountId}/content/{contentId}/template/{templateId}", throwIfEmpty);
        }

        public ContentTemplate GetById(int contentId, int templateId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contentId, templateId, throwIfEmpty);
        }

        public ContentTemplate Create(int accountId, int contentId, ContentTemplate template)
        {
            return Api.Post($"account/{accountId}/content/{contentId}/template", template);
        }
        
        public ContentTemplate Create(int contentId, ContentTemplate template)
        {
            int accountId = template.AccountId > 0 ? template.AccountId : CurrentAccount;
            return Create(accountId, contentId, template);
        }

        public ContentTemplate Create(ContentTemplate template)
        {
            if (template.ContentId == 0)
                throw new ArgumentException("Content ID is missing.");

            int accountId = template.AccountId > 0 ? template.AccountId : CurrentAccount;
            return Create(accountId, template.ContentId, template);
        }

        public ContentTemplate Update(int accountId, int contentId, int templateId, ContentTemplate template)
        {
            return Api.Put($"account/{accountId}/content/{contentId}/template/{templateId}", template);
        }

        public ContentTemplate Update(int contentId, int templateId, ContentTemplate template)
        {
            int accountId = template.AccountId > 0 ? template.AccountId : CurrentAccount;
            return Update(accountId, contentId, templateId, template);
        }

        public ContentTemplate Update(ContentTemplate template)
        {
            if (template.Id == 0)
                throw new ArgumentException("Tempate ID is missing");
            if (template.ContentId == 0)
                throw new ArgumentException("Content ID is missing.");

            int accountId = template.AccountId > 0 ? template.AccountId : CurrentAccount;
            return Update(accountId, template.Id, template.ContentId, template);
        }

        public void Delete(int accountId, int contentId, int templateId)
        {
            Api.Delete($"account/{accountId}/content/{contentId}/template/{templateId}");
        }

        public void Delete(int contentId, int templateId)
        {
            Delete(CurrentAccount, contentId, templateId);
        }

        public void Delete(ContentTemplate template)
        {
            if (template.Id == 0)
                throw new ArgumentException("Tempate ID is missing");
            if (template.ContentId == 0)
                throw new ArgumentException("Content ID is missing.");

            int accountId = template.AccountId > 0 ? template.AccountId : CurrentAccount;

            Delete(accountId, template.ContentId, template.Id);
        }
    }
}
