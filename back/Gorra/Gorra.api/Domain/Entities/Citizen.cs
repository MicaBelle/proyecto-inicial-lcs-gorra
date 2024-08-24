using Gorra.api.Domain.Entities.BaseEntitys;

namespace Gorra.api.Domain.Entities
{
    public class Citizen : BaseEntity
    {
        public Citizen(string citizenName, string citizenLocation, bool canReadMap, float citizenLat, float citizenLong)
        {
            CitizenName = citizenName;
            CitizenLocation = citizenLocation;
            CanReadMap = canReadMap;
            CitizenLat = citizenLat;
            CitizenLong = citizenLong;
        }

        public Guid CitizenId { get; set; }
        public string CitizenName { get; set; }

        public string CitizenLocation { get; set; }

        public float CitizenLat { get; set; }
        public float CitizenLong { get; set; }

        public bool CanReadMap { get; set; }

        public virtual ICollection<Theft> DeclaredAccidents { get; set; }
    }
}
