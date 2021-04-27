using System;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CouponOfferContext : BaseContext, ICouponOfferContext
    {
        internal CouponOfferContext(IApiCaller api) : base(api)
        {
        }

        public CouponOffer GetById(int accountId, int campaignId, bool throwIfEmpty = false)
        {
            return Api.Get<CouponOffer>($"/account/{accountId}/campaign/{campaignId}/couponOffer", throwIfEmpty);
        }

        public CouponOffer GetById(int campaignId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CouponOffer Create(int accountId, int campaignId, CouponOffer offer)
        {
            return Api.Post($"/account/{accountId}/campaign/{campaignId}/couponOffer", offer);
        }

        public CouponOffer Create(int campaignId, CouponOffer offer)
        {
            int accountId = offer.AccountId > 0 ? offer.AccountId : CurrentAccount;
            return Create(accountId, campaignId, offer);
        }

        public CouponOffer Create(CouponOffer offer)
        {
            if (offer.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = offer.AccountId > 0 ? offer.AccountId : CurrentAccount;
            return Create(accountId, offer.CampaignId, offer);
        }

        public CouponOffer Update(int accountId, int campaignId, CouponOffer offer)
        {
            return Api.Put($"/account/{accountId}/campaign/{campaignId}/couponOffer", offer);
        }

        public CouponOffer Update(int campaignId, CouponOffer offer)
        {
            int accountId = offer.AccountId > 0 ? offer.AccountId : CurrentAccount;
            return Update(accountId, campaignId, offer);
        }

        public CouponOffer Update(CouponOffer offer)
        {
            if (offer.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = offer.AccountId > 0 ? offer.AccountId : CurrentAccount;
            return Update(accountId, offer.CampaignId, offer);
        }

        public void Delete(int accountId, int campaignId)
        {
            Api.Delete($"/account/{accountId}/campaign/{campaignId}/couponOffer");
        }

        public void Delete(int campaignId)
        {
            Delete(CurrentAccount, campaignId);
        }
    }
}
