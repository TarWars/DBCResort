using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hotel2.Models;

namespace Hotel2.Controllers
{
    public class DashboardController : Controller
    {

        public ActionResult Index() {
            return View();
        }
    }
}
