using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Business.Auth;
using WebApplication2.Business.Models;

namespace WebApplication2.Business.Attributes
{
    public class AdminAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var user = HttpContext.Current.User as User;
            if (HttpContext.Current.User is UserPrinciple)
            {
                return HttpContext.Current.User.IsInRole("admin");
            }
            return false;
        }
    }
}