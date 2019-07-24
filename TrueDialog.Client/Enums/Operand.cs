using System;

namespace TrueDialog.Model
{
    public enum Operand
    {
        /// <summary>
        /// Filter contacts by subscription ID
        /// </summary>
        /// <remarks>
        /// Can be used with "Subscription" FilterType only.
        /// </remarks>
        SubscriptionID = 1,

        /// <summary>
        /// Filter contacts by the date of creation.
        /// </summary>
        /// <remarks>
        /// Can be used with "Contact" FilterType only.
        /// </remarks>
        Created = 2,

        /// <summary>
        /// Filter contacts by contact ID.
        /// </summary>
        /// <remarks>
        /// Can be used with "Contact" FilterType only.
        /// </remarks>
        Id = 3,

        /// <summary>
        /// Filter contacts by contact's Email field.
        /// </summary>
        /// <remarks>
        /// Can be used with "Contact" FilterType only.
        /// </remarks>
        Email = 4,

        /// <summary>
        /// Filter contacts by contact's PhoneNumber field.
        /// </summary>
        /// <remarks>
        /// Can be used with "Contact" FilterType only.
        /// </remarks>
        Phone = 5,

        /// <summary>
        /// Filter contacts by keyword ID
        /// </summary>
        /// <remarks>
        /// Can be used with "Keyword" FilterType only.
        /// </remarks>
        ContactsByKeyword = 6,

        /// <summary>
        /// Filter contacts by keyword send date.
        /// </summary>
        /// <remarks>
        /// Can be used with "Keyword" FilterType only.
        /// </remarks>
        KeywordSentDate = 7
    }
}
