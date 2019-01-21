using Domain;
using NLog;
using ProjectAllocation.API.Core;
using Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectAllocation.Controllers
{
    public class ProjectTypeController : ApiController
    {
        private readonly IProjectTypeService _service;
        public const string UriPrefix = "api/ProjectType/";

        public ProjectTypeController(IProjectTypeService projectTypeService)
        {
            _service = projectTypeService;
        }

        [HttpPost]
        [Route(UriPrefix + "CreateProjectType")]
        [JwtAuthorize]
        public HttpResponseMessage CreateProjectType(ProjectType projectType)
        {
            LogManager.GetCurrentClassLogger().Debug("ProjectType API hit");
            if (projectType == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
            _service.Create(projectType);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
