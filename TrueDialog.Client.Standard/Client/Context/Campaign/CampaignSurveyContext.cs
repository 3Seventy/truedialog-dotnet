using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CampaignSurveyContext : BaseContext, ICampaignSurveyContext
    {
        internal CampaignSurveyContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        #region SubContexts
        public ICampaignQuestionContext Question { get { return GetContext<CampaignQuestionContext>(); } }
        public ICampaignAnswerContext Answer { get { return GetContext<CampaignAnswerContext>(); } }
        #endregion

        private const string ITEM = "/account/{accountId}/campaign/{campaignId}/dialog";

        public CampaignSurvey GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            return Api.Get<CampaignSurvey>($"/account/{accountId}/campaign/{campaignId}/dialog", throwIfEmpty);
        }

        public CampaignSurvey GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId);
        }

        public CampaignSurvey Create(int accountId, int campaignId, CampaignSurvey survey)
        {
            return Api.Post($"/account/{accountId}/campaign/{campaignId}/dialog", survey);
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
            return Api.Put($"/account/{accountId}/campaign/{campaignId}/dialog", survey);
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
