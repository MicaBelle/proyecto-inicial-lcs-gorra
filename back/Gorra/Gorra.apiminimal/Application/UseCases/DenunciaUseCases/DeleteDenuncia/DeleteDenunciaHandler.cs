using Gorra.apiminimal.Application.Data;
using Gorra.apiminimal.Application.DTO;
using MediatR;

namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.DeleteDenuncia
{
    public class DeleteDenunciaHandler : IRequestHandler<DeleteDenunciaRequest, Result>
    {
        public async Task<Result> Handle(DeleteDenunciaRequest request, CancellationToken cancellationToken)
        {

            var ciudadano = MockData.CitizenList.FirstOrDefault(x => x.Key == request.idCiudadano);

            var denunciaToDelete = ciudadano.Value.DeclaredDenuncia.FirstOrDefault(x => x.IdDenuncia == request.idDenuncia);

            if(denunciaToDelete == null)
            {
                return "No existe la denuncia que se quiere borrar";
            }

            return ciudadano.Value.DeclaredDenuncia.Remove(denunciaToDelete) ? "Denuncia borrada satisfactoriamente": "Denuncia no eliminada";
        }
    }
}
