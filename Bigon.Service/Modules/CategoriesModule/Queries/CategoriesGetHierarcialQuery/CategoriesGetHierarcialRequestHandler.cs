using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetHierarcialQuery
{
    class CategoriesGetHierarcialRequestHandler : IRequestHandler<CategoriesGetHierarcialRequest, IEnumerable<Category>>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoriesGetHierarcialRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public async Task<IEnumerable<Category>> Handle(CategoriesGetHierarcialRequest request, CancellationToken cancellationToken)
        {
            var categories = await catagoryRepository.GetAll(m => m.DeletedAt == null).ToListAsync(cancellationToken);

            return GetAllChildren(categories, null);
        }

        IEnumerable<Category> GetAllChildren(IEnumerable<Category> categories, Category parent)
        {
            if (parent!=null)
            {
                yield return parent;
            }

            foreach (var item in categories.Where(m=>m.ParentId==parent?.Id).SelectMany(m=>GetAllChildren(categories,m)))
            {
                yield return item;
            }
        }
    }
}
