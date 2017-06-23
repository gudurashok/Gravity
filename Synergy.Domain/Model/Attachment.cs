using Synergy.Domain.Entities;

namespace Synergy.Domain.Model
{
    public class Attachment
    {
        public AttachmentEntity Entity { get; set; }

        public Attachment()
        {
        }

        public Attachment(AttachmentEntity entity)
        {
            Entity = entity;
        }

        public bool IsNew()
        {
            return Entity.Nr == 0;
        }
    }
}
