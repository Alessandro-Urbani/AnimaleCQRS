using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AnimaleCQRS.Shared.Models
{
    public partial class VeterinarioDbContext : DbContext
    {
        public VeterinarioDbContext()
        {
        }

        public VeterinarioDbContext(DbContextOptions<VeterinarioDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animale> Animales { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-LN9RFDFK;Initial Catalog=VeterinarioDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Animale>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Razza).IsUnicode(false);

                entity.Property(e => e.Sesso).IsUnicode(false);

                entity.HasOne(d => d.IdPadroneNavigation)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.IdPadrone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Animale__IdPadro__267ABA7A");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Cognome).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
