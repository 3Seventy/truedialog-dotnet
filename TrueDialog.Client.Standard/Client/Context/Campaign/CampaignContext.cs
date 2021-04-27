using System;
using System.Collections.Generic;
using System.Linq;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CampaignContext : BaseContext, ICampaignContext
    {
        internal CampaignContext(IApiCaller api) : base(api)
        {
        }

        #region SubContexts
        public ICampaignSurveyContext Survey { get { return GetContext<CampaignSurveyContext>(); } }
        public ICouponDefinitionContext Coupon { get { return GetContext<CouponDefinitionContext>(); } }
        public IContentContext Content { get { return GetContext<ContentContext>(); } }
        public ILinkContext Link { get { return GetContext<LinkContext>(); } }
        #endregion

        public Campaign GetDefault(CampaignType type)
        {
            return GetDefault(CurrentAccount, type);
        }

        public Campaign GetDefault(int accountId, CampaignType type)
        {
            return Api.Get<List<Campaign>>($"/account/{accountId}/campaign?onlyMine=true", true, new { filter = $"(IsDefault eq true) and (CampaignTypeId eq {(int)type})" }).FirstOrDefault();
        }

        public List<Campaign> GetList(int accountId, bool onlyMine = true, bool throwIfEmpty = false)
        {
            return Api.Get<List<Campaign>>($"/account/{accountId}/campaign?onlyMine={onlyMine}", throwIfEmpty);
        }

        public List<Campaign> GetList(bool onlyMine = true, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, onlyMine, throwIfEmpty);
        }

        public Campaign GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            return Api.Get<Campaign>($"/account/{accountId}/campaign/{campaignId}", throwIfEmpty);
        }

        public Campaign GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public Campaign Create(int accountId, Campaign campaign)
        {
            return Api.Post($"/account/{accountId}/campaign", campaign);
        }

        public Campaign Create(Campaign campaign)
        {
            int accountId = campaign.AccountId > 0 ? campaign.AccountId : CurrentAccount;
            return Create(accountId, campaign);
        }

        public Campaign Update(int accountId, int campaignId, Campaign campaign)
        {
            return Api.Put($"/account/{accountId}/campaign/{campaignId}", campaign);
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
            Api.Delete($"/account/{accountId}/campaign/{campaignId}");
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
            return Api.Post<Campaign>($"/account/{accountId}/campaign", campaign);
        }
        #endregion
    }
}
