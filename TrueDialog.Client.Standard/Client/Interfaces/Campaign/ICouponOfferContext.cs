using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICouponOfferContext
    {
        CouponOffer GetById(int accountId, int campaignId, bool throwIfEmpty = false);

        CouponOffer GetById(int campaignId, bool throwIfEmpty = false);

        CouponOffer Create(int accountId, int campaignId, CouponOffer offer);

        CouponOffer Create(int campaignId, CouponOffer offer);

        CouponOffer Create(CouponOffer offer);

        CouponOffer Update(int accountId, int campaignId, CouponOffer offer);

        CouponOffer Update(int campaignId, CouponOffer offer);

        CouponOffer Update(CouponOffer offer);

        void Delete(int accountId, int campaignId);

        void Delete(int campaignId);
    }
}
