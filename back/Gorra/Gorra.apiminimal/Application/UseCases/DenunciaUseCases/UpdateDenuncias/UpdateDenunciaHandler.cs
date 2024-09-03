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

            if (citizen == null)
            {
                return "Ciudadano no encontrado";
            }

            if (citizen.DeclaredDenuncia.Count == 0 || !citizen.DeclaredDenuncia.Any())
            {
                return "Ciudadano no tiene denuncias";
            }
           var denuncia = citizen.DeclaredDenuncia.FirstOrDefault(x => x.IdDenuncia == request.idDenuncia);

           if (denuncia == null)
           {
                return "La denuncia especificada no existe";
           }



            denuncia.DenunciaDescription = request.denunciaDescription;
            denuncia.Coordenadas = request.coordenadas;
            denuncia.Location = request.location;
            denuncia.ModificationDate = DateTime.Now;


            return new UpdateDenunciaResponse(denuncia.IdDenuncia, denuncia.IdCitizen,denuncia.DenunciaDescription, denuncia.Coordenadas, denuncia.Location, denuncia.ModificationDate);

        }
    }
}
