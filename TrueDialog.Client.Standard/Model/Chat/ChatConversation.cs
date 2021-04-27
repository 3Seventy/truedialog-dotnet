using System;

namespace TrueDialog.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class ChatConversation
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AssignedTo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool AutoResponded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ContactId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RealTarget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int UnreadCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Unsubscribed { get; set; }
    }
}
