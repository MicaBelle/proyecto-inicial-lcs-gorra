using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenunciaByUserId
{
    public class GetDenunciaByUserIdHandler : IRequestHandler<GetDenunciaByUseridRequest, Result<GetDenunciaByUserIdResponse>>
    {
        public async Task<Result<GetDenunciaByUserIdResponse>> Handle(GetDenunciaByUseridRequest request, CancellationToken cancellationToken)
        {
            var citizen = MockData.CitizenList.FirstOrDefault(x => x.Key == request.idCiudadano).Value;

            if(citizen == null)
            {
                return "Ciudadano no encontrado";
            }

            if(citizen.DeclaredDenuncia.Count == 0 || !citizen.DeclaredDenuncia.Any())
            {
                return "Ciudadano no tiene denuncias";
            }

            return new GetDenunciaByUserIdResponse(citizen.DeclaredDenuncia);

        }
    }
}
