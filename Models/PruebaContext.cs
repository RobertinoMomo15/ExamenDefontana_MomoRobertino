﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ExamenDefontana_MomoRobertino.Models
{
    public partial class PruebaContext : DbContext
    {
        public PruebaContext()
        {
        }

        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Local> Local { get; set; }
        public virtual DbSet<Marca> Marca { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }
        public virtual DbSet<VentaDetalle> VentaDetalle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=lab-defontana-202310.caporvnn6sbh.us-east-1.rds.amazonaws.com,1433;Database=Prueba;User Id=ReadOnly;Password=d*3PSf2MmRX9vJtA5sgwSphCVQ26*T53uU;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Local>(entity =>
            {
                entity.HasKey(e => e.IdLocal)
                    .HasName("PK__Local__3E34B29DF6370FC0");

                entity.Property(e => e.IdLocal).HasColumnName("ID_Local");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marca__9B8F8DB2325A25B9");

                entity.Property(e => e.IdMarca).HasColumnName("ID_Marca");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__9B4120E21FBD1C85");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CostoUnitario).HasColumnName("Costo_Unitario");

                entity.Property(e => e.IdMarca).HasColumnName("ID_Marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Producto)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Producto__ID_Mar__52593CB8");
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => e.IdVenta)
                    .HasName("PK__Venta__3CD842E5A3F1C767");

                entity.Property(e => e.IdVenta).HasColumnName("ID_Venta");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdLocal).HasColumnName("ID_Local");

                entity.HasOne(d => d.IdLocalNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.IdLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Venta__ID_Local__571DF1D5");
            });

            modelBuilder.Entity<VentaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdVentaDetalle)
                    .HasName("PK__VentaDet__2F0CE38B52091CC3");

                entity.Property(e => e.IdVentaDetalle).HasColumnName("ID_VentaDetalle");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.IdVenta).HasColumnName("ID_Venta");

                entity.Property(e => e.PrecioUnitario).HasColumnName("Precio_Unitario");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentaDetalle)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentaDeta__ID_Pr__5DCAEF64");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentaDetalle)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VentaDeta__ID_Ve__5CD6CB2B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
