using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICampaignQuestionContext
    {
        CampaignQuestion GetById(int accountId, int campaignId, bool throwIfEmpty = true);

        CampaignQuestion GetById(int campaignId, bool throwIfEmpty = true);

        CampaignQuestion Create(int accountId, int campaignId, CampaignQuestion question);

        CampaignQuestion Create(int campaignId, CampaignQuestion question);

        CampaignQuestion Update(int accountId, int campaignId, CampaignQuestion question);

        CampaignQuestion Update(int campaignId, CampaignQuestion question);
    }
}
