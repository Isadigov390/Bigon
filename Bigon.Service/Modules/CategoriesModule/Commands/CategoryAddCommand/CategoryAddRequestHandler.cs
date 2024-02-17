using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryAddCommand
{
    
    class CategoryAddRequestHandler : IRequestHandler<CategoryAddRequest>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoryAddRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public async Task Handle(CategoryAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Category
            {
                Name = request.Name,
                Type=request.Type
            };

            if (request.ParentId is not null)
            {
                var parent = catagoryRepository.GetAsync(m => m.Id == request.ParentId, cancellationToken);
                entity.ParentId = parent.Id;
            }

            await catagoryRepository.AddAsync(entity);  
            await catagoryRepository.SaveAsync(cancellationToken);

        }
    }
}
