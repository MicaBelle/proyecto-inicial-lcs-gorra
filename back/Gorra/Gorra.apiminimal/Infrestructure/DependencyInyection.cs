using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Infrestructure.data;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Infrestructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IGorraDbContex, GorraDbContext>
            (o => o.UseSqlServer(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}
