using Gorra.apiminimal.Domain.Entities.BaseEntitys;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gorra.apiminimal.Domain.Entities
{
    public class Denuncia : BaseEntity
    {
        public Denuncia(Guid idCitizen, string denunciaDescription, float denunciaPositionLat, float denunciaPositionLon, string location, DateTime date, DateTime modDate)
        {
            IdCitizen = idCitizen;
            Location = location;
            CreateDate = date;
            ModificationDate = modDate;
            DenunciaDescription = denunciaDescription;
            DenunciaPositionLat = denunciaPositionLat;
            DenunciaPositionLon = denunciaPositionLon;
        }

        public Guid IdDenuncia { get; set; }

        public Guid IdCitizen { get; set; }

        public string DenunciaDescription { get; set; }

        public float DenunciaPositionLat { get; set; }
        public float DenunciaPositionLon { get; set; }
    }
}
