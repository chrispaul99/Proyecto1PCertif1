//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUProyecto
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pedido
    {
        public int idPedido { get; set; }
        public System.DateTime fecha { get; set; }
        public string documento { get; set; }
        public int idCliente { get; set; }
        public int idFormaPago { get; set; }
        public string tiempoOrder { get; set; }
        public string estado { get; set; }
        public int idLista { get; set; }
    
        public virtual FormaPago FormaPago { get; set; }
        public virtual Lista Lista { get; set; }
        public virtual Persona Persona { get; set; }
    }
}
