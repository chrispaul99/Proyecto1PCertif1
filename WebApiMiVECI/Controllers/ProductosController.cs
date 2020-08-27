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
    [RoutePrefix("api/Productos")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ProductosController : ApiController
    {
        [AllowAnonymous]
        public IHttpActionResult GetProducto()
        {
            try
            {
                List<Producto> todos = ProductoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        [Authorize(Roles = "N,C,A")]
        [HttpPost]
        [Route("Search")]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult Search(int id)
        {
            try
            {
                Producto result = ProductoBLL.Get(id);
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

        // GET: api/Productos/5
        [Authorize(Roles = "N,C,A")]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult GetProducto(int id)
        {
            try
            {
                List<Producto> result = ProductoBLL.ListNegocio(id);
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

        // PUT: api/Productos/5
        [Authorize(Roles = "N,A")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.idProducto)
            {
                return BadRequest();
            }
            try
            {
                ProductoBLL.Update(producto);
                return Content(HttpStatusCode.OK, "Producto actualizado correctamente");
            }
            catch (Exception ex)
            {
                Producto pro = ProductoBLL.Get(id);
                if (pro == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Productos
        [Authorize(Roles = "N,A")]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult PostProducto(Producto producto)
        {
            try
            {
                ProductoBLL.Create(producto);
                return Content(HttpStatusCode.Created, "Producto creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Productos/5
        [Authorize(Roles = "N,A")]
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteProducto(int id)
        {
            Producto producto = ProductoBLL.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            try
            {
                ProductoBLL.Delete(id);
                return Ok("Producto eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}