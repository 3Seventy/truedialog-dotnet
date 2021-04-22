using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICampaignAnswerContext
    {
        List<CampaignAnswer> GetList(int accountId, int campaignId, bool throwIfEmpty = true);

        List<CampaignAnswer> GetList(int campaignId, bool throwIfEmpty = true);

        CampaignAnswer GetById(int accountId, int campaignId, int answerId, bool throwIfEmpty = true);

        CampaignAnswer GetById(int campaignId, int answerId, bool throwIfEmpty = true);

        CampaignAnswer Create(int accountId, int campaignId, CampaignAnswer answer);

        CampaignAnswer Create(int campaignId, CampaignAnswer answer);

        CampaignAnswer Create(CampaignAnswer answer);

        CampaignAnswer Update(int accountId, int campaignId, int answerId, CampaignAnswer answer);

        CampaignAnswer Update(int campaignId, int answerId, CampaignAnswer answer);

        CampaignAnswer Update(CampaignAnswer answer);

        void Delete(int accountId, int campaignId, int answerId);

        void Delete(int campaignId, int answerId);

        void Delete(CampaignAnswer answer);
    }
}
