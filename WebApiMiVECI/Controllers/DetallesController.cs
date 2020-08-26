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
    public class DetallesController : ApiController
    {
        // GET: api/Detalles
        public IHttpActionResult GetDetalle()
        {
            try
            {
                List<Detalle> todos = DetalleBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Detalles/5

        [ResponseType(typeof(Detalle))]
        public IHttpActionResult GetDetalle(int id)
        {
            try
            {
                Detalle result = DetalleBLL.Get(id);
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

        // PUT: api/Detalles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDetalle(int id, Detalle detalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != detalle.idDetalle)
            {
                return BadRequest();
            }
            try
            {
                DetalleBLL.Update(detalle);
                return Content(HttpStatusCode.OK, "Detalle actualizado correctamente");
            }
            catch (Exception ex)
            {
                Detalle det = DetalleBLL.Get(id);
                if (det == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Detalles
        [ResponseType(typeof(Detalle))]
        public IHttpActionResult PostDetalle(Detalle detalle)
        {
            try
            {
                DetalleBLL.Create(detalle);
                return Content(HttpStatusCode.Created, "Detalle creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Detalles/5
        [ResponseType(typeof(Detalle))]
        public IHttpActionResult DeleteDetalle(int id)
        {
            Detalle detalle = DetalleBLL.Get(id);
            if (detalle == null)
            {
                return NotFound();
            }
            try
            {
                DetalleBLL.Delete(id);
                return Ok("Detalle eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}