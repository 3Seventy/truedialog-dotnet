using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CampaignQuestionContext : BaseContext
    {
        internal CampaignQuestionContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "/account/{accountId}/campaign/{campaignId}/question";

        public CampaignQuestion GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<CampaignQuestion>(ITEM, new { accountId, campaignId }, throwIfEmpty);
            return rval;
        }

        public CampaignQuestion GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CampaignQuestion Create(int accountId, int campaignId, CampaignQuestion question)
        {
            var rval = TDClient.Add(ITEM, new { accountId, campaignId }, question);
            return rval;
        }

        public CampaignQuestion Create(int campaignId, CampaignQuestion question)
        {
            return Create(CurrentAccount, campaignId, question);
        }

        public CampaignQuestion Update(int accountId, int campaignId, CampaignQuestion question)
        {
            var rval = TDClient.Update(ITEM, new { accountId, campaignId }, question);
            return rval;
        }

        public CampaignQuestion Update(int campaignId, CampaignQuestion question)
        {
            return Update(CurrentAccount, campaignId, question);
        }
    }
}
