using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CampaignSurveyContext : BaseContext
    {
        internal CampaignSurveyContext(InternalClient client) : base(client)
        {
        }

        #region SubContexts
        public CampaignQuestionContext Question { get { return GetContext<CampaignQuestionContext>(); } }
        public CampaignAnswerContext Answer { get { return GetContext<CampaignAnswerContext>(); } }
        #endregion

        private const string ITEM = "/account/{accountId}/campaign/{campaignId}/dialog";

        public CampaignSurvey GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<CampaignSurvey>(ITEM, new { accountId, campaignId }, throwIfEmpty);
            return rval;
        }

        public CampaignSurvey GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId);
        }

        public CampaignSurvey Create(int accountId, int campaignId, CampaignSurvey survey)
        {
            var rval = TDClient.Add(ITEM, new { accountId, campaignId }, survey);
            return rval;
        }

        public CampaignSurvey Create(int campaignId, CampaignSurvey survey)
        {
            return Create(CurrentAccount, campaignId, survey);
        }

        public CampaignSurvey Create(int accountId, int campaignId, int firstQuestionId)
        {
            return Create(accountId, campaignId, new CampaignSurvey { FirstQuestionId = firstQuestionId });
        }

        public CampaignSurvey Create(int campaignId, int firstQuestionId)
        {
            return Create(CurrentAccount, campaignId, new CampaignSurvey { FirstQuestionId = firstQuestionId });
        }

        public CampaignSurvey Update(int accountId, int campaignId, CampaignSurvey survey)
        {
            var rval = TDClient.Update(ITEM, new { accountId, campaignId }, survey);
            return rval;
        }

        public CampaignSurvey Update(int campaignId, CampaignSurvey survey)
        {
            return Update(CurrentAccount, campaignId, survey);
        }

        public CampaignSurvey Update(int accountId, int campaignId, int firstQuestionId)
        {
            return Update(accountId, campaignId, new CampaignSurvey { FirstQuestionId = firstQuestionId });
        }

        public CampaignSurvey Update(int campaignId, int firstQuestionId)
        {
            return Update(CurrentAccount, campaignId, new CampaignSurvey { FirstQuestionId = firstQuestionId });
        }
    }
}
