using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.DeleteDenuncia
{
    public record DeleteDenunciaRequest(int idDenuncia) : IRequest<Result>;
}
