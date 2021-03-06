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

        public virtual DbSet<Animale> Animali { get; set; }
        public virtual DbSet<Cliente> Clienti { get; set; }

    }
}
