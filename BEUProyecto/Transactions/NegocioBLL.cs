using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        Account account = new Account("dvjjvc5d6", "378624257943757", "V5KFa3uKUWpwCcok3g0n3pYyf4o");
                        Cloudinary cloudinary = new Cloudinary(account);
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(c.imagen)
                        };
                        var uploadResult = cloudinary.Upload(uploadParams);
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
    }
}
