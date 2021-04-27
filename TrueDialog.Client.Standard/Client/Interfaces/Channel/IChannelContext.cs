using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IChannelContext
    {
        ILongCodeContext LongCode { get; }

        List<Channel> GetList(int accountId, bool throwIfEmpty = true);

        List<Channel> GetList(bool throwIfEmpty = true);
    }
}
