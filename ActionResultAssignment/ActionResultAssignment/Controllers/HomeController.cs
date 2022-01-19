using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ActionResultAssignment.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string args) {

            if (args=="sample") {

                string fname = "/sample" + ".pdf";
                return File(fname,"application/pdf");

            } else if (args=="gotoabout") {

                return Redirect("about");

            } else if (args=="login") { 
               
                return View("success");
            }else{
                return Content("Entered Url");
            }
        }


        public ActionResult about() {

            return View();
        }
       
    }
}
