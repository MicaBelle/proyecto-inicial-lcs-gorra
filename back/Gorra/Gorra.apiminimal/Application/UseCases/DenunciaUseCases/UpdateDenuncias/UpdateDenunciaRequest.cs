using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.UpdateDenuncias
{
    public record UpdateDenunciaRequest(int idCiudadano, int idDenuncia, string denunciaDescription, List<float> coordenadas, string location) : IRequest<Result<UpdateDenunciaResponse>>;

}
