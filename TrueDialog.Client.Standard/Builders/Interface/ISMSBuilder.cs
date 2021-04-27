using TrueDialog.Model;

namespace TrueDialog.Builders
{
    public interface ISMSBuilder
    {
        ISMSBuilder Text(string messageText);

        ISMSBuilder From(string from);

        ISMSBuilder To(string to);

        ISMSBuilder Campaign(int campaignId);

        ActionPushCampaign Send();
    }
}
