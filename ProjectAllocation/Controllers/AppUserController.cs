using Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain;
using ProjectAllocation.API.Core;
using Common.Encryption;

namespace ProjectAllocation.Controllers
{
    public class AppUserController : ApiController
    {
        private readonly IAppUserService _appUserService;
        public const string UriPrefix = "api/AppUser/";

        public AppUserController(IAppUserService appUserService)
        {
             _appUserService = appUserService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route(UriPrefix + "Login")]
        public HttpResponseMessage Login(string username, string password)
        {
            if (username == null || password == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            AppUser currentUser = _appUserService.Authenticate(username, password);
            if (currentUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            var tokenString = Helper.GetToken(currentUser);
            //_appUserService.RecordLastLoginDateTime(currentUser.Id);

            return new HttpResponseMessage { Content = new StringContent(tokenString) };
        }

        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage RegisterUser(AppUser user)
        {
            if(user ==null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            user.HashedPassword = PasswordHasher.ComputeHash(user.password);
            _appUserService.Create(user);
            return new HttpResponseMessage { Content = new StringContent("User registered success"), StatusCode = HttpStatusCode.OK };
        }

        [HttpGet]
        [JwtAuthorize]
        public HttpResponseMessage NotifyDate()
        {
            return new HttpResponseMessage { Content = new StringContent("march 2nd"), StatusCode = HttpStatusCode.OK };
        }
    }
}
