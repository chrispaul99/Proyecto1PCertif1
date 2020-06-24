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
    using System.ComponentModel.DataAnnotations;

    public partial class Direccion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Direccion()
        {
            this.Negocio = new HashSet<Negocio>();
            this.Persona = new HashSet<Persona>();
        }

        [ScaffoldColumn(false)]
        public int idDireccion { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(55)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La latitud es requerida"), MaxLength(55)]
        [Display(Name = "Latitud")]
        public string latitud { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La longitud es requerida"), MaxLength(55)]
        [Display(Name = "Longitud")]
        public string longitud { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Referencia")]
        public string referencia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Negocio> Negocio { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Persona> Persona { get; set; }
    }
}
