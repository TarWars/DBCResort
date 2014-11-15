using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBCResort.Models;

namespace DBCResort.Controllers
{
    public class guestController : Controller
    {
        private mydbEntities db = new mydbEntities();

        //
        // GET: /guest/

        public ActionResult Index()
        {
            return View(db.guests.ToList());
        }

        //
        // GET: /guest/Details/5

        public ActionResult Details(int id = 0)
        {
            guest guest = db.guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // GET: /guest/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /guest/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(guest guest)
        {
            if (ModelState.IsValid)
            {
                db.guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guest);
        }

        //
        // GET: /guest/Edit/5

        public ActionResult Edit(int id = 0)
        {
            guest guest = db.guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // POST: /guest/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        //
        // GET: /guest/Delete/5

        public ActionResult Delete(int id = 0)
        {
            guest guest = db.guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        //
        // POST: /guest/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            guest guest = db.guests.Find(id);
            db.guests.Remove(guest);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}