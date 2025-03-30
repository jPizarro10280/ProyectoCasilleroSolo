using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class CasilleroProyectoContext : DbContext
{
    public CasilleroProyectoContext()
    {
    }

    public CasilleroProyectoContext(DbContextOptions<CasilleroProyectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<PrealertaPaquete> PrealertaPaquetes { get; set; }

    public virtual DbSet<Prealertum> Prealerta { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRol> UsuarioRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-FQNLCV38\\SQLEXPRESS; Database=Casillero_Proyecto; Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleF__3214EC07EA4EF939");

            entity.ToTable("DetalleFactura");

            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.Concepto).HasMaxLength(255);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Direccio__3214EC07BD53667A");

            entity.ToTable("Direccion");

            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.Estado).HasMaxLength(100);
            entity.Property(e => e.Linea1).HasMaxLength(255);
            entity.Property(e => e.Linea2).HasMaxLength(255);
            entity.Property(e => e.Pais).HasMaxLength(100);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Direccions)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Direccion_Usuario");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Factura__3214EC075C75A23D");

            entity.ToTable("Factura");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("pendiente");
            entity.Property(e => e.FechaEmision)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Impuestos).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Paquete).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Paquete");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Usuario");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paquete__3214EC0723568E5F");

            entity.ToTable("Paquete");

            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("porPagar");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Paquetes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Paquete_Usuario");
        });

        modelBuilder.Entity<PrealertaPaquete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prealert__3214EC07F1203CDD");

            entity.ToTable("PrealertaPaquete");

            entity.HasOne(d => d.Paquete).WithMany(p => p.PrealertaPaquetes)
                .HasForeignKey(d => d.PaqueteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrealertaPaquete_Paquete");

            entity.HasOne(d => d.Prealerta).WithMany(p => p.PrealertaPaquetes)
                .HasForeignKey(d => d.PrealertaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PrealertaPaquete_Prealerta");
        });

        modelBuilder.Entity<Prealertum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Prealert__3214EC07DA4FFF30");

            entity.HasIndex(e => e.NumeroSeguimiento, "UQ__Prealert__1976495D1EA1015E").IsUnique();

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasDefaultValue("prealertado");
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NumeroSeguimiento).HasMaxLength(100);
            entity.Property(e => e.Peso).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Prealerta)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Prealerta_Usuario");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC07CC0950F0");

            entity.ToTable("Rol");

            entity.HasIndex(e => e.Nombre, "UQ__Rol__75E3EFCF05E83AA3").IsUnique();

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC077835FE50");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19DC409AC3").IsUnique();

            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(15);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsuarioR__3214EC0739812A50");

            entity.ToTable("UsuarioRol");

            entity.HasOne(d => d.Rol).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Rol");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioRols)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioRol_Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
