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
    public class DetallesController : Controller
    {
        // GET: Detalles
        public ActionResult Index()
        {
            ViewBag.Title = "Detalles";
            return View(DetalleBLL.List());
        }

        // GET: Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = DetalleBLL.Get(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // GET: Detalles/Create
        public ActionResult Create()
        {
            ViewBag.idLista = new SelectList(ListaBLL.List(), "idLista", "idLista");
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre");
            return View();
        }

        // POST: Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalle,idProducto,idLista")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                DetalleBLL.Create(detalle);
                return RedirectToAction("Index");
            }

            ViewBag.idLista = new SelectList(ListaBLL.List(), "idLista", "idLista", detalle.idLista);
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre", detalle.idProducto);
            return View(detalle);
        }

        // GET: Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = DetalleBLL.Get(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLista = new SelectList(ListaBLL.List(), "idLista", "idLista", detalle.idLista);
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre", detalle.idProducto);
            return View(detalle);
        }

        // POST: Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalle,idProducto,idLista")] Detalle detalle)
        {
            if (ModelState.IsValid)
            {
                DetalleBLL.Update(detalle);
                return RedirectToAction("Index");
            }
            ViewBag.idLista = new SelectList(ListaBLL.List(), "idLista", "idLista", detalle.idLista);
            ViewBag.idProducto = new SelectList(ProductoBLL.List(), "idProducto", "nombre", detalle.idProducto);
            return View(detalle);
        }

        // GET: Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle detalle = DetalleBLL.Get(id);
            if (detalle == null)
            {
                return HttpNotFound();
            }
            return View(detalle);
        }

        // POST: Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
