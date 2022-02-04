using ClinicAppNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicAppNew.Controllers
{
        public class DoctorController : Controller
        {

             ClinicAppEntities db = new ClinicAppEntities();
           public ActionResult Index(string search = "", string sortcolm = "dname", string icon = "fa-sort-desc", int pageno = 1)
            {
            
                //display data without any condition
                //List<Doctor> doctors=db.Doctors.ToList();


            //to display data on perticular condition
            List<Doctor> doctors = db.Doctors.Where(temp => temp.dname.Contains(search)).ToList();
                ViewBag.Search = search;



                ViewBag.sortcolm = sortcolm;
                ViewBag.icon = icon;
                if (ViewBag.sortcolm == "did")
                {
                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.did).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.did).ToList();

                }
                else if (ViewBag.sortcolm == "dname")
                {

                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.dname).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.dname).ToList();

                }
                else if (ViewBag.sortcolm == "specialist")
                {

                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.specialist).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.specialist).ToList();


                }
                else if (ViewBag.sortcolm == "mobile")
                {
                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.mobile).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.mobile).ToList();


                }
                else if (ViewBag.sortcolm == "email")
                {
                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.email).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.email).ToList();

                }
                else if (ViewBag.sortcolm == "address")
                {
                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.address).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.address).ToList();

                }
                else if (ViewBag.sortcolm == "description")
                {
                    if (ViewBag.icon == "fa-sort-asc")
                        doctors = doctors.OrderBy(temp => temp.description).ToList();
                    else
                        doctors = doctors.OrderByDescending(temp => temp.description).ToList();

                }

                int recordperpage = 5;
                int totalpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(doctors.Count) / Convert.ToDouble(recordperpage)));
                int pageredcordtoskip = (pageno - 1) * recordperpage;
                ViewBag.pageno = pageno;
                ViewBag.totalpage = totalpage;
                doctors = doctors.Skip(pageredcordtoskip).Take(recordperpage).ToList();
                return View(doctors);
            }

            public ActionResult Details(int id)
            {
               
                Doctor d = db.Doctors.Where(temp => temp.did == id).FirstOrDefault();
                return View(d);
            }

            //this is get method to get create request from user
            public ActionResult Create()
            {
                
                return View();
            }

            //this is post request to insert data from user in form
            [HttpPost]
            public ActionResult Create(Doctor d)
            {
                db.Doctors.Add(d);
                db.SaveChanges();
                return RedirectToAction("index");
            }


            public ActionResult Edit(int id)
            {
                Doctor d = db.Doctors.Where(temp => temp.did == id).FirstOrDefault();
                return View(d);
            }

            [HttpPost]
            public ActionResult Edit(Doctor d)
            {
               
                Doctor oldDoctor = db.Doctors.Where(temp => temp.did == d.did).FirstOrDefault();
                oldDoctor.dname = d.dname;
                oldDoctor.email = d.email;
                oldDoctor.specialist = d.specialist;
                oldDoctor.mobile = d.mobile;
                oldDoctor.address = d.address;
                oldDoctor.description = d.description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        public ActionResult Delete(int id)
        {

            Doctor d = db.Doctors.Where(temp => temp.did == id).FirstOrDefault();
            db.Doctors.Remove(d);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
       }
    }