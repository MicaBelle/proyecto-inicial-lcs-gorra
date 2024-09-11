using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia
{
    public class CreateDenunciaHandler : IRequestHandler<CreateDenunciaRequest, Result<CreateDenunciaResponse>>
    {
        private readonly IGorraDbContex _context;
        public CreateDenunciaHandler(IGorraDbContex contex) { 

            _context = contex;
        }
        public async Task<Result<CreateDenunciaResponse>> Handle(CreateDenunciaRequest request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrEmpty(request.denunciaDescription))
            {
                return "ingrese una descripcion de los hechos";
            }

            if (string.IsNullOrEmpty(request.location))
            {
                return "Ingrese un lugar de los hechos";
            }

            if(string.IsNullOrEmpty(request.coordenadas))
            {
                return "Las coordenadas no fueron enviadas";
            }

            var ciudadano =await _context.Ciudadanos.FirstOrDefaultAsync(x => x.CitizenId == request.idCitizen);

            if (ciudadano == null) {

                return "Error en la creacion de la denuncia, ciudadano no encontrado";

            }

            Denuncia denuncia = new(request.idCitizen, request.denunciaDescription, request.coordenadas,request.location,DateTime.Now,DateTime.Now);

            await _context.Denuncias.AddAsync(denuncia);

            await _context.SaveChangesAsync(cancellationToken);

            return new CreateDenunciaResponse(denuncia.IdDenuncia,request.idCitizen,request.denunciaDescription, request.coordenadas, request.location,DateTime.Now,DateTime.Now);
        }
    }
}
