using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenuncias
{
    public class GetDenunciaHandler : IRequestHandler<GetDenunciaRequest, Result<GetDenunciaResponse>>
    {
        public async Task<Result<GetDenunciaResponse>> Handle(GetDenunciaRequest request, CancellationToken cancellationToken)
        {
            var denuncias =  MockData.CitizenList.Values.SelectMany(x => x.DeclaredDenuncia).ToList();

            if(!denuncias.Any() || denuncias == null)
            {
                return "No existen denuncias";
            }

            return new GetDenunciaResponse(denuncias);
        }
    }
}
