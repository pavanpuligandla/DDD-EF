using Common.Audit;
using System;

namespace Domain
{
    
    public class User : Entity<long>
    {
        public User()
        {

        }
        public virtual string Username { get; set; }
        public virtual string Domain { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
