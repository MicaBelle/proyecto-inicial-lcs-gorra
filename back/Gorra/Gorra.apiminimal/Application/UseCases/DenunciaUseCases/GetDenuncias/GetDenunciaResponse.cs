using Gorra.apiminimal.Domain.Entities;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenuncias
{

    public record GetDenunciaResponse(IEnumerable <Denuncia> denuncias); 
}
