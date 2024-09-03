using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia
{
    public class CreateDenunciaHandler : IRequestHandler<CreateDenunciaRequest, Result<CreateDenunciaResponse>>
    {
        public async Task<Result<CreateDenunciaResponse>> Handle(CreateDenunciaRequest request, CancellationToken cancellationToken)
        {
            var ciudadano = MockData.CitizenList.FirstOrDefault(x => x.Key == request.idCitizen);

            var indiceDenuncias =MockData.CitizenList.Values.SelectMany(x => x.DeclaredDenuncia).Count();

            Denuncia denuncia = new(request.idCitizen, request.denunciaDescription, request.coordenadas,request.location,DateTime.Now,DateTime.Now);

            denuncia.IdDenuncia = indiceDenuncias + 1;

            ciudadano.Value.DeclaredDenuncia.Add(denuncia);

            return new CreateDenunciaResponse(denuncia.IdDenuncia,request.idCitizen,request.denunciaDescription, request.coordenadas, request.location,DateTime.Now,DateTime.Now);
        }
    }
}
