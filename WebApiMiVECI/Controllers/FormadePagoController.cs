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
    public class FormadePagoController : ApiController
    {
        // GET: api/FormadePago
        [Authorize(Roles = "C,N,A")]
        public IHttpActionResult GetFormaPago()
        {
            try
            {
                List<FormaPago> todos = FormaDePagoBLL.List();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/FormadePago/5
        [Authorize(Roles = "A")]
        [ResponseType(typeof(FormaPago))]
        public IHttpActionResult GetFormaPago(int id)
        {
            try
            {
                FormaPago result = FormaDePagoBLL.Get(id);
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
        [Authorize(Roles = "A")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFormaPago(int id, FormaPago formaPago)
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
                FormaPago forma = FormaDePagoBLL.Get(id);
                if (forma == null)
                {
                    return NotFound();
                }
                else
                {
                    Console.WriteLine(ex);
                    return StatusCode(HttpStatusCode.NoContent);
                }
            }
        }

        // POST: api/FormadePago
        [Authorize(Roles = "A")]
        [ResponseType(typeof(FormaPago))]
        public IHttpActionResult PostFormaPago(FormaPago formaPago)
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
        [Authorize(Roles = "A")]
        [ResponseType(typeof(FormaPago))]
        public IHttpActionResult DeleteFormaPago(int id)
        {
            FormaPago formaPago = FormaDePagoBLL.Get(id);
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