using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pry1ParcialCert_I.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.title = "MI VECI";
            return View("Home");
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        public ActionResult Register(int? id)
        {
            return View("Registro");
        }
    }
}