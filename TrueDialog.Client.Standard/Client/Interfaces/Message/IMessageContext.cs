using TrueDialog.Builders;
using TrueDialog.Model;

namespace TrueDialog
{
    public interface IMessageContext
    {
        ISMSBuilder SMS();

        ReturnActionPushCampaign Submit(int accountId, ActionPushCampaign action);

        ReturnActionPushCampaign Submit(ActionPushCampaign action);

        ReturnActionPushCampaign SendBasic(string from, string to, string message);
    }
}
