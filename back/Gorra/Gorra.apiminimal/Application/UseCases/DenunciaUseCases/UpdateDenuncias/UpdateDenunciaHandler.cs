using AutoMapper;
using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.UpdateDenuncias
{
    public class UpdateDenunciaHandler : IRequestHandler<UpdateDenunciaRequest, Result<UpdateDenunciaResponse>>
    {
        private readonly IGorraDbContex _context;

        public UpdateDenunciaHandler(IGorraDbContex context)
        {
            _context = context;
        }

        public async Task<Result<UpdateDenunciaResponse>> Handle(UpdateDenunciaRequest request, CancellationToken cancellationToken)
        {

           var denuncia = await _context.Denuncias.FirstOrDefaultAsync(x => x.IdDenuncia == request.idDenuncia && x.IdCitizen == request.idCiudadano);

           if (denuncia == null)
           {
                return "La denuncia especificada no existe";
           }

            if (string.IsNullOrEmpty(request.denunciaDescription) || request.denunciaDescription == "String")
            {
                return "ingrese una descripcion de los hechos";
            }


            denuncia.DenunciaDescription = request.denunciaDescription;
            denuncia.ModificationDate = DateTime.Now;

            _context.Denuncias.Update(denuncia);

            await _context.SaveChangesAsync(cancellationToken);


            return new UpdateDenunciaResponse(denuncia.IdDenuncia, denuncia.IdCitizen,denuncia.DenunciaDescription, denuncia.Coordenadas, denuncia.Location, denuncia.ModificationDate);

        }
    }
}
