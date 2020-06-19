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
    public class Forma_de_PagoController : Controller
    {
        private Entities db = new Entities();

        // GET: Forma_de_Pago
        public ActionResult Index()
        {
            return View(db.Forma_de_Pago.ToList());
        }

        // GET: Forma_de_Pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forma_de_Pago forma_de_Pago = db.Forma_de_Pago.Find(id);
            if (forma_de_Pago == null)
            {
                return HttpNotFound();
            }
            return View(forma_de_Pago);
        }

        // GET: Forma_de_Pago/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Forma_de_Pago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFormaPago,cantidad")] Forma_de_Pago forma_de_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Forma_de_Pago.Add(forma_de_Pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forma_de_Pago);
        }

        // GET: Forma_de_Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forma_de_Pago forma_de_Pago = db.Forma_de_Pago.Find(id);
            if (forma_de_Pago == null)
            {
                return HttpNotFound();
            }
            return View(forma_de_Pago);
        }

        // POST: Forma_de_Pago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFormaPago,cantidad")] Forma_de_Pago forma_de_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forma_de_Pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forma_de_Pago);
        }

        // GET: Forma_de_Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forma_de_Pago forma_de_Pago = db.Forma_de_Pago.Find(id);
            if (forma_de_Pago == null)
            {
                return HttpNotFound();
            }
            return View(forma_de_Pago);
        }

        // POST: Forma_de_Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forma_de_Pago forma_de_Pago = db.Forma_de_Pago.Find(id);
            db.Forma_de_Pago.Remove(forma_de_Pago);
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
