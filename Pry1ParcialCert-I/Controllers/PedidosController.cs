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
    public class PedidosController : Controller
    {
        private Entities db = new Entities();

        // GET: Pedidos
        public ActionResult Index()
        {
            ViewBag.title = "LISTADO DE PEDIDOS REGISTRADOS";
            return View(PedidoBLL.List());
        }

        public ActionResult PanelCliente_Pedidos()
        {
            return View();
        }

        public ActionResult Comprobante()
        {
            return View();
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.idFormaPago = new SelectList(db.Forma_de_Pago, "idFormaPago", "idFormaPago");
            ViewBag.idLista = new SelectList(db.Lista, "idLista", "idLista");
            return View();
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedido,fecha,documento,idCliente,idLista,idFormaPago")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                PedidoBLL.Create(pedido);
                return RedirectToAction("Index");
            }

            ViewBag.idFormaPago = new SelectList(db.Forma_de_Pago, "idFormaPago", "idFormaPago", pedido.idFormaPago);
            ViewBag.idLista = new SelectList(db.Lista, "idLista", "idLista", pedido.idLista);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFormaPago = new SelectList(db.Forma_de_Pago, "idFormaPago", "idFormaPago", pedido.idFormaPago);
            ViewBag.idLista = new SelectList(db.Lista, "idLista", "idLista", pedido.idLista);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedido,fecha,documento,idCliente,idLista,idFormaPago")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                PedidoBLL.Create(pedido);
                return RedirectToAction("Index");
            }
            ViewBag.idFormaPago = new SelectList(db.Forma_de_Pago, "idFormaPago", "idFormaPago", pedido.idFormaPago);
            ViewBag.idLista = new SelectList(db.Lista, "idLista", "idLista", pedido.idLista);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
