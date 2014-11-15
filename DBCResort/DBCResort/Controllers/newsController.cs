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
    public class newsController : Controller
    {
        private mydbEntities db = new mydbEntities();

        //
        // GET: /news/

        public ActionResult Index()
        {
            var news = db.news.Include(n => n.employee);
            return View(news.ToList());
        }

        //
        // GET: /news/Details/5

        public ActionResult Details(int id = 0)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // GET: /news/Create

        public ActionResult Create()
        {
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username");
            return View();
        }

        //
        // POST: /news/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(news news)
        {
            if (ModelState.IsValid)
            {
                db.news.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", news.Employee_idEmployee);
            return View(news);
        }

        //
        // GET: /news/Edit/5

        public ActionResult Edit(int id = 0)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", news.Employee_idEmployee);
            return View(news);
        }

        //
        // POST: /news/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(news news)
        {
            if (ModelState.IsValid)
            {
                db.Entry(news).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Employee_idEmployee = new SelectList(db.employees, "idEmployee", "Username", news.Employee_idEmployee);
            return View(news);
        }

        //
        // GET: /news/Delete/5

        public ActionResult Delete(int id = 0)
        {
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        //
        // POST: /news/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            news news = db.news.Find(id);
            db.news.Remove(news);
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