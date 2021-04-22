namespace TrueDialog
{
    public interface IReportContext
    {
        IMessageReportContext Message { get; }
        ICampaignReportContext Campaign { get; }
    }
}
