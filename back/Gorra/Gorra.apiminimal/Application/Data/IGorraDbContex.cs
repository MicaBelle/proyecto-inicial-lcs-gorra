using Gorra.apiminimal.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.Data
{
    public interface IGorraDbContex
    {
        DbSet<Ciudadano> Ciudadanos { get; }

        DbSet<Denuncia> Denuncias { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
