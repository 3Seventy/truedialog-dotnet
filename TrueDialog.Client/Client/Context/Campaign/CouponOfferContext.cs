using System;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CouponOfferContext : BaseContext
    {
        internal CouponOfferContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "account/{accountId}/campaign/{campaignId}/couponOffer";

        public CouponOffer GetById(int accountId, int campaignId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetItem<CouponOffer>(ITEM, new { accountId, campaignId }, throwIfEmpty);
            return rval;
        }

        public CouponOffer GetById(int campaignId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CouponOffer Create(int accountId, int campaignId, CouponOffer offer)
        {
            var rval = TDClient.Add(ITEM, new { accountId, campaignId }, offer);
            return rval;
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
            var rval = TDClient.Update(ITEM, new { accountId, campaignId }, offer);
            return rval;
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
            TDClient.Delete(ITEM, new { accountId, campaignId });
        }

        public void Delete(int campaignId)
        {
            Delete(CurrentAccount, campaignId);
        }
    }
}
