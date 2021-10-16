using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webcodefirst.Models
{
    public partial class dbLSCContext : DbContext
    {
        public dbLSCContext()
        {
        }

        public dbLSCContext(DbContextOptions<dbLSCContext> options) : base(options)
        {
        }

        public virtual DbSet<TblColor> TblColors { get; set; }
        public virtual DbSet<TblProducto> TblProductos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=dbwip.database.windows.net;Database=dbLSC;User=saAzure;Password=Sonic991978;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblColor>(entity =>
            {
                entity.ToTable("tblColor");

                entity.Property(e => e.CodigoColor)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CodigoHex).HasMaxLength(6);

                entity.Property(e => e.NombreColor).HasMaxLength(50);
            });

            modelBuilder.Entity<TblProducto>(entity =>
            {
                entity.ToTable("tblProductos");

                entity.HasIndex(e => e.TblColorId, "IX_tblProductos_tblColorId");

                entity.Property(e => e.CodigoProducto)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Existencia).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.TblColorId).HasColumnName("tblColorId");

                entity.HasOne(d => d.TblColor)
                    .WithMany(p => p.TblProductos)
                    .HasForeignKey(d => d.TblColorId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
