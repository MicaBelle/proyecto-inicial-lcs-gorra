using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia
{
    public class CreateDenunciaHandler : IRequestHandler<CreateDenunciaRequest, Result<CreateDenunciaResponse>>
    {
        public async Task<Result<CreateDenunciaResponse>> Handle(CreateDenunciaRequest request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
