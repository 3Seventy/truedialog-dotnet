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

        public ActionPushCampaign Submit(int accountId, ActionPushCampaign action)
        {
            return Api.Post($"account/{accountId}/action-pushCampaign", action);
        }

        public ActionPushCampaign Submit(ActionPushCampaign action)
        {
            return Submit(CurrentAccount, action);
        }

        public ActionPushCampaign SendBasic(string from, string to, string message)
        {
            return Api.Post($"account/{CurrentAccount}/action-pushCampaign", new ActionPushCampaign
            {
                Channels = new List<string> { from },
                Targets = new List<string> { Utils.ReadPhoneNumber(to) },
                Message = message,
                Execute = true
            });
        }
    }
}
