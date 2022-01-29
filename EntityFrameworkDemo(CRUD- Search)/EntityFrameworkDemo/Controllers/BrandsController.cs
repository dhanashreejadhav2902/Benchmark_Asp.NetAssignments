using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class BrandsController : Controller
    {
        // GET: Brands
        public ActionResult Index()
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            List<Brand> brands=db.Brands.ToList();
            return View(brands);

        }
    }
}