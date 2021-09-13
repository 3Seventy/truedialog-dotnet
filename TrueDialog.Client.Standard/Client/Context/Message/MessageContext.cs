using System.Collections.Generic;

using TrueDialog.Builders;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class MessageContext : BaseContext, IMessageContext
    {
        internal MessageContext(IApiCaller api) : base(api)
        {
        }

        public ISMSBuilder SMS()
        {
            return new SMSBuilder(this);
        }

        public ReturnActionPushCampaign Submit(int accountId, ActionPushCampaign action)
        {
            return Api.Post<ReturnActionPushCampaign>($"account/{accountId}/action-pushCampaign", action);
        }

        public ReturnActionPushCampaign Submit(ActionPushCampaign action)
        {
            return Submit(CurrentAccount, action);
        }

        public ReturnActionPushCampaign SendBasic(string from, string to, string message)
        {
            return Api.Post<ReturnActionPushCampaign>($"account/{CurrentAccount}/action-pushCampaign", new ActionPushCampaign
            {
                Channels = new List<string> { from },
                RawTargets = new List<string> { Utils.ReadPhoneNumber(to) },
                Message = message,
                Execute = true
            });
        }
    }
}
