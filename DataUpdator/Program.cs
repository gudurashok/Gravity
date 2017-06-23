using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Gravity.Root.Entities;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;
using Raven.Client.Indexes;
using Raven.Client.Linq;
using Scalable.Win.Controls;
using Synergy.Domain.Entities;

namespace DataUpdator
{
    static class Program
    {
        private static IDocumentStore sourceStore { get; set; }
        private static IDocumentStore targetStore { get; set; }
        private static string sourceDbName { get; set; }
        private static string targetDbName { get; set; }
        private static StreamWriter file;
        private static string _sourceUrl;
        private static string _targetUrl;
        private static bool _isSourceApiKey;
        private static bool _isTargetApiKey;
        private static int _taskNumber = 1;
        private static string _sourceStoreType = "S";
        private static string _targetStoreType = "S";

        static void Main()
        {
            file = File.CreateText(Application.StartupPath + "\\" + "log.txt");

            Console.WriteLine(@"Enter Source Database Type (E=Embedded, S=Server):");
            _sourceStoreType = Console.ReadLine().ToUpper();

            Console.WriteLine(@"Enter Source Database Path/Url:");
            _sourceUrl = Console.ReadLine();
            //_sourceUrl = @"C:\S3PL\ScalableSoftware.Synergy";

            if (_sourceStoreType == "S")
            {
                Console.WriteLine(@"Enter Raven Source Database Name or ApiKey:");
                sourceDbName = Console.ReadLine();

                Console.WriteLine(@"Is source database ApiKey? (Y/N):");
                var keyChar = Console.ReadLine().ToUpper();
                _isSourceApiKey = keyChar == "Y" ? true : false;
            }

            Console.WriteLine(@"Enter Target Database Type (E=Embedded, S=Server):");
            _targetStoreType = Console.ReadLine().ToUpper();

            Console.WriteLine(@"Enter Target Database Path/Url:");
            _targetUrl = Console.ReadLine();
            //_targetUrl = "https://diver.ravenhq.com/databases/Ashok-Scalable-Synergy";

            if (_targetStoreType == "S")
            {
                Console.WriteLine(@"Enter Raven Target Database Name or ApiKey:");
                targetDbName = Console.ReadLine();
                //targetDbName = "0890401c-43ed-4a35-8239-008122e8d4f4";

                Console.WriteLine(@"Is target database ApiKey? (Y/N):");
                var keyChar = Console.ReadLine().ToUpper();
                _isTargetApiKey = keyChar == "Y" ? true : false;
            }

            //Source
            if (_sourceStoreType == "E")
                sourceStore = new EmbeddableDocumentStore { DataDirectory = _sourceUrl }.Initialize();
            else if (_isSourceApiKey)
                sourceStore = new DocumentStore { Url = _sourceUrl, ApiKey = sourceDbName }.Initialize();
            else
                sourceStore = new DocumentStore { Url = _sourceUrl, DefaultDatabase = sourceDbName }.Initialize();

            //Target
            if (_targetStoreType == "E")
                targetStore = new EmbeddableDocumentStore { DataDirectory = _targetUrl }.Initialize();
            else if (_isTargetApiKey)
                targetStore = new DocumentStore { Url = _targetUrl, ApiKey = targetDbName }.Initialize();
            else
                targetStore = new DocumentStore { Url = _targetUrl, DefaultDatabase = targetDbName }.Initialize();

            try
            {
                updateData();
                Console.WriteLine(@"Waiting for flushing write operation");
                Thread.Sleep(2000);
                compareData();

                sourceStore.Dispose();
                targetStore.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("ERROR: {0}", ex));
            }
            finally
            {
                file.Close();
            }

            Console.WriteLine(@"Completed");
            Console.Read();
            Console.Read();
        }

        private static void compareData()
        {
            int sourceTaskCount;
            int sourceTaskExecutionCount;

            using (var ss = sourceStore.OpenSession())
            {
                sourceTaskCount = getTaskCount(ss);
                sourceTaskExecutionCount = getTaskExecutionCount(ss);
            }

            using (var ts = targetStore.OpenSession())
            {
                var taskCount = getTaskCount(ts);
                var taskExecutionCount = getTaskExecutionCount(ts);

                if (taskCount == sourceTaskCount)
                    Console.WriteLine(@"All Tasks imported");
                else
                    Console.WriteLine(string.Format("Error in task import: Source tasks: {0}, Target tasks: {1}", sourceTaskCount, taskCount));

                if (taskExecutionCount == sourceTaskExecutionCount)
                    Console.WriteLine(@"All TaskExecutions imported.");
                else
                    Console.WriteLine(string.Format("Error in task execution import: Source task executions: {0}, Target task executions: {1}", sourceTaskExecutionCount, taskExecutionCount));
            }
        }

