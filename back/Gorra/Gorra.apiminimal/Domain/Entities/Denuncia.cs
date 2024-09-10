

namespace Gorra.apiminimal.Domain.Entities
{
    public class Denuncia
    {
        public Denuncia() { }
        public Denuncia(int idCitizen, string denunciaDescription,
            List<float> coordenadas, string location, DateTime date, DateTime modDate)
        {
            IdCitizen = idCitizen;
            Location = location;
            CreateDate = date;
            ModificationDate = modDate;
            DenunciaDescription = denunciaDescription;
            Coordenadas = coordenadas;
        }

        public int IdDenuncia { get; set; }

        public int IdCitizen { get; set; }
        public DateTime ModificationDate { get; set; }
        public DateTime CreateDate { get; set; }

        public string? Location { get; set; }
        public string DenunciaDescription { get; set; }

        public List<float> Coordenadas { get; set; }
    }
}
