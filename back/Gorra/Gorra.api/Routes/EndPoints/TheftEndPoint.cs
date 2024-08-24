namespace Gorra.api.Routes.EndPoints
{
    public static class TheftEndPoint
    {
        const string PATH = "/Theft";


        public static IEndpointRouteBuilder MapSuperHeroes(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            return builder;
        }
    }
}
