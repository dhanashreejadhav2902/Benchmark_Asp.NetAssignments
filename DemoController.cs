using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFirstDemo.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}