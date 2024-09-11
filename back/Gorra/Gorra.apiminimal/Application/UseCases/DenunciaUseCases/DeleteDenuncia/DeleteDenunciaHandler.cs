using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.DeleteDenuncia
{
    public class DeleteDenunciaHandler : IRequestHandler<DeleteDenunciaRequest, Result>
    {
        private readonly IGorraDbContex _context;

        public DeleteDenunciaHandler(IGorraDbContex context)
        {
            _context = context;
        }

        public async Task<Result> Handle(DeleteDenunciaRequest request, CancellationToken cancellationToken)
        {
            var denunciaToDelete =await _context.Denuncias.FirstOrDefaultAsync(x => x.IdDenuncia == request.idDenuncia && x.IdCitizen == request.idCiudadano);

            if(denunciaToDelete == null)
            {
                return "No existe la denuncia que se quiere borrar";
            }

            _context.Denuncias.Remove(denunciaToDelete);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
