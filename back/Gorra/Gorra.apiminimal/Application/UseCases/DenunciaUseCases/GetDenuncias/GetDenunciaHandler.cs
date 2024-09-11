using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.GetDenuncias
{
    public class GetDenunciaHandler : IRequestHandler<GetDenunciaRequest, Result<GetDenunciaResponse>>
    {
        private readonly IGorraDbContex _context;

        public GetDenunciaHandler(IGorraDbContex context) {
        
            _context = context;
        
        }

        public async Task<Result<GetDenunciaResponse>> Handle(GetDenunciaRequest request, CancellationToken cancellationToken)
        {
           
            var denuncias = await _context.Denuncias.AsNoTracking().ToListAsync(cancellationToken);

            if(denuncias.Count() == 0 || denuncias == null)
            {
                return "No existen denuncias";
            }

            return new GetDenunciaResponse(denuncias);
        }
    }
}
