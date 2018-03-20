using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Audit
{
    public interface IAuditEntity
    {
        DateTime CreatedDate { get; set; }

        long CreatedBy { get; set; }

        DateTime ModifiedDate { get; set; }

        long ModifiedBy { get; set; }
    }
}
