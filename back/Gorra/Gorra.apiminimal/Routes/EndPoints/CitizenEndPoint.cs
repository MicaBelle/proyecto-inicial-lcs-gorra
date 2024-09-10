using Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen;
using Gorra.apiminimal.Application.UseCases.CitizenUseCases.LogInCitizen;
using Gorra.apiminimal.Routes.Extensions;
using MediatR;
using Microsoft.AspNetCore.Cors;
using System.IO;

namespace Gorra.apiminimal.Routes.EndPoints
{
    public static class CitizenEndPoint
    {
        const string PATH = "/citizen";

        public static IEndpointRouteBuilder MapCitizen(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            group.MapPost("", async (CreateCitizenRequest request, IMediator mediator) =>
            await mediator.Send(request).ToHttpResult());

            group.MapPost("login", async (LogInCitizenRequest request, IMediator mediator) =>
            await mediator.Send(request).ToHttpResult());



            return builder;
        }
    }
}
