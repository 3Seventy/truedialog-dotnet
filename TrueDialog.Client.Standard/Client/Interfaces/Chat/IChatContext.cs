using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IChatContext
    {
        List<ContactLookupRow> ContactLookup(ContactLookupOptions options, out int count);

        List<ContactLookupRow> ContactLookup(int accountId, ContactLookupOptions options, out int count);

        void StopConversation(int conversationId);

        void StopConversation(int accountId, int conversationId);

        void HideConversation(int conversationId);

        void HideConversation(int accountId, int conversationId);

        List<ChatMessage> GetMessages(int conversationId, int skip, int top);

        List<ChatMessage> GetMessages(int accountId, int conversationId, int skip, int top);

        List<ChatConversation> FindConversations(string needle, int skip, int top, out int count);

        List<ChatConversation> FindConversations(int accountId, string needle, int skip, int top, out int count);

        List<ChatConversation> GetConversations(int accountId, out int totalCount, int skip = 0, int take = 20, bool throwIfEmpty = false);

        List<ChatConversation> GetConversations(out int totalCount, int skip = 0, int take = 20, bool throwIfEmpty = false);

        ChatToken GetToken();

        ChatToken GetToken(int accountId);

        ChatConfig GetItem(bool throwIfEmpty = true);

        ChatConfig GetItem(int accountId, bool throwIfEmpty = true);

        ChatConfig Update(int accountId, ChatConfig config);

        ChatConfig Update(ChatConfig config);
    }
}
