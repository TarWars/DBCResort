using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel2.Models;

namespace Hotel2.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            DBCResortEntities db = new DBCResortEntities();
            ViewBag.idEmpoyee = new SelectList(db.Employees, "idEmplyee", "Username");
            ViewBag.idGuest = new SelectList(db.Guests, "idGuest", "Username");
            ViewBag.idRoom = new SelectList(db.Rooms, "idRoom", "Status");
            return View();
        }

    }
}
