using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;

namespace Gorra.apiminimal.Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            MockData.GenerateCitizen();

            services.AddMediatR(o => o.RegisterServicesFromAssembly(typeof(Result).Assembly));

            return services;
        }
    }
}
