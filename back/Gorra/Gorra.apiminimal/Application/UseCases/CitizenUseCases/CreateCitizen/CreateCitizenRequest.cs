using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public record CreateCitizenRequest(int citizenId,
        string citizenName,
        string citizenLocation,
        bool canReadMap,
        float citizenLat,
        float citizenLong,
        string location) : IRequest<Result<CreateCitizenResponse>>;
}
