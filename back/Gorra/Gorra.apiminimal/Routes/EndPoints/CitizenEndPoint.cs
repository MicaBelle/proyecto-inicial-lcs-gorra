using System.IO;

namespace Gorra.apiminimal.Routes.EndPoints
{
    public static class CitizenEndPoint
    {
        const string PATH = "/Citizen";
    

        public static IEndpointRouteBuilder MapSuperHeroes(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            return builder;
        }
    }
}
