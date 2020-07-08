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
    public class ProductoesController : Controller
    {
        // GET: Productoes
        public ActionResult Index()
        {
            ViewBag.Title = "Productos";
            return View(ProductoBLL.List());
        }

        public ActionResult PanelCliente_Productos(int? id)
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
            ViewBag.id = persona.idPersona;
            ViewBag.nombres = persona.nombres;
            ViewBag.Lst = ProductoBLL.List();
            return View("PanelCliente_Productos");
        }

        // GET: Productoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = ProductoBLL.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.idNegocio = new SelectList(NegocioBLL.List(), "idNegocio", "nombre");
            return View();
        }

        // POST: Productoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,nombre,precio,categoria,descripcion,stock,disponibilidad,imagen,idNegocio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductoBLL.Create(producto);
                return RedirectToAction("Index");
            }

            ViewBag.idNegocio = new SelectList(NegocioBLL.List(), "idNegocio", "nombre", producto.idNegocio);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = ProductoBLL.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idNegocio = new SelectList(NegocioBLL.List(), "idNegocio", "nombre", producto.idNegocio);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,nombre,precio,categoria,descripcion,stock,disponibilidad,imagen,idNegocio")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                ProductoBLL.Update(producto);
                return RedirectToAction("Index");
            }
            ViewBag.idNegocio = new SelectList(NegocioBLL.List(), "idNegocio", "nombre", producto.idNegocio);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = ProductoBLL.Get(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
