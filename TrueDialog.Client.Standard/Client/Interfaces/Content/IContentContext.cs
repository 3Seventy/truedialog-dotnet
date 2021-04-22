using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContentContext
    {
        #region SubContext
        IContentTemplateContext Template { get; }
        #endregion

        List<Content> GetList(int accountId, bool throwIfEmpty = false);

        List<Content> GetList(bool throwIfEmpty = false);

        Content GetById(int accountId, int contentId, bool throwIfEmpty = true);

        Content GetById(int contentId, bool throwIfEmpty = true);

        Content Create(int accountId, Content content);

        Content Create(Content content);

        Content Update(int accountId, int contentId, Content content);

        Content Update(int contentId, Content content);

        Content Update(Content content);

        void Delete(int accountId, int contentId);

        void Delete(int contentId);

        void Delete(Content content);
    }
}
