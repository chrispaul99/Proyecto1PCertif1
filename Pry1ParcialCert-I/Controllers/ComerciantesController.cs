using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUProyecto;
using BEUProyecto.Transactions;

namespace Pry1ParcialCert_I.Controllers
{
    public class ComerciantesController : Controller
    {
        public ActionResult PanelComerciante(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            Persona persona = PersonaBLL.Get(comerciante.idPersona);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = comerciante.idComerciante;
            ViewBag.nombres = persona.nombres;
            ViewBag.correo = persona.correo;
            return View("PanelComerciante");
        }
        public ActionResult PanelNegocio(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            Persona persona = PersonaBLL.Get(comerciante.idPersona);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = comerciante.idComerciante;
            ViewBag.nombres = persona.nombres;
            ViewBag.correo = persona.correo;
            ViewBag.lst = NegocioBLL.List();
            return View("PanelNegocio");
        }
        public ActionResult PanelPedidos(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            Persona persona = PersonaBLL.Get(comerciante.idPersona);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = comerciante.idComerciante;
            ViewBag.nombres = persona.nombres;
            ViewBag.correo = persona.correo;
            return View("PanelPedidos");
        }
        public ActionResult PanelDatos(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            Persona persona = PersonaBLL.Get(comerciante.idPersona);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            Direccion direccion = DireccionBLL.Get(persona.idDireccion);
            ViewBag.id = comerciante.idComerciante;
            ViewBag.nombres = persona.nombres;
            ViewBag.correo = persona.correo;
            ViewBag.apellidos = persona.apellidos;
            ViewBag.cedula = persona.cedula;
            ViewBag.celular = persona.celular;
            ViewBag.latitud = direccion.latitud;
            ViewBag.longitud = direccion.longitud;
            ViewBag.referencia = direccion.referencia;
            return View("PanelInformacion");
        }
        // GET: Comerciantes
        public ActionResult Index()
        {
            ViewBag.Title = "Comerciantes";
            return View(ComercianteBLL.List());
        }

        // GET: Comerciantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            return View(comerciante);
        }

        // GET: Comerciantes/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Comerciantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "idComerciante,baseLegal,idPersona")] Comerciante comerciante,int id)
        {
                comerciante.idPersona = id;
                ComercianteBLL.Create(comerciante);
                return RedirectToAction("Login","Home");
        }

        // GET: Comerciantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(PersonaBLL.List(), "idPersona", "nombres", comerciante.idPersona);
            return View(comerciante);
        }

        // POST: Comerciantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idComerciante,baseLegal,idPersona")] Comerciante comerciante)
        {
            if (ModelState.IsValid)
            {
                ComercianteBLL.Update(comerciante);
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(PersonaBLL.List(), "idPersona", "nombres", comerciante.idPersona);
            return View(comerciante);
        }

        // GET: Comerciantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = ComercianteBLL.Get(id);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            return View(comerciante);
        }

        // POST: Comerciantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComercianteBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
