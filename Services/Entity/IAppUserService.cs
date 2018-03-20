using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services.Entity
{
    public partial interface IAppUserService
    {
        AppUser FetchAndAuthenticate(string userLogin, string userPassword);
        void Register(AppUser user);
        void RecordLastLoginDateTime(long userId);
    }
}
