using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public interface IPrincipalUserContextProvider : IUserContextProvider
    {
        IPrincipalUserContext GetCurrentUserContext();

        void SetCurrentUserContext(IUserContext principalUserContext);

        void SetCurrentUserContext(IPrincipalUserContext principalUserContext);
    }
}
