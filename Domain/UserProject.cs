using System;
using Common.Audit;

namespace Domain
{
    public class UserProject : Entity<long>
    {
        public UserProject()
        {

        }
        public virtual User User { get; set; }
        public virtual Project Project { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
