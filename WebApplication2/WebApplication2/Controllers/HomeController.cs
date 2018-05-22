using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Business.Attributes;
using WebApplication2.Business.Services;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private LogginService _logginService;
        public HomeController()
        {
            _logginService = new LogginService();
        }

        
        public ActionResult Index()
        {
            return View();
        }

       // IIdentity
        public ActionResult About()
        {
            _logginService.Login("login", "login");
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Admin]
        public ActionResult Contact()
        {
            _logginService.Logout();
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}