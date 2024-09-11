

namespace Gorra.apiminimal.Domain.Entities
{
    public class Denuncia
    {
        public Denuncia(int idCitizen, string denunciaDescription,
            string coordenadas, string location, DateTime createDate, DateTime modificationDate)
        {
            IdCitizen = idCitizen;
            Location = location;
            CreateDate = createDate;
            ModificationDate = modificationDate;
            DenunciaDescription = denunciaDescription;
            Coordenadas = coordenadas;
        }

        public int IdDenuncia { get; set; }

        public int IdCitizen { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime CreateDate { get; set; }

        public string? Location { get; set; }
        public string DenunciaDescription { get; set; }

        public string Coordenadas { get; set; }


    }
}
