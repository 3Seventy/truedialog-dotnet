using RestSharp;

using System;
using System.Collections.Generic;
using System.Globalization;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class MessageReportContext : BaseContext
    {
        internal MessageReportContext(InternalClient client) : base(client)
        {
        }

        private const string URL = "account/{accountId}/report/MessageLogReport";
        
        private List<MessageReportRow> InternalGetReport(int accountId, 
            DateTime? from = null, 
            DateTime? to = null, 
            string filter = null, 
            bool throwIfEmpty = false)
        {
            var url = URL;
            if (from.HasValue)
            {
                url += ((url.IndexOf('?') != -1) ? "&" : "?") + "from=" + from.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }

            if (to.HasValue)
            {
                url += ((url.IndexOf('?') != -1) ? "&" : "?") + "to=" + to.Value.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }

            IRestRequest request = TDClient.BuildRequest(Method.GET, URL, new { accountId }, null, null, filter);
            IRestResponse response = TDClient.InnerExecute(request);
            return TDClient.ProcessListResponse<MessageReportRow>(request, response, throwIfEmpty);
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
            return InternalGetReport(accountId, filter: string.Format("$filter=ActionId eq {0}", actionId), throwIfEmpty: false);
        }

        public List<MessageReportRow> GetMessageReportForAction(int actionId, bool throwIfEmpty = false)
        {
            return InternalGetReport(CurrentAccount, filter: string.Format("$filter=ActionId eq {0}", actionId), throwIfEmpty: false);
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
