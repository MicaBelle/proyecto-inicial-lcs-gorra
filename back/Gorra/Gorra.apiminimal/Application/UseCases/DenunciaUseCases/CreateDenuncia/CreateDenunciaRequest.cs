using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia
{
    public record CreateDenunciaRequest(int iddenuncia, int idCitizen, string denunciaDescription, (float, float) coordenadas, string location) : IRequest<Result<CreateDenunciaResponse>>;
}
