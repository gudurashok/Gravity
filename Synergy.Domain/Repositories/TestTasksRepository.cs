using System;
using System.Collections.Generic;
using Gravity.Root.Common;
using Gravity.Root.Repositories;
using Raven.Client;
using Scalable.Shared.Common;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;

namespace Synergy.Domain.Repositories
{
    public class TestTasksRepository : RepositoryBase
    {
        #region Declarations

        private IDocumentSession session;

        #endregion

        #region Public Method

        public void Insert()
        {
            using (session = Store.OpenSession())
            {
                if (SysConfig.TestDataInserted)
                    return;

                createLocations();
                createProjects();
                createTaskTypes();
                createChecklists();
                createTasks();

                //createIssLocations();
                //createIssProjects();
                //createIssTaskTypes();
                //createIssChecklists();

                session.SaveChanges();
                SysConfig.TestDataInserted = true;
            }
        }

        #endregion

        #region Test Data Creation

        private void createLocations()
        {
            session.Store(new LocationEntity { Name = "Surat", IsActive = true });
            session.Store(new LocationEntity { Name = "Sachin", IsActive = true });
            session.Store(new LocationEntity { Name = "Pandesara" });
            session.Store(new LocationEntity { Name = "Banjara Hills", IsActive = true });
        }

        private void createProjects()
        {
            session.Store(new ProjectEntity { Name = "Synergy", Description = "Synergy Task Management System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Mingle", Description = "Mingle is Project Management System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Easy", Description = "Easy is a Business Accounting System", IsActive = true });
            session.Store(new ProjectEntity { Name = "DTwo", Description = "D2 is a Textile Manufacturing System", IsActive = true });
            session.Store(new ProjectEntity { Name = "ExpoMan", Description = "ExpoMan is Export Documentation and Management System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Slack", Description = "Slack is Business Managment System", IsActive = false });
            session.Store(new ProjectEntity { Name = "Personal", Description = "Personal Tasks", IsActive = true });
        }

        private void createTaskTypes()
        {
            session.Store(new TaskTypeEntity { Name = "Regular", Description = "Regular Task", IsActive = true });
            session.Store(new TaskTypeEntity { Name = "Special", Description = "Special Task", IsActive = true });
            session.Store(new TaskTypeEntity { Name = "Technical", Description = "Technical Task", IsActive = true });
        }

        private void createChecklists()
        {
            var checklist = ChecklistEntity.New();
            checklist.Name = "Ticket Booking";
            checklist.Items = new List<ChecklistItemEntity>
                                {
                                    new ChecklistItemEntity {Nr = 1, Name = "Check login"},
                                    new ChecklistItemEntity {Nr = 2, Name = "Check bank status"},
                                    new ChecklistItemEntity {Nr = 3, Name = "Take Person details"},
                                    new ChecklistItemEntity {Nr = 4, Name = "Check Availability"}
                                };
            checklist.IsActive = true;
            session.Store(checklist);

            checklist = ChecklistEntity.New();
            checklist.Name = "Deposit Money";
            checklist.Items = new List<ChecklistItemEntity>
                                {
                                    new ChecklistItemEntity {Nr = 1, Name = "Take Bank details"},
                                    new ChecklistItemEntity {Nr = 2, Name = "Take Amount"},
                                    new ChecklistItemEntity {Nr = 3, Name = "Fill pay-in-slip"},
                                };
            checklist.IsActive = false;
            session.Store(checklist);

            checklist = ChecklistEntity.New();
            checklist.Name = "Guest house Booking";
            checklist.Items = new List<ChecklistItemEntity>
                                {
                                    new ChecklistItemEntity {Nr = 1, Name = "Enquire the hotel for availability"},
                                    new ChecklistItemEntity {Nr = 2, Name = "Specify acommodation"},
                                    new ChecklistItemEntity {Nr = 3, Name = "Check facilities"},
                                };
            checklist.IsActive = true;
            session.Store(checklist);
        }

