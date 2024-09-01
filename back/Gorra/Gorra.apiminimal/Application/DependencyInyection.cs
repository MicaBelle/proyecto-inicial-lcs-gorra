using Gorra.apiminimal.Application.DTO;

namespace Gorra.apiminimal.Application
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
