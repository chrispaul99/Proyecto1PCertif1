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
    public class ComerciantesController : ApiController
    {
        // GET: api/Comerciantes
        public IHttpActionResult GetComerciante()
        {
            try
            {
                List<Comerciante> todos = ComercianteBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Comerciantes/5

        [ResponseType(typeof(Comerciante))]
        public IHttpActionResult GetComerciante(int id)
        {
            try
            {
                Comerciante result = ComercianteBLL.Get(id);
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

        // PUT: api/Comerciantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutComerciante(int id, Comerciante comerciante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comerciante.idComerciante)
            {
                return BadRequest();
            }
            try
            {
                ComercianteBLL.Update(comerciante);
                return Content(HttpStatusCode.OK, "Comerciante actualizado correctamente");
            }
            catch (Exception ex)
            {
                Comerciante cor = ComercianteBLL.Get(id);
                if (cor == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Comerciantes
        [ResponseType(typeof(Comerciante))]
        public IHttpActionResult PostComerciante(Comerciante comerciante)
        {
            try
            {
                ComercianteBLL.Create(comerciante);
                return Content(HttpStatusCode.Created, "Comerciante creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Comerciantes/5
        [ResponseType(typeof(Comerciante))]
        public IHttpActionResult DeleteComerciante(int id)
        {
            Comerciante comerciante = ComercianteBLL.Get(id);
            if (comerciante == null)
            {
                return NotFound();
            }
            try
            {
                ComercianteBLL.Delete(id);
                return Ok("Comerciante eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}