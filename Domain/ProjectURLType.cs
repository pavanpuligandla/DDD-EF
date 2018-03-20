using Common.Audit;

namespace Domain {
    
    public class ProjectURLType : AuditEntity<long>
    {
        public ProjectURLType()
        {

        }
        public virtual string ProjectURLTypeVal { get; set; }
        public virtual string ProjectURLTypeDescription { get; set; }
    }
}
