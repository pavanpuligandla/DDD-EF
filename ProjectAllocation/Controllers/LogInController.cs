using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAllocation.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(string username,string password)
        {
            return View();
        }
    }
}