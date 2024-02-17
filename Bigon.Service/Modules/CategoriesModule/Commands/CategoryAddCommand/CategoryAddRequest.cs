using Bigon.Domain.Models.Stables;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    public class CategoryAddRequest : IRequest
    {
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }

    }
}
