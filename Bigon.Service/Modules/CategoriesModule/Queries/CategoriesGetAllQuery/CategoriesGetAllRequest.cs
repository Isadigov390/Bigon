using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllQuery
{
    public class CategoriesGetAllRequest : IRequest<IEnumerable<Category>>
    {

    }
}
    