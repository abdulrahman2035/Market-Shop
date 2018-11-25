using Marketshop.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketshop.Controllers
{

    public class HomeController : Controller
    {

        private ApplicationDbContext _Context;
        public HomeController()
        {

            _Context = new ApplicationDbContext();
        }

        public ActionResult category()
        {

            var cat = _Context.Category.ToList();


            return View(cat);
        }

        public ActionResult Products(int id)
        {

            var products = _Context.Product.Where(c=>c.Categoryid==id );


            return View(products);
        }

        public ActionResult Product_Details(int id)
        {

            var productDetails = _Context.Product.Include(c=>c.Category).SingleOrDefault(p=>p.id==id);


            return View(productDetails);
        }



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}