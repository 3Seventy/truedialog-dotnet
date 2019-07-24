using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContentTemplateContext : BaseContext
    {
        internal ContentTemplateContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/content/{contentId}/template";
        private const string ITEM = "/account/{accountId}/content/{contentId}/template/{templateId}";

        public List<ContentTemplate> GetList(int accountId, int contentId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ContentTemplate>(LIST, new { accountId, contentId }, throwIfEmpty);
            return rval;
        }

        public List<ContentTemplate> GetList(int contentId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, contentId, throwIfEmpty);
        }

        public ContentTemplate GetById(int accountId, int contentId, int templateId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ContentTemplate>(ITEM, new { accountId, contentId, templateId }, throwIfEmpty);
            return rval;
        }

        public ContentTemplate GetById(int contentId, int templateId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, contentId, templateId, throwIfEmpty);
        }

        public ContentTemplate Create(int accountId, int contentId, ContentTemplate template)
        {
            var rval = TDClient.Add(LIST, new { accountId, contentId }, template);
            return rval;
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
            var rval = TDClient.Update(ITEM, new { accountId, contentId, templateId }, template);
            return rval;
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
            TDClient.Delete(ITEM, new { accountId, contentId, templateId });
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
