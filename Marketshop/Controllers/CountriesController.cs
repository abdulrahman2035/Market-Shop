using Marketshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marketshop.Controllers
{
    public class CountriesController : Controller
    {

        private ApplicationDbContext _Context;


        public CountriesController()
        {

            _Context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        // GET: Countries
        public ActionResult Index()
        {

            //var Countries = _Context.Country.ToList();
            var Countries = _Context.Country.ToList();

            return View(Countries);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {

            //var Countries = _Context.Country.SingleOrDefault(c=>c.id==id);

            var Countries = _Context.Country.SingleOrDefault(c => c.id == id);


            return View(Countries);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        public ActionResult Create(Country Country)
        {
            try
            {


                _Context.Country.Add(Country);
                _Context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {

         var countries=  _Context.Country.SingleOrDefault(c => c.id == id);


            return View(countries);
        }

        // POST: Countries/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Country Country)
        {
            try
            {
                // TODO: Add update logic here


                var CountryDB = _Context.Country.SingleOrDefault(c => c.id == id);
                CountryDB.Name = Country.Name;
                _Context.SaveChanges();




                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {

            var country = _Context.Country.SingleOrDefault(c => c.id == id);

            return View(country);
        }

        // POST: Countries/Delete/5
        [HttpPost] 
        public ActionResult Delete(int id, Country Country)
        {
            try
            {
                // TODO: Add delete logic here

                var CountryDB = _Context.Country.SingleOrDefault(c => c.id == id);

                _Context.Country.Remove(CountryDB);
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
