﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BecDevGenEntradaSalidaCprEvent
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class adConexionDB : DbContext
    {
        public adConexionDB()
            : base("name=adConexionDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admAgentes> admAgentes { get; set; }
        public virtual DbSet<admAlmacenes> admAlmacenes { get; set; }
        public virtual DbSet<admCaracteristicas> admCaracteristicas { get; set; }
        public virtual DbSet<admCaracteristicasValores> admCaracteristicasValores { get; set; }
        public virtual DbSet<admClasificaciones> admClasificaciones { get; set; }
        public virtual DbSet<admClasificacionesValores> admClasificacionesValores { get; set; }
        public virtual DbSet<admClientes> admClientes { get; set; }
        public virtual DbSet<admConceptos> admConceptos { get; set; }
        public virtual DbSet<admDocumentos> admDocumentos { get; set; }
        public virtual DbSet<admDocumentosModelo> admDocumentosModelo { get; set; }
        public virtual DbSet<admDomicilios> admDomicilios { get; set; }
        public virtual DbSet<admEjercicios> admEjercicios { get; set; }
        public virtual DbSet<admFoliosDigitales> admFoliosDigitales { get; set; }
        public virtual DbSet<admMonedas> admMonedas { get; set; }
        public virtual DbSet<admMovimientos> admMovimientos { get; set; }
        public virtual DbSet<admProductos> admProductos { get; set; }
        public virtual DbSet<admProductosDetalles> admProductosDetalles { get; set; }
        public virtual DbSet<admProductosFotos> admProductosFotos { get; set; }
        public virtual DbSet<admUnidadesMedidaPeso> admUnidadesMedidaPeso { get; set; }
        public virtual DbSet<bec_event_documento_encabezado> bec_event_documento_encabezado { get; set; }
        public virtual DbSet<bec_event_documento_movimiento> bec_event_documento_movimiento { get; set; }
    }
}
