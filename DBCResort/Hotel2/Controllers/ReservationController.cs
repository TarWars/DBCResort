using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel2.Models;

namespace Hotel2.Controllers
{
    public class ReservationController : Controller
    {
        private DBCResortEntities db = new DBCResortEntities();

        //
        // GET: /Reservation/

        public ActionResult Index()
        {
            var reservations = db.Reservations.Include(r => r.Employee).Include(r => r.Guest).Include(r => r.Room);
            return View(reservations.ToList());
        }

        //
        // GET: /Reservation/Details/5

        public ActionResult Details(int id = 0)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //
        // GET: /Reservation/Create

        public ActionResult Create()
        {
            ViewBag.idEmpoyee = new SelectList(db.Employees, "idEmplyee", "Username");
            ViewBag.idGuest = new SelectList(db.Guests, "idGuest", "Username");
            ViewBag.idRoom = new SelectList(db.Rooms, "idRoom", "Status");
            return View();
        }

        //
        // POST: /Reservation/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpoyee = new SelectList(db.Employees, "idEmplyee", "Username", reservation.idEmpoyee);
            ViewBag.idGuest = new SelectList(db.Guests, "idGuest", "Username", reservation.idGuest);
            ViewBag.idRoom = new SelectList(db.Rooms, "idRoom", "Status", reservation.idRoom);
            return View(reservation);
        }

        //
        // GET: /Reservation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpoyee = new SelectList(db.Employees, "idEmplyee", "Username", reservation.idEmpoyee);
            ViewBag.idGuest = new SelectList(db.Guests, "idGuest", "Username", reservation.idGuest);
            ViewBag.idRoom = new SelectList(db.Rooms, "idRoom", "Status", reservation.idRoom);
            return View(reservation);
        }

        //
        // POST: /Reservation/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpoyee = new SelectList(db.Employees, "idEmplyee", "Username", reservation.idEmpoyee);
            ViewBag.idGuest = new SelectList(db.Guests, "idGuest", "Username", reservation.idGuest);
            ViewBag.idRoom = new SelectList(db.Rooms, "idRoom", "Status", reservation.idRoom);
            return View(reservation);
        }

        //
        // GET: /Reservation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Reservation reservation = db.Reservations.Find(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        //
        // POST: /Reservation/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservation reservation = db.Reservations.Find(id);
            db.Reservations.Remove(reservation);
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