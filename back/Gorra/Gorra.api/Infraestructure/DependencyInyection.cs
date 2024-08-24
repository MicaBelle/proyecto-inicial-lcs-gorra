using Gorra.api.Application.Data;
using Gorra.api.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Gorra.api.Infraestructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IGorraDBContext, GorraDbContext>
            (o => o.UseSqlServer(configuration["SqlServerConnectionString"]));

            return services;
        }
    }
}
