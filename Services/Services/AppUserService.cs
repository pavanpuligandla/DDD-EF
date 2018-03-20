using Common.Encryption;
using DataAccess.Implementation;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public partial interface IAppUserService: IEntityService<AppUser>
    {
        AppUser Authenticate(string username, string password);
    }

    public partial class AppUserService
    {
        public AppUser Authenticate(string username, string password)
        {
            AppUser user = _repository.Find(x => x.AppUsername == username);
            if (user == null)
                return null;

            return PasswordHasher.VerifyHash(password, user.HashedPassword) ? user : null;
        }
    }
}
