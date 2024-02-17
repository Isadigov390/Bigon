using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.CategoriesModule.Queries.CategoriesGetyIdQuery
{
    internal class CategoryGetByIdRequestHandler : IRequestHandler<CategoryGetByIdRequest, CategoryGetByIdDto>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoryGetByIdRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public async Task<CategoryGetByIdDto> Handle(CategoryGetByIdRequest request, CancellationToken cancellationToken)
        {
            var dto = await (from c in catagoryRepository.GetAll(m => m.DeletedAt == null)
                             join p in catagoryRepository.GetAll() on c.ParentId equals p.Id into leftJoin
                             from l in leftJoin.DefaultIfEmpty()
                             where c.Id == request.Id
                             select new CategoryGetByIdDto {
                                 Id = c.Id,
                                 Name = c.Name,
                                 ParentId = c.ParentId,
                                 ParentName = l.Name,
                                 Type = c.Type,
                             }).FirstOrDefaultAsync(cancellationToken);

            return dto;
        }
    }
}
