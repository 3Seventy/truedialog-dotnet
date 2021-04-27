using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ICampaignReportContext
    {
        List<CampaignReportRow> GetCampaignReport(int accountId, int subscriptionId = 0, bool throwIfEmpty = false);

        List<CampaignReportRow> GetCampaignReport(int subscriptionId = 0, bool throwIfEmpty = false);

        CampaignReportRow GetReportForCampaign(int accountId, int campaignId, bool throwIfEmpty = true);

        CampaignReportRow GetReportForCampaign(int campaignId, bool throwIfEmpty = true);
    }
}
