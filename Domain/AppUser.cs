using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Common.Security;
using System.Security.Principal;
using Common.Audit;

namespace Domain {
    
    public class AppUser : AuditEntity<long>, IPrincipalUserContext
    {
        public AppUser()
        {
            LastLogin = DateTime.Now;
        }
        public virtual string AppUsername { get; set; }

        public string password;
        //[JsonIgnore]
        //public virtual string Password { get; set; }
        public virtual string HashedPassword { get; set; }
        public virtual DateTime? LastLogin { get; set; }
        public virtual bool IsActive { get; set; }
  
        [JsonIgnore]
        public virtual IIdentity Identity
        {
            get { return new UserIdentity(AppUsername); }
        }

        //long IUserContext.Id => throw new NotImplementedException();

        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }
    }
}
