using Gorra.api.Domain.Entities.BaseEntitys;

namespace Gorra.api.Domain.Entities
{
    public class Theft : BaseEntity
    {
        public Theft(string theftDescription, float thefPositionLat, float thefPositionLon)
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
