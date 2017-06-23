using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Model;
using Scalable.Shared.Common;
using Synergy.Domain.Entities;
using Synergy.Domain.Properties;
using Synergy.Domain.Repositories;

namespace Synergy.Domain.Model
{
    public class TaskTemplate
    {
        public TaskTemplateEntity Entity { get; set; }
        public User AssignedBy { get; set; }
        public User AssignedTo { get; set; }
        public IList<User> CcTo { get; set; }
        public TaskType Type { get; set; }
        public Project Project { get; set; }
        public Location Location { get; set; }
        public Checklist Checklist { get; set; }

        public TaskTemplate(TaskTemplateEntity entity)
        {
            Entity = entity;
            Checklist = new Checklist(entity.Checklist);
        }

        public void Save()
        {
            EntityValidator.Validate(Entity);
            var repo = new TaskRepository();

            if (IsNew() && repo.GetTemplateByName(Entity.Name) != null)
                throw new ValidationException(Resources.TemplateAlreadyExist);

            repo.Save(Entity);
        }

        private bool IsNew()
        {
            return string.IsNullOrEmpty(Entity.Id);
        }

        public string Name
        {
            get { return Entity.Name; }
        }

        public override string ToString()
        {
            return string.Format("{0} Template", Entity.Name);
        }

        public static TaskTemplate New()
        {
            return new TaskTemplate(new TaskTemplateEntity());
        }
    }
}
