﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Comerciante> Comerciante { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Direccion> Direccion { get; set; }
        public virtual DbSet<Forma_de_Pago> Forma_de_Pago { get; set; }
        public virtual DbSet<Lista> Lista { get; set; }
        public virtual DbSet<Negocio> Negocio { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}
