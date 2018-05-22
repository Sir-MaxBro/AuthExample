using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace WebApplication2.Business.Auth
{
    public class UserPrinciple : IPrincipal
    {
        public UserPrinciple(string userName)
        {
            Identity = new GenericIdentity(userName);
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }

        public string UserName { get; set; }

        public string[] Roles { get; set; }
    }
}