        private static void updateData()
        {
            deleteTasks();
            deleteTaskExecutions();
            //createIndexes();
            updateTasks();
            updateTaskParentIds();
            deleteOldEntries();
            ////copyExistingEntries(conn);
        }

        private static void deleteTasks()
        {
            Console.WriteLine(@"Deleting Old Tasks...");
            using (var s = targetStore.OpenSession())
            {
                while (true)
                {
                    var ids = s.Query<TaskEntity>().Select(t => t.Id).ToArray();

                    if (ids.Count() == 0)
                        break;

                    foreach (var id in ids)
                        s.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);
                }
            }
        }

        private static void deleteTaskExecutions()
        {
            Console.WriteLine(@"Deleting Task executions...");
            using (var s = targetStore.OpenSession())
            {
                while (true)
                {
                    var ids = s.Query<TaskExecutionEntity>().Select(t => t.Id).ToArray();

                    if (ids.Count() == 0)
                        break;

                    foreach (var id in ids)
                        s.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);
                }
            }
        }

        #region Index creation

        private static void createIndexes()
        {
            Console.WriteLine(@"Creating Indexes...");

            var catalog = new CompositionContainer(new AssemblyCatalog(typeof(Task_Search).Assembly));
            IndexCreation.CreateIndexes(catalog,
                        targetStore.DatabaseCommands.ForDatabase(targetDbName),
                        targetStore.Conventions);
        }

        #endregion

        #region Updating tasks and its associated entries

        private static void updateTasks()
        {
            _taskNumber = 1;
            var rtb = new iRichTextBox();
            var count = getTaskCount(sourceStore.OpenSession());

            Console.WriteLine(string.Format("Total: {0} tasks found.", count));
            Console.WriteLine(@"Press any key to continue...");
            Console.Read();

            for (var i = 1; i <= count; i++)
            {
                using (var ss = sourceStore.OpenSession())
                {
                    var tasks = ss.Query<TaskEntity>().Where(t => t.Number == i);
                    foreach (var task in tasks)
                    {
                        file.WriteLine(string.Format("Task # {0} details has been updated", i));

                        var newId = "TaskEntities/" + _taskNumber;
                        updateTaskComments(task.Id, newId);
                        updateTaskMessages(task.Id, newId);
                        updateTaskReminders(task.Id, newId);
                        updateCurrentTaskData(task.Id, newId);
                        updateTaskExecutions(task.Id, newId);

                        using (var ts = targetStore.OpenSession())
                        {
                            try
                            {
                                rtb.RichText = task.Description;
                                task.DescriptionText = rtb.Text;
                                task.Id = newId;
                                ts.Store(task);
                                ts.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(string.Format("Error: {0};  ID: {1}, Description: {2}", ex.Message, task.Id, task.Description));
                                Console.Read();
                                Console.Read();
                            }
                        }

                        _taskNumber++;
                    }
                }

                file.WriteLine(string.Format("Task # {0} updated", i));
                Console.WriteLine(string.Format("Task # {0} updated", i));
            }
        }

        private static void updateTaskParentIds()
        {
            Console.WriteLine(string.Format("Updating Parent Tasks..."));

            IList<TaskEntity> tasks;
            using (var session2 = targetStore.OpenSession(targetDbName))
            {
                tasks = session2.Query<TaskEntity>()
                    .Where(t => t.ParentId != null && t.ParentId != "")
                    .Take(1024)
                    .ToList();
            }

            foreach (var task in tasks)
            {
                TaskEntity parentTask;
                using (var ss = sourceStore.OpenSession(sourceDbName))
                    parentTask = ss.Query<TaskEntity>().FirstOrDefault(t => t.Id == task.ParentId);

                using (var ts = targetStore.OpenSession(targetDbName))
                {
                    var newPTask = ts.Query<TaskEntity>()
                                        .FirstOrDefault(t => t.Number == parentTask.Number
                                                        && t.CreatedOn == parentTask.CreatedOn);
                    if (newPTask == null)
                    {
                        Console.WriteLine(string.Format("Cannot find parent task nr {0} in target db", parentTask.Number));
                        continue;
                    }

                    task.ParentId = newPTask.Id;
                    ts.Store(task);
                    ts.SaveChanges();
                }
            }
        }

        private static void updateTaskComments(string oldTaskId, string newTaskId)
        {
            Console.WriteLine(@"Updating Comments...");
            using (var ss = sourceStore.OpenSession())
            {
                var comments = ss.Query<TaskCommentEntity>().Where(t => t.TaskId == oldTaskId);

                using (var ts = targetStore.OpenSession())
                {
                    foreach (var comment in comments)
                    {
                        comment.TaskId = newTaskId;
                        ts.Store(comment);
                    }

                    ts.SaveChanges();
                }
            }
        }

        private static void updateTaskMessages(string taskId, string newId)
        {
            Console.WriteLine(@"Updating Messages...");
            using (var ss = sourceStore.OpenSession())
            {
                var messages = ss.Query<TaskMessageEntity>().Where(m => m.TaskId == taskId);

                using (var ts = targetStore.OpenSession())
                {
                    foreach (var message in messages)
                    {
                        message.TaskId = newId;
                        ts.Store(message);
                    }

                    ts.SaveChanges();
                }
            }
        }

        private static void updateTaskReminders(string taskId, string newId)
        {
            Console.WriteLine(@"Updating Reminders...");
            using (var ss = sourceStore.OpenSession())
            {
                var reminders = ss.Query<TaskReminderEntity>().Where(r => r.TaskId == taskId);

                using (var ts = targetStore.OpenSession())
                {
                    foreach (var reminder in reminders)
                    {
                        reminder.TaskId = newId;
                        ts.Store(reminder);
                    }

                    ts.SaveChanges();
                }
            }
        }

        private static void updateCurrentTaskData(object taskId, string newId)
        {
            Console.WriteLine(@"Updating CurrentTasks...");
            using (var ss = sourceStore.OpenSession())
            {
                var configs = ss.Query<UserConfigEntity>().Where(
                        c => c.Name == "CurrentTask" && c.Value != null && c.Value == taskId);

                using (var ts = targetStore.OpenSession())
                {
                    foreach (var config in configs)
                    {
                        config.Value = newId;
                        ts.Store(config);
                    }
                    ts.SaveChanges();
                }
            }
        }

        private static void updateTaskExecutions(string taskId, string newId)
        {
            Console.WriteLine(@"Updating Executions...");
            TaskExecutionEntity execution;
            using (var ss = sourceStore.OpenSession())
            {
                var executionId = taskId + "/Executions";
                //execution = ss.Query<TaskExecutionEntity>().SingleOrDefault(e => e.Id == executionId);
                execution = ss.Load<TaskExecutionEntity>(executionId);

                if (execution == null)
                    return;
            }
            using (var ts = targetStore.OpenSession())
            {
                execution.Id = newId + "/Executions";
                ts.Store(execution);
                ts.SaveChanges();
            }
        }

        private static int getTaskCount(IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = s.Query<TaskEntity>().Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        private static int getTaskExecutionCount(IDocumentSession s)
        {
            RavenQueryStatistics stats;
            var result = s.Query<TaskExecutionEntity>().Statistics(out stats).Take(0).ToArray();
            return stats.TotalResults;
        }

        #endregion

        #region Deleting Old Unused Entries

        private static void deleteOldEntries()
        {
            Console.WriteLine(@"Deleting Old Entries...");
            using (var s = targetStore.OpenSession())
            {
                while (true)
                {
                    var ids = s.Query<UserConfigEntity>().Where(c => c.Name == "LoggedIn").Select(c => c.Id).ToArray();

                    if (ids.Count() == 0)
                        break;

                    foreach (var id in ids)
                        s.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);
                }
            }

            using (var s = targetStore.OpenSession())
            {
                while (true)
                {
                    var ids = s.Query<UserConfigEntity>().Where(c => c.Name == "AnyError").Select(c => c.Id).ToArray();

                    if (ids.Count() == 0)
                        break;

                    foreach (var id in ids)
                        s.Advanced.DocumentStore.DatabaseCommands.Delete(id, null);
                }
            }
        }

        #endregion
    }

    public class Task_Search : AbstractMultiMapIndexCreationTask<Task_Search.Result>
    {
        public class Result
        {
            public string TaskId { get; set; }
            public object[] SearchQuery { get; set; }
        }

        public Task_Search()
        {
            AddMap<TaskEntity>(tasks => from task in tasks
                                        select new Result
                                        {
                                            TaskId = task.Id,
                                            SearchQuery = new[]
                                                        {
                                                            task.Name, 
                                                            task.Tag, 
                                                            task.DescriptionText
                                                        }
                                        });

            AddMap<TaskCommentEntity>(comments => from comment in comments
                                                  select new Result
                                                  {
                                                      TaskId = comment.TaskId,
                                                      SearchQuery = new[] { comment.Comment }
                                                  });

            Reduce = results => from result in results
                                group result by result.TaskId
                                    into g
                                    select new Result
                                    {
                                        TaskId = g.Key,
                                        SearchQuery = g.Where(t => t.TaskId == g.Key)
                                                        .Select(c => c.SearchQuery).ToArray()
                                    };

            Index(p => p.SearchQuery, FieldIndexing.Analyzed);
        }
    }
}