        private void createTasks()
        {
            #region Task #1

            var task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 1;
            task.Name = @"Replace broken pane of glass in the window at bath room";
            task.Description = @"Replace broken pane of glass in the window at home. The activities involved in the work are:; obtaining the glass and putty, installing the new glass, choosing the paint, obtaining a tin of paint, painting the new putty once it has set, wiping the new glass free of finger smears etc.";
            task.DescriptionText = @"Replace broken pane of glass in the window at home. The activities involved in the work are:; obtaining the glass and putty, installing the new glass, choosing the paint, obtaining a tin of paint, painting the new putty once it has set, wiping the new glass free of finger smears etc.";
            task.Tag = @"personal";
            task.Priority = Priority.Medium;
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/2";
            task.Checklist = getCheklistForTask1();
            task.CreatedById = "UserEntities/1";
            task.CreatedOn = DateTime.Now;
            session.Store(task);

            #endregion

            #region Task #2

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 2;
            task.Name = @"Call new client";
            task.Description = @"Call the new client and setup a meeting to discuss about Synergy";
            task.DescriptionText = @"Call the new client and setup a meeting to discuss about Synergy";
            task.Tag = @"official";
            task.Priority = Priority.Highest;
            task.TypeId = "TaskTypeEntities/2";
            task.ProjectId = "ProjectEntities/2";
            task.LocationId = "LocationEntities/3";
            task.Checklist = getChecklistForTask2();
            task.Recurrence = getRecurrenceForTask2();
            task.CreatedById = "UserEntities/2";
            task.CreatedOn = DateTime.Now;
            session.Store(task);

            #endregion

            #region Task #3

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 3;
            task.Name = @"Task - 3";
            task.Description = @"Task -3 Description";
            task.DescriptionText = @"Task -3 Description";
            task.Tag = @"billing";
            task.EstimatedTime = EnumUtil.GetEnumDescription(Duration.OneDay);
            task.DueDate = DateTime.Now.AddDays(1);
            task.StartDate = DateTime.Today;
            task.Priority = Priority.High;
            task.CreatedById = "UserEntities/2";
            task.CreatedOn = DateTime.Now;
            task.AssignedToId = "UserEntities/1";
            task.TypeId = "TaskTypeEntities/3";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            session.Store(task);

            #endregion

            #region Task #4

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 4;
            task.Name = @"Task - 4";
            task.Description = @"Task - 4 Description";
            task.DescriptionText = @"Task - 4 Description";
            task.Tag = @"billing";
            task.CreatedOn = DateTime.Now;
            task.EstimatedTime = EnumUtil.GetEnumDescription(Duration.TwoDays);
            task.DueDate = DateTime.Now.AddDays(4);
            task.StartDate = DateTime.Today.AddDays(1);
            task.Priority = Priority.Medium;
            task.CreatedById = "UserEntities/4";
            task.AssignedToId = "UserEntities/2";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/4";
            task.LocationId = "LocationEntities/2";
            session.Store(task);

            #endregion

            #region Task #5

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 5;
            task.Name = @"Task - 5";
            task.Description = @"Task - 5 Description";
            task.DescriptionText = @"Task - 5 Description";
            task.Tag = @"sales";
            task.CreatedOn = DateTime.Now;
            task.EstimatedTime = EnumUtil.GetEnumDescription(Duration.OneHour);
            task.DueDate = DateTime.Now.AddDays(2);
            task.StartDate = DateTime.Today.AddDays(1);
            task.Priority = Priority.Normal;
            task.CreatedById = "UserEntities/4";
            task.AssignedToId = "UserEntities/3";
            task.TypeId = "TaskTypeEntities/3";
            task.ProjectId = "ProjectEntities/5";
            task.LocationId = "LocationEntities/1";
            session.Store(task);

            #endregion

            #region Task #6

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 6;
            task.Name = @"Task - 6";
            task.Description = @"Task - 6 Description";
            task.DescriptionText = @"Task - 6 Description";
            task.Tag = @"marketing";
            task.CreatedOn = DateTime.Now;
            task.StartDate = DateTime.Today.AddDays(1);
            task.Priority = Priority.Low;
            task.CreatedById = "UserEntities/4";
            task.AssignedToId = "UserEntities/5";
            task.TypeId = "TaskTypeEntities/2";
            task.ProjectId = "ProjectEntities/2";
            task.LocationId = "LocationEntities/2";
            session.Store(task);

            #endregion

            #region Task #7

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 7;
            task.Name = @"Task - 7";
            task.Description = @"Task - 7 Description";
            task.DescriptionText = @"Task - 7 Description";
            task.Tag = @"sales";
            task.CreatedOn = DateTime.Now;
            task.StartDate = DateTime.Today.AddDays(2);
            task.Priority = Priority.Normal;
            task.CreatedById = "UserEntities/5";
            task.AssignedById = "UserEntities/2";
            task.AssignedToId = "UserEntities/3";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            session.Store(task);

            #endregion

            #region Task #8

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 8;
            task.Name = @"Task - 8";
            task.Description = @"Task - 8 Description";
            task.DescriptionText = @"Task - 8 Description";
            task.Tag = @"marketing";
            task.CreatedOn = DateTime.Now;
            task.StartDate = DateTime.Today.AddDays(2);
            task.DueDate = DateTime.Now.AddDays(5);
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/4";
            task.AssignedById = "UserEntities/2";
            task.AssignedToId = "UserEntities/3";
            task.Recurrence = getRecurrenceForTask1();
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            session.Store(task);

            #endregion

            #region Task #9

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 9;
            task.Name = @"Task - 9";
            task.Description = @"Task - 9 Description";
            task.DescriptionText = @"Task - 9 Description";
            task.Tag = @"marketing";
            task.CreatedOn = DateTime.Now;
            task.StartDate = DateTime.Today.AddDays(2);
            task.DueDate = DateTime.Now.AddDays(5);
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/5";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            session.Store(task);

            #endregion

            #region Task #10

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 10;
            task.Name = @"Task - 10";
            task.Description = @"Task - 10 Description";
            task.DescriptionText = @"Task - 10 Description";
            task.Tag = @"sales";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(5, 2, 3, 40));
            task.StartDate = DateTime.Now.Subtract(new TimeSpan(4, 2, 3, 40));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(1, 2, 3, 40));
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/2";
            task.AssignedById = "UserEntities/4";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Completed;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(3, 2, 3, 40));
            task.CompletePct = 100;
            session.Store(task);

            #endregion

            #region Task #11

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 11;
            task.Name = @"Task - 11";
            task.Description = @"Task - 11 Description";
            task.DescriptionText = @"Task - 11 Description";
            task.Tag = @"personal";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(10, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(8, 0, 0, 0));
            task.Priority = Priority.Normal;
            task.CreatedById = "UserEntities/2";
            task.AssignedById = "UserEntities/4";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Completed;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(9, 0, 0, 0));
            task.CompletePct = 100;
            session.Store(task);

            #endregion

            #region Task #12

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 12;
            task.Name = @"Task - 12";
            task.Description = @"Task - 12 Description";
            task.DescriptionText = @"Task - 12 Description";
            task.Tag = @"misc";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(4, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/2";
            task.AssignedById = "UserEntities/4";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Completed;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0));
            task.CompletePct = 100;
            session.Store(task);

            #endregion

            #region Task #13

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 13;
            task.Name = @"Task - 13";
            task.Description = @"Task - 13 Description";
            task.DescriptionText = @"Task - 13 Description";
            task.Tag = @"misc";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(5, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(2, 0, 0, 0));
            task.Priority = Priority.Normal;
            task.CreatedById = "UserEntities/2";
            task.AssignedById = "UserEntities/4";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Cancelled;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(3, 0, 0, 0));
            task.CompletePct = 20;
            session.Store(task);

            var comment = TaskCommentEntity.New();
            comment.Comment = @"Cancel reason 13";
            comment.UserId = "UserEntities/2";
            comment.TaskId = task.Id;
            comment.CommentedOn = DateTime.Now;
            session.Store(comment);

            #endregion

            #region Task #14

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 14;
            task.Name = @"Task - 14";
            task.Description = @"Task - 14 Description";
            task.DescriptionText = @"Task - 14 Description";
            task.Tag = @"store";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0));
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/2";
            task.AssignedById = "UserEntities/4";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Cancelled;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(17, 0, 0, 0));
            task.CompletePct = 40;
            session.Store(task);

            comment = TaskCommentEntity.New();
            comment.Comment = @"Cancel reason 14";
            comment.UserId = "UserEntities/2";
            comment.TaskId = task.Id;
            comment.CommentedOn = DateTime.Now;
            session.Store(comment);

            #endregion

            #region Task #15

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 15;
            task.Name = @"Task - 15";
            task.Description = @"Task - 15 Description";
            task.DescriptionText = @"Task - 15 Description";
            task.Tag = @"store";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0));
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/3";
            task.AssignedById = "UserEntities/3";
            task.AssignedToId = "UserEntities/2";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Cancelled;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(17, 0, 0, 0));
            task.CompletePct = 40;
            session.Store(task);

            comment = TaskCommentEntity.New();
            comment.Comment = @"Cancel reason 15";
            comment.UserId = "UserEntities/3";
            comment.TaskId = task.Id;
            comment.CommentedOn = DateTime.Now;
            session.Store(comment);

            #endregion

            #region Task #16

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 16;
            task.Name = @"Task - 16";
            task.Description = @"Task - 16 Description";
            task.DescriptionText = @"Task - 16 Description";
            task.Tag = @"bank";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0));
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/3";
            task.AssignedToId = "UserEntities/4";
            task.AssignedById = "UserEntities/4";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Cancelled;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(17, 0, 0, 0));
            task.CompletePct = 40;
            session.Store(task);

            comment = TaskCommentEntity.New();
            comment.Comment = @"Cancel reason 16";
            comment.UserId = "UserEntities/3";
            comment.TaskId = task.Id;
            comment.CommentedOn = DateTime.Now;
            session.Store(comment);

            #endregion

            #region Task #17

            task = new TaskEntity();
            task.Id = EntityPrefix.TaskPrefix + 17;
            task.Name = @"Task - 17";
            task.Description = @"Task - 17 Description";
            task.DescriptionText = @"Task - 17 Description";
            task.Tag = @"bank";
            task.CreatedOn = DateTime.Now.Subtract(new TimeSpan(20, 0, 0, 0));
            task.DueDate = DateTime.Now.Subtract(new TimeSpan(15, 0, 0, 0));
            task.Priority = Priority.Lowest;
            task.CreatedById = "UserEntities/3";
            task.AssignedToId = "UserEntities/2";
            task.AssignedById = "UserEntities/3";
            task.TypeId = "TaskTypeEntities/1";
            task.ProjectId = "ProjectEntities/1";
            task.LocationId = "LocationEntities/1";
            task.Status = TaskStatus.Cancelled;
            task.CompletedOn = DateTime.Now.Subtract(new TimeSpan(17, 0, 0, 0));
            task.CompletePct = 40;
            session.Store(task);

            comment = TaskCommentEntity.New();
            comment.Comment = @"Cancel reason 17";
            comment.UserId = "UserEntities/3";
            comment.TaskId = task.Id;
            comment.CommentedOn = DateTime.Now;
            session.Store(comment);

            #endregion
        }

        #region Task Masters

        private ChecklistEntity getCheklistForTask1()
        {
            return new ChecklistEntity
            {
                Items = new List<ChecklistItemEntity>
                        {
                            new ChecklistItemEntity {Nr = 1, Name = "Take measurements"},
                            new ChecklistItemEntity {Nr = 2, Name = "Purchase glass"},
                            new ChecklistItemEntity {Nr = 3, Name = "Hire a worker to fix it"},
                        }
            };
        }

        private ChecklistEntity getChecklistForTask2()
        {
            return new ChecklistEntity
            {
                Items = new List<ChecklistItemEntity>
                        {
                            new ChecklistItemEntity {Nr = 1, Name = "Book a hotel for meeting"},
                            new ChecklistItemEntity {Nr = 2, Name = "Arrange food facilities"},
                            new ChecklistItemEntity {Nr = 3, Name = "Inform client about the meeting"},
                        }
            };
        }

        private RecurrenceEntity getRecurrenceForTask1()
        {
            var recurrence = new RecurrenceEntity();
            recurrence.Type = RecurrenceType.Weekly;
            recurrence.IsRegenerated = false;
            recurrence.Interval = 5;
            recurrence.DaysOfWeek = 71;
            recurrence.DayOfMonth = 0;
            recurrence.DayOfWeek = DayOfWeekType.First;
            recurrence.DayOfWeekIndex = DayOfWeekIndexType.Day;
            recurrence.Month = 0;
            recurrence.StartDate = DateTime.Today;
            recurrence.RangeType = RecurrenceRangeType.EndByDate;
            recurrence.Occurences = 20;
            recurrence.EndDate = DateTime.Today.AddDays(20);
            return recurrence;
        }

        private RecurrenceEntity getRecurrenceForTask2()
        {
            var recurrence = new RecurrenceEntity();
            recurrence.Type = RecurrenceType.Daily;
            recurrence.IsRegenerated = false;
            recurrence.Interval = 1;
            recurrence.DaysOfWeek = 0;
            recurrence.DayOfMonth = 0;
            recurrence.DayOfWeek = DayOfWeekType.First;
            recurrence.DayOfWeekIndex = DayOfWeekIndexType.Day;
            recurrence.Month = 0;
            recurrence.StartDate = DateTime.Today;
            recurrence.RangeType = RecurrenceRangeType.NoEnd;
            recurrence.Occurences = 0;
            recurrence.EndDate = DateTime.Today.AddDays(30);
            return recurrence;
        }

        #endregion

        #endregion

        #region iScalable Data Methods

        private void createIssLocations()
        {
            session.Store(new LocationEntity { Name = "Hyderabad", IsActive = true, IsPreferred = true });
            session.Store(new LocationEntity { Name = "Surat", IsActive = true });
        }

        private void createIssProjects()
        {
            session.Store(new ProjectEntity { Name = "Gravity", Description = "Gravity is a base program for all projects", IsActive = true, IsPreferred = true });
            session.Store(new ProjectEntity { Name = "Synergy", Description = "Synergy Task Management System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Mingle", Description = "Mingle is Party Management System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Ferry", Description = "Ferry is Data Importing System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Foresight", Description = "Foresight is BI Reports System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Insight", Description = "Insight is Workflow Managment System", IsActive = true });
            session.Store(new ProjectEntity { Name = "Personal", Description = "Personal Tasks", IsActive = true });
            session.Store(new ProjectEntity { Name = "Office", Description = "Office Tasks", IsActive = true });
        }

        private void createIssTaskTypes()
        {
            session.Store(new TaskTypeEntity { Name = "ToDo", Description = "Task to be done", IsActive = true, IsPreferred = true });
            session.Store(new TaskTypeEntity { Name = "Bug", Description = "Error in program", IsActive = true });
            session.Store(new TaskTypeEntity { Name = "Requirement", Description = "Requirement", IsActive = true });
        }

        private void createIssChecklists()
        {
            session.Store(new ChecklistEntity
            {
                Name = "Release Checklist",
                Items = new List<ChecklistItemEntity>
                        {
                            new ChecklistItemEntity { Nr =  1, Name = "Take Release build" },
                            new ChecklistItemEntity { Nr =  2, Name = "Set AppConfig keys" },
                            new ChecklistItemEntity { Nr =  3, Name = "Check Support libraries" },
                            new ChecklistItemEntity { Nr =  4, Name = "Protect with Reactor" },
                            new ChecklistItemEntity { Nr =  5, Name = "Perform smoke test" },
                            new ChecklistItemEntity { Nr =  6, Name = "Compress and deliver" }
                        },
                IsActive = true
            });

            session.Store(new ChecklistEntity
            {
                Name = "Deployment Checklist",
                Items = new List<ChecklistItemEntity>
                        {
                            new ChecklistItemEntity { Nr = 1, Name = "Step - 1" },
                            new ChecklistItemEntity { Nr = 2, Name = "Step - 2" },
                            new ChecklistItemEntity { Nr = 3, Name = "Step - 3" }
                        },
                IsActive = true
            });
        }

        #endregion
    }
}
