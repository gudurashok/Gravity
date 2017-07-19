using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Gravity.Root.Model;
using Gravity.Root.Repositories;
using Raven.Client;
using Raven.Client.Linq;
using Scalable.Shared.Common;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Indexes;
using Synergy.Domain.Model;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Repositories
{
    public class TaskRepository : RepositoryBase
    {
        #region Task

        public void SaveTask(TaskEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public static Task GetTaskWithFullDetails(TaskEntity entity, IDocumentSession s)
        {
            var task = new Task(entity);
            fillTaskFullDetails(task, s);
            return task;
        }

        private static void fillTaskFullDetails(Task task, IDocumentSession s)
        {
            task.Parent = string.IsNullOrWhiteSpace(task.Entity.ParentId)
                                ? null : new Task(s.Load<TaskEntity>(task.Entity.ParentId));
            task.Type = string.IsNullOrWhiteSpace(task.Entity.TypeId)
                                ? null : new TaskType(s.Load<TaskTypeEntity>(task.Entity.TypeId));
            task.Project = string.IsNullOrWhiteSpace(task.Entity.ProjectId)
                                ? null : new Project(s.Load<ProjectEntity>(task.Entity.ProjectId));
            task.Location = string.IsNullOrWhiteSpace(task.Entity.LocationId)
                                ? null : new Location(s.Load<LocationEntity>(task.Entity.LocationId));
            task.CreatedBy = string.IsNullOrWhiteSpace(task.Entity.CreatedById)
                                ? null : new User(s.Load<UserEntity>(task.Entity.CreatedById));
            task.AssignedBy = string.IsNullOrWhiteSpace(task.Entity.AssignedById)
                                ? null : new User(s.Load<UserEntity>(task.Entity.AssignedById));
            task.AssignedTo = string.IsNullOrWhiteSpace(task.Entity.AssignedToId)
                                ? null : new User(s.Load<UserEntity>(task.Entity.AssignedToId));
            task.CcTo = getCcToUsers(task.Entity.CcToIds, s);
        }

        private static IList<User> getCcToUsers(IList<string> ccIds, IDocumentSession s)
        {
            return ccIds == null || ccIds.Count == 0
                       ? null
                       : s.Load<UserEntity>(ccIds).ToList()
                          .Select(u => new User(u)).ToList();
        }

        public int GetNewTaskNumber()
        {
            using (var s = Store.OpenSession())
            {
                RavenQueryStatistics stats;
                var result = s.Query<TaskEntity>().Statistics(out stats).Take(0).ToArray();
                return stats.TotalResults + 1;
            }
        }

        public TaskEntity GetTaskEntityBy(string taskId)
        {
            using (var s = Store.OpenSession())
                return s.Load<TaskEntity>(taskId);
        }

        public Task GetTaskByNumber(int taskNr)
        {
            using (var s = Store.OpenSession())
            {
                var taskId = EntityPrefix.TaskPrefix + taskNr;
                var taskEntity = s.Query<TaskEntity>()
                                    .FirstOrDefault(t => t.Id == taskId &&
                                        (t.CreatedById == GravitySession.User.Entity.Id
                                        || t.AssignedById == GravitySession.User.Entity.Id
                                        || t.AssignedToId == GravitySession.User.Entity.Id
                                        || t.CcToIds.Any(u => u == GravitySession.User.Entity.Id)));
                return taskEntity == null ? null : new Task(taskEntity);
            }

        }

        public Task GetFullDetailedTaskBy(string taskId)
        {
            using (var s = Store.OpenSession())
                return GetTaskWithFullDetails(s.Load<TaskEntity>(taskId), s);
        }

        public IList<string> GetAllTaskTags()
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskEntity>()
                        .Select(t => t.Tag)
                        .Distinct()
                        .ToList();
        }

        #endregion

        #region Task template

        public static TaskTemplate GetTaskTemplateWithFullDetails(TaskTemplateEntity entity, IDocumentSession s)
        {
            var template = new TaskTemplate(entity);
            fillTaskTemplateFullDetails(template, s);
            return template;
        }

        private static void fillTaskTemplateFullDetails(TaskTemplate template, IDocumentSession s)
        {
            template.Type = string.IsNullOrWhiteSpace(template.Entity.TypeId)
                                ? null : new TaskType(s.Load<TaskTypeEntity>(template.Entity.TypeId));
            template.Project = string.IsNullOrWhiteSpace(template.Entity.ProjectId)
                                ? null : new Project(s.Load<ProjectEntity>(template.Entity.ProjectId));
            template.Location = string.IsNullOrWhiteSpace(template.Entity.LocationId)
                                ? null : new Location(s.Load<LocationEntity>(template.Entity.LocationId));
            template.AssignedBy = string.IsNullOrWhiteSpace(template.Entity.AssignedById)
                                ? null : new User(s.Load<UserEntity>(template.Entity.AssignedById));
            template.AssignedTo = string.IsNullOrWhiteSpace(template.Entity.AssignedToId)
                                ? null : new User(s.Load<UserEntity>(template.Entity.AssignedToId));
            template.CcTo = getCcToUsers(template.Entity.CcToIds, s);
        }

        #endregion

        #region Task Mesasge

        public void SaveTaskMessage(TaskMessageEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public bool HasAnyNewMessagesForUser(string userId)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskMessageEntity>()
                        .Count(m => m.ToUserId == userId) > 0;
        }

        #endregion

        #region Task Reminder

        public int GetReminderCount(string userId)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskReminderEntity>()
                        .Where(r => r.UserIds.Any(id => id == userId)
                                    && r.RemindOn <= DateTime.Now)
                        .Count();
        }

        #endregion

        #region Task Comment

        public void SaveTaskComment(TaskCommentEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public IEnumerable<TaskComment> GetCommentsOf(string taskId)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskCommentEntity>()
                     .Where(e => e.TaskId == taskId)
                     .ToList()
                     .Select(e => new TaskComment(e) { User = s.Load<UserEntity>(e.UserId) })
                     .ToList();
        }

        public int TaskCommentsCount(string taskId)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskCommentEntity>()
                        .Count(e => e.TaskId == taskId);
        }

        #endregion

        #region Task Checklist

        public IEnumerable<ChecklistEntity> GetAllChecklists()
        {
            using (var s = Store.OpenSession())
                return s.Query<ChecklistEntity>().ToList();
        }

        public void SaveTaskChecklist(ChecklistEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public void DeleteTaskChecklistById(string id)
        {
            checkIsTaskChecklistIsInUse(id);
            base.DeleteById(id);
        }

        private void checkIsTaskChecklistIsInUse(string checklistId)
        {
            var task = GetTaskEntityByTaskChecklistId(checklistId);
            if (task != null)
                throw new ValidationException(string.Format(Resources.TaskChecklistInUse, task.Name));
        }

        private TaskEntity GetTaskEntityByTaskChecklistId(string id)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskEntity>()
                        .FirstOrDefault(t => t.Checklist.Id == id);
        }

        #endregion

        #region Task Types

        public IEnumerable<TaskTypeEntity> GetAllTaskTypes()
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskTypeEntity>().ToList();
        }

        public void SaveTaskType(TaskTypeEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public void SetPreferredTaskType(TaskTypeEntity entity)
        {
            using (var s = Store.OpenSession())
            {
                var types = GetAllTaskTypes();
                foreach (var type in types)
                {
                    type.IsPreferred = entity.Id == type.Id;
                    s.Store(type);
                }

                s.SaveChanges();
            }
        }

        public TaskTypeEntity GetPreferredTaskType()
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskTypeEntity>()
                        .SingleOrDefault(t => t.IsPreferred && t.IsActive);
        }

        public void DeleteTaskTypeById(string id)
        {
            checkIsTaskTypeIsInUse(id);
            base.DeleteById(id);
        }

        private void checkIsTaskTypeIsInUse(string typeId)
        {
            var task = GetTaskEntityByTaskTypeId(typeId);
            if (task != null)
                throw new ValidationException(string.Format(Resources.TaskTypeInUse, task.Name));
        }

        private TaskEntity GetTaskEntityByTaskTypeId(string id)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskEntity>()
                        .FirstOrDefault(t => t.TypeId == id);
        }

        #endregion

        #region Locations

        public IEnumerable<LocationEntity> GetAllLocations()
        {
            using (var s = Store.OpenSession())
                return s.Query<LocationEntity>().ToList();
        }

        public void SaveLocation(LocationEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public void SetPreferredLocation(LocationEntity entity)
        {
            using (var s = Store.OpenSession())
            {
                var locations = GetAllLocations();
                foreach (var location in locations)
                {
                    location.IsPreferred = entity.Id == location.Id;
                    s.Store(location);
                }

                s.SaveChanges();
            }
        }

        public LocationEntity GetPreferredLocation()
        {
            using (var s = Store.OpenSession())
                return s.Query<LocationEntity>()
                        .SingleOrDefault(t => t.IsPreferred && t.IsActive);
        }

        public void DeleteLocationById(string id)
        {
            checkIsLocationIsInUse(id);
            base.DeleteById(id);
        }

        private void checkIsLocationIsInUse(string locationId)
        {
            var task = GetTaskEntityByLocationId(locationId);
            if (task != null)
                throw new ValidationException(string.Format(Resources.LocationInUse, task.Name));
        }

        private TaskEntity GetTaskEntityByLocationId(string id)
        {
            using (var s = Store.OpenSession())
                return s.Load<TaskEntity>(id);
        }

        #endregion

        #region Projects

        public IEnumerable<ProjectEntity> GetAllProjects()
        {
            using (var s = Store.OpenSession())
                return s.Query<ProjectEntity>().ToList();
        }

        public void SaveProject(ProjectEntity entity)
        {
            EntityValidator.Validate(entity);
            base.Save(entity);
        }

        public void SetPreferredProject(ProjectEntity entity)
        {
            using (var s = Store.OpenSession())
            {
                var projects = GetAllProjects();
                foreach (var project in projects)
                {
                    project.IsPreferred = entity.Id == project.Id;
                    s.Store(project);
                }

                s.SaveChanges();
            }
        }

        public ProjectEntity GetPreferredProject()
        {
            using (var s = Store.OpenSession())
                return s.Query<ProjectEntity>()
                        .SingleOrDefault(t => t.IsPreferred && t.IsActive);
        }

        public void DeleteProjectById(string id)
        {
            checkIsProjectIsInUse(id);
            base.DeleteById(id);
        }

        private void checkIsProjectIsInUse(string projectId)
        {
            var task = GetTaskEntityByProjectId(projectId);
            if (task != null)
                throw new ValidationException(string.Format(Resources.ProjectInUse, task.Name));
        }

        private TaskEntity GetTaskEntityByProjectId(string id)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskEntity>()
                        .FirstOrDefault(t => t.ProjectId == id);
        }

        #endregion

        public IList<AppMenuItemEntity> GetAllAppMenuItems()
        {
            var menuItems = new List<AppMenuItemEntity>();

            var menuItem = new AppMenuItemEntity();
            menuItem.Nr = 1;
            menuItem.DisplayOrder = "1";
            menuItem.Name = "Parties";
            menuItem.Caption = "&Parties";
            menuItem.UIControlName = "UParties";
            menuItem.UIControlPath = "Mingle.UC.Controls";
            menuItem.UIAssembly = "Mingle.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.P;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuItem.IsNodeItem = true;
            menuItems.Add(menuItem);

            menuItem = new AppMenuItemEntity();
            menuItem.Nr = 2;
            menuItem.DisplayOrder = "2";
            menuItem.Name = "Tasks";
            menuItem.Caption = "&Tasks";
            menuItem.UIControlName = "UTasks";
            menuItem.UIControlPath = "Synergy.UC.Controls";
            menuItem.UIAssembly = "Synergy.UC.dll";
            menuItem.ShortcutKeys = Keys.Control | Keys.T;
            menuItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuItem.IsNodeItem = true;
            menuItems.Add(menuItem);

            if (GravitySession.User.Entity.IsAdmin)
                return menuItems.OrderBy(m => m.DisplayOrder).ToList();

            return menuItems.Where(m => !m.IsForAdminOnly).OrderBy(m => m.DisplayOrder).ToList();
        }

        public int GetTaskCountByUser(string userId)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<Tasks_Count.ReduceResult, Tasks_Count>()
                            .Where(t => t.UserId == userId)
                            .FirstOrDefault();

                return result != null ? result.Count : 0;
            }
        }

        public IEnumerable<TaskStats> GetAllTaskStats()
        {
            var taskStats = new List<TaskStats>();
            using (var s = Store.OpenSession())
            {
                var users = s.Query<UserEntity>();
                foreach (var user in users)
                {
                    var task = GetTaskStatsByUser(user.Id);
                    task.UserName = user.Name;
                    taskStats.Add(task);
                }
            }

            return taskStats;
        }

        public TaskStats GetTaskStatsByUser(string userId)
        {
            var taskStat = new TaskStats();
            taskStat.UserId = userId;

            using (var s = Store.OpenSession())
            {
                taskStat.Total = getTotalTasks(userId, s);
                taskStat.Pending = getPendingTasks(userId, s);
                taskStat.Cancelled = getCancelledTasks(userId, s);
                taskStat.Completed = getCompletedTasks(userId, s);
                taskStat.NotStarted = getNotStartedTasks(userId, s);
                taskStat.OverDue = getTaskStatsQuery(userId, s)
                                        .Where(t => t.DueDate != null
                                            && ((t.DueDate.Value.TimeOfDay == DateTime.MinValue.TimeOfDay
                                                    && t.DueDate.Value.Date < DateTime.Today)
                                                || (t.DueDate.Value.TimeOfDay != DateTime.MinValue.TimeOfDay
                                                    && t.DueDate.Value < DateTime.Now))
                                            && t.Status == TaskStatus.Pending).Count();
                taskStat.DueToday = getTaskStatsQuery(userId, s)
                                        .Where(t => t.DueDate != null
                                            && t.DueDate.Value.Date == DateTime.Today
                                            && t.Status == TaskStatus.Pending).Count();
                taskStat.DueThisWeek = getTaskStatsQuery(userId, s)
                                        .Where(t => t.DueDate != null
                                            && t.DueDate.Value.Date >= DateTime.Today
                                            && t.DueDate.Value <= DateTime.Today.Add(
                                                new TimeSpan((6 - (int)DateTime.Today.DayOfWeek), 23, 59, 59))
                                            && t.Status == TaskStatus.Pending).Count();
                taskStat.StartedToday = getTaskStatsQuery(userId, s)
                                        .Where(t => t.StartDate != null
                                            && t.StartDate.Value.Date == DateTime.Today
                                            && t.Status == TaskStatus.Pending).Count();
            }
            return taskStat;
        }

        private int getTotalTasks(string userId, IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = getStatsQuery(userId, s)
                            .Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        private int getPendingTasks(string userId, IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = getStatsQuery(userId, s)
                            .Where(t => t.Status == TaskStatus.Pending)
                            .Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        private int getCancelledTasks(string userId, IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = getStatsQuery(userId, s)
                            .Where(t => t.Status == TaskStatus.Cancelled)
                            .Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        private int getCompletedTasks(string userId, IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = getStatsQuery(userId, s)
                            .Where(t => t.Status == TaskStatus.Completed)
                            .Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        private int getNotStartedTasks(string userId, IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = getStatsQuery(userId, s)
                            .Where(t => t.StartDate == null && t.Status == TaskStatus.Pending)
                            .Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        private IRavenQueryable<TaskEntity> getStatsQuery(string userId, IDocumentSession s)
        {
            return s.Query<TaskEntity>()
                    .Where(t => t.CreatedById == userId || t.AssignedById == userId
                            || t.AssignedToId == userId || t.CcToIds.Any(u => u == userId));
        }

        private IEnumerable<TaskEntity> getTaskStatsQuery(string userId, IDocumentSession s)
        {
            return s.Query<TaskEntity>()
                    .Where(t => t.CreatedById == userId || t.AssignedById == userId
                            || t.AssignedToId == userId || t.CcToIds.Any(u => u == userId));
        }

        public TaskExecutionEntity GetTaskExecutionsById(string taskExecutionId)
        {
            using (var s = Store.OpenSession())
                return s.Load<TaskExecutionEntity>(taskExecutionId);
        }

        public TaskReminderEntity GetReminderByTaskAndUserId(string taskId, string userId)
        {
            using (var s = Store.OpenSession())
            {
                return s.Query<TaskReminderEntity>()
                        .Where(r => r.UserIds.Any(id => id == userId)
                                    && r.TaskId == taskId && r.IsDefault)
                        .SingleOrDefault();
            }
        }

        public IList<TaskEntity> GetRecursiveTasks(RecurrenceType recurrenceType)
        {
            using (var s = Store.OpenSession())
            {
                var result = s.Query<TaskEntity>()
                        .Where(r => (r.CreatedById == GravitySession.User.Entity.Id
                                        || r.AssignedById == GravitySession.User.Entity.Id
                                        || r.AssignedToId == GravitySession.User.Entity.Id
                                        || r.CcToIds.Any(u => u == GravitySession.User.Entity.Id))
                                    && r.Recurrence != null
                                    && r.Recurrence.RepeatFrom ==  RecurrenceRepeatFrom.DueDate
                                    && r.Recurrence.Type == recurrenceType
                                    && r.Recurrence.Duplicate)
                        .ToList();

                return result.Where(t => t.DueDate.Value.Date <= DateTime.Today)
                            .OrderByDescending(t => t.CreatedOn)
                            .OrderByDescending(t => t.DueDate.Value)
                            .OrderByDescending(t => t.Id).ToList();
            }
        }

        public TaskTemplateEntity GetTemplateByName(string name)
        {
            using (var s = Store.OpenSession())
                return s.Query<TaskTemplateEntity>()
                        .FirstOrDefault(t => t.Name == name);
        }

        public IList<Task> GetTasksContaining(string searchText)
        {
            using (var s = Store.OpenSession())
            {
                var query = s.Query<Task_Search.Result, Task_Search>()
                            .Search(p => p.SearchQuery, searchText,
                                escapeQueryOptions: EscapeQueryOptions.AllowAllWildcards)
                            .As<Task_Search.Result>().ToList();

                return query.Count == 0
                            ? null
                            : s.Load<TaskEntity>(query.Select(i => i.TaskId).Distinct().ToList())
                                .Where(t => (t.CreatedById == GravitySession.User.Entity.Id
                                            || t.AssignedById == GravitySession.User.Entity.Id
                                            || t.AssignedToId == GravitySession.User.Entity.Id
                                            || (t.CcToIds != null && t.CcToIds.Any(u => u == GravitySession.User.Entity.Id))))
                                .Select(t => GetTaskWithFullDetails(t, s)).ToList();
            }
        }

        public IList<string> GetSearchSuggestions(string searchText)
        {
            using (var s = Store.OpenSession())
                return s.Query<Task_Search.Result, Task_Search>()
                        .Search(p => p.SearchQuery, searchText,
                                escapeQueryOptions: EscapeQueryOptions.AllowAllWildcards)
                        .As<Task_Search.Result>()
                        .Suggest().Suggestions;
        }
    }
}
