using System;
using System.ComponentModel.DataAnnotations;
using Gravity.Root.Common;
using Synergy.Domain.Properties;

namespace Synergy.Domain.Entities
{
    public class TaskCommentEntity
    {
        public string Id { get; set; }
        public string TaskId { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "TaskCommentCannotBeEmpty")]
        public string Comment { get; set; }
        public DateTime CommentedOn { get; set; }

        public static TaskCommentEntity New()
        {
            return new TaskCommentEntity { Id = EntityPrefix.CommentPrefix };
        }
    }
}
