namespace TrueDialog.Context
{
    public class ReportContext : BaseContext
    {
        internal ReportContext(InternalClient client) : base(client)
        {
        }

        #region SubContexts
        public MessageReportContext Message { get { return GetContext<MessageReportContext>(); } }
        public CampaignReportContext Campaign { get { return GetContext<CampaignReportContext>(); } }
        #endregion
    }
}
