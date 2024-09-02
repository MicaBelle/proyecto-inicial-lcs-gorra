using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.UpdateDenuncias
{
    public record UpdateDenunciaRequest(int idCiudadano, int idDenuncia, string denunciaDescription, (float, float) coordenadas, string location) : IRequest<Result<UpdateDenunciaResponse>>;

}
