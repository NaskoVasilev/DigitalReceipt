using System;

namespace DigitalReceipt.Data.Common
{
    public class AuditableEntity<TKey> : Entity<TKey>, IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
