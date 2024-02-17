using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllSafeQuery
{
    class CategoriesGetAllSafeRequestHandler : IRequestHandler<CategoriesGetAllSafeRequest, IEnumerable<Category>>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoriesGetAllSafeRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public Task<IEnumerable<Category>> Handle(CategoriesGetAllSafeRequest request, CancellationToken cancellationToken)
        {
            return catagoryRepository.GetSafeCategories(request.Id,request.Type);
        }
    }
}
