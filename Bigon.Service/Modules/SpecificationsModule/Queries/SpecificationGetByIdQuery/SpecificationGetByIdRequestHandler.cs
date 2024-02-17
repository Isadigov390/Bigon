using Bigon.Application.Repositories;
using Bigon.Domain.Models.Entities;
using MediatR;

namespace Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetByIdQuery
{
    class SpecificationGetByIdRequestHandler : IRequestHandler<SpecificationGetByIdRequest, SpecificationGetByIdRequestDto>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationGetByIdRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }
        public async Task<SpecificationGetByIdRequestDto> Handle(SpecificationGetByIdRequest request, CancellationToken cancellationToken)
        {
            Specification entity;

            if (request.OnlyAvailable)
            {
                entity = await specificationRepository.GetAsync(m => m.Id == request.Id && m.DeletedAt == null, cancellationToken);
            }
            else
            {
                entity = await specificationRepository.GetAsync(m => m.Id == request.Id, cancellationToken);
            }

            var dto = new SpecificationGetByIdRequestDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
    }
}
