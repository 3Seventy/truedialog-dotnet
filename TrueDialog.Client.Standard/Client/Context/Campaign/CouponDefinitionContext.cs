using System;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CouponDefinitionContext : BaseContext, ICouponDefinitionContext
    {
        internal CouponDefinitionContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        #region SubContexts
        public ICouponOfferContext Offer { get { return GetContext<CouponOfferContext>(); } }
        #endregion

        public CouponDefinition GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            return Api.Get<CouponDefinition>($"/account/{accountId}/campaign/{campaignId}/coupon", throwIfEmpty);
        }

        public CouponDefinition GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CouponDefinition Create(int accountId, int campaignId, CouponDefinition definition)
        {
            return Api.Post($"/account/{accountId}/campaign/{campaignId}/coupon", definition);
        }

        public CouponDefinition Create(int campaignId, CouponDefinition definition)
        {
            int accountId = definition.AccountId > 0 ? definition.AccountId : CurrentAccount;
            return Create(accountId, campaignId, definition);
        }

        public CouponDefinition Create(CouponDefinition definition)
        {
            if (definition.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = definition.AccountId > 0 ? definition.AccountId : CurrentAccount;
            return Create(accountId, definition.CampaignId, definition);
        }

        public CouponDefinition Update(int accountId, int campaignId, CouponDefinition definition)
        {
            return Api.Put($"/account/{accountId}/campaign/{campaignId}/coupon", definition);
        }

        public CouponDefinition Update(int campaignId, CouponDefinition definition)
        {
            int accountId = definition.AccountId > 0 ? definition.AccountId : CurrentAccount;
            return Update(accountId, campaignId, definition);
        }

        public CouponDefinition Update(CouponDefinition definition)
        {
            if (definition.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = definition.AccountId > 0 ? definition.AccountId : CurrentAccount;
            return Update(accountId, definition.CampaignId, definition);
        }

        public CouponRedemption Redeem(int accountId, string couponCode)
        {
            return Api.Post<CouponRedemption>($"/account/{accountId}/event-redeemcoupon", couponCode);
        }

        public CouponRedemption Redeem(string couponCode)
        {
            return Redeem(CurrentAccount, couponCode);
        }

        public CouponRedemptionDetails RedemptionDetails(int accountId, int campaignId)
        {
            return Api.Get<CouponRedemptionDetails>($"/account/{accountId}/campaign/{campaignId}/coupon/redemptions");
        }

        public CouponRedemptionDetails RedemptionDetails(int campaignId)
        {
            return RedemptionDetails(CurrentAccount, campaignId);
        }

        public CouponRedemptionDetails RedemptionDetails(CouponDefinition definition)
        {
            if (definition.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = definition.AccountId > 0 ? definition.AccountId : CurrentAccount;
            return RedemptionDetails(accountId, definition.CampaignId);
        }
    }
}
