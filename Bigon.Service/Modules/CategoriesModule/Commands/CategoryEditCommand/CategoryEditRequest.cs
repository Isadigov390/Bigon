using Bigon.Domain.Models.Stables;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    public class CategoryEditRequest : IRequest
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }

    }
}
