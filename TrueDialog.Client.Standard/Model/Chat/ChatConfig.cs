namespace TrueDialog.Model
{
    public class ChatConfig : BaseAudited
    {
        /// <summary>
        /// The account this chat object is for.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Set if the server should auto generate a name for newly connected SMS clients.
        /// </summary>
        /// <remarks>
        /// If set, then the name generated will be their phone number with the country dialing code 
        /// replaced with the ISO 3166-1 ISO code. If not set, then the user will be prompted to send a name.
        /// </remarks>
        public bool AutoGenerateName { get; set; }

        /// <summary>
        /// The name of the channel to perform summons on.
        /// </summary>
        /// <remarks>
        /// When a user sends a /SUMMMON command this is the channel we'll use for summoning the mobile user to chat.
        /// </remarks>
        public string SummonChannel { get; set; }

        /// <summary>
        /// Set to the group chat name to use for newly connecting SMS users.
        /// </summary>
        /// <remarks>
        /// When set, new SMS users will auto join this group chat. This has no effect on
        /// SMS users who join via the SUMMON command.
        /// </remarks>
        public string GroupName { get; set; }

        /// <summary>
        /// By turning this off the user is sent nothing when they first connect.
        /// </summary>
        public bool SendGreeting { get; set; }

        /// <summary>
        /// Set if you want to send auto respond when user answers your chat
        /// </summary>
        public bool AutoResponse { get; set; }

        /// <summary>
        /// Message to send as auto response
        /// </summary>
        public string AutoResponseMessage { get; set; }
    }
}
