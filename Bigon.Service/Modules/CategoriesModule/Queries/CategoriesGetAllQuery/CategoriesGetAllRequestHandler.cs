using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetAllQuery
{
    
    class CategoriesGetAllRequestHandler : IRequestHandler<CategoriesGetAllRequest, IEnumerable<Category>>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoriesGetAllRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public async Task<IEnumerable<Category>> Handle(CategoriesGetAllRequest request, CancellationToken cancellationToken)
        {
            return await catagoryRepository.GetAll(m => m.DeletedAt == null).ToListAsync(cancellationToken);
        }
    }
}
