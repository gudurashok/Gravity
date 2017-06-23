using Raven.Imports.Newtonsoft.Json;

namespace Synergy.Domain.Indexes
{
    public class TaskStats
    {
        public string UserId { get; set; }
        [JsonIgnore]
        public string UserName { get; set; }
        public int Total { get; set; }
        public int TotalInList { get; set; }
        public int Pending { get; set; }
        public int Cancelled { get; set; }
        public int Completed { get; set; }
        public int OverDue { get; set; }
        public int Late { get; set; }
        public int NotStarted { get; set; }
        public int StartedToday { get; set; }
        public int DueToday { get; set; }
        public int DueTomorrow { get; set; }
        public int DueThisWeek { get; set; }
        public int Inactive { get; set; }
        public int Active { get; set; }
        public int InProgress { get; set; }
        public int Own { get; set; }
        public int AssignedTo { get; set; }
        public int AssignedBy { get; set; }
        public int CcBy { get; set; }
        public int CcTo { get; set; }
        public int ByType { get; set; }
        public int ByLocation { get; set; }
        public int ByProject { get; set; }

        public override string ToString()
        {
            return string.Format("Stats: T:{0} L:{1} P:{2} O:{3} DT:{4} DW:{5}", 
                        Total, TotalInList, Pending, OverDue, DueToday, DueThisWeek);
        }

        public string ToToolTipString()
        {
            return string.Format(
                        "Tasks Statistics: " +
                        "\nTotal:{0} " +
                        "\nCurrent List:{1} " +
                        "\nPending:{2} " +
                        "\nOver due:{3} " +
                        "\nDue Today:{4} " +
                        "\nDue this week:{5}",
                        Total, TotalInList, Pending,
                        OverDue, DueToday, DueThisWeek);
        }
    }

    //public class Task_UserStats : AbstractMultiMapIndexCreationTask<TaskStats>, IIndexDefinition
    //{
    //    public Task_UserStats()
    //    {
    //        AddMap<UserEntity>(users => from user in users
    //                                    select new TaskStats
    //                                    {
    //                                        UserId = user.Id,
    //                                        Total = 0,
    //                                        Pending = 0,
    //                                        Cancelled = 0,
    //                                        Completed = 0,
    //                                        NotStarted = 0
    //                                    });

    //        AddMap<TaskEntity>(tasks => from task in tasks
    //                                    select new TaskStats
    //                                    {
    //                                        UserId = task.CreatedById,
    //                                        Total = 1,
    //                                        Pending = task.Status == TaskStatus.Pending ? 1 : 0,
    //                                        Cancelled = task.Status == TaskStatus.Cancelled ? 1 : 0,
    //                                        Completed = task.Status == TaskStatus.Completed ? 1 : 0,
    //                                        NotStarted = !task.StartDate.HasValue && task.Status == TaskStatus.Pending ? 1 : 0
    //                                    });

    //        AddMap<TaskEntity>(tasks => from task in tasks
    //                                    where !string.IsNullOrEmpty(task.AssignedById)
    //                                    select new TaskStats
    //                                    {
    //                                        UserId = task.AssignedById,
    //                                        Total = 1,
    //                                        Pending = task.Status == TaskStatus.Pending ? 1 : 0,
    //                                        Cancelled = task.Status == TaskStatus.Cancelled ? 1 : 0,
    //                                        Completed = task.Status == TaskStatus.Completed ? 1 : 0,
    //                                        NotStarted = !task.StartDate.HasValue && task.Status == TaskStatus.Pending ? 1 : 0
    //                                    });

    //        AddMap<TaskEntity>(tasks => from task in tasks
    //                                    where !string.IsNullOrWhiteSpace(task.AssignedToId)
    //                                    select new TaskStats
    //                                    {
    //                                        UserId = task.AssignedToId,
    //                                        Total = 1,
    //                                        Pending = task.Status == TaskStatus.Pending ? 1 : 0,
    //                                        Cancelled = task.Status == TaskStatus.Cancelled ? 1 : 0,
    //                                        Completed = task.Status == TaskStatus.Completed ? 1 : 0,
    //                                        NotStarted = !task.StartDate.HasValue && task.Status == TaskStatus.Pending ? 1 : 0
    //                                    });

    //        AddMap<TaskEntity>(tasks => from task in tasks
    //                                    from ccId in task.CcToIds
    //                                    select new TaskStats
    //                                    {
    //                                        UserId = ccId,
    //                                        Total = 1,
    //                                        Pending = task.Status == TaskStatus.Pending ? 1 : 0,
    //                                        Cancelled = task.Status == TaskStatus.Cancelled ? 1 : 0,
    //                                        Completed = task.Status == TaskStatus.Completed ? 1 : 0,
    //                                        NotStarted = !task.StartDate.HasValue && task.Status == TaskStatus.Pending ? 1 : 0
    //                                    });

    //        Reduce = results => from result in results
    //                            group result by result.UserId
    //                                into g
    //                                select new TaskStats
    //                                    {
    //                                        UserId = g.Key,
    //                                        Total = g.Sum(t => t.Total),
    //                                        Pending = g.Sum(t => t.Pending),
    //                                        Cancelled = g.Sum(t => t.Cancelled),
    //                                        Completed = g.Sum(t => t.Completed),
    //                                        NotStarted = g.Sum(t => t.NotStarted)
    //                                    };
    //    }
    //}
}
