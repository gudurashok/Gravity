using System.Linq;
using Gravity.Root.Common;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Synergy.Domain.Entities;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.Model
{
    public class TaskReminder
    {
        public TaskReminderEntity Entity { get; private set; }
        private static int _reminderCount;

        public TaskReminder(TaskReminderEntity entity)
        {
            Entity = entity;
        }

        public static TaskReminder New()
        {
            return new TaskReminder(TaskReminderEntity.New());
        }

        public void Save()
        {
            EntityValidator.Validate(Entity);
            var repo = new TaskRepository();
            repo.Save(Entity);
        }

        public static void DeleteReminderOfCurrentUser(TaskReminder reminder)
        {
            var repo = new TaskRepository();
            if (reminder.Entity.UserIds.Count > 1)
            {
                reminder.Entity.UserIds = reminder.Entity.UserIds
                                                .Where(u => u.ToString() != GravitySession.User.Entity.Id)
                                                .ToList();

                repo.Save(reminder.Entity);
                return;
            }

            repo.DeleteById(reminder.Entity.Id);
        }

        public static void DeleteAllRemindersOfCurrentUser()
        {
            var repo = new TaskReminders();
            var reminders = repo.SearchItems(new PicklistSearchCriteria(false, 4096));

            foreach (var reminder in reminders)
                DeleteReminderOfCurrentUser(reminder.Reminder);
        }

        public static bool HaveAnyNewRemindersForCurrentUser()
        {
            var repo = new TaskRepository();
            var count = repo.GetReminderCount(GravitySession.User.Entity.Id);
            if (_reminderCount == count)
                return false;

            if (_reminderCount > count)
            {
                _reminderCount = count;
                return false;
            }

            _reminderCount = count;
            return _reminderCount != 0;
        }

        public static TaskReminder GetReminderForSelectedTask(string taskId, string userId)
        {
            var repo = new TaskRepository();
            var entity = repo.GetReminderByTaskAndUserId(taskId, userId);
            return entity == null ? null : new TaskReminder(entity);
        }
    }
}
