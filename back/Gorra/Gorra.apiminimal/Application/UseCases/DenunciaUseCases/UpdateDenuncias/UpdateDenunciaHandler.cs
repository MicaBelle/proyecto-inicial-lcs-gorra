using AutoMapper;
using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.UpdateDenuncias
{
    public class UpdateDenunciaHandler : IRequestHandler<UpdateDenunciaRequest, Result<UpdateDenunciaResponse>>
    {
        public async Task<Result<UpdateDenunciaResponse>> Handle(UpdateDenunciaRequest request, CancellationToken cancellationToken)
        {
            var citizen = MockData.CitizenList.FirstOrDefault(x => x.Key == request.idCiudadano).Value;



            if (citizen.DeclaredDenuncia.Count == 0 || !citizen.DeclaredDenuncia.Any())
            {
                return "Ciudadano no tiene denuncias";
            }
           var denuncia = citizen.DeclaredDenuncia.FirstOrDefault(x => x.IdDenuncia == request.idDenuncia);

           if (denuncia == null)
           {
                return "La denuncia especificada no existe";
           }

            if (string.IsNullOrEmpty(request.denunciaDescription) || request.denunciaDescription == "String")
            {
                return "ingrese una descripcion de los hechos";
            }

            if (string.IsNullOrEmpty(request.location) || request.location == "String")
            {
                return "Ingrese un lugar de los hechos";
            }

            if (!request.coordenadas.Any() || request.coordenadas.Count < 2)
            {
                return "Las coordenadas no fueron enviadas";
            }


            denuncia.DenunciaDescription = request.denunciaDescription;
            denuncia.Coordenadas = request.coordenadas;
            denuncia.Location = request.location;
            denuncia.ModificationDate = DateTime.Now;


            return new UpdateDenunciaResponse(denuncia.IdDenuncia, denuncia.IdCitizen,denuncia.DenunciaDescription, denuncia.Coordenadas, denuncia.Location, denuncia.ModificationDate);

        }
    }
}
