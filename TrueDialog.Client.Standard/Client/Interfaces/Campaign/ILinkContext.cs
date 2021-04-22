using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ILinkContext
    {
        List<Link> GetList(int accountId, bool throwIfEmpty = false);

        List<Link> GetList(bool throwIfEmpty = false);

        Link GetById(int accountId, int linkId, bool throwIfEmpty = true);

        Link GetById(int linkId, bool throwIfEmpty = true);

        Link Create(int accountId, Link link);

        Link Create(Link link);

        Link Update(int accountId, int linkId, Link link);

        Link Update(int linkId, Link link);

        Link Update(Link link);

        void Delete(int accountId, int linkId);

        void Delete(int linkId);

        void Delete(Link link);
    }
}
