using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUProyecto.Transactions
{
    public class PersonaBLL
    {
        public static void Create(Persona p)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Persona.Add(p);
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

        public static Persona Get(int? id)
        {
            Entities db = new Entities();
            return db.Persona.Find(id);
        }

        public static void Update(Persona alumno)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Persona.Attach(alumno);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Modified;
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

        public static bool ValidateLogin(Persona persona)
        {
            Entities db = new Entities();
            foreach(var item in db.Persona.ToList())
            {
                if(item.correo==persona.correo && item.password == persona.password)
                {
                    return true;
                }
            }
            return false;

        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Persona alumno = db.Persona.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<Persona> List()
        {
            Entities db = new Entities();
            return db.Persona.ToList();
        }


        private static List<Persona> GetPersonas(string criterio)
        {
            Entities db = new Entities();
            return db.Persona.Where(x => x.apellidos.ToLower().Contains(criterio)).ToList();
        }

        private static Persona GetPersona(string cedula)
        {
            Entities db = new Entities();
            return db.Persona.FirstOrDefault(x => x.cedula == cedula);
        }
    }
}
