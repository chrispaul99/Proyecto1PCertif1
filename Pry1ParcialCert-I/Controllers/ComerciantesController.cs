using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUProyecto;

namespace Pry1ParcialCert_I.Controllers
{
    public class ComerciantesController : Controller
    {
        private Entities db = new Entities();

        // GET: Comerciantes
        public ActionResult Index()
        {
            var comerciante = db.Comerciante.Include(c => c.Persona);
            return View(comerciante.ToList());
        }

        // GET: Comerciantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = db.Comerciante.Find(id);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            return View(comerciante);
        }

        // GET: Comerciantes/Create
        public ActionResult Create()
        {
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombres");
            return View();
        }

        // POST: Comerciantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idComerciante,baseLegal,idPersona")] Comerciante comerciante)
        {
            if (ModelState.IsValid)
            {
                db.Comerciante.Add(comerciante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombres", comerciante.idPersona);
            return View(comerciante);
        }

        // GET: Comerciantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = db.Comerciante.Find(id);
            if (comerciante == null)
            {
                return HttpNotFound();
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombres", comerciante.idPersona);
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
                db.Entry(comerciante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idPersona = new SelectList(db.Persona, "idPersona", "nombres", comerciante.idPersona);
            return View(comerciante);
        }

        // GET: Comerciantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comerciante comerciante = db.Comerciante.Find(id);
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
            Comerciante comerciante = db.Comerciante.Find(id);
            db.Comerciante.Remove(comerciante);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
