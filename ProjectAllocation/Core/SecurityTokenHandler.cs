using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;

using System.Linq;
using System.Web;

namespace ProjectAllocation.API.Core
{
    public class SecurityTokenHandler : JwtSecurityTokenHandler
    {
        protected override void ValidateLifetime(JwtSecurityToken jwt)
        {
            if (jwt == null)
                throw new ArgumentNullException("jwt");
            object obj;
            bool flag1 = jwt.Payload.TryGetValue("nbf", out obj);
            bool flag2 = jwt.Payload.TryGetValue("exp", out obj);
            if (!flag2 && RequireExpirationTime)
                throw new SecurityTokenValidationException(string.Format(CultureInfo.InvariantCulture,
                    "Jwt10322: Lifetime validation failed. The token is missing the 'exp' (Expiration Time) claim.\njwt: '{0}'.",
                    new object[1]
                    {
                        jwt
                    }));
            if (flag1 && flag2 && jwt.ValidFrom > jwt.ValidTo)
            {
                throw new SecurityTokenValidationException(string.Format(CultureInfo.InvariantCulture,
                    "Jwt10403: Invalid dates. validFrom: '{0}' > validTo: {1}.", new object[2]
                    {
                        jwt.ValidFrom,
                        jwt.ValidTo
                    }));
            }
            DateTime dateTimeUtcNow = DateTime.UtcNow;
            if (flag1 && jwt.ValidFrom > dateTimeUtcNow)
            {
                throw new SecurityTokenValidationException(string.Format(CultureInfo.InvariantCulture,
                    "Jwt10306: Lifetime validation failed. The token is not yet valid.\nValidFrom: '{0}'\nCurrent time: '{1}'.",
                    new object[2]
                    {
                        jwt.ValidFrom,
                        dateTimeUtcNow
                    }));
            }
            if (!flag2 || !(jwt.ValidTo < dateTimeUtcNow))
                return;
            throw new SecurityTokenValidationException(string.Format(CultureInfo.InvariantCulture,
                "Jwt10305: Lifetime validation failed. The token is expired.\nValidTo: '{0}'\nCurrent time: '{1}'.",
                new object[2]
                {
                    jwt.ValidTo,
                    dateTimeUtcNow
                }));
        }
    }
}