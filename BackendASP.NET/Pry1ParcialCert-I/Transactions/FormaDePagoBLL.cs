using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class FormaDePagoBLL
    {
        public static void Create(Forma_de_Pago f)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Forma_de_Pago.Add(f);
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

        public static Forma_de_Pago Get(int? id)
        {
            Entities db = new Entities();
            return db.Forma_de_Pago.Find(id);
        }

        public static void Update(Forma_de_Pago forma_De_Pago)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Forma_de_Pago.Attach(forma_De_Pago);
                        db.Entry(forma_De_Pago).State = System.Data.Entity.EntityState.Modified;
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
                        Forma_de_Pago forma_De_Pago = db.Forma_de_Pago.Find(id);
                        db.Entry(forma_De_Pago).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Forma_de_Pago> List()
        {
            Entities db = new Entities();
            return db.Forma_de_Pago.ToList();
        }
    }
}
