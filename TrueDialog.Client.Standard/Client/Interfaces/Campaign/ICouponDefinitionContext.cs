using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICouponDefinitionContext
    {
        #region SubContexts
        ICouponOfferContext Offer { get; }
        #endregion

        CouponDefinition GetById(int accountId, int campaignId, bool throwIfEmpty = true);

        CouponDefinition GetById(int campaignId, bool throwIfEmpty = true);

        CouponDefinition Create(int accountId, int campaignId, CouponDefinition definition);

        CouponDefinition Create(int campaignId, CouponDefinition definition);

        CouponDefinition Create(CouponDefinition definition);

        CouponDefinition Update(int accountId, int campaignId, CouponDefinition definition);

        CouponDefinition Update(int campaignId, CouponDefinition definition);

        CouponDefinition Update(CouponDefinition definition);

        CouponRedemption Redeem(int accountId, string couponCode);

        CouponRedemption Redeem(string couponCode);

        CouponRedemptionDetails RedemptionDetails(int accountId, int campaignId);

        CouponRedemptionDetails RedemptionDetails(int campaignId);

        CouponRedemptionDetails RedemptionDetails(CouponDefinition definition);
    }
}
