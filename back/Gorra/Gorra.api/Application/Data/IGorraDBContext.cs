using Gorra.api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorra.api.Application.Data
{
    public interface IGorraDBContext 
    {
        DbSet<Citizen> Citizens { get; }
        DbSet<Theft> Thefts { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
