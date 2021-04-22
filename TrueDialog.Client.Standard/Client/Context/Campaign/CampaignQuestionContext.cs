using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CampaignQuestionContext : BaseContext, ICampaignQuestionContext
    {
        internal CampaignQuestionContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public CampaignQuestion GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            return Api.Get<CampaignQuestion>($"/account/{accountId}/campaign/{campaignId}/question", throwIfEmpty);
        }

        public CampaignQuestion GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CampaignQuestion Create(int accountId, int campaignId, CampaignQuestion question)
        {
            return Api.Post($"/account/{accountId}/campaign/{campaignId}/question", question);
        }

        public CampaignQuestion Create(int campaignId, CampaignQuestion question)
        {
            return Create(CurrentAccount, campaignId, question);
        }

        public CampaignQuestion Update(int accountId, int campaignId, CampaignQuestion question)
        {
            return Api.Put($"/account/{accountId}/campaign/{campaignId}/question", question);
        }

        public CampaignQuestion Update(int campaignId, CampaignQuestion question)
        {
            return Update(CurrentAccount, campaignId, question);
        }
    }
}
