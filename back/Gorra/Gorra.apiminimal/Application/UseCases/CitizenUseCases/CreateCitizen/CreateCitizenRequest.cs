using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public record CreateCitizenRequest(string citizenName, string password) : IRequest<Result<CreateCitizenResponse>>;
}
