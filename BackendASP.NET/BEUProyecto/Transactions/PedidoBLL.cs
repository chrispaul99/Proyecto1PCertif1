﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class PedidoBLL
    {
        public static void Create(Pedido c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Pedido.Add(c);
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

        public static Pedido Get(int? id)
        {
            Entities db = new Entities();
            return db.Pedido.Find(id);
        }

        public static void Update(Pedido Pedido)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Pedido.Attach(Pedido);
                        db.Entry(Pedido).State = System.Data.Entity.EntityState.Modified;
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
                        Pedido Pedido = db.Pedido.Find(id);
                        db.Entry(Pedido).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Pedido> List()
        {
            Entities db = new Entities();
            return db.Pedido.ToList();
        }

        public static List<Pedido> FiltrarPorCliente(int idCliente)
        {
            List<Pedido> listado = new List<Pedido>();
            Entities db = new Entities();
            List<Pedido> pedidos = db.Pedido.ToList();
            listado = pedidos.Where(x => x.idCliente == idCliente).ToList();
            /*foreach (var item in db.Pedido.ToList())
            {
                Persona persona = PersonaBLL.Get(item.idCliente);
                if (persona.idPersona == idCliente)
                {
                    listado.Add(item);
                }
            }*/
            return listado;
        }
    }
}
