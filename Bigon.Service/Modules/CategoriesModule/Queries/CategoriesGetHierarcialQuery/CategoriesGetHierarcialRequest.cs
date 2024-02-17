using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetHierarcialQuery
{
    public  class CategoriesGetHierarcialRequest : IRequest<IEnumerable<Category>>
    {
    }
}
