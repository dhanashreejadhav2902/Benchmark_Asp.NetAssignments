using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            List<Category> catogires=db.Categories.ToList();
            return View(catogires);
        }
    }
}