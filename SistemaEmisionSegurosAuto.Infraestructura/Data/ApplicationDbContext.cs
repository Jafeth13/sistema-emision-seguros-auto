using Microsoft.EntityFrameworkCore;
using SistemaEmisionSegurosAuto.Domain.Entidades;
using SistemaEmisionSegurosAuto.Entidades;

namespace SistemaEmisionSegurosAuto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Cobertura> Coberturas { get; set; }

        public DbSet<Poliza> Polizas { get; set; }

        public DbSet<PolizaCobertura> PolizaCoberturas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolizaCobertura>()
                .HasKey(pc => new
                {
                    pc.PolizaId,
                    pc.CoberturaId
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}