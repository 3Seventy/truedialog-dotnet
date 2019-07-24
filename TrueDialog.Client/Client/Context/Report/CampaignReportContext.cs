using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CampaignReportContext : BaseContext
    {
        internal CampaignReportContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/newReport/campaignDetailed/{subscriptionId}";
        private const string ITEM = "account/{accountId}/newReport/campaignDetailed/{subscriptionId}/{campaignId}";

        public List<CampaignReportRow> GetCampaignReport(int accountId, int subscriptionId = 0, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<CampaignReportRow>(LIST, new { accountId, subscriptionId }, throwIfEmpty);
            return rval;
        }

        public List<CampaignReportRow> GetCampaignReport(int subscriptionId = 0, bool throwIfEmpty = false)
        {
            return GetCampaignReport(CurrentAccount, subscriptionId, throwIfEmpty);
        }

        public CampaignReportRow GetReportForCampaign(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<CampaignReportRow>(ITEM, new { accountId, subscriptionId = 0, campaignId }, throwIfEmpty);
            return rval;
        }

        public CampaignReportRow GetReportForCampaign(int campaignId, bool throwIfEmpty = true)
        {
            return GetReportForCampaign(CurrentAccount, campaignId, throwIfEmpty);
        }
    }
}
