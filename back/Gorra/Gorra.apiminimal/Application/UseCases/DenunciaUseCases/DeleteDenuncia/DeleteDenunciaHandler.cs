using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.DeleteDenuncia
{
    public class DeleteDenunciaHandler : IRequestHandler<DeleteDenunciaRequest, Result>
    {
        public async Task<Result> Handle(DeleteDenunciaRequest request, CancellationToken cancellationToken)
        {
            return "Denuncia borrada satisfactoriamente";
        }
    }
}
