
namespace Bigon.Domain.Models.Entities
{
    public  class Brand : AuditableEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}
