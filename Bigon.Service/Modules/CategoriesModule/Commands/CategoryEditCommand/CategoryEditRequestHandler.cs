using Bigon.Application.Repositories;
using Bigon.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryEditCommand
{
    class CategoryEditRequestHandler : IRequestHandler<CategoryEditRequest>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoryEditRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public async Task Handle(CategoryEditRequest request, CancellationToken cancellationToken)
        {
            var entity = await catagoryRepository.GetAsync(m=>m.Id== request.Id,cancellationToken);

            if (request.Id==request.ParentId)
            {
                throw new CircleReferenceException("ParentId");
            }
            else if(request.ParentId is not null){

                var relatedIds = await catagoryRepository.GetRelatedIds(entity.Id);

                if(relatedIds.Any(m=>m.Id==request.ParentId.Value))
                {
                    throw new CircleReferenceException("ParentId");
                }
            }

            entity.Name = request.Name;
            entity.Type = request.Type; 
            entity.ParentId = request.ParentId;

            await catagoryRepository.SaveAsync(cancellationToken);

        }
    }
}
