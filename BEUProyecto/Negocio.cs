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
    using System.Web;

    public partial class Negocio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Negocio()
        {
            this.Producto = new HashSet<Producto>();
        }

        [ScaffoldColumn(false)]
        public int idNegocio { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El nombre es requerido"), MaxLength(55)]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "La categoría es requerida"), MaxLength(55)]
        [Display(Name = "Categoría")]
        public string categoria { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Descripción")]
        public string descripcion { get; set; }

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "EL horario es requerido")]
        [Display(Name = "Horario")]
        public System.DateTime horario { get; set; }


        [Display(Name = "Estado")]
        public bool estado { get; set; }

        [Display(Name = "Imagen")]
        public string imagen { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }


        [Display(Name = "Delivery")]
        public bool delivery { get; set; }

        
        [Display(Name = "Reserva")]
        public bool reserva { get; set; }

        
        [Display(Name = "Dirección")]
        public int idDireccion { get; set; }

        
        [Display(Name = "Comerciante")]
        public int idComerciante { get; set; }
    
        public virtual Comerciante Comerciante { get; set; }
        public virtual Direccion Direccion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
