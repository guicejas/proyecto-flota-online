﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo.SEGURIDAD
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SistFlota_Seguridad_ModeloContainer : DbContext
    {
        public SistFlota_Seguridad_ModeloContainer()
            : base("name=SistFlota_Seguridad_ModeloContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Perfil> Perfiles { get; set; }
        public virtual DbSet<Formulario> Formularios { get; set; }
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
    }
}