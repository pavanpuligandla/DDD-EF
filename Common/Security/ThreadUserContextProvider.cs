using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Security
{
    public class ThreadUserContextProvider : IUserContextProvider
    {
        public virtual IUserContext GetCurrentUserContext()
        {
            return Thread.CurrentPrincipal as IPrincipalUserContext;
        }

        public void SetCurrentUserContext(IUserContext userContext)
        {
            IPrincipalUserContext currentPrincipal = new PrincipalUserContext(new GenericIdentity(string.Empty), null, userContext.Id);
            Thread.CurrentPrincipal = currentPrincipal;
        }
    }
}
