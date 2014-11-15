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
    public class reservationController : Controller
    {
        private mydbEntities db = new mydbEntities();

        //
        // GET: /reservation/

        public ActionResult Index()
        {
            var reservations = db.reservations.Include(r => r.employee).Include(r => r.guest);
            return View(reservations.ToList());
        }

        //
        // GET: /reservation/Details/5

        public ActionResult Details(int id = 0)
        {
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //
        // GET: /reservation/Create

        public ActionResult Create()
        {
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username");
            ViewBag.Guest_idGuest = new SelectList(db.guests, "idGuest", "Username");
            return View();
        }

        //
        // POST: /reservation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", reservation.Employee_idEmployee);
            ViewBag.Guest_idGuest = new SelectList(db.guests, "idGuest", "Username", reservation.Guest_idGuest);
            return View(reservation);
        }

        //
        // GET: /reservation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", reservation.Employee_idEmployee);
            ViewBag.Guest_idGuest = new SelectList(db.guests, "idGuest", "Username", reservation.Guest_idGuest);
            return View(reservation);
        }

        //
        // POST: /reservation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", reservation.Employee_idEmployee);
            ViewBag.Guest_idGuest = new SelectList(db.guests, "idGuest", "Username", reservation.Guest_idGuest);
            return View(reservation);
        }

        //
        // GET: /reservation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            reservation reservation = db.reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //
        // POST: /reservation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reservation reservation = db.reservations.Find(id);
            db.reservations.Remove(reservation);
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