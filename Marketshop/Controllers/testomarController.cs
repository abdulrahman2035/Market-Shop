using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketshop.Controllers
{
    public class testomarController : Controller
    {
        // GET: testomar
        public ActionResult Index()
        {
            return View();
        }

        // GET: testomar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: testomar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: testomar/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: testomar/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: testomar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: testomar/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: testomar/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
