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
    
    public partial class Persona
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Persona()
        {
            this.Comerciante = new HashSet<Comerciante>();
        }
    
        public int idPersona { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string cedula { get; set; }
        public string celular { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string rol { get; set; }
        public int idDireccion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comerciante> Comerciante { get; set; }
        public virtual Direccion Direccion { get; set; }
    }
}