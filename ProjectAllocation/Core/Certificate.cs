using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Hosting;

namespace ProjectAllocation.API.Core
{
    public static class Certificate
    {
        public static X509Certificate2 SigningCert { get; private set; }
        static Certificate()
        {
            var filepath = HostingEnvironment.MapPath("~/SendDev.pfx");
            SigningCert = new X509Certificate2(filepath, "123456", X509KeyStorageFlags.MachineKeySet);
        }
    }
}