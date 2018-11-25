using Marketshop.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Marketshop.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext _Context;

        public ProductsController()
        {

            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
               
        }

        // GET: Products
        public ActionResult Index()
        {

            var pro = _Context.Product.Include(m => m.Category).ToList();




            return View(pro);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var pro = _Context.Product.Include(m => m.Category).SingleOrDefault(c=>c.id==id);


            return View(pro);
        }

        // GET: Products/Create
        public ActionResult Create()
        {



            var cat = _Context.Category.ToList();
            List<SelectListItem> List = new List<SelectListItem>();


            foreach (var item in cat)
            {

                List.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });

            }

            ViewBag.catlist=List;




            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase File,Product Product)
        {
            try
            {
                Product.Image = File.FileName;

                _Context.Product.Add(Product);
                _Context.SaveChanges();

                if (File.ContentLength > 0)
                {

                    File.SaveAs(Server.MapPath("/Upload/"+File.FileName));

                }





                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {

            var products = _Context.Product.Include(c => c.Category).SingleOrDefault(p => p.id == id);



            var cat = _Context.Category.ToList();

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Text=item.Name,Value=item.id.ToString()});


            }


            ViewBag.catlist = list;



            return View();
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file,int id, Product Product)
        {
            try
            {
                var productdb = _Context.Product.SingleOrDefault(p => p.id == id);

                   var imagedb = productdb.Image;

                if (file != null) { 
                if (file.ContentLength > 0)
                {
                    imagedb = file.FileName;
                    file.SaveAs(Server.MapPath("/Upload/"+file.FileName));

                }

                }
                productdb.Image = imagedb;
                productdb.Categoryid = Product.Categoryid;
               
                productdb.Name = Product.Name;
                productdb.Price = Product.Price;
                productdb.Quantity = Product.Quantity;
                _Context.SaveChanges();


  




                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {


            var ProductDB = _Context.Product.SingleOrDefault(c=>c.id==id);


           


            return View(ProductDB);
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                var ProductDB = _Context.Product.SingleOrDefault(c => c.id == id);
                _Context.Product.Remove(ProductDB);
                _Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
