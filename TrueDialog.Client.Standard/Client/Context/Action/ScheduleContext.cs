using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ScheduleContext : BaseContext, IScheduleContext
    {
        internal ScheduleContext(IApiCaller api) : base(api)
        {
        }
        
        public List<ActionSchedule> GetList(int accountId, int actionId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ActionSchedule>>($"/account/{accountId}/action/{actionId}/schedule", throwIfEmpty);
        }

        public List<ActionSchedule> GetList(int actionId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, actionId, throwIfEmpty);
        }

        public ActionSchedule GetById(int accountId, int actionId, int scheduleId, bool throwIfEmpty = false)
        {
            return Api.Get<ActionSchedule>($"/account/{accountId}/action/{actionId}/schedule/{scheduleId}", throwIfEmpty);
        }

        public ActionSchedule GetById(int actionId, int scheduleId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, actionId, scheduleId, throwIfEmpty);
        }

        public ActionSchedule Create(int accountId, int actionId, ActionSchedule schedule)
        {
            return Api.Post($"/account/{accountId}/action/{actionId}/schedule", schedule);
        }

        public ActionSchedule Create(int actionId, ActionSchedule schedule)
        {
            int accountId = schedule.AccountId > 0 ? schedule.AccountId : CurrentAccount;
            return Create(accountId, actionId, schedule);
        }

        public ActionSchedule Create(ActionSchedule schedule)
        {
            if (schedule.ActionId == 0)
                throw new ArgumentException("Action ID is missing.");

            int accountId = schedule.AccountId > 0 ? schedule.AccountId : CurrentAccount;
            return Create(accountId, schedule.ActionId, schedule);
        }

        public ActionSchedule Update(int accountId, int actionId, int scheduleId, ActionSchedule schedule)
        {
            return Api.Put($"/account/{accountId}/action/{actionId}/schedule/{scheduleId}", schedule);
        }

        public ActionSchedule Update(int actionId, int scheduleId, ActionSchedule schedule)
        {
            return Update(CurrentAccount, actionId, scheduleId, schedule);
        }

        public ActionSchedule Update(ActionSchedule schedule)
        {
            if (schedule.ActionId == 0)
                throw new ArgumentException("Action ID is missing.");
            if (schedule.Id == 0)
                throw new ArgumentException("Schedule ID is missing.");

            int accountId = schedule.AccountId > 0 ? schedule.AccountId : CurrentAccount;

            return Update(accountId, schedule.ActionId, schedule.Id, schedule);
        }

        public void Delete(int accountId, int actionId, int scheduleId)
        {
            Api.Delete($"/account/{accountId}/action/{actionId}/schedule/{scheduleId}");
        }

        public void Delete(int actionId, int scheduleId)
        {
            Delete(CurrentAccount, actionId, scheduleId);
        }

        public void Delete(ActionSchedule schedule)
        {
            if (schedule.ActionId == 0)
                throw new ArgumentException("Action ID is missing.");
            if (schedule.Id == 0)
                throw new ArgumentException("Schedule ID is missing.");

            int accountId = schedule.AccountId > 0 ? schedule.AccountId : CurrentAccount;

            Delete(accountId, schedule.ActionId, schedule.Id);
        }
    }
}
