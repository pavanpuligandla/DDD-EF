using System;
using System.Linq;
using Domain;
using Send.Data.Repositories;
using DataAccess.Interfaces;
using Common.Encryption;
using System.IO;

namespace Services.Entity
{
    public partial class AppUserService : EntityService<AppUser, IAppUserRepository>, IAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppUserService
            (IAppUserRepository repository)
            : base(repository)
        {
            
        }
        //public AppUserService(IAppUserRepository appUserRepository, IUnitOfWork unitOfWork)
        //{
        //    _repository = appUserRepository;
        //    _unitOfWork = unitOfWork;
        //}

        public AppUser FetchAndAuthenticate(string userLogin, string userPassword)
        {
            AppUser appUser = Repository.FirstOrDefault(x => x.AppUsername == userLogin);
            if (appUser == null)
            {
                return null;
            }
            return PasswordHasher.VerifyHash(userPassword, appUser.Password) ? appUser : null;
        }

        public void RecordLastLoginDateTime(long userId)
        {
            AppUser user = Repository.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                Repository.Update(user);
                _unitOfWork.Commit();
            }
        }

        public void Register(AppUser user)
        {
            bool isLoginAvailable = Repository.Any(x => x.AppUsername.Equals(user.AppUsername)) == false;

            if (isLoginAvailable == false)
            {
                throw new InvalidDataException("Cannot register user, the username already exists");
            }

            user.Password = PasswordHasher.ComputeHash(user.Password);
            Repository.Add(user);
            _unitOfWork.Commit();
        }
    }
}
