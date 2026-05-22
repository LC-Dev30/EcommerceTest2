using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTest2.Data;

public partial class EcommercePracticeContext : DbContext
{
    public EcommercePracticeContext()
    {
    }

    public EcommercePracticeContext(DbContextOptions<EcommercePracticeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Facturacion> Facturacions { get; set; }

    public virtual DbSet<Ordene> Ordenes { get; set; }

    public virtual DbSet<OrdenesDetalle> OrdenesDetalles { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommercePractice;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clientes__3214EC07D215A3A1");

            entity.HasIndex(e => e.Email, "UQ__Clientes__A9D105344A386497").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Facturacion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Facturac__3214EC07215CB431");

            entity.ToTable("Facturacion");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Numeracion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.Facturacions)
                .HasForeignKey(d => d.IdOrden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FR_Facturacion_ordenes");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ordenes__3214EC07A4B8FC32");

            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Ordenes)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FR_Ordenes_Cliente");
        });

        modelBuilder.Entity<OrdenesDetalle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrdenesD__3214EC07C7F6597F");

            entity.ToTable("OrdenesDetalle");

            entity.Property(e => e.Cantidad).HasDefaultValue(1);
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.IdOrdenNavigation).WithMany(p => p.OrdenesDetalles)
                .HasForeignKey(d => d.IdOrden)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenesDetalle_Orden");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.OrdenesDetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenesDetalle_Producto");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC0721C95439");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(80)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
