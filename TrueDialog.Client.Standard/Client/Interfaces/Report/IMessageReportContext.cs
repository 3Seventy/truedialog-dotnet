using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IMessageReportContext
    {
        List<MessageReportRow> GetMessageReport(int accountId, bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReport(bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReportFrame(int accountId, DateTime from, DateTime to, bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReportFrame(DateTime? from, DateTime? to, bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReportForAction(int accountId, int actionId, bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReportForAction(int actionId, bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReportAdvanced(int accountId, DateTime? from, DateTime? to, string filter, bool throwIfEmpty = false);

        List<MessageReportRow> GetMessageReportAdvanced(DateTime? from, DateTime? to, string filter, bool throwIfEmpty = false);
    }
}
