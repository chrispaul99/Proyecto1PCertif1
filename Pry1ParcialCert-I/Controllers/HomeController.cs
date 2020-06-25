using BEUProyecto;
using BEUProyecto.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public ActionResult Login(Persona persona)
        {
            int idPer=PersonaBLL.ValidateLogin(persona);
            if(PersonaBLL.ValidateLogin(persona)!=0)
            {
                return RedirectToAction("PanelComerciante","Comerciantes",new {id=idPer});
            }
            return View();
        }
    }
}