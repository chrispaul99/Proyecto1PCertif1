using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiMiVeci.Models;

namespace WebApiMiVECI.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class EmailController : ApiController
    {
        // POST: api/Email
        public IHttpActionResult PostEmail(Email e)
        {
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("Mensaje de Usuario <" + e.destinatario + ">");
            mm.To.Add(e.destinatario);
            mm.Subject = e.Asunto;
            mm.Body = createEmailBody(e);
            mm.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                smtp.Send(mm);
            }
            return Content(HttpStatusCode.OK, "Correo enviado correctamente");
        }

        // PUT: api/Email/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Email/5
        public void Delete(int id)
        {
        }

        private string createEmailBody(Email e)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/Views/Home/Email.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{nombre}", e.nombre);
            body = body.Replace("{correo}", e.emisor);
            body = body.Replace("{asunto}", e.Asunto);
            body = body.Replace("{mensaje}", e.Mensaje);
            return body;

        }
    }
}
