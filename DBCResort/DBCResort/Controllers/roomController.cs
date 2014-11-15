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
    public class roomController : Controller
    {
        private mydbEntities db = new mydbEntities();

        //
        // GET: /room/

        public ActionResult Index()
        {
            var rooms = db.rooms.Include(r => r.employee);
            return View(rooms.ToList());
        }

        //
        // GET: /room/Details/5

        public ActionResult Details(int id = 0)
        {
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // GET: /room/Create

        public ActionResult Create()
        {
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username");
            return View();
        }

        //
        // POST: /room/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(room room)
        {
            if (ModelState.IsValid)
            {
                db.rooms.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", room.Employee_idEmployee);
            return View(room);
        }

        //
        // GET: /room/Edit/5

        public ActionResult Edit(int id = 0)
        {
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", room.Employee_idEmployee);
            return View(room);
        }

        //
        // POST: /room/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", room.Employee_idEmployee);
            return View(room);
        }

        //
        // GET: /room/Delete/5

        public ActionResult Delete(int id = 0)
        {
            room room = db.rooms.Find(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        //
        // POST: /room/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            room room = db.rooms.Find(id);
            db.rooms.Remove(room);
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