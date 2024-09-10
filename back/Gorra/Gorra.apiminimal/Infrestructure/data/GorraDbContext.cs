using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Infrestructure.data
{
    public class GorraDbContext : DbContext, IGorraDbContex
    {
        public GorraDbContext(DbContextOptions<GorraDbContext> options) : base(options) { }

        public DbSet<Ciudadano> Ciudadanos => Set<Ciudadano>();

        public DbSet<Denuncia> Denuncias => Set<Denuncia>();


        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Ciudadano>().HasKey(r => r.CitizenId);
            modelBuilder.Entity<Denuncia>().HasKey(r => r.IdDenuncia);

            modelBuilder.Entity<Ciudadano>()
                .HasMany(r => r.DeclaredDenuncia)
                .WithOne()
                .HasForeignKey(x => x.IdCitizen).OnDelete(DeleteBehavior.Cascade);



        }

    }

}
