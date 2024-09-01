namespace Gorra.apiminimal.Application.UseCases.CitizenUseCases.CreateCitizen
{
    public record CreateCitizenResponse(int citizenId, string citizenName, string citizenLocation, bool canReadMap, float citizenLat, float citizenLong, string location, DateTime date, DateTime modDatee);
}
