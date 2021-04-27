using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContentTemplateContext
    {
        List<ContentTemplate> GetList(int accountId, int contentId, bool throwIfEmpty = false);

        List<ContentTemplate> GetList(int contentId, bool throwIfEmpty = false);

        ContentTemplate GetById(int accountId, int contentId, int templateId, bool throwIfEmpty = true);

        ContentTemplate GetById(int contentId, int templateId, bool throwIfEmpty = true);

        ContentTemplate Create(int accountId, int contentId, ContentTemplate template);

        ContentTemplate Create(int contentId, ContentTemplate template);

        ContentTemplate Create(ContentTemplate template);

        ContentTemplate Update(int accountId, int contentId, int templateId, ContentTemplate template);

        ContentTemplate Update(int contentId, int templateId, ContentTemplate template);

        ContentTemplate Update(ContentTemplate template);

        void Delete(int accountId, int contentId, int templateId);

        void Delete(int contentId, int templateId);

        void Delete(ContentTemplate template);
    }
}
