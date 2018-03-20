using Common.Audit;
using System;

namespace Domain
{
    public class ProjectType : AuditEntity<long>
    {
        public virtual string ProjectTypeName { get; set; }
        public virtual string ProjectTypeDescription { get; set; }
    }
}
