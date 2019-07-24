using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ScheduleContext : BaseContext
    {
        internal ScheduleContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "account/{accountId}/action/{actionId}/schedule";
        private const string ITEM = "account/{accountId}/action/{actionId}/schedule/{scheduleId}";
        
        public List<ActionSchedule> GetList(int accountId, int actionId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ActionSchedule>(LIST, new { accountId, actionId }, throwIfEmpty);
            return rval;
        }

        public List<ActionSchedule> GetList(int actionId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, actionId, throwIfEmpty);
        }

        public ActionSchedule GetById(int accountId, int actionId, int scheduleId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetItem<ActionSchedule>(ITEM, new { accountId, actionId, scheduleId }, throwIfEmpty);
            return rval;
        }

        public ActionSchedule GetById(int actionId, int scheduleId, bool throwIfEmpty = false)
        {
            return GetById(CurrentAccount, actionId, scheduleId, throwIfEmpty);
        }

        public ActionSchedule Create(int accountId, int actionId, ActionSchedule schedule)
        {
            var rval = TDClient.Add(LIST, new { accountId, actionId }, schedule);
            return rval;
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
            var rval = TDClient.Update(ITEM, new { accountId, actionId, scheduleId }, schedule);
            return rval;
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
            TDClient.Delete(ITEM, new { accountId, actionId, scheduleId });
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
