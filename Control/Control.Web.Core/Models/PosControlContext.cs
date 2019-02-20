using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Control.Web.Core.Models
{
    public partial class PosControlContext : DbContext
    {
        public PosControlContext()
        {
        }

        public PosControlContext(DbContextOptions<PosControlContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GeneralBitacora> GeneralBitacora { get; set; }
        public virtual DbSet<GeneralParametros> GeneralParametros { get; set; }
        public virtual DbSet<GeneralUsuarios> GeneralUsuarios { get; set; }
        public virtual DbSet<InventarioCategorias> InventarioCategorias { get; set; }
        public virtual DbSet<InventarioMovimientos> InventarioMovimientos { get; set; }
        public virtual DbSet<InventarioProductos> InventarioProductos { get; set; }
        public virtual DbSet<InventarioTiposMovimientos> InventarioTiposMovimientos { get; set; }
        public virtual DbSet<ProveeduriaProveedores> ProveeduriaProveedores { get; set; }
        public virtual DbSet<VentasClientes> VentasClientes { get; set; }
        public virtual DbSet<VentasDetalleVentas> VentasDetalleVentas { get; set; }
        public virtual DbSet<VentasDocumentos> VentasDocumentos { get; set; }
        public virtual DbSet<VentasFormasPagos> VentasFormasPagos { get; set; }
        public virtual DbSet<VentasPagos> VentasPagos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=EPIC_LAP_10\\SQLEXPRESS;Database=PosControl;Trusted_Connection=True;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneralBitacora>(entity =>
            {
                entity.HasKey(e => e.IdBitacora);

                entity.ToTable("General.Bitacora");

                entity.Property(e => e.Descripcion).IsRequired();

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.GeneralBitacora)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bitacora_Usuarios");
            });

            modelBuilder.Entity<GeneralParametros>(entity =>
            {
                entity.HasKey(e => e.IdParametro);

                entity.ToTable("General.Parametros");

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.CorreoContactoRespaldos).HasMaxLength(50);

                entity.Property(e => e.DetalleFacturas).HasMaxLength(50);

                entity.Property(e => e.DisplayNameCorreo).HasMaxLength(50);

                entity.Property(e => e.FromCorreo).HasMaxLength(50);

                entity.Property(e => e.HostCorreo).HasMaxLength(50);

                entity.Property(e => e.Identificacion).HasMaxLength(50);

                entity.Property(e => e.NombreEmpresa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Nombre empresa')");

                entity.Property(e => e.PasswordCorreo).HasMaxLength(50);

                entity.Property(e => e.RutaLogo).HasMaxLength(50);

                entity.Property(e => e.RutaSistema).HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.UserNameCorreo).HasMaxLength(50);
            });

            modelBuilder.Entity<GeneralUsuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("General.Usuarios");

                entity.Property(e => e.Clave)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InventarioCategorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("Inventario.Categorias");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('Nueva descripción')");
            });

            modelBuilder.Entity<InventarioMovimientos>(entity =>
            {
                entity.HasKey(e => e.IdMovimientoInventario);

                entity.ToTable("Inventario.Movimientos");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioMovimientos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario.Movimientos_Inventario.Productos");

                entity.HasOne(d => d.IdTipoMovimientoNavigation)
                    .WithMany(p => p.InventarioMovimientos)
                    .HasForeignKey(d => d.IdTipoMovimiento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario.Movimientos_Inventario.TiposMovimientos");
            });

            modelBuilder.Entity<InventarioProductos>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("Inventario.Productos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('Nueva descripción')");

                entity.Property(e => e.Descuento).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Identificador)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Impuestos).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Utilidad).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.InventarioProductos)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario.Productos_Inventario.Categorias");

                entity.HasOne(d => d.IdProveedorNavigation)
                    .WithMany(p => p.InventarioProductos)
                    .HasForeignKey(d => d.IdProveedor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventario.Productos_Proveeduria.Proveedores");
            });

            modelBuilder.Entity<InventarioTiposMovimientos>(entity =>
            {
                entity.HasKey(e => e.IdTipoMovimiento);

                entity.ToTable("Inventario.TiposMovimientos");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProveeduriaProveedores>(entity =>
            {
                entity.HasKey(e => e.IdProveedor);

                entity.ToTable("Proveeduria.Proveedores");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Identificacion).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VentasClientes>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Ventas.Clientes");

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Identificacion).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<VentasDetalleVentas>(entity =>
            {
                entity.HasKey(e => e.IdDetalle);

                entity.ToTable("Ventas.DetalleVentas");

                entity.Property(e => e.TotalLinea).HasColumnType("decimal(38, 4)");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.VentasDetalleVentas)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas.DetalleVentas_Inventario.Productos");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentasDetalleVentas)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas.DetalleVentas_Ventas.Documentos");
            });

            modelBuilder.Entity<VentasDocumentos>(entity =>
            {
                entity.HasKey(e => e.IdVenta);

                entity.ToTable("Ventas.Documentos");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.VentasDocumentos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas.Documentos_Ventas.Clientes");
            });

            modelBuilder.Entity<VentasFormasPagos>(entity =>
            {
                entity.HasKey(e => e.IdFormaPago);

                entity.ToTable("Ventas.FormasPagos");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<VentasPagos>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("Ventas.Pagos");

                entity.Property(e => e.NumeroChequeTarjeta)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdFormaPagoNavigation)
                    .WithMany(p => p.VentasPagos)
                    .HasForeignKey(d => d.IdFormaPago)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas.Pagos_Ventas.FormasPago");

                entity.HasOne(d => d.IdVentaNavigation)
                    .WithMany(p => p.VentasPagos)
                    .HasForeignKey(d => d.IdVenta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ventas.Pagos_Ventas.Documentos");
            });
        }
    }
}
