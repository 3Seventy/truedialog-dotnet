using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ChannelContext : BaseContext
    {
        internal ChannelContext(InternalClient client) : base(client)
        {
        }

        #region SubContext
        public LongCodeContext LongCode { get { return GetContext<LongCodeContext>(); } }
        #endregion

        private const string LIST = "/account/{accountId}/channel/";
        
        public List<Channel> GetList(int accountId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetList<Channel>(LIST, new { accountId });
            return rval;
        }

        public List<Channel> GetList(bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }
    }
}
