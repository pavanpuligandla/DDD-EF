using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Common.Security
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string name)
        {
            Name = name;
            AuthenticationType = "Custom";
        }

        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get { return true; } }
        public string Name { get; private set; }
    }
}
