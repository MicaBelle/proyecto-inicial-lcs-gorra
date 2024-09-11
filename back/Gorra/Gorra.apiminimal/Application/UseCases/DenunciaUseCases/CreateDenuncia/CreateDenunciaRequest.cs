using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia
{
    public record CreateDenunciaRequest(int idCitizen, string denunciaDescription, string coordenadas, string location) : IRequest<Result<CreateDenunciaResponse>>;
}
