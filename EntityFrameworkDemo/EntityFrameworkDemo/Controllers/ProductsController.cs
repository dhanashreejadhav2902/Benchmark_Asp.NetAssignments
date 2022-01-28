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
        public ActionResult Index(string search="",string sortcolm="pname",string icon="fa-sort-desc",int pageno=1)
        {
            ProductDbEntities1 db = new ProductDbEntities1();
            //display data without any condition
            //List<Product> products=db.Products.ToList();


            //to display data on perticular condition
            List<Product> products = db.Products.Where(temp=>temp.pname.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.sortcolm=sortcolm;
            ViewBag.icon=icon;
            if (ViewBag.sortcolm == "pid") {
                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.pid).ToList();
                else
                    products = products.OrderByDescending(temp => temp.pid).ToList();

            } else if (ViewBag.sortcolm == "pname") {

                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.pname).ToList();
                else
                    products = products.OrderByDescending(temp => temp.pname).ToList();

            } else if (ViewBag.sortcolm == "price") {

                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.price).ToList();


            } else if (ViewBag.sortcolm == "dateofpurchase") {
                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.dateofpurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.dateofpurchase).ToList();


            }
            else if (ViewBag.sortcolm == "availablestatus")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.availablestatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.availablestatus).ToList();

            }
            else if (ViewBag.sortcolm == "cid")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.cname).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.cname).ToList();

            }
            else if (ViewBag.sortcolm == "bid")
            {
                if (ViewBag.icon == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.bname).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.bname).ToList();

            }

            int recordperpage = 5;
            int totalpage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count)/ Convert.ToDouble(recordperpage)));
            int pageredcordtoskip =(pageno-1)*recordperpage;
            ViewBag.pageno = pageno;
            ViewBag.totalpage=totalpage;
            products = products.Skip(pageredcordtoskip).Take(recordperpage).ToList();
            return View(products);
        }

        public ActionResult Details(int id) { 
        ProductDbEntities1 db=new ProductDbEntities1();
        Product p = db.Products.Where(temp => temp.pid == id).FirstOrDefault();
        return View(p);
        }

        //this is get method to get create request from user
        public ActionResult Create() {
            ProductDbEntities1 db = new ProductDbEntities1();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands=db.Brands.ToList();
            return View();
        }

        //this is post request to insert data from user in form
        [HttpPost]
        public ActionResult Create(Product p) {
            ProductDbEntities1 db = new ProductDbEntities1();

            /* file uploading
            if (Request.Files.Count>=1) { 
                 var file=Request.Files[0];
                 var imgBytes = new Byte[file.ContentLength-1];
                file.InputStream.Read(imgBytes, 0, file.ContentLength);
                var base64string=Convert.ToBase64String(imgBytes,0,imgBytes.Length);
                p.photo = base64string;
            }
            */

            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("index");
        }


        public ActionResult Edit(int id) {
           ProductDbEntities1 db = new ProductDbEntities1();
           Product p = db.Products.Where(temp => temp.pid == id).FirstOrDefault();
           ViewBag.Categories = db.Categories.ToList();
           ViewBag.Brands = db.Brands.ToList();
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