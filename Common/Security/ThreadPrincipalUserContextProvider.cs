using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Security
{
    public class ThreadPrincipalUserContextProvider : ThreadUserContextProvider, IPrincipalUserContextProvider, IUserContextProvider
    {
        public new IPrincipalUserContext GetCurrentUserContext()
        {
            return base.GetCurrentUserContext() as IPrincipalUserContext;
        }

        public new void SetCurrentUserContext(IUserContext principalUserContext)
        {
            Thread.CurrentPrincipal = (principalUserContext as IPrincipalUserContext);
        }

        public void SetCurrentUserContext(IPrincipalUserContext principalUserContext)
        {
            Thread.CurrentPrincipal = principalUserContext;
        }
    }
}
