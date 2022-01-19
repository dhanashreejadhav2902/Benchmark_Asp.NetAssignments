using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ProductApp.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult MyInfo() {
            return View();
        }

        //this is for perticular content or data
        public ActionResult GetEmpName(int EmpId) {

            var Emp = new[]{ 
              new { EmpId=1,EmpName="Dhanashree",Salary=30000},
              new { EmpId=2,EmpName="Akash",Salary=40000},
              new { EmpId=3,EmpName="sujata",Salary=50000}
            };

            string matchEmpName = null;
            foreach (var data in Emp) {
                if (data.EmpId == EmpId){
                    matchEmpName = data.EmpName;
                }
              
            }

            return Content(matchEmpName, "text/plain");
        }

        //this for returning any file i.e pdf or word file
        public ActionResult GetPaySlip(int EmpId) {
            string fname = "~/payslip" + EmpId + ".pdf";
            return File(fname,"application/pdf");
        }

        public ActionResult EmpFaceBookPage(int EmpId) {
            string fburl = "www.facebook.com/emp"+EmpId;
            return Redirect(fburl);
        }
    }
}