using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiMiVeci.Models
{
    public class Email
    {
        public string emisor { get; set; }
        public string nombre { get; set; }
        public string destinatario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }
}