using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetyIdQuery
{
    public class CategoryGetByIdRequest : IRequest<CategoryGetByIdDto>
    {
        public int Id { get; set; }
    }
}
