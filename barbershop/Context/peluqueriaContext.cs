using barbershop.model;
using Microsoft.EntityFrameworkCore;

namespace barbershop.Context
{
    public class PeluqueriaContext : DbContext
    {
        public PeluqueriaContext(DbContextOptions<PeluqueriaContext> options)
            : base(options)
        {
        }

        public DbSet<Files> Files { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TicketsCabecera> TicketsCabecera { get; set; }
        public DbSet<TicketsDetalle> TicketsDetalle { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PeluqueriaContext).Assembly);
        }
    }
}