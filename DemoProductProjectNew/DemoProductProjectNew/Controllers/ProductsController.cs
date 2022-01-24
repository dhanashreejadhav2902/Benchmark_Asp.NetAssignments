using DemoProductProjectNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProductProjectNew.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            List<Product> p = new List<Product>()
            {
                new Product(){ pid=1,pname="Laptop",price=30000},
                new Product(){ pid=2,pname="TV",price=50000},
                new Product(){ pid=3,pname="Mobile",price=10000},
                new Product(){ pid=4,pname="Headphones",price=2000}

            };
            ViewBag.p = p;
            return View();
        }

        public ActionResult Details(int id)
        {
            List<Product> p = new List<Product>()
            {
                new Product(){ pid=1,pname="Laptop",price=30000},
                new Product(){ pid=2,pname="TV",price=50000},
                new Product(){ pid=3,pname="Mobile",price=10000},
                new Product(){ pid=4,pname="Headphones",price=2000}

            };

            Product matchingProduct = null;
            foreach (var item in p)
            {
                if (item.pid == id)
                {
                    matchingProduct = item;
                }
            }

            ViewBag.MatchingProduct = matchingProduct;
            return View();
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p) {
            return View();
        }
    }
}