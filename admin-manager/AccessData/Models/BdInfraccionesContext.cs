using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AccessData.Models
{
    public partial class BdInfraccionesContext : DbContext
    {
        public BdInfraccionesContext()
        {
        }

        public BdInfraccionesContext(DbContextOptions<BdInfraccionesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Camara> Camaras { get; set; } = null!;
        public virtual DbSet<EstadoCamara> EstadoCamaras { get; set; } = null!;
        public virtual DbSet<EstadoInfraccion> EstadoInfraccions { get; set; } = null!;
        public virtual DbSet<Infraccion> Infraccions { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Modelo> Modelos { get; set; } = null!;
        public virtual DbSet<TipoInfraccion> TipoInfraccions { get; set; } = null!;
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camara>(entity =>
            {
                entity.ToTable("Camara");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.Property(e => e.NumeroCamara).HasColumnName("numeroCamara");

                entity.HasOne(d => d.IdEstadoCamaraNavigation)
                    .WithMany(p => p.Camaras)
                    .HasForeignKey(d => d.IdEstadoCamara)
                    .HasConstraintName("FK_Camara_EstadoCamara");
            });

            modelBuilder.Entity<EstadoCamara>(entity =>
            {
                entity.ToTable("EstadoCamara");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<EstadoInfraccion>(entity =>
            {
                entity.ToTable("EstadoInfraccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Infraccion>(entity =>
            {
                entity.ToTable("Infraccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.IdEstadoInfraccion).HasColumnName("idEstadoInfraccion");

                entity.Property(e => e.IdTipoInfraccion).HasColumnName("idTipoInfraccion");

                entity.Property(e => e.IdVehiculo).HasColumnName("idVehiculo");

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("latitud");

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("longitud");

                entity.HasOne(d => d.IdEstadoInfraccionNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdEstadoInfraccion)
                    .HasConstraintName("FK_Infraccion_EstadoInfraccion");

                entity.HasOne(d => d.IdTipoInfraccionNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdTipoInfraccion)
                    .HasConstraintName("FK_Infraccion_TipoInfraccion");

                entity.HasOne(d => d.IdVehiculoNavigation)
                    .WithMany(p => p.Infraccions)
                    .HasForeignKey(d => d.IdVehiculo)
                    .HasConstraintName("FK_Infraccion_Vehiculo");
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.ToTable("Marca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.ToTable("Modelo");

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Modelos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK_Modelo_Marca");
            });

            modelBuilder.Entity<TipoInfraccion>(entity =>
            {
                entity.ToTable("TipoInfraccion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("descripcion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.ToTable("Vehiculo");

                entity.Property(e => e.Chasis)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("chasis");

                entity.Property(e => e.Patente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patente");

                entity.HasOne(d => d.IdModeloNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdModelo)
                    .HasConstraintName("FK_Vehiculo_Modelo");

                entity.HasOne(d => d.IdTipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.IdTipoVehiculo)
                    .HasConstraintName("FK_Vehiculo_TipoVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
