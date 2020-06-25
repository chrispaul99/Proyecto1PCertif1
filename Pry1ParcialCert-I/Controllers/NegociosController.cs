﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUProyecto;
using BEUProyecto.Transactions;
using CloudinaryDotNet;

namespace Pry1ParcialCert_I.Controllers
{
    public class NegociosController : Controller
    {
        private Entities db = new Entities();

        // GET: Negocios
        public ActionResult Index()
        {
            ViewBag.title = "LISTADO DE NEGOCIOS REGISTRADOS";
            return View(NegocioBLL.List());
        }

        public ActionResult PanelCliente_Inicio()
        {
            return View();
        }
        public ActionResult ContactForm(Negocio negocio)
        {
            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(negocio.ImageFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(negocio.ImageFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

            //Its Create complete path to store in server.  
            negocio.imagen = UploadPath + FileName;

            //To copy and save file into server.  
            negocio.ImageFile.SaveAs(negocio.imagen);

            return View();
        }
        // GET: Negocios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = NegocioBLL.Get(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // GET: Negocios/Create
        public ActionResult Create()
        {
            ViewBag.idComerciante = new SelectList(db.Comerciante, "idComerciante", "baseLegal");
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre");
            return View();
        }

        // POST: Negocios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idNegocio,nombre,categoria,descripcion,horario,estado,imagen,delivery,reserva,idDireccion,idComerciante")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                NegocioBLL.Create(negocio);
                return RedirectToAction("Index");
            }

            ViewBag.idComerciante = new SelectList(db.Comerciante, "idComerciante", "baseLegal", negocio.idComerciante);
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre", negocio.idDireccion);
            return View(negocio);
        }

        // GET: Negocios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = NegocioBLL.Get(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idComerciante = new SelectList(db.Comerciante, "idComerciante", "baseLegal", negocio.idComerciante);
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre", negocio.idDireccion);
            return View(negocio);
        }

        // POST: Negocios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idNegocio,nombre,categoria,descripcion,horario,estado,imagen,delivery,reserva,idDireccion,idComerciante")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                NegocioBLL.Update(negocio);
                return RedirectToAction("Index");
            }
            ViewBag.idComerciante = new SelectList(db.Comerciante, "idComerciante", "baseLegal", negocio.idComerciante);
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "nombre", negocio.idDireccion);
            return View(negocio);
        }

        // GET: Negocios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Negocio negocio = NegocioBLL.Get(id);
            if (negocio == null)
            {
                return HttpNotFound();
            }
            return View(negocio);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NegocioBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
