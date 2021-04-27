namespace TrueDialog.Model
{
    /// <summary>
    /// Different Action Types
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// This Action type lets you Attach a keyword to a Campaign
        /// </summary>
        AttachKeyword = 1,

        /// <summary>
        /// This Action Type lets you send an SMS
        /// </summary>
        SendSMS = 2,

        /// <summary>
        /// This Action Type lets you push a campaign to a contact ot a list of contacts usign a contact list
        /// </summary>
        PushCampaign = 3,

        /// <summary>
        /// This Action Type triggers a Callback on a Dialog Campaign
        /// </summary>
        DialogCallback = 4,

        /// <summary>
        /// This Action Type triggers a callback when a contact Text in STOP
        /// </summary>
        StopCallback = 5,

        /// <summary>
        /// This Action Type triggers a callback when a contact Text in a Keyword
        /// </summary>
        KeywordCallback = 6,

        /// <summary>
        /// This Action Type triggers a callback on an new account signup via chargify
        /// </summary>
        ChargifyCallback = 7,

        /// <summary>
        /// This Action Type triggers a callback on an account creation
        /// </summary>
        NewAccountCallback = 8,

        /// <summary>
        /// This Action Type lets you import list of contacts into the system from a CSV file.
        /// </summary>
        ImportContacts = 13,

        /// <summary>
        /// This Action Type lets you Kill a push campaign if its not yet triggered
        /// </summary>
        KillCampaignPush = 14


    }
}
