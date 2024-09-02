using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public record CreateCitizenRequest(int citizenId,string citizenName, string password) : IRequest<Result<CreateCitizenResponse>>;
}
