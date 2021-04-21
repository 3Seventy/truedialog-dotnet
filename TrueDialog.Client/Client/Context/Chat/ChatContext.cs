using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ChatContext : BaseContext
    {
        internal ChatContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "/account/{accountId}/chatconfig/";
        private const string TOKEN = "/chattoken/{accountId}";
        private const string CONVERSATION_LIST = "account/{accountId}/chat/conversation";
        private const string CONVERSATION_ITEM = "account/{accountId}/chat/conversation/{conversationId}";
        private const string SEARCH_CONVERSATION = "account/{accountId}/conversation/search";
        private const string CONTACT_LOOKUP = "account/{accountId}/contactLookup";

        public List<ContactLookupRow> ContactLookup(ContactLookupOptions options, out int count)
        {
            return ContactLookup(CurrentAccount, options, out count);
        }

        public List<ContactLookupRow> ContactLookup(int accountId, ContactLookupOptions options, out int count)
        {
            var request = TDClient.BuildRequest(Method.POST, CONTACT_LOOKUP, new { accountId }, options);
            var response = TDClient.InnerExecute(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                count = 0;
                return new List<ContactLookupRow>();
            }

            var rval = response.Deserialize<List<ContactLookupRow>>();
            var countHeader = response.Headers.FirstOrDefault(p => p.Name == "X-TrueDialog-Count");
            count = countHeader != null ? int.Parse(countHeader.Value.ToString()) : rval.Count;

            return rval;
        }

        public void StopConversation(int conversationId)
        {
            StopConversation(CurrentAccount, conversationId);
        }

        public void StopConversation(int accountId, int conversationId)
        {
            TDClient.Delete(CONVERSATION_ITEM, new { accountId, conversationId });
        }

        public void HideConversation(int conversationId)
        {
            HideConversation(CurrentAccount, conversationId);
        }

        public void HideConversation(int accountId, int conversationId)
        {
            TDClient.Update(CONVERSATION_ITEM, new { accountId, conversationId }, new ChatConversation
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
            IRestRequest request = TDClient.BuildRequest(Method.GET, CONVERSATION_ITEM, new { accountId, conversationId }, filter: string.Format("$skip={0}&$top={1}", skip, top));

            IRestResponse response = TDClient.InnerExecute(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
                return new List<ChatMessage>();

            var res = response.Deserialize<List<ChatMessage>>();

            return res;
        }

        public List<ChatConversation> FindConversations(string needle, int skip, int top, out int count)
        {
            return FindConversations(CurrentAccount, needle, skip, top, out count);
        }

        public List<ChatConversation> FindConversations(int accountId, string needle, int skip, int top, out int count)
        {
            IRestRequest request = TDClient.BuildRequest(Method.POST, SEARCH_CONVERSATION, new { accountId }, needle.Trim(), filter: string.Format("$skip={0}&$top={1}", skip, top));
            IRestResponse response = TDClient.InnerExecute(request);

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                count = 0;
                return new List<ChatConversation>();
            }

            var rval = response.Deserialize<List<ChatConversation>>();
            var countHeader = response.Headers.FirstOrDefault(p => p.Name == "X-TrueDialog-Count");
            count = countHeader != null ? int.Parse(countHeader.Value.ToString()) : rval.Count;

            return rval;
        }

        public List<ChatConversation> GetConversations(int accountId, out int totalCount, int skip = 0, int take = 20, bool throwIfEmpty = false)
        {
            //"X-TrueDialog-Count";
            IRestRequest request = TDClient.BuildRequest(Method.GET, CONVERSATION_LIST, new { accountId }, filter: string.Format("$skip={0}&$top={1}", skip, take));
            IRestResponse response = TDClient.InnerExecute(request);

            var rval = TDClient.ProcessListResponse<ChatConversation>(request, response, throwIfEmpty);
            var countHeader = response.Headers.FirstOrDefault(p => p.Name == "X-TrueDialog-Count");
            totalCount = countHeader != null ? int.Parse(countHeader.Value.ToString()) : rval.Count;

            return rval;
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
            var rval = TDClient.GetItem<ChatToken>(TOKEN, new { accountId });
            return rval;
        }

        public ChatConfig GetItem(bool throwIfEmpty = true)
        {
            return GetItem(CurrentAccount, throwIfEmpty);
        }

        public ChatConfig GetItem(int accountId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ChatConfig>(ITEM, new { accountId });
            return rval;
        }

        public ChatConfig Update(int accountId, ChatConfig config)
        {
            var rval = TDClient.Update<ChatConfig>(ITEM, new { accountId }, config);
            return rval;
        }

        public ChatConfig Update(ChatConfig config)
        {
            return Update(CurrentAccount, config);
        }
    }
}
