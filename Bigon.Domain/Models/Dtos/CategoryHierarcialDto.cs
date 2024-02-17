using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bigon.Domain.Models.Dtos
{
    public class CategoryHierarcialDto
    {
        public int Id { get; set; }
        [DisplayName("Parent")]
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public IEnumerable<CategoryHierarcialDto> Children { get; set; }
    }
}
