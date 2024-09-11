using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenunciaByUserId
{
    public class GetDenunciaByUserIdHandler : IRequestHandler<GetDenunciaByUseridRequest, Result<GetDenunciaByUserIdResponse>>
    {
        private readonly IGorraDbContex _context;

        public GetDenunciaByUserIdHandler(IGorraDbContex contex)
        {
            _context = contex;
        }
        public async Task<Result<GetDenunciaByUserIdResponse>> Handle(GetDenunciaByUseridRequest request, CancellationToken cancellationToken)
        {
            var denuncias = await _context.Denuncias.Where(x => x.IdCitizen == request.idCiudadano).ToListAsync(cancellationToken);


            if(denuncias.Count() == 0 && denuncias ==null)
            {
                return "Ciudadano no tiene denuncias";
            }

            return new GetDenunciaByUserIdResponse(denuncias);

        }
    }
}
