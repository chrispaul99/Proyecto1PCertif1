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
    public class PersonasController : Controller
    {
        private Entities db = new Entities();

        // GET: Personas
        public ActionResult Index()
        {
            ViewBag.title = "LISTADO DE PERSONAS REGISTRADAS";
            return View(PersonaBLL.List());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = PersonaBLL.Get(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Register(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = DireccionBLL.Get(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "idPersona,nombres,apellidos,cedula,celular,correo,password,rol,idDireccion")] Persona persona, int? id)
        {
            if (ModelState.IsValid)
            {
                persona.idDireccion = id;
                PersonaBLL.Create(persona);
                if(persona.rol=="N")
                    return RedirectToAction("Register", "Comerciantes", new { id = persona.idPersona });
                else
                    return RedirectToAction("Login", "Home");
            }
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre", persona.idDireccion);
            return RedirectToAction("Register", "Personas");

        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = PersonaBLL.Get(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre", persona.idDireccion);
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPersona,nombres,apellidos,cedula,celular,correo,password,rol,idDireccion")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                PersonaBLL.Update(persona);
                return RedirectToAction("Index");
            }
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre", persona.idDireccion);
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = PersonaBLL.Get(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonaBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
