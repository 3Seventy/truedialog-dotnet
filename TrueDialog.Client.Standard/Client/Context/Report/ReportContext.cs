namespace TrueDialog.Context
{
    internal class ReportContext : BaseContext, IReportContext
    {
        internal ReportContext(IApiCaller api) : base(api)
        {
        }

        #region SubContexts
        public IMessageReportContext Message { get { return GetContext<MessageReportContext>(); } }
        public ICampaignReportContext Campaign { get { return GetContext<CampaignReportContext>(); } }
        #endregion
    }
}
