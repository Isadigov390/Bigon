using Bigon.Application.Repositories;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationRemoveCommand
{
    class SpecificationRemoveRequestHandler : IRequestHandler<SpecificationRemoveRequest>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationRemoveRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }
        public async Task Handle(SpecificationRemoveRequest request, CancellationToken cancellationToken)
        {
            var entity = await specificationRepository.GetAsync(m=>m.Id==request.Id && m.DeletedAt==null,cancellationToken);
            specificationRepository.Remove(entity);
            await specificationRepository.SaveAsync(cancellationToken);
        }
    }
}
