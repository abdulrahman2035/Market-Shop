using Marketshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Marketshop.Controllers
{
    public class CitiesController : Controller
    {

        private ApplicationDbContext _Context;

        public CitiesController()
        {


            _Context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }




        // GET: Cities
        public ActionResult Index()

        {

            var Cities = _Context.City.Include(m => m.Country).ToList();
            return View(Cities);
        }

        // GET: Cities/Details/5
        public ActionResult Details(int id)
        {

            var Cities = _Context.City.Include(m => m.Country).SingleOrDefault(c=>c.id==id);


            return View(Cities);
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            //get Countries for dropdown list

            var Countries = _Context.Country.ToList();

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Countries)
            {
                List.Add(new SelectListItem { Text=item.Name,Value=item.id.ToString()});
            }
            ViewBag.list = List;

            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        public ActionResult Create(City City)
        {
            try
            {
                // TODO: Add insert logic here

                if (City.id==0)  //add  not edit
                {

                    _Context.City.Add(City);
                    _Context.SaveChanges();


                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {

            var Cities = _Context.City.Include(m => m.Country).SingleOrDefault(c => c.id == id);
            var Countries = _Context.Country.ToList();

            List<SelectListItem> List = new List<SelectListItem>();

            foreach (var item in Countries)
            {

                List.Add(new SelectListItem { Text=item.Name,Value=item.id.ToString()});


            }

            ViewBag.list = List;



            return View(Cities);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, City City)
        {
            try
            {
                // TODO: Add update logic here

                if (City.id>0)
                {
                    var CityDB = _Context.City.SingleOrDefault(c => c.id == id);
                    CityDB.Name = City.Name;
                    CityDB.Countryid = City.Countryid;
                    _Context.SaveChanges();

                }







                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cities/Delete/5
        public ActionResult Delete(int id)
        {
       //     var city = _context.city.Include(m => m.country).SingleOrDefault(c => c.id == id);

            var City = _Context.City.Include(c => c.Country).SingleOrDefault(m=>m.id==id);

            return View(City);
        }

        // POST: Cities/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, City City)
        {
            try
            {
                // TODO: Add delete logic here

                var CityDB = _Context.City.SingleOrDefault(c=>c.id==id);

                _Context.City.Remove(CityDB);
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
