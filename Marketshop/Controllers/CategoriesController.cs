using Marketshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketshop.Controllers
{
    public class CategoriesController : Controller
    {

        private ApplicationDbContext _Context;
        public CategoriesController()
        {

            _Context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();

        }
        


        // GET: Categories
        public ActionResult Index()
        {

            var cat = _Context.Category.ToList();



            return View(cat);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {

            var cat = _Context.Category.SingleOrDefault(c => c.id == id);

            return View(cat);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {



            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(Category Category)
        {
            try
            {
                _Context.Category.Add(Category);

                _Context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {

            var cat = _Context.Category.SingleOrDefault(c => c.id == id);

            return View(cat);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category Category)
        {
            try
            {
                var catdb = _Context.Category.SingleOrDefault(c => c.id == id);
                catdb.Name = Category.Name;

                _Context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {

            var cat = _Context.Category.SingleOrDefault(c=>c.id==id);


            return View(cat);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category Category)
        {
            try
            {

                var catdb = _Context.Category.SingleOrDefault(c => c.id == id);

                _Context.Category.Remove(catdb);
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
