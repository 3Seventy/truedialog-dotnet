using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IKeywordContext
    {
        List<Keyword> GetTotalList(int accountId, bool throwIfEmpty = false);

        List<Keyword> GetTotalList(bool throwIfEmpty = false);

        List<Keyword> GetList(int accountId, string channel, bool throwIfEmpty = false);

        List<Keyword> GetList(string channel, bool throwIfEmpty = false);

        Keyword GetByName(int accountId, string channel, string keyword, bool throwIfEmpty = true);

        Keyword GetByName(string channel, string keyword, bool throwIfEmpty = true);

        Keyword Create(int accountId, string channel, string keyword);

        Keyword Create(string channel, string keyword);

        void Delete(int accountId, string channel, string keyword);

        void Delete(string channel, string keyword);

        List<Contact> GetKeywordContacts(int accountId, int keywordId, bool throwIfEmpty = false);

        List<Contact> GetKeywordContacts(int keywordId, bool throwIfEmpty = false);

        Campaign GetAttachedCampaign(int accountId, string channel, string keyword, bool throwIfEmpty = false);

        Campaign GetAttachedCampaign(string channel, string keyword, bool throwIfEmpty = false);

        Keyword AttachCampaign(int accountId, string channel, string keyword, int campaignId);

        Keyword AttachCampaign(string channel, string keyword, int campaignId);

        void DetachCampaign(int accountId, string channel, string keyword);

        void DetachCampaign(string channel, string keyword);
    }
}
