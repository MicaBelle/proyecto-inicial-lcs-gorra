namespace Gorra.apiminimal.Domain.Entities
{
    public class Ciudadano
    {
        public Ciudadano()
        {
            DeclaredDenuncia = new List<Denuncia>();
        }
        public Ciudadano(string citizenName,string password,DateTime date, DateTime modDate)
        {
            CitizenName = citizenName;
            CreateDate = date;
            ModificationDate = modDate;
            CitizenPass = password;
            DeclaredDenuncia = new List<Denuncia>();
        }

        public int CitizenId { get; set; }
        public string CitizenName { get; set; }
        public string CitizenPass {  get; set; }

        public DateTime ModificationDate { get; set; }
        public DateTime CreateDate { get; set; }
        public List<Denuncia> DeclaredDenuncia { get; set; }
    }
}
