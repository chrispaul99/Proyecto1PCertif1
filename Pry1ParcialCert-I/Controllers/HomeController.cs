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
            PersonaBLL.ValidateLogin(persona);
            if(PersonaBLL.ValidateLogin(persona))
            {
                //Validacion de contraseña
                var idc = 0;
                var idCliente = PersonaBLL.GetId(persona.correo);
                foreach (var item in idCliente)
                {
                    idc = item.idPersona;
                }

                return RedirectToAction("PanelCliente_Inicio", "Negocios", new { id = idc });
            }
            return View();
        }
    }
}