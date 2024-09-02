using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.LogInCitizen
{
    public record LogInCitizenRequest ( string citizenUserName, string citizenPassword) : IRequest<Result>;

}
