using Gorra.apiminimal.Domain.Entities.BaseEntitys;

namespace Gorra.apiminimal.Domain.Entities
{
    public class Denuncia : BaseEntity
    {
        public Denuncia(string theftDescription, float thefPositionLat, float thefPositionLon)
        {
            TheftDescription = theftDescription;
            ThefPositionLat = thefPositionLat;
            ThefPositionLon = thefPositionLon;
        }

        public Guid IdTheft { get; set; }

        public string TheftDescription { get; set; }

        public float ThefPositionLat { get; set; }
        public float ThefPositionLon { get; set; }
    }
}
