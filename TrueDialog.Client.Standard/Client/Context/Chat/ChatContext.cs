using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ChatContext : BaseContext, IChatContext
    {
        internal ChatContext(IApiCaller api) : base(api)
        {
        }

        public List<ContactLookupRow> ContactLookup(ContactLookupOptions options, out int count)
        {
            return ContactLookup(CurrentAccount, options, out count);
        }

        public List<ContactLookupRow> ContactLookup(int accountId, ContactLookupOptions options, out int count)
        {
            /* TODO: review option to return enveloped response */
            count = options.Take + 1;
            return Api.Post<List<ContactLookupRow>>($"/account/{accountId}/contactLookup", options);
        }

        public void StopConversation(int conversationId)
        {
            StopConversation(CurrentAccount, conversationId);
        }

        public void StopConversation(int accountId, int conversationId)
        {
            Api.Delete($"/account/{accountId}/chat/conversation/{conversationId}");
        }

        public void HideConversation(int conversationId)
        {
            HideConversation(CurrentAccount, conversationId);
        }

        public void HideConversation(int accountId, int conversationId)
        {
            Api.Put($"/account/{accountId}/chat/conversation/{conversationId}", new ChatConversation
            {
                Id = conversationId,
                StatusId = 1
            });
        }

        public List<ChatMessage> GetMessages(int conversationId, int skip, int top)
        {
            return GetMessages(CurrentAccount, conversationId, skip, top);
        }

        public List<ChatMessage> GetMessages(int accountId, int conversationId, int skip, int top)
        {
            return Api.Get<List<ChatMessage>>($"/account/{accountId}/chat/conversation/{conversationId}", false, new { skip, top });
        }

        public List<ChatConversation> FindConversations(string needle, int skip, int top, out int count)
        {
            return FindConversations(CurrentAccount, needle, skip, top, out count);
        }

        public List<ChatConversation> FindConversations(int accountId, string needle, int skip, int top, out int count)
        {
            count = top + 1;
            return Api.Post<List<ChatConversation>>($"/account/{accountId}/conversation/search", needle.Trim(), new { skip, top });
        }

        public List<ChatConversation> GetConversations(int accountId, out int totalCount, int skip = 0, int top = 20, bool throwIfEmpty = false)
        {
            totalCount = top + 1;
            return Api.Get<List<ChatConversation>>($"/account/{accountId}/chat/conversation", throwIfEmpty, new { skip, top });
        }

        public List<ChatConversation> GetConversations(out int totalCount, int skip = 0, int take = 20, bool throwIfEmpty = false)
        {
            return GetConversations(CurrentAccount, out totalCount, skip, take, throwIfEmpty);
        }

        public ChatToken GetToken()
        {
            return GetToken(CurrentAccount);
        }

        public ChatToken GetToken(int accountId)
        {
            return Api.Get<ChatToken>($"/chattoken/{accountId}", true);
        }

        public ChatConfig GetItem(bool throwIfEmpty = true)
        {
            return GetItem(CurrentAccount, throwIfEmpty);
        }

        public ChatConfig GetItem(int accountId, bool throwIfEmpty = true)
        {
            return Api.Get<ChatConfig>($"/account/{accountId}/chatconfig/", throwIfEmpty);
        }

        public ChatConfig Update(int accountId, ChatConfig config)
        {
            return Api.Put($"/account/{accountId}/chatconfig/", config);
        }

        public ChatConfig Update(ChatConfig config)
        {
            return Update(CurrentAccount, config);
        }
    }
}
