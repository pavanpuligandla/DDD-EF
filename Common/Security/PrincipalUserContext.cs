using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public class PrincipalUserContext : GenericPrincipal, IPrincipalUserContext, IUserContext, IPrincipal
    {
        public long Id
        {
            get;
            private set;
        }

        public PrincipalUserContext(IIdentity identity, string[] roles, long id) : base(identity, roles)
        {
            this.Id = id;
        }
    }
}
