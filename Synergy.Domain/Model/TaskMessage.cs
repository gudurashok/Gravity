using System;
using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Common;
using Scalable.Shared.Model;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Repositories;
using Scalable.Shared.Common;

namespace Synergy.Domain.Model
{
    public class TaskMessage
    {
        public TaskMessageEntity Entity { get; private set; }

        public TaskMessage(TaskMessageEntity entity)
        {
            Entity = entity;
        }

        private TaskMessage()
        {
            Entity = TaskMessageEntity.New();
        }

        private static TaskMessage New()
        {
            return new TaskMessage();
        }

        public static void SendAcknowledgementForAllMessages()
        {
            var messages = getNonAckMessagesOfCurrentUser();
            foreach (var message in messages)
                SendAcknowledgement(message);
        }

        private static IEnumerable<TaskMessage> getNonAckMessagesOfCurrentUser()
        {
            var repo = new TaskMessages();
            return repo.SearchItems(new PicklistSearchCriteria(false, 4096))
                       .Where(m => m.Entity.Type != TaskUpdateType.Acknowledged)
                       .Select(m => new TaskMessage(m.Entity));
        }

        public static void SendAcknowledgement(TaskMessage message)
        {
            saveMessage(Task.GetTaskBy(message.Entity.TaskId),
                        message.Entity.ByUserId,
                        TaskUpdateType.Acknowledged);
        }

        public static void SendTaskCreationMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.Created);
        }

        public static void SendTaskModificationMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.Modified);
        }

        public static void SendTaskChecklistUpdatedMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.ChecklistUpdated);
        }

        public static void SendTaskCancelationMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.Cancelled);
        }

        public static void SendTaskReopeningMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.Reopened);
        }

        public static void SendTaskProgressionMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.ProgressChanged);
        }

        public static void SendTaskCompletionMessage(Task task)
        {
            sendTaskMessage(task, TaskUpdateType.Completed);
        }

        public static void SendCommentAddedOnTaskMessage(TaskComment comment)
        {
            sendTaskMessage(comment.Task, TaskUpdateType.Commented);
        }

        private static void sendTaskMessage(Task task, TaskUpdateType updateType)
        {
            if (task.IsTaskCreatedOnBehalf())
                saveMessage(task, task.Entity.CreatedById, updateType);

            if (!string.IsNullOrWhiteSpace(task.Entity.AssignedById))
                saveMessage(task, getByUserId(task), updateType);

            if (!string.IsNullOrWhiteSpace(task.Entity.AssignedToId))
                saveMessage(task, getToUserId(task), updateType);

            if (task.Entity.CcToIds == null)
                return;

            foreach (var userId in task.Entity.CcToIds)
                saveMessage(task, userId, updateType);
        }

        private static string getByUserId(Task task)
        {
            return !string.IsNullOrWhiteSpace(task.Entity.CreatedById) &&
                    task.Entity.AssignedById == GravitySession.User.Entity.Id
                       ? task.Entity.CreatedById
                       : task.Entity.AssignedById;
        }

        private static string getToUserId(Task task)
        {
            return !string.IsNullOrWhiteSpace(task.Entity.CreatedById) &&
                    task.Entity.AssignedToId == GravitySession.User.Entity.Id
                       ? task.Entity.CreatedById
                       : task.Entity.AssignedToId;
        }

        public static bool HasAnyNewMessagesForCurrentUser()
        {
            var repo = new TaskRepository();
            return repo.HasAnyNewMessagesForUser(GravitySession.User.Entity.Id);
        }

        public override string ToString()
        {
            return string.Format(@"Task #{0} '{1}', Has been {2}, By {3} On: {4} {5}",
                                Task.GetTaskNumber(Entity.TaskId), Entity.TaskName,
                                EnumUtil.GetEnumDescription(Entity.Type),
                                Entity.ByUserName,
                                Entity.DateTime.ToShortDateString(),
                                Entity.DateTime.ToShortTimeString());
        }

        public static void DeleteMessageOfCurrentUser(TaskMessage message)
        {
            var repo = new TaskRepository();
            repo.DeleteById(message.Entity.Id);
        }

        public static void DeleteAllNonAcknowledgementMessages()
        {
            var repo = new TaskRepository();
            foreach (var message in getNonAckMessagesOfCurrentUser())
                repo.DeleteById(message.Entity.Id);
        }

        public static void DeleteAllMessagesOfCurrentUser()
        {
            var repo = new TaskMessages();
            var messages = repo.SearchItems(new PicklistSearchCriteria(false, 4096));

            foreach (var message in messages.Select(m => m.Entity))
                repo.DeleteById(message.Id);
        }

        private static void saveMessage(Task task, string userId, TaskUpdateType updateType)
        {
            var message = New();
            message.Entity.ToUserId = userId;
            message.Entity.Type = updateType;

            message.Entity.TaskId = task.Entity.Id;
            //message.Entity.TaskNumber = task.GetTaskNumber();
            message.Entity.TaskName = task.Entity.Name;
            message.Entity.ByUserId = GravitySession.User.Entity.Id;
            message.Entity.ByUserName = GravitySession.User.Entity.Name;
            message.save();
        }

        private void save()
        {
            Entity.DateTime = DateTime.Now;
            var repo = new TaskRepository();
            repo.SaveTaskMessage(Entity);
        }
    }
}
