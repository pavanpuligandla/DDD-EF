using Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ProjectAllocation.API.Core
{
    public class AuthHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            AuthenticationHeaderValue auth = request.Headers.Authorization;

            if (auth != null)
            {
                var tokenHandler = new SecurityTokenHandler { CertificateValidator = X509CertificateValidator.None };

                //Get the bearer token from the request header
                var token = tokenHandler.ReadToken(auth.Parameter) as JwtSecurityToken;
                if (token != null)
                {
                    X509Certificate2 signingCert;
                    try
                    {
                        signingCert = Certificate.SigningCert;
                    }
                    catch (Exception ex)
                    {
                        //LogManager.GetCurrentClassLogger().Log(LogLevel.Fatal, ex);
                        throw ex;
                    }

                    var parameters = new TokenValidationParameters
                    {
                        AllowedAudience = "http://localhost",
                        SigningToken = new X509SecurityToken(signingCert),
                        ValidIssuer = "http://localhost"
                    };

                    // removed try/catch block. 
                    // the catch statement did not catch the token expired exception, 
                    // and catching it prevents the browser from knowing that there is an error 
                    // (request remains pending for the session) 
                    // TODO: find ways of catching / returning http error to client
                    ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters);

                    Claim claimEmail = token.Claims.FirstOrDefault(x => x.Type == "Email");
                }
            }
            return base.SendAsync(request, cancellationToken);
        }
    }
}