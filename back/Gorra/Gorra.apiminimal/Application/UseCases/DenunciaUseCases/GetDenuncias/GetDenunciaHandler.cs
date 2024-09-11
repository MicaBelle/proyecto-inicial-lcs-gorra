using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using Gorra.apiminimal.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenuncias
{
    public class GetDenunciaHandler : IRequestHandler<GetDenunciaRequest, Result<GetDenunciaResponse>>
    {
        private IGorraDbContex _context;

        public GetDenunciaHandler(IGorraDbContex context) {
        
            _context = context;
        
        }

        public async Task<Result<GetDenunciaResponse>> Handle(GetDenunciaRequest request, CancellationToken cancellationToken)
        {
            var denuncias = await _context.Denuncias.ToListAsync();

            if(!denuncias.Any() || denuncias == null)
            {
                return "No existen denuncias";
            }

            return new GetDenunciaResponse(denuncias);
        }
    }
}
