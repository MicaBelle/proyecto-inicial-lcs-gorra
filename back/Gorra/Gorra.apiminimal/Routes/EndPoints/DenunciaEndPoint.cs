using Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia;
using Gorra.apiminimal.Application.UseCases.DenunciaUseCases.DeleteDenuncia;
using Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenunciaByUserId;
using Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenuncias;
using Gorra.apiminimal.Application.UseCases.DenunciaUseCases.UpdateDenuncias;
using Gorra.apiminimal.Routes.Extensions;
using MediatR;

namespace Gorra.apiminimal.Routes.EndPoints
{
    public static class DenunciaEndPoint
    {
        const string PATH = "/denuncia";


        public static IEndpointRouteBuilder MapDenuncia(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);


            group.MapPost("", async (CreateDenunciaRequest request, IMediator mediator) =>
            await mediator.Send(request).ToHttpResult());

            group.MapGet("", async (IMediator mediator) =>
            await mediator.Send(new GetDenunciaRequest()).ToHttpResult());

            group.MapGet("{id}", async (int id,IMediator mediator) =>
            await mediator.Send(new GetDenunciaByUseridRequest(id)).ToHttpResult());


            group.MapPut("", async (UpdateDenunciaRequest request, IMediator mediator) =>
            await mediator.Send(request).ToHttpResult());

            group.MapDelete("", async (int citizenId, int denunciaId, IMediator mediator) =>
            await mediator.Send(new DeleteDenunciaRequest(denunciaId, citizenId)).ToHttpResult());


            return builder;
        }
    }
}
