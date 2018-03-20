using Common.Audit;
using System;

namespace Domain {
    
    public class Role : AuditEntity<long>
    {
        public Role()
        {

        }
        public virtual string RoleName { get; set; }
        public virtual string RoleDescription { get; set; }
    }
}
