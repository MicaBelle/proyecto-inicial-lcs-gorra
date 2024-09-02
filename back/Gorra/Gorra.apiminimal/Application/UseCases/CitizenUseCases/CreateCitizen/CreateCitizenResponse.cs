namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public record CreateCitizenResponse(int citizenId, string citizenName, string password, DateTime date, DateTime modDatee);
}
