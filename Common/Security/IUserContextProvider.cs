using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public interface IUserContextProvider
    {
        IUserContext GetCurrentUserContext();

        void SetCurrentUserContext(IUserContext principalUserContext);
    }
}
