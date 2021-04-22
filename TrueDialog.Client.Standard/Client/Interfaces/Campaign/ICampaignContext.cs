using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICampaignContext
    {
        ICampaignSurveyContext Survey { get; }
        ICouponDefinitionContext Coupon { get; }
        IContentContext Content { get; }
        ILinkContext Link { get; }

        Campaign GetDefault(CampaignType type);

        Campaign GetDefault(int accountId, CampaignType type);

        List<Campaign> GetList(int accountId, bool onlyMine = true, bool throwIfEmpty = false);

        List<Campaign> GetList(bool onlyMine = true, bool throwIfEmpty = false);

        Campaign GetById(int accountId, int campaignId, bool throwIfEmpty = true);

        Campaign GetById(int campaignId, bool throwIfEmpty = true);

        Campaign Create(int accountId, Campaign campaign);

        Campaign Create(Campaign campaign);

        Campaign Update(int accountId, int campaignId, Campaign campaign);

        Campaign Update(int campaignId, Campaign campaign);

        Campaign Update(Campaign campaign);

        void Delete(int accountId, int campaignId);

        void Delete(int campaignId);

        void Delete(Campaign campaign);

        Campaign CreateGateway(int accountId, string name, int subscriptionId = 0);

        Campaign CreateGateway(string name, int subscriptionId = 0);

        Campaign CreateBasic(int accountId, string name, string message, int subscriptionId = 0);

        Campaign CreateBasic(string name, string message, int subscriptionId = 0);
    }
}
