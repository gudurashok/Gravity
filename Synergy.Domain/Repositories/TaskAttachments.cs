using System.Collections.Generic;
using System.Linq;
using Gravity.Root.Repositories;
using Scalable.Shared.Model;
using Scalable.Shared.Repositories;
using Synergy.Domain.Entities;

namespace Synergy.Domain.Repositories
{
    public class TaskAttachments : RepositoryBase, IListRepository
    {
        private readonly IList<AttachmentEntity> _attachments;

        public TaskAttachments(IList<AttachmentEntity> attachments)
        {
            _attachments = attachments;
        }

        public IList<dynamic> SearchItems(PicklistSearchCriteria criteria)
        {
            return _attachments.Cast<dynamic>().ToList();
        }
    }
}
