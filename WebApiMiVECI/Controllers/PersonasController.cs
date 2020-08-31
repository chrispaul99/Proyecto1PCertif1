using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BEUProyecto;
using BEUProyecto.Transactions;

namespace WebApiMiVECI.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class PersonasController : ApiController
    {
        // GET: api/Personas
        [Authorize(Roles = "A")]
        public IHttpActionResult GetPersona()
        {
            try
            {
                List<Persona> todos = PersonaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Personas/5
        [Authorize(Roles = "C,N,A")]
        [ResponseType(typeof(Persona))]
        public IHttpActionResult GetPersona(int id)
        {
            try
            {
                Persona result = PersonaBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT: api/Personas/5
        [Authorize(Roles = "C,N,A")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.idPersona)
            {
                return BadRequest();
            }
            try
            {
                PersonaBLL.Update(persona);
                return Content(HttpStatusCode.OK, "Persona actualizada correctamente");
            }
            catch (Exception ex)
            {
                Persona per = PersonaBLL.Get(id);
                if (per == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public IHttpActionResult PostPersona(Persona persona)
        {
            try
            {
                PersonaBLL.Create(persona);
                return Content(HttpStatusCode.Created, "Persona creada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Personas/5
        [Authorize(Roles = "C,N,A")]
        [ResponseType(typeof(Persona))]
        public IHttpActionResult DeletePersona(int id)
        {
            Persona persona = PersonaBLL.Get(id);
            if (persona == null)
            {
                return NotFound();
            }
            try
            {
                PersonaBLL.Delete(id);
                return Ok("Persona eliminada correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}