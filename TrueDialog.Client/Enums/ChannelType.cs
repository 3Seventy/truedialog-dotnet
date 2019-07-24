namespace TrueDialog.Model
{
    /// <summary>
    /// The type of messages that can be sent on a channel.
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// Channel is for sending plain text SMS messages.
        /// </summary>
        Sms     = 0,

        /// <summary>
        /// Channel supports sending large format messages such as images.
        /// </summary>
        Mms     = 1,

        /// <summary>
        /// Channel is for sending email messages.
        /// </summary>
        Email   = 2,

        /// <summary>
        /// Channel is for voice/audio messages.
        /// </summary>
        Voice   = 3,

        /// <summary>
        /// The channel is for testing and the messages will be discarded after being logged.
        /// </summary>
        /// <remarks>
        /// This channel behaves the same as the SMS channel type, but messages are not delivered to the target.
        /// </remarks>
        Null    = 4
    }
}