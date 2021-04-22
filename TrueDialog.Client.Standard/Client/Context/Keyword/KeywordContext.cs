using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class KeywordContext : BaseContext, IKeywordContext
    {
        internal KeywordContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public List<Keyword> GetTotalList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Keyword>>($"account/{accountId}/keyword", throwIfEmpty);
        }

        public List<Keyword> GetTotalList(bool throwIfEmpty = false)
        {
            return GetTotalList(CurrentAccount, throwIfEmpty);
        }

        public List<Keyword> GetList(int accountId, string channel, bool throwIfEmpty = false)
        {
            return Api.Get<List<Keyword>>($"account/{accountId}/channel/{channel}/keyword", throwIfEmpty);
        }

        public List<Keyword> GetList(string channel, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, channel, throwIfEmpty);
        }

        public Keyword GetByName(int accountId, string channel, string keyword, bool throwIfEmpty = true)
        {
            return Api.Get<Keyword>($"account/{accountId}/channel/{channel}/keyword/{keyword}", throwIfEmpty);
        }

        public Keyword GetByName(string channel, string keyword, bool throwIfEmpty = true)
        {
            return GetByName(CurrentAccount, channel, keyword, throwIfEmpty);
        }

        public Keyword Create(int accountId, string channel, string keyword)
        {
            return Api.Post($"account/{accountId}/channel/{channel}/keyword", new Keyword { Name = keyword });
        }

        public Keyword Create(string channel, string keyword)
        {
            if (string.IsNullOrEmpty(channel))
                throw new ArgumentException("Channel code/ID is missing.");

            return Create(CurrentAccount, channel, keyword);
        }

        public void Delete(int accountId, string channel, string keyword)
        {
            Api.Delete($"account/{accountId}/channel/{channel}/keyword/{keyword}");
        }

        public void Delete(string channel, string keyword)
        {
            Delete(CurrentAccount, channel, keyword);
        }

        public List<Contact> GetKeywordContacts(int accountId, int keywordId, bool throwIfEmpty = false)
        {
            return Api.Get<List<Contact>>($"account/{accountId}/keyword/{keywordId}/contact", throwIfEmpty);
        }

        public List<Contact> GetKeywordContacts(int keywordId, bool throwIfEmpty = false)
        {
            return GetKeywordContacts(CurrentAccount, keywordId, throwIfEmpty);
        }

        public Campaign GetAttachedCampaign(int accountId, string channel, string keyword, bool throwIfEmpty = false)
        {
            return Api.Get<Campaign>($"account/{accountId}/channel/{channel}/keyword/{keyword}/campaign", throwIfEmpty);
        }

        public Campaign GetAttachedCampaign(string channel, string keyword, bool throwIfEmpty = false)
        {
            return GetAttachedCampaign(CurrentAccount, channel, keyword, throwIfEmpty);
        }

        public Keyword AttachCampaign(int accountId, string channel, string keyword, int campaignId)
        {
            return Api.Post<Keyword>($"account/{accountId}/channel/{channel}/keyword/{keyword}/campaign", campaignId);
        }

        public Keyword AttachCampaign(string channel, string keyword, int campaignId)
        {
            return AttachCampaign(CurrentAccount, channel, keyword, campaignId);
        }

        public void DetachCampaign(int accountId, string channel, string keyword)
        {
            Api.Delete($"account/{accountId}/channel/{channel}/keyword/{keyword}/campaign");
        }

        public void DetachCampaign(string channel, string keyword)
        {
            DetachCampaign(CurrentAccount, channel, keyword);
        }
    }
}
