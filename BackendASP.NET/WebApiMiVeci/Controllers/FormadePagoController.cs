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
    [Authorize]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class FormadePagoController : ApiController
    {
        // GET: api/FormadePago
        public IHttpActionResult GetFormaPago()
        {
            try
            {
                List<Forma_de_Pago> todos = FormaDePagoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/FormadePago/5

        [ResponseType(typeof(Forma_de_Pago))]
        public IHttpActionResult GetFormaPago(int id)
        {
            try
            {
                Forma_de_Pago result = FormaDePagoBLL.Get(id);
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

        // PUT: api/FormadePago/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormaPago(int id, Forma_de_Pago formaPago)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != formaPago.idFormaPago)
            {
                return BadRequest();
            }
            try
            {
                FormaDePagoBLL.Update(formaPago);
                return Content(HttpStatusCode.OK, "Forma de Pago actualizada correctamente");
            }
            catch (Exception ex)
            {
                Forma_de_Pago forma = FormaDePagoBLL.Get(id);
                if (forma == null)
                {
                    return NotFound();
                }
                else
                {
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/FormadePago
        [ResponseType(typeof(Forma_de_Pago))]
        public IHttpActionResult PostFormaPago(Forma_de_Pago formaPago)
        {
            try
            {
                FormaDePagoBLL.Create(formaPago);
                return Content(HttpStatusCode.Created, "Forma de Pago creada correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/FormadePago/5
        [ResponseType(typeof(Forma_de_Pago))]
        public IHttpActionResult DeleteFormaPago(int id)
        {
            Forma_de_Pago formaPago = FormaDePagoBLL.Get(id);
            if (formaPago == null)
            {
                return NotFound();
            }
            try
            {
                FormaDePagoBLL.Delete(id);
                return Ok("Forma de Pago eliminada correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}