namespace Gorra.apiminimal.Application.UseCases.DenunciaUseCases.CreateDenuncia
{
    public record CreateDenunciaResponse(int iddenuncia, int idCitizen, string denunciaDescription, List<float> coordenadas, string location, DateTime date, DateTime modDate);
}
