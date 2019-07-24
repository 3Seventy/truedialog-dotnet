using RestSharp;

using System;
using System.Collections.Generic;

using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CampaignContext : BaseContext
    {
        internal CampaignContext(InternalClient client) : base(client)
        {
        }

        #region SubContexts
        public CampaignSurveyContext Survey { get { return GetContext<CampaignSurveyContext>(); } }
        public CouponDefinitionContext Coupon { get { return GetContext<CouponDefinitionContext>(); } }
        public ContentContext Content { get { return GetContext<ContentContext>(); } }
        public LinkContext Link { get { return GetContext<LinkContext>(); } }
        #endregion

        private const string LIST = "/account/{accountId}/campaign?onlyMine={onlyMine}";
        private const string ITEM = "/account/{accountId}/campaign/{campaignId}";

        public List<Campaign> GetList(int accountId, bool onlyMine = true, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<Campaign>(LIST, new { accountId, onlyMine }, throwIfEmpty);
            return rval;
        }

        public List<Campaign> GetList(bool onlyMine = true, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, onlyMine, throwIfEmpty);
        }

        public Campaign GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<Campaign>(ITEM, new { accountId, campaignId }, throwIfEmpty);
            return rval;
        }

        public Campaign GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public Campaign Create(int accountId, Campaign campaign)
        {
            var rval = TDClient.Add(LIST, new { accountId }, campaign);
            return rval;
        }

        public Campaign Create(Campaign campaign)
        {
            int accountId = campaign.AccountId > 0 ? campaign.AccountId : CurrentAccount;
            return Create(accountId, campaign);
        }

        public Campaign Update(int accountId, int campaignId, Campaign campaign)
        {
            var rval = TDClient.Update(ITEM, new { accountId, campaignId }, campaign);
            return rval;
        }

        public Campaign Update(int campaignId, Campaign campaign)
        {
            int accountId = campaign.AccountId > 0 ? campaign.AccountId : CurrentAccount;
            return Update(accountId, campaignId, campaign);
        }

        public Campaign Update(Campaign campaign)
        {
            if (campaign.Id == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = campaign.AccountId > 0 ? campaign.AccountId : CurrentAccount;
            return Update(accountId, campaign.Id, campaign);
        }

        public void Delete(int accountId, int campaignId)
        {
            TDClient.Delete(ITEM, new { accountId, campaignId });
        }

        public void Delete(int campaignId)
        {
            Delete(CurrentAccount, campaignId);
        }

        public void Delete(Campaign campaign)
        {
            if (campaign.Id == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = campaign.AccountId > 0 ? campaign.AccountId : CurrentAccount;
            Delete(accountId, campaign.Id);
        }

        #region Shortcuts
        public Campaign CreateGateway(int accountId, string name, int subscriptionId = 0)
        {
            return Create(accountId, new Campaign
            {
                Name = name,
                SubscriptionId = subscriptionId,
                CampaignType = CampaignType.Gateway
            });
        }

        public Campaign CreateGateway(string name, int subscriptionId = 0)
        {
            return CreateGateway(CurrentAccount, name, subscriptionId);
        }

        public Campaign CreateBasic(int accountId, string name, string message, int subscriptionId = 0)
        {
            return InternalCreate(accountId, new CreateCampaign
            {
                CampaignType = CampaignType.Basic,
                Name = name,
                SubscriptionId = subscriptionId,
                Content = new CreateUpdateContent
                {
                    Name = string.Format("A{0}_C{1}_CONTENT", accountId, name),
                    Templates = new List<CreateUpdateContentTemplate>
                    {
                        new CreateUpdateContentTemplate
                        {
                            ChannelType = ChannelType.Sms,
                            EncodingType = EncodingType.Razor,
                            LanguageType = LanguageType.English,
                            Template = message
                        }
                    }
                }
            });
        }

        public Campaign CreateBasic(string name, string message, int subscriptionId = 0)
        {
            return CreateBasic(CurrentAccount, name, message, subscriptionId);
        }

        internal Campaign InternalCreate(int accountId, CreateCampaign campaign)
        {
            IRestRequest request = TDClient.BuildRequest(Method.POST, LIST, new { accountId }, campaign);
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<Campaign>(request, response, "add");
        }
        #endregion
    }
}
