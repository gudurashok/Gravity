using System.Collections.Generic;
using Gravity.Root.Repositories;
using System.Linq;
using Raven.Client;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Entities;
using Synergy.Domain.Enums;
using Synergy.Domain.Model;
using Synergy.Domain.ViewModel;

namespace Synergy.Domain.Repositories
{
    public class Tasks : RepositoryBase, IListRepository
    {
        public readonly TaskSearchCriteria _criteria;

        public TaskSearchCriteria Criteria
        {
            get { return _criteria; }
        }

        public Tasks(TaskSearchCriteria taskSearchCriteria)
        {
            _criteria = taskSearchCriteria;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            using (var s = Store.OpenSession())
            {
                var query = getTaskSearchQuery(s)
                    .Where(t => t.Name.StartsWith(criteria.SearchText))
                    .OrderBy(t => t.Name);

                var result = criteria.Count > 0 
                            ? query.Take(criteria.Count).ToList() 
                            : query.ToList();

                if (criteria.PopulateFullDetails)
                    return result
                        .Select(e => new TaskListItem { Task = TaskRepository.GetTaskWithFullDetails(e, s) })
                        .OrderByDescending(t => t.Nr)
                        .Cast<dynamic>().ToList();

                return result
                        .Select(e => new TaskListItem { Task = new Task(e) })
                        .OrderByDescending(t => t.Nr)
                        .Cast<dynamic>().ToList();
            }
        }

        private IQueryable<TaskEntity> getTaskSearchQuery(IDocumentSession s)
        {
            IQueryable<TaskEntity> query = s.Query<TaskEntity>();
            query = setAssignmentFilter(query);
            query = setTaskStatusFilter(query);
            query = setPriorityFilter(query);
            query = setTaskTypeFilter(query);
            query = setProjectFilter(query);
            query = setLocationFilter(query);
            query = setDatePeriodFilter(query);
            //Implement GroupBy first then order by
            query = setOrderBy(query);
            return query;
        }

        #region Assignment Filter

        private IQueryable<TaskEntity> setAssignmentFilter(IQueryable<TaskEntity> query)
        {
            switch (_criteria.SearchIn)
            {
                case SearchIn.None:
                    return userByFilter(query);
                case SearchIn.AssignedBy:
                    return assignedByFilter(query);
                case SearchIn.AssignedTo:
                    return assignedToFilter(query);
                case SearchIn.CCBy:
                    return ccByFilter(query);
                case SearchIn.CCTo:
                    return ccToFilter(query);
                default:
                    return query;
            }
        }

        private IQueryable<TaskEntity> userByFilter(IQueryable<TaskEntity> query)
        {
            return query.Where(t => t.CreatedById == _criteria.User.Id ||
                                    t.AssignedById == _criteria.User.Id ||
                                    t.AssignedToId == _criteria.User.Id ||
                                    t.CcToIds.Any(id => id == _criteria.User.Id));
        }

        private IQueryable<TaskEntity> assignedByFilter(IQueryable<TaskEntity> query)
        {
            if (_criteria.SearchUserId == null)
                return userByFilter(query);

            if (_criteria.User.Id == _criteria.SearchUserId)
                return query.Where(t => t.AssignedById == _criteria.SearchUserId ||
                                        t.CreatedById == _criteria.SearchUserId);

            return query.Where(t => (t.AssignedToId == _criteria.User.Id &&
                                     t.AssignedById == _criteria.SearchUserId) ||
                                    (t.AssignedToId == _criteria.User.Id &&
                                     t.CreatedById == _criteria.SearchUserId) ||
                                    (t.CreatedById == _criteria.User.Id &&
                                     t.AssignedById == _criteria.SearchUserId));
        }

        private IQueryable<TaskEntity> assignedToFilter(IQueryable<TaskEntity> query)
        {
            if (_criteria.SearchUserId == null)
                return userByFilter(query);

            if (_criteria.User.Id == _criteria.SearchUserId)
                return query.Where(t => t.CreatedById == _criteria.SearchUserId ||
                                        t.AssignedToId == _criteria.SearchUserId);

            return query.Where(t => (t.AssignedToId == _criteria.SearchUserId &&
                                     t.AssignedById == _criteria.User.Id) ||
                                    (t.AssignedToId == _criteria.SearchUserId &&
                                     t.CreatedById == _criteria.User.Id) ||
                                    (t.CreatedById == _criteria.SearchUserId &&
                                     t.AssignedById == _criteria.User.Id));
        }

        private IQueryable<TaskEntity> ccByFilter(IQueryable<TaskEntity> query)
        {
            if (_criteria.SearchUserId == null)
                return userByFilter(query);

            if (_criteria.User.Id == _criteria.SearchUserId)
                return query.Where(t => t.CreatedById == _criteria.SearchUserId);

            return query.Where(t => (t.CcToIds.Any(id => id == _criteria.User.Id) &&
                                     t.CreatedById == _criteria.SearchUserId));
        }

