using Gorra.apiminimal.Domain.Entities.BaseEntitys;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gorra.apiminimal.Domain.Entities
{
    public class Denuncia : BaseEntity
    {

        public static int currentId = 0;
        public Denuncia(int idCitizen, string denunciaDescription,  (float, float) coordenadas, string location, DateTime date, DateTime modDate)
        {
            IdCitizen = idCitizen;
            IdDenuncia = currentId + 1;
            Location = location;
            CreateDate = date;
            ModificationDate = modDate;
            DenunciaDescription = denunciaDescription;
            Coordenadas = coordenadas;
        }

        public int IdDenuncia { get; set; }

        public int IdCitizen { get; set; }

        public string DenunciaDescription { get; set; }

        public (float,float) Coordenadas { get; set; }
    }
}
