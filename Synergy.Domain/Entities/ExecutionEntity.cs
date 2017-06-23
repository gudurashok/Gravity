using System;
using Gravity.Root.Common;

namespace Synergy.Domain.Entities
{
    public class ExecutionEntity
    {
        public string UserId { get; set; }
        public DateTime StartedAt { get; private set; }
        public DateTime? StoppedAt { get; set; }
        public string Notes { get; set; }

        public static ExecutionEntity New()
        {
            return new ExecutionEntity
                    {
                        UserId = GravitySession.User.Entity.Id,
                        StartedAt = DateTime.Now
                    };
        }
    }
}
