using Gorra.apiminimal.Domain.Entities;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenunciaByUserId
{
    public record GetDenunciaByUserIdResponse(IEnumerable<Denuncia> denuncia);

}
