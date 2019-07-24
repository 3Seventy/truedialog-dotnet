using System.Collections.Generic;
using TrueDialog.Builders;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class MessageContext : BaseContext
    {
        internal MessageContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/action-pushCampaign";

        public ISMSBuilder SMS()
        {
            return new SMSBuilder(this);
        }

        public ActionPushCampaign Submit(int accountId, ActionPushCampaign action)
        {
            var rval = TDClient.Add(LIST, new { accountId }, action);

            return rval;
        }

        public ActionPushCampaign Submit(ActionPushCampaign action)
        {
            return Submit(CurrentAccount, action);
        }

        public ActionPushCampaign SendBasic(string from, string to, string message)
        {
            var rval = TDClient.Add(LIST, new { accountId = CurrentAccount }, new ActionPushCampaign
            {
                Channels = new List<string> { from },
                Targets = new List<string> { Utils.ReadPhoneNumber(to) },
                Message = message,
                Execute = true
            });

            return rval;
        }
    }
}
