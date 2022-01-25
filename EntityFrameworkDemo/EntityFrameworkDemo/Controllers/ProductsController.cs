using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkDemo.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(string search="")
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            //display data without any condition
            //List<Product> products=db.Products.ToList();


            //to display data on perticular condition
            List<Product> products = db.Products.Where(temp=>temp.pname.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(products);
        }

        public ActionResult Details(int id) { 
        ProductDbEntities1 db=new ProductDbEntities1();
        Product p = db.Products.Where(temp => temp.pid == id).FirstOrDefault();
        return View(p);
        }

        //this is get method to get create request from user
        public ActionResult Create() {
            return View();
        }

        //this is post request to insert data from user in form
        [HttpPost]
        public ActionResult Create(Product p) {
            ProductDbEntities1 db = new ProductDbEntities1();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Edit(int id) {
           ProductDbEntities1 db = new ProductDbEntities1();
           Product p = db.Products.Where(temp => temp.pid == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            Product oldProduct = db.Products.Where(temp => temp.pid == p.pid).FirstOrDefault();
            oldProduct.pname = p.pname;
            oldProduct.price = p.price;
            oldProduct.dateofpurchase = p.dateofpurchase;
            oldProduct.availablestatus = p.availablestatus;
            oldProduct.bid = p.bid;
            oldProduct.cid = p.cid;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            Product p = db.Products.Where(temp => temp.pid == id).FirstOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id,Product p1)
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            Product p = db.Products.Where(temp => temp.pid == id).FirstOrDefault();
            db.Products.Remove(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}