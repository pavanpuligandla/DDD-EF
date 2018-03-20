using Common.Audit;

namespace Domain {
    
    public class Project : AuditEntity<long>
    {
        public Project()
        {

        }
        public virtual ProjectType ProjectType { get; set; }
        public virtual string ProjectName { get; set; }
        public virtual string ProjectDescription { get; set; }
    }
}
