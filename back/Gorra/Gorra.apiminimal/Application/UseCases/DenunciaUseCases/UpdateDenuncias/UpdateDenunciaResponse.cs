namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.UpdateDenuncias
{
    public record UpdateDenunciaResponse(int iddenuncia, int idCitizen, string denunciaDescription, string coordenadas, string location, DateTime modDate);

}
