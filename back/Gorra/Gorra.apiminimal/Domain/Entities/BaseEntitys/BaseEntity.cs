namespace Gorra.apiminimal.Domain.Entities.BaseEntitys
{
    public class BaseEntity
    {
        public DateTime ModificationDate {  get; set; }
        public DateTime CreateDate { get; set; }

        public string? Location { get; set; }
    }
}
