using System;
using System.Collections.Generic;
using System.Globalization;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class MessageReportContext : BaseContext, IMessageReportContext
    {
        internal MessageReportContext(IApiCaller api) : base(api)
        {
        }

        private List<MessageReportRow> InternalGetReport(int accountId, 
            DateTime? from = null, 
            DateTime? to = null, 
            object filter = null, 
            bool throwIfEmpty = false)
        {
            var url = $"account/{accountId}/report/MessageLogReport";
            if (from.HasValue)
            {
                url += ((url.IndexOf('?') != -1) ? "&" : "?") + "from=" + from.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }

            if (to.HasValue)
            {
                url += ((url.IndexOf('?') != -1) ? "&" : "?") + "to=" + to.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }

            return Api.Get<List<MessageReportRow>>(url, throwIfEmpty, filter);
        }

        public List<MessageReportRow> GetMessageReport(int accountId, bool throwIfEmpty = false)
        {
            return InternalGetReport(accountId, throwIfEmpty: throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReport(bool throwIfEmpty = false)
        {
            return InternalGetReport(CurrentAccount, throwIfEmpty: throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReportFrame(int accountId, DateTime from, DateTime to, bool throwIfEmpty = false)
        {
            return InternalGetReport(accountId, from, to, throwIfEmpty: throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReportFrame(DateTime? from, DateTime? to, bool throwIfEmpty = false)
        {
            return InternalGetReport(CurrentAccount, from, to, throwIfEmpty: throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReportForAction(int accountId, int actionId, bool throwIfEmpty = false)
        {
            return InternalGetReport(accountId, filter: new { filter = $"ActionId eq {actionId}" }, throwIfEmpty: throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReportForAction(int actionId, bool throwIfEmpty = false)
        {
            return InternalGetReport(CurrentAccount, filter: new { filter = $"ActionId eq {actionId}" }, throwIfEmpty: throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReportAdvanced(int accountId, DateTime? from, DateTime? to, string filter, bool throwIfEmpty = false)
        {
            return InternalGetReport(accountId, from, to, filter, throwIfEmpty);
        }

        public List<MessageReportRow> GetMessageReportAdvanced(DateTime? from, DateTime? to, string filter, bool throwIfEmpty = false)
        {
            return InternalGetReport(CurrentAccount, from, to, filter, throwIfEmpty);
        }
    }
}
