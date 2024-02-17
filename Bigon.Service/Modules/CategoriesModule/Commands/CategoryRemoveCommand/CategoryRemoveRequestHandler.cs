using Bigon.Application.Repositories;
using DocumentFormat.OpenXml.Wordprocessing;
using MediatR;

namespace Bigon.Application.Modules.CategoriesModule.Commands.CategoryRemoveCommand
{
    internal class CategoryRemoveRequestHandler : IRequestHandler<CategoryRemoveRequest>
    {
        private readonly ICatagoryRepository catagoryRepository;

        public CategoryRemoveRequestHandler(ICatagoryRepository catagoryRepository)
        {
            this.catagoryRepository = catagoryRepository;
        }
        public async Task Handle(CategoryRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await catagoryRepository.GetAsync(m=>m.Id==request.Id,cancellationToken);
            catagoryRepository.Remove(entity);
            await catagoryRepository.SaveAsync(cancellationToken);
        }
    }
}
