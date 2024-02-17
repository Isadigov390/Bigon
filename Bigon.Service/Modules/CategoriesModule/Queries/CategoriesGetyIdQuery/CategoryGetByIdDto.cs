using Bigon.Domain.Models.Stables;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetyIdQuery
{
    public class CategoryGetByIdDto
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
    }
}
