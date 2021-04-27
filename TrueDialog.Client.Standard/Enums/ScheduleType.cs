namespace TrueDialog.Model
{
    /// <summary>
    /// Event schedule type
    /// </summary>
    /// <remarks>
    /// Currently the only supported types are: Now, OneTime and Daily.
    /// </remarks>
    public enum ScheduleType
    {
        /// <summary>
        /// Event is run immediately.
        /// </summary>
        Now = 1,

        /// <summary>
        /// Event will run once in the future and stop.
        /// </summary>
        OneTime = 2,

        /// <summary>
        /// Event will run every second.
        /// </summary>
        /// <remarks>
        /// This is a place holder value and is not supported.
        /// </remarks>
        Second  = 3,

        /// <summary>
        /// Event will run every minute.
        /// </summary>
        /// <remarks>
        /// This is a place holder value and is not supported.
        /// </remarks>
        Minute  = 4,

        /// <summary>
        /// The event will run every hour.
        /// </summary>
        /// <remarks>
        /// This is a place holder value and is not supported.
        /// </remarks>
        Hour    = 5,

        /// <summary>
        /// The event will run once a day.
        /// </summary>
        Daily   = 6,

        /// <summary>
        /// The event will run once a week.
        /// </summary>
        /// <remarks>
        /// This is a place holder value and is not supported.
        /// </remarks>
        Weekly  = 7,

        /// <summary>
        /// The event will run once a month.
        /// </summary>
        /// <remarks>
        /// This is a place holder value and is not supported.
        /// </remarks>
        Monthly = 8,

        /// <summary>
        /// The event will run once a year.
        /// </summary>
        /// <remarks>
        /// This is a place holder value and is not supported.
        /// </remarks>
        Yearly  = 9
    }
}