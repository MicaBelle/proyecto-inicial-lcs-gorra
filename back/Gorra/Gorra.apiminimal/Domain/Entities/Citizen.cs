using Gorra.apiminimal.Domain.Entities.BaseEntitys;

namespace Gorra.apiminimal.Domain.Entities
{
    public class Citizen : BaseEntity
    {
        public Citizen(string citizenName, string citizenLocation, bool canReadMap, float citizenLat, float citizenLong,string location,DateTime date, DateTime modDate)
        {
            CitizenName = citizenName;
            CitizenLocation = citizenLocation;
            CanReadMap = canReadMap;
            CitizenLat = citizenLat;
            CitizenLong = citizenLong;
            Location = location;
            CreateDate = date;
            ModificationDate = modDate;
            DeclaredThefts = new HashSet<Denuncia>();
        }

        public Guid CitizenId { get; set; }
        public string CitizenName { get; set; }

        public string CitizenLocation { get; set; }

        public float CitizenLat { get; set; }
        public float CitizenLong { get; set; }

        public bool CanReadMap { get; set; }

        public virtual ICollection<Denuncia> DeclaredThefts { get; set; }
    }
}
