using System.Text;
using Gravity.Root.Common;
using Gravity.Root.Entities;
using Scalable.Shared.Common;
using Scalable.Shared.Model;
using Synergy.Domain.Enums;

namespace Synergy.Domain.Model
{
    public class TaskSearchCriteria
    {
        public UserEntity User { get; set; }
        public TaskStatus Status { get; set; }
        public Priority Priority { get; set; }
        public TaskOrderByField OrderBy { get; set; }
        public TaskGroupByField GroupBy { get; set; }
        public string TaskTypeId { get; set; }
        public string TaskTypeName { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string LocationId { get; set; }
        public string LocationName { get; set; }
        public SearchIn SearchIn { get; set; }
        public string SearchUserId { get; set; }
        public UserEntity SearchUser { get; set; }
        public DatePeriodField DatePeriodField { get; set; }
        public DatePeriod Period { get; set; }

        public TaskSearchCriteria()
        {
            User = GravitySession.User.Entity;
            Status = TaskStatus.Pending;
            DatePeriodField = DatePeriodField.None;
            Priority = Priority.None;
            OrderBy = TaskOrderByField.None;
            GroupBy = TaskGroupByField.None;
        }

        public override string ToString()
        {
            var criteria = new StringBuilder();

            criteria.Append("Current filter: ")
                .Append(string.Format("User = {0}", User.Name))
                .Append(string.Format(", Status = {0}", Status))
                .Append(string.Format(", Priority = {0}", Priority));

            if (!string.IsNullOrWhiteSpace(TaskTypeId))
                criteria.Append(string.Format(", Task type = {0}", TaskTypeName));

            if (!string.IsNullOrWhiteSpace(ProjectId))
                criteria.Append(string.Format(", Project = {0}", ProjectName));

            if (!string.IsNullOrWhiteSpace(LocationId))
                criteria.Append(string.Format(", Location = {0}", LocationName));

            if (SearchIn != SearchIn.None && SearchUser != null)
                criteria.Append(string.Format(", {0} {1}", SearchIn, SearchUser.Name));

            if (DatePeriodField != DatePeriodField.None)
                criteria.Append(string.Format(", {0} = {1}",
                                EnumUtil.GetEnumDescription(DatePeriodField),
                                Period.ToDateTimeString()));

            return criteria.ToString();
        }
    }
}
