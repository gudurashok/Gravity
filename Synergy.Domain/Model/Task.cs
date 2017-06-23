using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Gravity.Root.Common;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Properties;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.Model
{
    public class Task
    {
        #region Properties

        public TaskEntity Entity { get; set; }
        public Task Parent { get; set; }
        public TaskType Type { get; set; }
        public Project Project { get; set; }
        public Location Location { get; set; }
        public User CreatedBy { get; set; }
        public User AssignedBy { get; set; }
        public User AssignedTo { get; set; }
        public IList<User> CcTo { get; set; }
        public Checklist Checklist { get; set; }

        #endregion

        #region Constructor

        public Task(TaskEntity entity)
        {
            Entity = entity;
            Checklist = new Checklist(Entity.Checklist);
        }

        private Task()
        {
            Entity = new TaskEntity();
            loadDefaults();
            CcTo = new List<User>();
            Checklist = new Checklist(Entity.Checklist);
        }

        private void loadDefaults()
        {
            var repo = new TaskRepository();

            var type = repo.GetPreferredTaskType();
            if (type != null)
                Entity.TypeId = type.Id;

            var location = repo.GetPreferredLocation();
            if (location != null)
                Entity.LocationId = location.Id;

            var project = repo.GetPreferredProject();
            if (project != null)
                Entity.ProjectId = project.Id;
        }

        public static Task New()
        {
            return new Task();
        }

        public static Task GetTaskBy(string taskId)
        {
            var repo = new TaskRepository();
            return new Task(repo.GetTaskEntityBy(taskId));
        }

        public static Task GetFullDetailedTaskBy(string taskId)
        {
            var repo = new TaskRepository();
            return repo.GetFullDetailedTaskBy(taskId);
        }

        #endregion

        #region Save

        public void Save(bool skipSendMessage = false)
        {
            //checkTaskStartingBeforeCreation();
            checkTaskDueBeforeCreation();
            checkTaskStartingAfterDue();
            checkTaskSelfAssignment();
            checkAssignedByAndToAreEqual();
            removeRedundantCcIdsIfExist();

            EntityValidator.Validate(Entity);
            var repo = new TaskRepository();
            repo.SaveTask(Entity);

            if (!skipSendMessage)
                sendTaskCreatedOrModifiedMessages(IsNew());
        }

        private void removeRedundantCcIdsIfExist()
        {
            if (Entity.CcToIds == null)
                return;

            if (!string.IsNullOrWhiteSpace(Entity.CreatedById))
                Entity.CcToIds.Remove(Entity.CreatedById);

            if (!string.IsNullOrWhiteSpace(Entity.AssignedById))
                Entity.CcToIds.Remove(Entity.AssignedById);

            if (!string.IsNullOrWhiteSpace(Entity.AssignedToId))
                Entity.CcToIds.Remove(Entity.AssignedToId);
        }

        private int getNewTaskNumber()
        {
            var repo = new TaskRepository();
            return repo.GetNewTaskNumber();
        }

        //private void checkTaskStartingBeforeCreation()
        //{
        //    if (Entity.StartDate.HasValue &&
        //        Entity.StartDate.Value < Entity.CreatedOn)
        //        throw new ValidationException(Resources.TaskCannotStartBeforeCreation);
        //}

        private void checkTaskDueBeforeCreation()
        {
            if (Entity.DueDate.HasValue)
            {
                //TODO: Create Extension method
                if (Entity.DueDate.Value.TimeOfDay == DateTime.MinValue.TimeOfDay)
                {
                    if (Entity.DueDate.Value.Date < Entity.CreatedOn.Date)
                        throw new ValidationException(Resources.TaskCannotDueBeforeCreation);
                }
                else
                {
                    if (Entity.DueDate.Value < Entity.CreatedOn)
                        throw new ValidationException(Resources.TaskCannotDueBeforeCreation);
                }
            }
        }

        private void checkTaskStartingAfterDue()
        {
            if (Entity.StartDate.HasValue && Entity.DueDate.HasValue)
            {
                //TODO: Create Extension method
                if (Entity.DueDate.Value.TimeOfDay == DateTime.MinValue.TimeOfDay)
                {
                    if (Entity.StartDate.Value.Date > Entity.DueDate.Value.Date)
                        throw new ValidationException(Resources.TaskCannotStartAfterDueDate);
                }
                else
                {
                    if (Entity.StartDate.Value > Entity.DueDate)
                        throw new ValidationException(Resources.TaskCannotStartAfterDueDate);
                }
            }
        }

        private void checkTaskSelfAssignment()
        {
            if (Entity.CreatedById == Entity.AssignedById ||
                Entity.CreatedById == Entity.AssignedToId)
                throw new ValidationException(Resources.CannotAssignToSelf);
        }

        private void checkAssignedByAndToAreEqual()
        {
            if (!string.IsNullOrWhiteSpace(Entity.AssignedById) &&
                        Entity.AssignedById == Entity.AssignedToId)
                throw new ValidationException(Resources.AssignedByAndToUserCannotBeEqual);
        }

        private void sendTaskCreatedOrModifiedMessages(bool isNew)
        {
            if (!IsTaskCreatedOnBehalf() && isSelfTask())
                return;

            if (isNew)
                TaskMessage.SendTaskCreationMessage(this);
            else
                TaskMessage.SendTaskModificationMessage(this);
        }

        public bool IsTaskCreatedOnBehalf()
        {
            return GravitySession.User.Entity.Id != Entity.CreatedById &&
                   Entity.AssignedToId != GravitySession.User.Entity.Id &&
                   Entity.AssignedById != GravitySession.User.Entity.Id;
        }

        private bool isSelfTask()
        {
            return string.IsNullOrWhiteSpace(Entity.AssignedById) &&
                   string.IsNullOrWhiteSpace(Entity.AssignedToId) &&
                   (Entity.CcToIds == null || Entity.CcToIds.Count == 0);
        }

        #endregion

        #region Complete

        public void Complete()
        {
            Entity.Status = TaskStatus.Completed;
            Entity.CompletedOn = DateTime.Now;
            Save(true);
            TaskMessage.SendTaskCompletionMessage(this);
        }

        #endregion

        #region Cancel & Reopen

        public void Cancel(string reason, User user)
        {
            Entity.Status = TaskStatus.Cancelled;
            Entity.CompletedOn = DateTime.Now;
            saveComment(string.Format("CANCELLED DUE TO: {0}", reason), user, true);
            Save(true);
            TaskMessage.SendTaskCancelationMessage(this);
        }

        public void Reopen(string reason, User user)
        {
            Entity.Status = TaskStatus.Pending;
            Entity.Recurrence = null;
            Entity.CompletedOn = null;
            saveComment(string.Format("RE-OPENED BECAUSE: {0}", reason), user, true);
            Save(true);
            TaskMessage.SendTaskReopeningMessage(this);
        }

        private void saveComment(string reason, User user, bool skipSendMessage = false)
        {
            var commentEntity = TaskCommentEntity.New();
            commentEntity.Comment = reason;
            commentEntity.TaskId = Entity.Id;
            commentEntity.UserId = user.Entity.Id;

            new TaskComment(commentEntity).Save(skipSendMessage);
        }

        #endregion

        #region Update Progress

        public void UpdateProgress()
        {
            if (Entity.CompletePct == 100)
            {
                Complete();
                return;
            }

            Entity.CompletedOn = DateTime.Now;
            Save(true);
            TaskMessage.SendTaskProgressionMessage(this);
        }

        #endregion

        #region Status Queries

        private bool _wasNew;
        
        public bool WasNew
        {
            get { return _wasNew; }
            set { _wasNew = value; }
        }
        
        public bool IsNew()
        {
            return Entity.Id == EntityPrefix.TaskPrefix;
        }

        public bool CanUpdateStatus(TaskUpdateAction action, User user)
        {
            if (IsNew())
                return true;

            refreshEntity();

            switch (action)
            {
                case TaskUpdateAction.Cancel:
                    return CanCancel(user);
                case TaskUpdateAction.Complete:
                    return CanComplete(user);
                case TaskUpdateAction.Reopen:
                    return CanReopen(user);
                case TaskUpdateAction.Edit:
                    return CanEdit(user);
                default:
                    throw new ArgumentOutOfRangeException("action");
            }
        }

        private void refreshEntity()
        {
            var repo = new TaskRepository();
            Entity = repo.Read<TaskEntity>(Entity.Id);
        }

        public bool CanCancel(User user)
        {
            return Entity.Status == TaskStatus.Pending && canCancelInternal(user);
        }

        private bool canCancelInternal(User user)
        {
            return (user.Entity.Id == Entity.CreatedById ||
                    (!string.IsNullOrWhiteSpace(Entity.AssignedById) &&
                     user.Entity.Id == Entity.AssignedById));
        }

        public bool CanComplete(User user)
        {
            return Entity.Status == TaskStatus.Pending &&
                    (Entity.CreatedById == user.Entity.Id ||
                    Entity.AssignedById == user.Entity.Id ||
                    Entity.AssignedToId == user.Entity.Id);
        }

        private bool canCompleteInternal(User user)
        {
            if (string.IsNullOrWhiteSpace(Entity.AssignedToId))
                return user.Entity.Id == Entity.CreatedById;

            return user.Entity.Id == Entity.AssignedToId;
        }

        public bool CanReopen(User user)
        {
            if (Entity.Status == TaskStatus.Pending)
                return false;

            if (Entity.Status == TaskStatus.Cancelled)
                return canCancelInternal(user);

            if (Entity.Status == TaskStatus.Completed)
                return canCompleteInternal(user);

            return false;
        }

        public bool CanEdit(User user)
        {
            return IsNew() || CanCancel(user);
        }

        #endregion

        #region ToStrings

        public string ToStringTaskInfo(User user)
        {
            if (IsNew())
                return "";

            var result = new StringBuilder();

            result.Append(string.Format("CREATED ON: {0} {1}",
                                Entity.CreatedOn.ToShortDateString(),
                                Entity.CreatedOn.ToShortTimeString()));

            if (!string.IsNullOrWhiteSpace(Entity.AssignedById))
            {
                if (user.Entity.Id == Entity.AssignedById)
                    result.Append(", ASSIGNED TO: ").Append(CreatedBy.Entity.Name);
                else
                    result.Append(", ASSIGNED BY: ").Append(AssignedBy.Entity.Name);
            }

            if (!string.IsNullOrWhiteSpace(Entity.AssignedToId))
            {
                if (user.Entity.Id == Entity.AssignedToId)
                    result.Append(", ASSIGNED BY: ").Append(CreatedBy.Entity.Name);
                else
                    result.Append(", ASSIGNED TO: ").Append(AssignedTo.Entity.Name);
            }

            if (!string.IsNullOrWhiteSpace(Entity.TypeId))
                result.Append(", TYPE: ").Append(Type.Entity.Name);

            if (!string.IsNullOrWhiteSpace(Entity.ProjectId))
                result.Append(", PROJECT: ").Append(Project.Entity.Name);

            if (!string.IsNullOrWhiteSpace(Entity.LocationId))
                result.Append(", LOCATION: ").Append(Location.Entity.Name);

            if (!string.IsNullOrWhiteSpace(Entity.EstimatedTime))
                result.Append(", ESTIMATED TIME: ").Append(Entity.EstimatedTime);

            if (Entity.CompletedOn.HasValue)
                result.Append(string.Format(", {0} ON: {1} {2}", Entity.Status.ToString().ToUpper(),
                                    Entity.CompletedOn.Value.ToShortDateString(),
                                    Entity.CompletedOn.Value.ToShortTimeString()));

            return result.ToString();
        }

        public string ToStringComments()
        {
            if (IsNew())
                return "";

            var repo = new TaskRepository();
            var comments = new StringBuilder();

            foreach (var comment in repo.GetCommentsOf(Entity.Id).OrderByDescending(c => c.Entity.CommentedOn))
                comments.AppendLine(comment.ToString());

            return comments.ToString();
        }

        public string GetTaskNumber()
        {
            var id = Entity.Id;
            return id.Replace(EntityPrefix.TaskPrefix, "");
        }

        public static string GetTaskNumber(string taskId)
        {
            return taskId.Replace(EntityPrefix.TaskPrefix, "");
        }


        #endregion
    }
}
