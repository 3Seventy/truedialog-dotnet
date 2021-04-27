using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ChannelContext : BaseContext, IChannelContext
    {
        internal ChannelContext(IApiCaller api) : base(api)
        {
        }

        #region SubContext
        public ILongCodeContext LongCode { get { return GetContext<LongCodeContext>(); } }
        #endregion
        
        public List<Channel> GetList(int accountId, bool throwIfEmpty = true)
        {
            return Api.Get<List<Channel>>($"/account/{accountId}/channel", throwIfEmpty);
        }

        public List<Channel> GetList(bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }
    }
}
