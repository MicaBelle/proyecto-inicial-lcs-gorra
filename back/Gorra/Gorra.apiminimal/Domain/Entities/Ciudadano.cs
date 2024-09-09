using Gorra.apiminimal.Domain.Entities.BaseEntitys;

namespace Gorra.apiminimal.Domain.Entities
{
    public class Ciudadano : BaseEntity
    {
        public Ciudadano(int citizenId ,string citizenName,string password,DateTime date, DateTime modDate)
        {
            CitizenName = citizenName;
            CreateDate = date;
            ModificationDate = modDate;
            CitizenPass = password;
            CitizenId = citizenId;
            DeclaredDenuncia = new List<Denuncia>();
        }

        public int CitizenId { get; set; }
        public string CitizenName { get; set; }
        public string CitizenPass {  get; set; }

        public List<Denuncia> DeclaredDenuncia { get; set; }
    }
}
