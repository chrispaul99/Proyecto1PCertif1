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
    //[Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class NegociosController : ApiController
    {
        public IHttpActionResult GetNegocio()
        {
            try
            {
                List<Negocio> todos = NegocioBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Negocios/5

        [ResponseType(typeof(Negocio))]
        public IHttpActionResult GetNegocio(int id)
        {
            try
            {
                Negocio result = NegocioBLL.Get(id);
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

        // PUT: api/Negocios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNegocio(Negocio negocio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                NegocioBLL.Update(negocio);
                return Content(HttpStatusCode.OK, "Negocio actualizado correctamente");
            }
            catch (Exception ex)
            {
                if (negocio == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Negocios
        [ResponseType(typeof(Negocio))]
        public IHttpActionResult PostNegocio(Negocio negocio)
        {
            try
            {
                NegocioBLL.Create(negocio);
                return Content(HttpStatusCode.Created, "Negocio creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Negocios/5
        [ResponseType(typeof(Negocio))]
        public IHttpActionResult DeleteNegocio(int id)
        {
            Negocio negocio = NegocioBLL.Get(id);
            if (negocio == null)
            {
                return NotFound();
            }
            try
            {
                NegocioBLL.Delete(id);
                return Ok("Negocio eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}