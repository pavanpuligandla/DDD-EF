using Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Http;

namespace ProjectAllocation.API.Core
{
    public class Helper
    {
        public static string GetToken(AppUser currentUser)
        {

            // If not match found - return error.
            if (currentUser == null)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            X509Certificate2 signingCert;

            try
            {
                signingCert = Certificate.SigningCert;
            }
            catch (Exception ex)
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Email", currentUser.AppUsername),
                    new Claim("Role", "User"),
                }),

                AppliesToAddress = "http://localhost",
                TokenIssuerName = "http://localhost",
                SigningCredentials = new X509SigningCredentials(signingCert),
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}