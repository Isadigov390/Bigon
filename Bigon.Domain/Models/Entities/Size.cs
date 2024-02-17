namespace Bigon.Domain.Models.Entities
{
    public class Size : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallName { get; set; }

    }
}
