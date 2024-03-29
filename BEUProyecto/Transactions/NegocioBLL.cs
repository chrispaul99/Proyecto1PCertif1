﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BEUProyecto.Transactions
{
    public class NegocioBLL
    {
        public static void Create(Negocio c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Negocio.Add(c);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Negocio Get(int? id)
        {
            Entities db = new Entities();
            return db.Negocio.Find(id);
        }
        public static void Update(Negocio Negocio)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Negocio.Attach(Negocio);
                        db.Entry(Negocio).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Negocio Negocio = db.Negocio.Find(id);
                        db.Entry(Negocio).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<Negocio> List()
        {
            Entities db = new Entities();
            return db.Negocio.ToList();
        }

        public static List<Negocio> ListCiudad(string ciudad)
        {
            List<Negocio> listado = new List<Negocio>();
            Entities db = new Entities();
            foreach (var item in db.Negocio.ToList())
            {
                Direccion direccion = DireccionBLL.Get(item.idDireccion);
                if (direccion.ciudad == ciudad)
                {
                    listado.Add(item);
                }
            }
            return listado;
        }

        public static List<Negocio> List(string criterio)
        {
            Entities db = new Entities();
            return db.Negocio.Where(x => x.nombre.Contains(criterio)).ToList();
        }
    }
}