        private IQueryable<TaskEntity> ccToFilter(IQueryable<TaskEntity> query)
        {
            if (_criteria.SearchUserId == null)
                return userByFilter(query);

            if (_criteria.User.Id == _criteria.SearchUserId)
                return query.Where(t => t.CreatedById == _criteria.SearchUserId);

            return query.Where(t => (t.CcToIds.Any(id => id == _criteria.SearchUserId) &&
                                     t.CreatedById == _criteria.User.Id));
        }

        #endregion

        #region Other Filters

        private IQueryable<TaskEntity> setTaskStatusFilter(IQueryable<TaskEntity> query)
        {
            if (_criteria.Status != TaskStatus.All)
                query = query.Where(t => t.Status == _criteria.Status);

            return query;
        }

        private IQueryable<TaskEntity> setPriorityFilter(IQueryable<TaskEntity> query)
        {
            if (_criteria.Priority != Priority.None)
                query = query.Where(t => t.Priority == _criteria.Priority);

            return query;
        }

        private IQueryable<TaskEntity> setTaskTypeFilter(IQueryable<TaskEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(_criteria.TaskTypeId))
                query = query.Where(t => t.TypeId == _criteria.TaskTypeId);

            return query;
        }

        private IQueryable<TaskEntity> setProjectFilter(IQueryable<TaskEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(_criteria.ProjectId))
                query = query.Where(t => t.ProjectId == _criteria.ProjectId);

            return query;
        }

        private IQueryable<TaskEntity> setLocationFilter(IQueryable<TaskEntity> query)
        {
            if (!string.IsNullOrWhiteSpace(_criteria.LocationId))
                query = query.Where(t => t.LocationId == _criteria.LocationId);

            return query;
        }

        private IQueryable<TaskEntity> setDatePeriodFilter(IQueryable<TaskEntity> query)
        {
            switch (_criteria.DatePeriodField)
            {
                case DatePeriodField.CreatedOn:
                    query = query.Where(t => t.CreatedOn >= _criteria.Period.From &&
                                             t.CreatedOn <= _criteria.Period.To);
                    break;
                case DatePeriodField.DueDate:
                    query = query.Where(t => t.DueDate >= _criteria.Period.From &&
                                             t.DueDate <= _criteria.Period.To);
                    break;
                case DatePeriodField.StartDate:
                    query = query.Where(t => t.StartDate >= _criteria.Period.From &&
                                             t.StartDate <= _criteria.Period.To);
                    break;
                case DatePeriodField.CompletedOn:
                    query = query.Where(t => t.Status == TaskStatus.Completed &&
                                             t.CompletedOn >= _criteria.Period.From &&
                                             t.CompletedOn <= _criteria.Period.To);
                    break;
            }

            return query;
        }

        private IQueryable<TaskEntity> setOrderBy(IQueryable<TaskEntity> query)
        {
            switch (_criteria.OrderBy)
            {
                case TaskOrderByField.Number:
                    query = query.OrderBy(t => t.Id);
                    break;
                case TaskOrderByField.Name:
                    query = query.OrderBy(t => t.Name);
                    break;
                case TaskOrderByField.Tag:
                    query = query.OrderBy(t => t.Tag);
                    break;
                case TaskOrderByField.DueDate:
                    query = query.OrderBy(t => t.DueDate);
                    break;
                case TaskOrderByField.StartDate:
                    query = query.OrderBy(t => t.StartDate);
                    break;
                case TaskOrderByField.CreatedBy:
                    query = query.OrderBy(t => t.CreatedById);
                    break;
                case TaskOrderByField.CreatedOn:
                    query = query.OrderBy(t => t.CreatedOn);
                    break;
                case TaskOrderByField.AssignedBy:
                    query = query.OrderBy(t => t.AssignedById);
                    break;
                case TaskOrderByField.AssignedTo:
                    query = query.OrderBy(t => t.AssignedToId);
                    break;
                case TaskOrderByField.Priority:
                    query = query.OrderBy(t => t.Priority);
                    break;
                case TaskOrderByField.Type:
                    query = query.OrderBy(t => t.TypeId);
                    break;
                case TaskOrderByField.Project:
                    query = query.OrderBy(t => t.ProjectId);
                    break;
                case TaskOrderByField.Location:
                    query = query.OrderBy(t => t.LocationId);
                    break;
                case TaskOrderByField.Checklist:
                    query = query.OrderBy(t => t.Checklist.Name);
                    break;
                case TaskOrderByField.Status:
                    query = query.OrderBy(t => t.Status);
                    break;
                case TaskOrderByField.CompletedOn:
                    query = query.OrderBy(t => t.CompletedOn);
                    break;
                case TaskOrderByField.CompletePct:
                    query = query.OrderBy(t => t.CompletePct);
                    break;
            }

            return query;
        }

        #endregion
    }
}
