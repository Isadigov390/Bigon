using Bigon.Domain.Models.Dtos;
using Bigon.Domain.Models.Entities;
using Bigon.Domain.Models.Stables;
using Bigon.Infrastructure.Abstracts;

namespace Bigon.Application.Repositories
{
    public interface ICatagoryRepository : IAsyncRepository<Category>
    {
       Task<IEnumerable<RelatedCategoryIds> > GetRelatedIds(int id);
       Task<IEnumerable<Category> > GetSafeCategories(int id,CategoryType type);



    }
}
