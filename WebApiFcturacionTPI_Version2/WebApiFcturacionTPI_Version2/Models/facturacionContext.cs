﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiFcturacionTPI.Models;

public partial class facturacionContext : DbContext
{
    public facturacionContext(DbContextOptions<facturacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detallefactura> Detallefacturas { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FormasPago> FormasPagos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.Idarticulo);

            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnName("precio");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente);

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Fechanac)
                .HasColumnType("datetime")
                .HasColumnName("fechanac");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Detallefactura>(entity =>
        {
            entity.HasKey(e => new { e.Iddetalle, e.Nrofactura });

            entity.ToTable("detallefacturas");

            entity.Property(e => e.Iddetalle)
                .ValueGeneratedOnAdd()
                .HasColumnName("iddetalle");
            entity.Property(e => e.Nrofactura).HasColumnName("nrofactura");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Idarticulo).HasColumnName("idarticulo");

            entity.HasOne(d => d.IdarticuloNavigation).WithMany(p => p.Detallefacturas)
                .HasForeignKey(d => d.Idarticulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_detallefacturas_Articulos");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Nrofactura);

            entity.ToTable("Factura");

            entity.Property(e => e.Nrofactura).HasColumnName("nrofactura");
            entity.Property(e => e.Cliente).HasColumnName("cliente");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Formapago).HasColumnName("formapago");
            entity.Property(e => e.Motivobaja)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("motivobaja");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Clientes");

            entity.HasOne(d => d.FormapagoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.Formapago)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_FormasPago");
        });

        modelBuilder.Entity<FormasPago>(entity =>
        {
            entity.HasKey(e => e.IdFormaPago);

            entity.ToTable("FormasPago");

            entity.Property(e => e.IdFormaPago).HasColumnName("id_formaPago");
            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario);

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Contraseña)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("contraseña");
            entity.Property(e => e.Usuario1)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}