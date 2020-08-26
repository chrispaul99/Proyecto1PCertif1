using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class DireccionBLL
    {
        public static void Create(Direccion d)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Direccion.Add(d);
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

        public static Direccion Get(int? id)
        {
            Entities db = new Entities();
            return db.Direccion.Find(id);
        }
        public static Direccion GetAdress(string ln,string lat)
        {
            int id = 0;
            Entities db = new Entities();
            foreach(var item in db.Direccion)
            {
                if(item.latitud==ln && item.latitud == lat)
                {
                    id = item.idDireccion;   
                }
            }
            return db.Direccion.Find(id);
        }
        public static void Update(Direccion direccion)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Direccion.Attach(direccion);
                        db.Entry(direccion).State = System.Data.Entity.EntityState.Modified;
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
                        Direccion direccion = db.Direccion.Find(id);
                        db.Entry(direccion).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Direccion> List()
        {
            Entities db = new Entities();
            return db.Direccion.ToList();
        }
    }
}
