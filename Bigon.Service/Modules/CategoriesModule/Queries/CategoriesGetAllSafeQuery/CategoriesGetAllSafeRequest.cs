using Bigon.Domain.Models.Entities;
using Bigon.Domain.Models.Stables;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllSafeQuery
{
    public class CategoriesGetAllSafeRequest : IRequest<IEnumerable<Category>>
    {
        public int Id { get; set; } 
        public CategoryType Type { get; set; } 
        
    }
}
    