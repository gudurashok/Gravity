using System;
using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Common;
using Gravity.Root.Repositories;
using Raven.Client;
using Raven.Client.Linq;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Entities;
using Synergy.Domain.Model;
using Synergy.Domain.ViewModel;

namespace Synergy.Domain.Repositories
{
    public class TaskReminders : RepositoryBase, IListRepository
    {
        private readonly bool _getAllReminders;

        public TaskReminders(bool getAllReminders = false)
        {
            _getAllReminders = getAllReminders;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                return getTaskReminderQuery(s)
                        .OrderByDescending(r => r.RemindOn)
                        .ToList()
                        .Select(r => new TaskReminderListItem { Reminder = new TaskReminder(r) })
                        .Cast<dynamic>().ToList();
            }
        }

        private IQueryable<TaskReminderEntity> getTaskReminderQuery(IDocumentSession s)
        {
            return _getAllReminders
                       ? s.Query<TaskReminderEntity>()
                            .Where(r => r.UserIds.Any(id => id == GravitySession.User.Entity.Id))
                       : s.Query<TaskReminderEntity>()
                            .Where(r => r.UserIds.Any(id => id == GravitySession.User.Entity.Id) 
                                        && r.RemindOn <= DateTime.Now);
        }
    }
}
