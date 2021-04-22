using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CampaignReportContext : BaseContext, ICampaignReportContext
    {
        internal CampaignReportContext(ITrueDialogClient client, IApiCaller api) : base(client, api)
        {
        }

        public List<CampaignReportRow> GetCampaignReport(int accountId, int subscriptionId = 0, bool throwIfEmpty = false)
        {
            return Api.Get<List<CampaignReportRow>>($"account/{accountId}/newReport/campaignDetailed/{subscriptionId}", throwIfEmpty);
        }

        public List<CampaignReportRow> GetCampaignReport(int subscriptionId = 0, bool throwIfEmpty = false)
        {
            return GetCampaignReport(CurrentAccount, subscriptionId, throwIfEmpty);
        }

        public CampaignReportRow GetReportForCampaign(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            return Api.Get<CampaignReportRow>($"account/{accountId}/newReport/campaignDetailed/0/{campaignId}", throwIfEmpty);
        }

        public CampaignReportRow GetReportForCampaign(int campaignId, bool throwIfEmpty = true)
        {
            return GetReportForCampaign(CurrentAccount, campaignId, throwIfEmpty);
        }
    }
}
