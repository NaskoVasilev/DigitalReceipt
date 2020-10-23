using System;

namespace DigitalReceipt.Data.Common
{
    public class DeletableEntity<TKey> : Entity<TKey>
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
