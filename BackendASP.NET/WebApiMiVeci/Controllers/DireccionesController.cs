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

namespace WebApiMiVeci.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class DireccionesController : ApiController
    {
        // GET: api/Direcciones
        public IHttpActionResult GetDireccion()
        {
            try
            {
                List<Direccion> todos = DireccionBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Direcciones/5
        
        [ResponseType(typeof(Direccion))]
        public IHttpActionResult GetDireccion(int id)
        {
            try
            {
                Direccion result = DireccionBLL.Get(id);
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

        // PUT: api/Direcciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDireccion(int id, Direccion direccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != direccion.idDireccion)
            {
                return BadRequest();
            }
            try
            {
                DireccionBLL.Update(direccion);
                return Content(HttpStatusCode.OK, "Dirección actualizada correctamente");
            }
            catch (Exception ex)
            {
                Direccion dir = DireccionBLL.Get(id);
                if (dir == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Direcciones
        [ResponseType(typeof(Direccion))]
        public IHttpActionResult PostDireccion(Direccion direccion)
        {
            try
            {
                DireccionBLL.Create(direccion);
                return CreatedAtRoute("DefaultApi", new { id = direccion.idDireccion }, direccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Direcciones/5
        [ResponseType(typeof(Direccion))]
        public IHttpActionResult DeleteDireccion(int id)
        {
            Direccion direccion =DireccionBLL.Get(id);
            if (direccion == null)
            {
                return NotFound();
            }
            try
            {
                DireccionBLL.Delete(id);
                return Ok("Dirección eliminada correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            } 
        }
    }
}