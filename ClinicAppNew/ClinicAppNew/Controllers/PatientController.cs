using ClinicAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicAppNew.Controllers
{
    public class PatientController : Controller
    {
        ClinicAppEntities db = new ClinicAppEntities();
        public ActionResult Index(string search = "", string sortcolm = "pname", string icon = "fa-sort-desc", int pageno = 1)
        {
            
            //display data without any condition
            //List<Product> products=db.Products.ToList();


            //to display data on perticular condition
            List<Patient> patient = db.Patients.Where(temp => temp.pname.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.sortcolm = sortcolm;
            ViewBag.icon = icon;
            if (ViewBag.sortcolm == "pid")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.pid).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.pid).ToList();

            }
            else if (ViewBag.sortcolm == "pname")
            {

                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.pname).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.pname).ToList();

            }
            else if (ViewBag.sortcolm == "mobile")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.mobile).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.mobile).ToList();


            }
            else if (ViewBag.sortcolm == "email")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.email).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.email).ToList();

            }
            else if (ViewBag.sortcolm == "paddress")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.paddress).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.paddress).ToList();

            }
            else if (ViewBag.sortcolm == "description")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.description).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.description).ToList();

            }
            else if (ViewBag.sortcolm == "healthinsurance")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.healthinsurance).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.healthinsurance).ToList();

            }

            else if (ViewBag.sortcolm == "did")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    patient = patient.OrderBy(temp => temp.Doctor.dname).ToList();
                else
                    patient = patient.OrderByDescending(temp => temp.Doctor.dname).ToList();

            }


            int recordperpage = 5;
            int totalpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(patient.Count) / Convert.ToDouble(recordperpage)));
            int pageredcordtoskip = (pageno - 1) * recordperpage;
            ViewBag.pageno = pageno;
            ViewBag.totalpage = totalpage;
            patient = patient.Skip(pageredcordtoskip).Take(recordperpage).ToList();
            return View(patient);
        }

        public ActionResult Details(int id)
        {
            
            Patient p = db.Patients.Where(temp => temp.pid == id).FirstOrDefault();
            return View(p);
        }

        //this is get method to get create request from user
        public ActionResult Create()
        {
            
            ViewBag.Doctor = db.Doctors.ToList();
            return View();
        }

        //this is post request to insert data from user in form
        [HttpPost]
        public ActionResult Create(Patient p)
        {
           
            db.Patients.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Edit(int id)
        {
            Patient p = db.Patients.Where(temp => temp.pid == id).FirstOrDefault();
            ViewBag.Doctor = db.Doctors.ToList();
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Patient p)
        {
            
            Patient oldProduct = db.Patients.Where(temp => temp.pid == p.pid).FirstOrDefault();
            oldProduct.pname = p.pname;
            oldProduct.mobile = p.mobile;
            oldProduct.email = p.email;
            oldProduct.paddress = p.paddress;
            oldProduct.description = p.description;
            oldProduct.healthinsurance = p.healthinsurance;
            oldProduct.did = p.did;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            
            Patient p = db.Patients.Where(temp => temp.pid == id).FirstOrDefault();
            db.Patients.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult Search(Patient p)
        {
            ViewBag.s = p;
            List<Patient> patient = db.Patients
           .Where(s => s.pname == p.pname || p.pname == null)
           .Where(s => s.mobile == p.mobile || p.mobile == null)
           .Where(s => s.email == p.email || p.email == null)
           .Where(s => s.did == p.did || p.did == null)
           .ToList();
            ViewBag.doc = db.Doctors;

            return View(patient);
        }
    }
}