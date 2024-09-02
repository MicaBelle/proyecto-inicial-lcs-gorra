using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenunciaByUserId
{
    public record GetDenunciaByUseridRequest(int idCiudadano) : IRequest<Result<GetDenunciaByUserIdResponse>>;
}
