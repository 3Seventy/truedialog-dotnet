using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IScheduleContext
    {
        List<ActionSchedule> GetList(int accountId, int actionId, bool throwIfEmpty = false);

        List<ActionSchedule> GetList(int actionId, bool throwIfEmpty = false);

        ActionSchedule GetById(int accountId, int actionId, int scheduleId, bool throwIfEmpty = false);

        ActionSchedule GetById(int actionId, int scheduleId, bool throwIfEmpty = false);

        ActionSchedule Create(int accountId, int actionId, ActionSchedule schedule);

        ActionSchedule Create(int actionId, ActionSchedule schedule);

        ActionSchedule Create(ActionSchedule schedule);

        ActionSchedule Update(int accountId, int actionId, int scheduleId, ActionSchedule schedule);

        ActionSchedule Update(int actionId, int scheduleId, ActionSchedule schedule);

        ActionSchedule Update(ActionSchedule schedule);

        void Delete(int accountId, int actionId, int scheduleId);

        void Delete(int actionId, int scheduleId);

        void Delete(ActionSchedule schedule);
    }
}
