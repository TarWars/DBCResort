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
    public class RoomController : Controller
    {
        private DBCResortEntities db = new DBCResortEntities();

        //
        // GET: /Room/

        public ActionResult Index()
        {
            var rooms = db.Rooms.Include(r => r.Employee);
            return View(rooms.ToList());
        }

        //
        // GET: /Room/Details/5

        public ActionResult Details(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // GET: /Room/Create

        public ActionResult Create()
        {
            ViewBag.idEmployee = new SelectList(db.Employees, "idEmplyee", "Username");
            return View();
        }

        //
        // POST: /Room/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmployee = new SelectList(db.Employees, "idEmplyee", "Username", room.idEmployee);
            return View(room);
        }

        //
        // GET: /Room/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmployee = new SelectList(db.Employees, "idEmplyee", "Username", room.idEmployee);
            return View(room);
        }

        //
        // POST: /Room/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmployee = new SelectList(db.Employees, "idEmplyee", "Username", room.idEmployee);
            return View(room);
        }

        //
        // GET: /Room/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /Room/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
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