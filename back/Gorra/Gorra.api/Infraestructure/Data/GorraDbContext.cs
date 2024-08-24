using Gorra.api.Application.Data;
using Gorra.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorra.api.Infraestructure.Data
{
    public class GorraDbContext : DbContext, IGorraDBContext
    {

        public GorraDbContext(DbContextOptions<GorraDbContext> options) : base(options)
        {
        }
        public DbSet<Citizen> Citizens => Set<Citizen>();

        public DbSet<Theft> Thefts => Set<Theft>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
