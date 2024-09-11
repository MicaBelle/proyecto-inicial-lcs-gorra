namespace Gorra.apiminimal.Domain.Entities
{
    public class Ciudadano
    {
        public Ciudadano(string citizenName,string citizenPass, DateTime createDate, DateTime modificationDate)
        {
            CitizenName = citizenName;
            CreateDate = createDate;
            ModificationDate = modificationDate;
            CitizenPass = citizenPass;
            DeclaredDenuncia = new List<Denuncia>();
        }

        public int CitizenId { get; set; }
        public string CitizenName { get; set; }
        public string CitizenPass {  get; set; }

        public DateTime ModificationDate { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<Denuncia> DeclaredDenuncia { get; set; }
    }
}
