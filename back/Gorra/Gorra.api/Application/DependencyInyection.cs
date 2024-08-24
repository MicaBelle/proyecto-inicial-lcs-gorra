using Gorra.api.Application.Data;
using Gorra.api.Application.DTO;
using Gorra.api.Infraestructure.Data;

namespace Gorra.api.Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(Result).Assembly));

            return services;
        }
    }
}
