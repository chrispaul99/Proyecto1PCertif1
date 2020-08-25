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
    [RoutePrefix("api/Pedidos")]
    [EnableCors(origins: "https://localhost:4200", headers: "*", methods: "*")]
    public class PedidosController : ApiController
    {
        public IHttpActionResult GetPedido()
        {
            try
            {
                List<Pedido> todos = PedidoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Pedidos/5

        [ResponseType(typeof(Pedido))]
        public IHttpActionResult GetPedido(int id)
        {
            try
            {
                Pedido result = PedidoBLL.Get(id);
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
        [HttpGet]
        [Route("MyOrders")]
        public IHttpActionResult MyOrders(int id)
        {
            try
            {
                List<Pedido> misPedidos = PedidoBLL.MisOrders(id);
                return Content(HttpStatusCode.OK, misPedidos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
        // PUT: api/Pedidos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPedido(int id, Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pedido.idPedido)
            {
                return BadRequest();
            }
            try
            {
                PedidoBLL.Update(pedido);
                return Content(HttpStatusCode.OK, "Pedido actualizado correctamente");
            }
            catch (Exception ex)
            {
                Pedido ped = PedidoBLL.Get(id);
                if (ped == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/Pedidos
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult PostPedido(Pedido pedido)
        {
            try
            {
                PedidoBLL.Create(pedido);
                return Content(HttpStatusCode.Created, "Pedido creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Pedidos/5
        [ResponseType(typeof(Pedido))]
        public IHttpActionResult DeletePedido(int id)
        {
            Pedido pedido = PedidoBLL.Get(id);
            if (pedido == null)
            {
                return NotFound();
            }
            try
            {
                PedidoBLL.Delete(id);
                return Ok("Pedido eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}