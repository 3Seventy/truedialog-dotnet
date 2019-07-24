using RestSharp;
using System;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CouponDefinitionContext : BaseContext
    {
        internal CouponDefinitionContext(InternalClient client) : base(client)
        {
        }

        #region SubContexts
        public CouponOfferContext Offer { get { return GetContext<CouponOfferContext>(); } }
        public ExternalCouponListContext ExternalCouponList { get { return GetContext<ExternalCouponListContext>(); } }
        public ExternalCouponCodeContext ExternalCouponCode { get { return GetContext<ExternalCouponCodeContext>(); } }
        #endregion

        private const string ITEM = "/account/{accountId}/campaign/{campaignId}/coupon";
        private const string REDEEM = "/account/{accountId}/event-redeemcoupon";
        private const string REDEMPTION_DETAILS = "/account/{accountId}/campaign/{campaignId}/coupon/redemptions";

        public CouponDefinition GetById(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<CouponDefinition>(ITEM, new { accountId, campaignId }, throwIfEmpty);
            return rval;
        }

        public CouponDefinition GetById(int campaignId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CouponDefinition Create(int accountId, int campaignId, CouponDefinition definition)
        {
            var rval = TDClient.Add(ITEM, new { accountId, campaignId }, definition);
            return rval;
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
            var rval = TDClient.Update(ITEM, new { accountId, campaignId }, definition);
            return rval;
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
            IRestRequest request = TDClient.BuildRequest(Method.POST, REDEEM, new { accountId }, couponCode);
            IRestResponse response = TDClient.InnerExecute(request);

            return TDClient.ProcessOperationResponse<CouponRedemption>(request, response, "redeem");
        }

        public CouponRedemption Redeem(string couponCode)
        {
            return Redeem(CurrentAccount, couponCode);
        }

        public CouponRedemptionDetails RedemptionDetails(int accountId, int campaignId)
        {
            var rval = TDClient.GetItem<CouponRedemptionDetails>(REDEMPTION_DETAILS, new { accountId, campaignId });
            return rval;
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
