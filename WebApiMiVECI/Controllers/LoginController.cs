using BEUProyecto;
using BEUProyecto.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiMiVeci.Models;

namespace WebApiMiVECI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Login")]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            Persona usuario = new Persona();
            usuario.correo = login.correo;
            usuario.password = login.password;
            Persona user = PersonaBLL.ValidateLogin(usuario);
            if (user != null)
            {
                return Ok(new { token = TokenGenerator.GenerateTokenJwt(user) });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
