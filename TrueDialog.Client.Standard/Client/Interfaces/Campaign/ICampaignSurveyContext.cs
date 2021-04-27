using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICampaignSurveyContext
    {
        #region SubContexts
        ICampaignQuestionContext Question { get; }
        ICampaignAnswerContext Answer { get; }
        #endregion

        CampaignSurvey GetById(int accountId, int campaignId, bool throwIfEmpty = true);

        CampaignSurvey GetById(int campaignId, bool throwIfEmpty = true);

        CampaignSurvey Create(int accountId, int campaignId, CampaignSurvey survey);

        CampaignSurvey Create(int campaignId, CampaignSurvey survey);

        CampaignSurvey Create(int accountId, int campaignId, int firstQuestionId);

        CampaignSurvey Create(int campaignId, int firstQuestionId);

        CampaignSurvey Update(int accountId, int campaignId, CampaignSurvey survey);

        CampaignSurvey Update(int campaignId, CampaignSurvey survey);

        CampaignSurvey Update(int accountId, int campaignId, int firstQuestionId);

        CampaignSurvey Update(int campaignId, int firstQuestionId);
    }
}
