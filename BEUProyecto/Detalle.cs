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
    
    public partial class Detalle
    {
        public int idDetalle { get; set; }
        public int idProducto { get; set; }
        public int idLista { get; set; }
        public int cantidad { get; set; }
        public decimal total { get; set; }
    
        public virtual Lista Lista { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
