using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenuncias
{
    public record GetDenunciaRequest() : IRequest<Result<GetDenunciaResponse>>;

}
