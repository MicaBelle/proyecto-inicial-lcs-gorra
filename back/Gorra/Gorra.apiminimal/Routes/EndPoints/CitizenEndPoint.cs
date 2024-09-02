using System.IO;

namespace Gorra.apiminimal.Routes.EndPoints
{
    public static class CitizenEndPoint
    {
        const string PATH = "/citizen";
    

        public static IEndpointRouteBuilder MapCitizen(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            return builder;
        }
    }
}
