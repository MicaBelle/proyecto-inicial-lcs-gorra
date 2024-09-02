namespace Gorra.apiminimal.Routes.EndPoints
{
    public static class DenunciaEndPoint
    {
        const string PATH = "/denuncia";


        public static IEndpointRouteBuilder MapDenuncia(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            return builder;
        }
    }
}
