using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ProjectAllocation.API.Core
{
    public class JwtAuthorize : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var principal = Thread.CurrentPrincipal;
            var user = principal as AppUser;

            if (user == null || user.Identity.IsAuthenticated == false)
            {
                HttpContext.Current.Response.AddHeader("AuthenticationStatus", "NotAuthenticated");

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
            }

            var controller = actionContext.ControllerContext.Controller as ApiController;
            if (controller != null)
            {
                controller.User = user;
            }
        }
    }
}