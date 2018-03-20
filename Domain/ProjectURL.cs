using Common.Audit;

namespace Domain {
    
    public class ProjectURL : Entity<long>
    {
        public virtual Project Project { get; set; }
        public virtual ProjectURLType ProjectURLType { get; set; }
    }
}
