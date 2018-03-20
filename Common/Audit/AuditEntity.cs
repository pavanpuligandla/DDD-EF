using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Audit
{
    public abstract class AuditEntity<T> : Entity<T>, IAuditEntity
    {
        public DateTime CreatedDate { get; set; }

        public long CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public long ModifiedBy { get; set; }
    }
}
