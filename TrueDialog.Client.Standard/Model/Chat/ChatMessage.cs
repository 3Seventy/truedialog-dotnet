using System;

namespace TrueDialog.Model
{
    public class ChatMessage
    {
        public ChatMessage()
        {
            Weight = 1;
        }

        public Guid Id { get; set; }

        public DateTime LogDate { get; set; }

        public int ConversationId { get; set; }

        public bool Incoming { get; set; }

        public string Message { get; set; }

        public string Sender { get; set; }

        public bool Viewed { get; set; }

        public int Weight { get; set; }

        public string MessageId { get; set; }

        public int StatusId { get; set; }

        public int ConcatId { get; set; }

        public int ConcatNum { get; set; }

        public int ConcatCount { get; set; }
    }
}
