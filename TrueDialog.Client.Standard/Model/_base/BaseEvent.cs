using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TrueDialog.Model
{
    /// <summary />
    public class BaseEvent : BaseAudited
    {
        /// <summary>
        /// The account ID that the event reports under.
        /// </summary>
        [DataMember]
        public int AccountId { get; set; }

        /// <summary>
        /// The name of the event.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        #region schedule parameters

        /// <summary>
        /// Schedule Type Id: Now, OneTime, second, minute, hour, daily, weekly, monthly, yearly.
        /// </summary>
        [DataMember]
        public int ScheduleTypeId { get; set; }

        /// <summary>
        /// Value in seconds (0-60), minutes(0-60) or hours(1-12)  if repeated after specified interval.
        /// Days of the week use a bit mask to specify when to run:
        /// 
        /// 0x01 = Monday 
        /// 0x02 = Tuesday
        /// 0x04 = Wednesday
        /// 0x08 = Thursday
        /// 0x10 = Friday
        /// 0x20 = Saturday
        /// 0x40 = Sunday
        /// 0x7F = Every day
        /// </summary>
        [DataMember]
        public int Interval { get; set; }

        /// <summary>
        /// Starting time for the recurring schedule. Ex: Every 15 mins from 4am to 8 am.
        /// </summary>
        [DataMember]
        public DateTime? StartDateTime { get; set; }

        /// <summary>
        /// End time for the recurring schedule. Ex: Every 15 mins from 4am to 8 am.
        /// </summary>
        [DataMember]
        public DateTime? EndDateTime { get; set; }

        /// <summary>
        /// Specify when the recurring schedule occurs during the week. Values can be 1-7 or MON,TUE,WED,THU,FRI,SAT,SUN
        /// Multiple values can be specified using comma as delimiter. Use * for all days.
        /// </summary>
        [DataMember]
        public string DayOfWeek { get; set; }

        /// <summary>
        /// Day of month. 1-31 depending on which month. * for all months
        /// </summary>
        [DataMember]
        public string DayOfMonth { get; set; }

        /// <summary>
        /// Month :0 and 11, or by using the strings JAN, FEB, MAR, APR, MAY, JUN, JUL, AUG, SEP, OCT, NOV and DEC. * for all months
        /// </summary>
        [DataMember]
        public string Month { get; set; }

        /// <summary>
        /// Year. 4 digit or comma delimited for multiple years. ex: 2013 or 2013,2014.
        /// </summary>
        [DataMember]
        public string Year { get; set; }

        /// <summary>
        /// Enumeration mapping for ScheduleTypeId
        /// </summary>
        [IgnoreDataMember]
        public ScheduleType ScheduleType
        {
            get { return (ScheduleType)ScheduleTypeId; }
            set { ScheduleTypeId = (int)value; }
        }

        #endregion
    }
}
