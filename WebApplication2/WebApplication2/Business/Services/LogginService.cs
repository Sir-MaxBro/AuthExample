using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebApplication2.Business.Models;

namespace WebApplication2.Business.Services
{
    public class LogginService
    {
        public void Login(string login, string password)
        {
            if (IsValidUser(login, password))
            {
                var user = GetUser(login);
                var userData = JsonConvert.SerializeObject(user);
                var ticket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData);
                var encryptTicket = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private bool IsValidUser(string login, string password)
        {
            if (login == password)
            {
                return true;
            }
            return false;
        }

        private User GetUser(string login)
        {
            Role role = new Role
            {
                Id = 1,
                Name = "admin"
            };

            User user = new User()
            {
                Id = 1,
                Name = login,
                Roles = new Role[] { role }
            };

            return user;
        }
    }
}