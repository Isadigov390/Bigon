namespace Bigon.Domain.Models.Entities
{
    public class Color : AuditableEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
