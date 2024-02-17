using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Commands.SpecificationAddCommand
{
    class SpecificationAddRequestHandler : IRequestHandler<SpecificationAddRequest, Specification>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationAddRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }
        async Task<Specification> IRequestHandler<SpecificationAddRequest, Specification>.Handle(SpecificationAddRequest request, CancellationToken cancellationToken)
        {
            var entity = new Specification();
            entity.Name= request.Name;
            await specificationRepository.AddAsync(entity, cancellationToken);
            await specificationRepository.SaveAsync(cancellationToken);
            return entity;  
        }
    }
}
