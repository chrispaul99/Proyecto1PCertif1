using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class ProductoBLL
    {
        public static void Create(Producto c)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Producto.Add(c);
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

        public static Producto Get(int? id)
        {
            Entities db = new Entities();
            return db.Producto.Find(id);
        }

        public static void Update(Producto Producto)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Producto.Attach(Producto);
                        db.Entry(Producto).State = System.Data.Entity.EntityState.Modified;
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
                        Producto Producto = db.Producto.Find(id);
                        db.Entry(Producto).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Producto> List()
        {
            Entities db = new Entities();
            return db.Producto.ToList();
        }
        public static List<Producto> ListAzar()
        {
            List<Producto> listado = List();
            int total = listado.Count();
            List<Producto> listadoAzar = new List<Producto>();
            Random rnd = new Random();
            for(int i=1;i<=10;i++)
            {
                int num = rnd.Next(total);
                listadoAzar.Add(listado[num]);
                
            }
            return listadoAzar;
        }
        public static List<Producto> ListNegocio(int idNegocio)
        {
            List<Producto> listado = new List<Producto>();
            Entities db = new Entities();
            foreach (var item in db.Producto.ToList())
            {
                Negocio negocio = NegocioBLL.Get(item.idNegocio);
                if (negocio.idNegocio == idNegocio)
                {
                    listado.Add(item);
                }
            }
            return listado;
        }
    }
}
