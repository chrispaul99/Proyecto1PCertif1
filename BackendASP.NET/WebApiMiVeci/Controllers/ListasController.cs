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
    public class ListasController : ApiController
    {
        public IHttpActionResult GetLista()
        {
            try
            {
                List<Lista> todos = ListaBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Listas/5

        [ResponseType(typeof(Lista))]
        public IHttpActionResult GetLista(int id)
        {
            try
            {
                Lista result = ListaBLL.Get(id);
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

        // PUT: api/Listas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLista(int id, Lista lista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lista.idLista)
            {
                return BadRequest();
            }
            try
            {
                ListaBLL.Update(lista);
                return Content(HttpStatusCode.OK, "Lista actualizada correctamente");
            }
            catch (Exception ex)
            {
                Lista list = ListaBLL.Get(id);
                if (list == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Listas
        [ResponseType(typeof(Lista))]
        public IHttpActionResult PostLista(Lista lista)
        {
            try
            {
                ListaBLL.Create(lista);
                return Content(HttpStatusCode.Created, "Lista creada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Listas/5
        [ResponseType(typeof(Lista))]
        public IHttpActionResult DeleteLista(int id)
        {
            Lista lista = ListaBLL.Get(id);
            if (lista == null)
            {
                return NotFound();
            }
            try
            {
                ListaBLL.Delete(id);
                return Ok("Lista eliminada correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}