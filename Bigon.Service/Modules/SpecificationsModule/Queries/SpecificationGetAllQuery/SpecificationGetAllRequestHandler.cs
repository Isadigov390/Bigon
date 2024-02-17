using Bigon.Application.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Application.Modules.SpecificationsModule.Queries.SpecificationGetAllQuery
{
    class SpecificationGetAllRequestHandler : IRequestHandler<SpecificationGetAllRequest, IEnumerable<SpecificationGetAllRequestDto>>
    {
        private readonly ISpecificationRepository specificationRepository;

        public SpecificationGetAllRequestHandler(ISpecificationRepository specificationRepository)
        {
            this.specificationRepository = specificationRepository;
        }
        public async Task<IEnumerable<SpecificationGetAllRequestDto>> Handle(SpecificationGetAllRequest request, CancellationToken cancellationToken)
        {
            var query =  specificationRepository.GetAll();

            if (request.OnlyAvailable)
            {
                query = query.Where(m => m.DeletedAt == null);
            }
            var response= await query.Select(m => new SpecificationGetAllRequestDto
            {
                 Id=m.Id,
                 Name=m.Name,
               
            }).ToListAsync(cancellationToken);   
            return response;    
        }
    }
}
