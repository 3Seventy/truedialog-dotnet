using RestSharp;
using System;
using System.Collections.Generic;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class KeywordContext : BaseContext
    {
        internal KeywordContext(InternalClient client) : base(client)
        {
        }

        private const string ALL_LIST = "account/{accountId}/keyword";
        private const string LIST = "account/{accountId}/channel/{channel}/keyword";
        private const string ITEM = "account/{accountId}/channel/{channel}/keyword/{keyword}";
        private const string KEYWORD_CONTACT = "/account/{accountId}/keyword/{keywordId}/contact";
        private const string KEYWORD_CAMPAIGN = "/account/{accountId}/channel/{channel}/keyword/{keyword}/campaign";

        public List<Keyword> GetTotalList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Keyword>(ALL_LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<Keyword> GetTotalList(bool throwIfEmpty = false)
        {
            return GetTotalList(CurrentAccount, throwIfEmpty);
        }

        public List<Keyword> GetList(int accountId, string channel, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Keyword>(LIST, new { accountId, channel }, throwIfEmpty);
            return rval;
        }

        public List<Keyword> GetList(string channel, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, channel, throwIfEmpty);
        }

        public Keyword GetByName(int accountId, string channel, string keyword, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Keyword>(ITEM, new { accountId, channel, keyword }, throwIfEmpty);
            return rval;
        }

        public Keyword GetByName(string channel, string keyword, bool throwIfEmpty = true)
        {
            return GetByName(CurrentAccount, channel, keyword, throwIfEmpty);
        }

        public Keyword Create(int accountId, string channel, string keyword)
        {
            var rval = TDClient.Add(LIST, new { accountId, channel }, new Keyword
            {
                Name = keyword
            });
            return rval;
        }

        public Keyword Create(string channel, string keyword)
        {
            if (string.IsNullOrEmpty(channel))
                throw new ArgumentException("Channel code/ID is missing.");

            return Create(CurrentAccount, channel, keyword);
        }

        public void Delete(int accountId, string channel, string keyword)
        {
            TDClient.Delete(ITEM, new { accountId, channel, keyword });
        }

        public void Delete(string channel, string keyword)
        {
            Delete(CurrentAccount, channel, keyword);
        }

        public List<Contact> GetKeywordContacts(int accountId, int keywordId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Contact>(KEYWORD_CONTACT, new { accountId, keywordId }, throwIfEmpty);
            return rval;
        }

        public List<Contact> GetKeywordContacts(int keywordId, bool throwIfEmpty = false)
        {
            return GetKeywordContacts(CurrentAccount, keywordId, throwIfEmpty);
        }

        public Campaign GetAttachedCampaign(int accountId, string channel, string keyword, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetItem<Campaign>(KEYWORD_CAMPAIGN, new { accountId, channel, keyword }, throwIfEmpty);
            return rval;
        }

        public Campaign GetAttachedCampaign(string channel, string keyword, bool throwIfEmpty = false)
        {
            return GetAttachedCampaign(CurrentAccount, channel, keyword, throwIfEmpty);
        }

        public Keyword AttachCampaign(int accountId, string channel, string keyword, int campaignId)
        {
            IRestRequest request = TDClient.BuildRequest(Method.POST, KEYWORD_CAMPAIGN, new { accountId, channel, keyword }, campaignId);
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<Keyword>(request, response, "attach campaign");
        }

        public Keyword AttachCampaign(string channel, string keyword, int campaignId)
        {
            return AttachCampaign(CurrentAccount, channel, keyword, campaignId);
        }

        public void DetachCampaign(int accountId, string channel, string keyword)
        {
            TDClient.Delete(KEYWORD_CAMPAIGN, new { accountId, channel, keyword });
        }

        public void DetachCampaign(string channel, string keyword)
        {
            DetachCampaign(CurrentAccount, channel, keyword);
        }
    }
}
