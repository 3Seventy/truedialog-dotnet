using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Builders
{
    public interface ISMSBuilder
    {
        ISMSBuilder Text(string messageText);

        ISMSBuilder From(string from);

        ISMSBuilder To(string to);

        ISMSBuilder To(IEnumerable<string> to);

        ISMSBuilder Campaign(int campaignId);

        ISMSBuilder IgnoreInvalidTargets(bool ignore = true);

        ISMSBuilder ForceOptIn(bool forceOptIn = true);

        ActionPushCampaign Send();
    }
}
