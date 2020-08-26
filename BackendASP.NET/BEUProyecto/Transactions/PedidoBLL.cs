using System;
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
                        c.fecha = DateTime.Now;
                        c.tiempoOrder = "Sin Determinar";
                        c.estado = "Ingresado";
                        UpdateStock(c);

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
        public static void UpdateStock(Pedido pedido)
        {
            foreach (var item in pedido.Lista.Detalle)
            {
                item.Producto.stock -= item.cantidad;
                ProductoBLL.Update(item.Producto);
                item.Producto = null;
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
        public static List<Pedido> MisOrders(int cliente)
        {
            Entities db = new Entities();
            return db.Pedido.Where(x => x.idCliente == cliente).ToList();
        }
    }
}
