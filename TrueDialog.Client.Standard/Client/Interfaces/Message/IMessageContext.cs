using TrueDialog.Builders;
using TrueDialog.Model;

namespace TrueDialog
{
    public interface IMessageContext
    {
        ISMSBuilder SMS();

        ActionPushCampaign Submit(int accountId, ActionPushCampaign action);

        ActionPushCampaign Submit(ActionPushCampaign action);

        ActionPushCampaign SendBasic(string from, string to, string message);
    }
}
