using Common.Audit;
using System;

namespace Domain
{
    public class UserRole : Entity<long>
    {
        public UserRole()
        {

        }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
