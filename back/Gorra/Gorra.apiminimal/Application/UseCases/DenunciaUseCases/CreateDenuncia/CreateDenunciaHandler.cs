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

            Denuncia denuncia = new(request.idCitizen,request.denunciaDescription,request.coordenadas,request.location,DateTime.Now,DateTime.Now);

            ciudadano.Value.DeclaredDenuncia.Add(denuncia);

            return new CreateDenunciaResponse(request.iddenuncia,request.idCitizen,request.denunciaDescription,request.coordenadas,request.location,DateTime.Now,DateTime.Now);
        }
    }
}
