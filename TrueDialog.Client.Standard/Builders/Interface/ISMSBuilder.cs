using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Builders
{
    public interface ISMSBuilder
    {
        ISMSBuilder Text(string messageText);

        ISMSBuilder WithMedia(int mediaId);

        ISMSBuilder From(string from);

        ISMSBuilder To(string to);

        ISMSBuilder To(IEnumerable<string> to);

        ISMSBuilder WithPersonalMessages(IEnumerable<PersonalMessage> messages);

        ISMSBuilder WithPersonalMessages(IDictionary<string, string> messages);

        ISMSBuilder Campaign(int campaignId);

        ISMSBuilder IgnoreInvalidTargets(bool ignore = true);

        ISMSBuilder ForceOptIn(bool forceOptIn = true);

        ISMSBuilder RoundRobinById(bool roundRobinById = true);

        ISMSBuilder GlobalRoundRobin(bool globalRoundRobin = true);

        ReturnActionPushCampaign Send();
    }
}
