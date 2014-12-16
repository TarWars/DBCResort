using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Hotel2.Controllers
{
    public class SessionController : Controller
    {

        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public void Create(string username, string password)
        {
            System.Web.HttpContext.Current.Response.Write("Test create:" + username + password);
            //Response.Redirect("http://localhost:50674");

        }


    }
}
