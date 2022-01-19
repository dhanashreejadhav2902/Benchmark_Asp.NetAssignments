using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorEngineAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? amt)
        {
            ViewBag.amt = amt;
            return View();
        }

    }
}